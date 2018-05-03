using MessageImpl;
using System;
using UserInterface;

namespace UserImpl
{
    public class User : MarshalByRefObject, IUser
    {
        private readonly int userNumber;
        private readonly string userName;
        private readonly Action<string> action;

        public User(int userNumber, string userName, Action<string> action)
        {
            this.userNumber = userNumber;
            this.userName = userName;
            this.action = action;
        }

        public void AcceptMessage(Message message)
        {
            string senderId = message.SenderName.Length != 0 ? message.SenderName : message.SenderNumber.ToString();
            string msg = $"{senderId}: {message.Msg}\n";
            action(msg);
        }

        public string GetUserName()
        {
            return userName;
        }

        public int GetUserNumber()
        {
            return userNumber;
        }
    }
}
