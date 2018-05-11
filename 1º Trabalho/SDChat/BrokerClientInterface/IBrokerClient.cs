using GroupImpl;
using MessageImpl;

namespace BrokerClientInterface
{
    public interface IBrokerClient
    {
        /// <summary>
        /// Register a group.
        /// </summary>
        /// <param name="group">The object representing the group.</param>
        void RegisterGroup(Group group);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="destNumber"></param>
        void AddUserToGroup(string groupName, int destNumber);

        /// <summary>
        /// Sends a message to a user.
        /// </summary>
        /// <param name="receiver">The identifier of the receiving user.</param>
        /// <param name="message">The object representing the message.</param>
        void SendMessageToUser(int receiver, Message message);

        /// <summary>
        /// Sends a message to a group.
        /// </summary>
        /// <param name="groupName">The identifier of the group to send a message.</param>
        /// <param name="message">The object representing the message.</param>
        void SendMessageToGroup(string groupName, Message message);

        /// <summary>
        /// Unregister a group.
        /// </summary>
        /// <param name="groupName">The identifier of the group to be unregistered.</param>
        void UnregisterGroup(string groupName);
    }
}
