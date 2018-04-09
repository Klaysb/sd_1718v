namespace Interfaces
{
    public interface IUser
    {
        /// <summary>
        /// The name of the user.
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// The user's phone number.
        /// </summary>
        int UserNumber { get; }

        /// <summary>
        /// Accept message from other users.
        /// </summary>
        /// <param name="message">The received message.</param>
        /// <param name="sender">The user that sends this message.</param>
        void AcceptMessage(string message, IUser sender);
    }
}
