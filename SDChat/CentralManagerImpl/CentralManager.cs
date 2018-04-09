using Interfaces;
using System;
using System.Collections.Concurrent;

namespace CentralManagerImpl
{
    public class CentralManager : MarshalByRefObject, ICentralManager
    {

        private ConcurrentDictionary<int, IBroker> users = new ConcurrentDictionary<int, IBroker>();
        private ConcurrentDictionary<string, string> groupNames = new ConcurrentDictionary<string, string>();

        public bool ExistsUser(int userNumber)
        {
            return users.ContainsKey(userNumber);
        }

        public void Register(int userNumber, IBroker broker)
        {
            if (!users.TryAdd(userNumber, broker))
                throw new ArgumentException($"User already exists with number: {userNumber}");
        }

        public void RegisterGroup(string groupName)
        {
            if (!groupNames.TryAdd(groupName, groupName))
                throw new ArgumentException($"The group name {groupName} already exists.");
        }

        // TODO: prevent errors.
        public void SendMessageToUsers(string message, int srcUserNumber, params int[] destUserNumbers)
        {
            foreach (int userNumber in destUserNumbers)
            {
                if (users.TryGetValue(userNumber, out IBroker broker))
                    broker.SendMessageToUser(userNumber, message, srcUserNumber);
            }
        }

        public void Unregister(int userNumber)
        {
            users.TryRemove(userNumber, out IBroker broker);
        }

        public void UnregisterGroup(string groupName)
        {
            groupNames.TryRemove(groupName, out string value);
        }
    }
}
