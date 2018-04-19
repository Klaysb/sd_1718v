using CentralManagerInterface;
using System;
using System.Collections.Concurrent;
using BrokerInterface;
using UserInterface;

namespace CentralManagerImpl
{
    public class CentralManager : MarshalByRefObject, ICentralManager
    {
        private ConcurrentDictionary<int, Tuple<IUser, IBroker>> users = new ConcurrentDictionary<int, Tuple<IUser, IBroker>>();
        private ConcurrentDictionary<string, IBroker> groupNames = new ConcurrentDictionary<string, IBroker>();


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
            if (!groupNames.TryAdd(groupName, broker))
                throw new ArgumentException($"The group name {groupName} already exists.");
        }

        public void SendMessageToUsers(string message, int srcUserNumber, params int[] destUserNumbers)
        {
            foreach (int userNumber in destUserNumbers)
            {
                try
                {
                    if (users.TryGetValue(userNumber, out Tuple<IUser, IBroker> tuple))
                        tuple.Item2.SendMessageToUser(userNumber, message, tuple.Item1);
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
            if (!groupNames.TryRemove(groupName, out IBroker broker))
                throw new ArgumentException($"Group with name: {groupName} does not exist.");
        }

        public void AddUserToGroup(int adderMember, int userNumber, string groupName)
        {
            if (!users.ContainsKey(userNumber))
                throw new ArgumentException($"The user with number {userNumber} does not exist.");
            if(groupNames.TryGetValue(groupName, out IBroker broker))
            {
                try
                {
                    broker.AddUserToGroup(adderMember, userNumber, groupName);
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

    }
}
