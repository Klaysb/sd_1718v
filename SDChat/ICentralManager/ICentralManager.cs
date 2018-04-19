using BrokerInterface;
using System;
using UserInterface;

namespace CentralManagerInterface
{
    public interface ICentralManager
    {
        /// <summary>
        /// Register a user in the central manager.
        /// </summary>
        /// <param name="userNumber">The identifier to be registered in the central manager.</param>
        /// <param name="user">The user will belong.</param>
        /// <param name="broker">The broker will belong.</param>
        void Register(int userNumber, IUser user, IBroker broker);

        /// <summary>
        /// Unregister the user from central manager.
        /// </summary>
        /// <param name="userNumber">The identifier of the user.</param>
        void Unregister(int userNumber);

        /// <summary>
        /// Register a group.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        void RegisterGroup(string groupName, IBroker broker);

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

        /// <summary>
        /// Adds a user to a group.
        /// </summary>
        /// <param name="owner">The identifier of the group's owner.</param>
        /// <param name="adderMember">User already belonging to the group that will add another user.</param>
        /// <param name="userNumber">User that will be added to the group.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="userNumbers">The identifiers of the users to be added.</param>
        void AddUserToGroup(int owner, int adderMember, int userNumber, string groupName, int[] userNumbers);
    }
}
