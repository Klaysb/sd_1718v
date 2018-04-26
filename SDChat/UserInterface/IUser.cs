using MessageImpl;

namespace UserInterface
{
    public interface IUser
    {
        /// <summary>
        /// The name of the user.
        /// </summary>
        string GetUserName();

        /// <summary>
        /// The user's phone number.
        /// </summary>
        int GetUserNumber();

        /// <summary>
        /// Accept message from other users.
        /// </summary>
        /// <param name="message">The object representing the message.</param>
        void AcceptMessage(Message message);
    }
}
