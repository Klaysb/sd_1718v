using GroupImpl;
using UserInterface;
using CentralManagerInterface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MessageImpl;
using BrokerClientInterface;
using BrokerServiceInterface;

namespace BrokerImpl
{
    public class Broker : MarshalByRefObject, IBrokerClient, IBrokerService
    {

        private readonly ICentralManager manager;
        private readonly ConcurrentDictionary<int, IUser> users = new ConcurrentDictionary<int, IUser>();
        private readonly ConcurrentDictionary<string, Tuple<Group, List<int>>> groupNames = new ConcurrentDictionary<string, Tuple<Group, List<int>>>();

        public Broker(ICentralManager manager) => this.manager = manager;

        private void CheckIfRegistered(int userNumber)
        {
            if (!users.ContainsKey(userNumber))
                throw new ArgumentException($"User with number {userNumber} is not registered.");
        }

        /****************************************************************************************************************/
        /*                                        Methods called by the manager                                          /
        /*                                                                                                               /
        /****************************************************************************************************************/

        public void RegisterGroup(Group group)
        {
            var groupName = group.Name;
            var tuple = new Tuple<Group, List<int>>(group, new List<int>());
            groupNames.TryAdd(groupName, tuple);
        }

        public void AddUserToGroup(string groupName, int destNumber)
        {
            if (!users.TryGetValue(destNumber, out IUser user)) return;
            if(groupNames.TryGetValue(groupName, out Tuple<Group, List<int>> tuple))
            {
                if (!tuple.Item2.Contains(destNumber))
                    tuple.Item2.Add(destNumber);
            }
        }

        public void SendMessageToUser(int receiver, Message message)
        {
            if (users.TryGetValue(receiver, out IUser user))
                user.AcceptMessage(message);
        }

        public void SendMessageToGroup(string groupName, Message message)
        {
            if (groupNames.TryGetValue(groupName, out Tuple<Group, List<int>> tuple))
                tuple.Item2.ForEach(userNumber => SendMessageToUser(userNumber, message));
        }

        public void UnregisterGroup(string groupName)
        {
            groupNames.TryRemove(groupName, out Tuple<Group, List<int>> tuple);
        }

        /****************************************************************************************************************/
        /*                                        Methods called by the user                                             /
        /*                                                                                                               /
        /****************************************************************************************************************/

        public void Register(IUser user)
        {
            if (!users.TryAdd(user.GetUserNumber(), user))
                throw new ArgumentException("A user with the same number has already been registered.");
        }

        public void RegisterGroup(int userNumber, string groupName)
        {
            CheckIfRegistered(userNumber);
            var group = new Group(userNumber, groupName);
            var list = new List<int> { userNumber };
            var tuple = new Tuple<Group, List<int>>(group, list);
            if (!groupNames.TryAdd(groupName, tuple))
                throw new ArgumentException("A group with the same name has already been registered.");
            try
            {
                manager.RegisterGroup(group, this);
            }
            catch (Exception)
            {
                // The user must not know about any erros related to the central manager.
            }
        }

        public void AddUserToGroup(string groupName, int destNumber, int srcNumber)
        {
            CheckIfRegistered(srcNumber);
            if (!groupNames.TryGetValue(groupName, out Tuple<Group, List<int>> tuple))
                throw new ArgumentException("The group does not exist.");
            if (!tuple.Item2.Contains(srcNumber))
                throw new ArgumentException("The user does not belong to this group.");
            if(tuple.Item2.Contains(destNumber))
                throw new ArgumentException("The user already belongs to this group.");
            if(users.TryGetValue(destNumber, out IUser user))
            {
                tuple.Item2.Add(destNumber);
                return;
            }
            try
            {
                manager.AddUserToGroup(groupName, destNumber, this);
            }
            catch(Exception)
            {

            }
        }

        public void SendMessageToUser(int destUserNumber, string message, int srcUserNumber)
        {
            CheckIfRegistered(srcUserNumber);
            var userName = users[srcUserNumber].GetUserName();
            var msg = new Message
            {
                Msg = message,
                SenderName = userName,
                SenderNumber = srcUserNumber
            };
            if (users.TryGetValue(destUserNumber, out IUser user))
            {
                try
                {
                    user.AcceptMessage(msg);
                    return;
                }
                catch (Exception)
                {
                    throw new Exception("Could not send message to user.");
                }
            }
            try
            {
                manager.SendMessageToBrokers(destUserNumber, msg, this);
            }
            catch (Exception)
            {
                // The user must not know about any erros related to the central manager.
            }
        }

        public void SendMessageToGroup(string groupName, string message, int srcUserNumber)
        {
            CheckIfRegistered(srcUserNumber);
            if (!groupNames.TryGetValue(groupName, out Tuple<Group, List<int>> tuple))
                throw new ArgumentException("The group does not exist.");
            if (!tuple.Item2.Contains(srcUserNumber))
                throw new ArgumentException("The user doesn't belong to the group.");
            var userName = users[srcUserNumber].GetUserName();
            var msg = new Message
            {
                Msg = message,
                SenderName = userName,
                SenderNumber = srcUserNumber
            };
            foreach(var num in tuple.Item2)
            {
                try
                {
                    if (num != srcUserNumber && users.TryGetValue(num, out IUser user))
                        user.AcceptMessage(msg);
                }
                catch (Exception)
                {
                    //
                }
                
            }
            try
            {
                manager.SendMessageToGroup(groupName, msg, this);
            }
            catch (Exception)
            {
                // The user must not know about any erros related to the central manager.
            }
        }

        public void Unregister(int userNumber)
        {
            CheckIfRegistered(userNumber);
            users.TryRemove(userNumber, out IUser user);
        }

        public void UnregisterGroup(string groupName, int userNumber)
        {
            CheckIfRegistered(userNumber);
            if (!groupNames.TryGetValue(groupName, out Tuple<Group, List<int>> tuple))
                throw new ArgumentException($"The group that you specified does not exist.");
            if (tuple.Item1.Owner != userNumber)
                throw new ArgumentException("You do not have permission to delete this group.");
            groupNames.TryRemove(groupName, out Tuple<Group, List<int>> t);
            try
            {
                manager.UnregisterGroup(groupName, this);
            }
            catch (Exception)
            {
                // The user must not know about any erros related to the central manager.
            }
        }
    }
}
