using UserInterface;

namespace BrokerInterface
{
    public interface IBroker
    {
        /// <summary>
        /// Register a user in some region.
        /// </summary>
        /// <param name="user">User to be registered in some region.</param>
        void Register(IUser user);

        /// <summary>
        /// Unregister the user from some region.
        /// </summary>
        /// <param name="userNumber">The identifier of the user.</param>
        void Unregister(int userNumber);

        /// <summary>
        /// Register a group.
        /// </summary>
        /// <param name="userNumber">The identifier of the group's creator.</param>
        /// <param name="groupName">Name of the group.</param>
        void RegisterGroup(int userNumber, string groupName);

        /// <summary>
        /// Adds a user to a group.
        /// </summary>
        /// <param name="adderMember">User already belonging to the group that will add another user.</param>
        /// <param name="userNumber">User that will be added to the group.</param>
        /// <param name="groupName">Name of the group.</param>
        void AddUserToGroup(int adderMember, int userNumber, string groupName);

        /// <summary>
        /// Adds a user to a group.
        /// </summary>
        /// <param name="owner">The identifier of the group's owner.</param>
        /// <param name="userNumber">The identifier of the user that will be added.</param>
        /// <param name="groupName">The identifier of the group.</param>
        /// <param name="userNumbers">The identifiers of the members of the group.</param>
        void AddUserToGroup(int owner, int userNumber, string groupName, int[] userNumbers);

        /// <summary>
        /// Unregister a group with the <paramref name="groupName"/> identifier.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="userNumber">the identifier of the user that wants to unregister the group.</param>
        void UnregisterGroup(string groupName, int userNumber);

        /// <summary>
        /// Sends a message to a user.
        /// </summary>
        /// <param name="destUserNumber">The identifier of the receiver.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="srcUserNumber">The identifier of user that sends this message.</param>
        void SendMessageToUser(int destUserNumber, string message, int srcUserNumber);

        /// <summary>
        /// Sends a message to a user.
        /// </summary>
        /// <param name="destUserNumber">The identifier of the receiver.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="srcUser">The user that sends this message.</param>
        void SendMessageToUser(int destUserNumber, string message, IUser srcUser);

        /// <summary>
        /// Sends a message to a group.
        /// </summary>
        /// <param name="groupName">The identifier of the group receiver.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="srcUserNumber">The user that sends this message.</param>
        void SendMessageToGroup(string groupName, string message, int srcUserNumber);
    }
}
