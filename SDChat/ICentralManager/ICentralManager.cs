using BrokerInterface;
using GroupImpl;
using MessageImpl;

namespace CentralManagerInterface
{
    public interface ICentralManager
    {
        /// <summary>
        /// Register a group.
        /// </summary>
        /// <param name="group">The group to be registered.</param>
        /// <param name="callerBroker">The broker that calls this method.</param>
        void RegisterGroup(Group group, IBroker callerBroker);

        /// <summary>
        /// Add user to a group.
        /// </summary>
        /// <param name="groupName">The identifier of the group.</param>
        /// <param name="destNumber">The identifier of the user to be added.</param>
        /// <param name="callerBroker">The broker that calls this method.</param>
        void AddUserToGroup(string groupName, int destNumber, IBroker callerBroker);

        /// <summary>
        /// Sends a message to users.
        /// </summary>
        /// <param name="receiver">The identifier of the receiver.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="callerBroker">The broker that calls this method.</param>
        void SendMessageToBrokers(int receiver, Message message, IBroker callerBroker);

        /// <summary>
        /// Sends a message to group.
        /// </summary>
        /// <param name="groupName">The identifier of the group.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="callerBroker">The broker that calls this method.</param>
        void SendMessageToGroup(string groupName, Message message, IBroker callerBroker);

        /// <summary>
        /// Unregister a group.
        /// </summary>
        /// <param name="groupName">The identifier of the group.</param>
        /// <param name="callerBroker">The broker that calls this method.</param>
        void UnregisterGroup(string groupName, IBroker callerBroker);
    }
}
