using CentralManagerInterface;
using System;
using System.Collections.Concurrent;
using BrokerInterface;
using UserInterface;
using System.Collections.Generic;

namespace CentralManagerImpl
{
    public class CentralManager : MarshalByRefObject, ICentralManager
    {
        private ConcurrentDictionary<int, Tuple<IUser, IBroker>> users = new ConcurrentDictionary<int, Tuple<IUser, IBroker>>();
        private ConcurrentDictionary<string, HashSet<IBroker>> groupNames = new ConcurrentDictionary<string, HashSet<IBroker>>();

        public bool ExistsUser(int userNumber)
        {
            return users.ContainsKey(userNumber);
        }

        public void Register(int userNumber, IUser user, IBroker broker)
        {
            if (!users.TryAdd(userNumber, new Tuple<IUser, IBroker>(user, broker)))
                throw new ArgumentException($"User already exists with number: {userNumber}");
        }

        public void RegisterGroup(string groupName, IBroker broker)
        {
            if (!groupNames.TryAdd(groupName, new HashSet<IBroker> { broker }))
                throw new ArgumentException($"The group name {groupName} already exists.");
        }

        public void SendMessageToUsers(string message, int srcUserNumber, params int[] destUserNumbers)
        {
            foreach (int userNumber in destUserNumbers)
            {
                try
                {
                    if (users.TryGetValue(userNumber, out Tuple<IUser, IBroker> tuple) &&
                        users.TryGetValue(srcUserNumber, out Tuple<IUser, IBroker> srcTuple))
                            tuple.Item2.SendMessageToUser(userNumber, message, srcTuple.Item1);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void Unregister(int userNumber)
        {
            if(!users.TryRemove(userNumber, out Tuple<IUser, IBroker> tuple))
                throw new ArgumentException($"User with number: {userNumber} does not exist.");
        }

        public void UnregisterGroup(string groupName)
        {
            if (!groupNames.TryRemove(groupName, out HashSet<IBroker> brokers))
                throw new ArgumentException($"Group with name: {groupName} does not exist.");
        }

        public void AddUserToGroup(int owner, int adderMember, int userNumber, string groupName, int[] userNumbers)
        {
            if (users.TryGetValue(userNumber, out Tuple<IUser, IBroker> tuple))
            {
                if (groupNames.TryGetValue(groupName, out HashSet<IBroker> brokers))
                {
                    brokers.Add(tuple.Item2);
                    try
                    {
                        foreach (IBroker broker in brokers)
                        {
                            broker.AddUserToGroup(owner, userNumber, groupName, userNumbers);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
                throw new ArgumentException($"The user with number {userNumber} does not exist.");
        }
    }
}
