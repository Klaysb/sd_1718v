namespace Interfaces
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
        /// Unregister a group with the <paramref name="groupName"/> identifier.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        void UnregisterGroup(string groupName);

        /// <summary>
        /// Sends a message to a user.
        /// </summary>
        /// <param name="destUserNumber">The identifier of the receiver.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="srcUserNumber">The user that sends this message.</param>
        void SendMessageToUser(int destUserNumber, string message, int srcUserNumber);

        /// <summary>
        /// Sends a message to a group.
        /// </summary>
        /// <param name="groupName">The identifier of the group receiver.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="srcUserNumber">The user that sends this message.</param>
        void SendMessageToGroup(string groupName, string message, int srcUserNumber);
    }
}
