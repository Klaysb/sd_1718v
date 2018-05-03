using UserInterface;

namespace BrokerServiceInterface
{
    public interface IBrokerService
    {
        /// <summary>
        /// Register a user in some region.
        /// </summary>
        /// <param name="user">User to be registered in some region.</param>
        void Register(IUser user);

        /// <summary>
        /// Register a group.
        /// </summary>
        /// <param name="userNumber">The identifier of the group's creator.</param>
        /// <param name="groupName">Name of the group.</param>
        void RegisterGroup(int userNumber, string groupName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="destNumber"></param>
        /// <param name="srcNumber"></param>
        void AddUserToGroup(string groupName, int destNumber, int srcNumber);

        /// <summary>
        /// Sends a message to a user.
        /// </summary>
        /// <param name="destUserNumber">The identifier of the receiver.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="srcUserNumber">The identifier of user that sends this message.</param>
        void SendMessageToUser(int destUserNumber, string message, int srcUserNumber);

        /// <summary>
        /// Sends a message to a group.
        /// </summary>
        /// <param name="groupName">The identifier of the group receiver.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="srcUserNumber">The user that sends this message.</param>
        void SendMessageToGroup(string groupName, string message, int srcUserNumber);

        /// <summary>
        /// Unregister the user from some region.
        /// </summary>
        /// <param name="userNumber">The identifier of the user.</param>
        void Unregister(int userNumber);

        /// <summary>
        /// Unregister a group.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="userNumber">the identifier of the user that wants to unregister the group.</param>
        void UnregisterGroup(string groupName, int userNumber);
    }
}
