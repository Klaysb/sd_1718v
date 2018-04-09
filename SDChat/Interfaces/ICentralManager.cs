namespace Interfaces
{
    public interface ICentralManager
    {
        /// <summary>
        /// Register a user in the central manager.
        /// </summary>
        /// <param name="userNumber">The identifier to be registered in the central manager.</param>
        /// <param name="broker">Broker to which the user will belong.</param>
        void Register(int userNumber, IBroker broker);

        /// <summary>
        /// Unregister the user from central manager.
        /// </summary>
        /// <param name="userNumber">The identifier of the user.</param>
        void Unregister(int userNumber);

        /// <summary>
        /// Register a group.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        void RegisterGroup(string groupName);

        /// <summary>
        /// Unregister a group with the <paramref name="groupName"/> identifier.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        void UnregisterGroup(string groupName);

        /// <summary>
        /// Sends a message to users.
        /// </summary>
        /// <param name="message">The message to be sent.</param>
        /// <param name="srcUserNumber">The user that sends this message.</param>
        /// <param name="destUserNumbers">The identifier of the receivers.</param>
        void SendMessageToUsers(string message, int srcUserNumber, params int[] destUserNumbers);

        /// <summary>
        /// Return true if user was registered, otherwise return false.
        /// </summary>
        /// <param name="userNumber">The identifier of the user to search if exists.</param>
        /// <returns></returns>
        bool ExistsUser(int userNumber);
    }
}
