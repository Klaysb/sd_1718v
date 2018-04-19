using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace UserImpl
{
    public class User : MarshalByRefObject, IUser
    {
        private int userNumber;
        private string userName;
        private Action<string> action;

        public User(int userNumber, string userName, Action<string> action)
        {
            this.userNumber = userNumber;
            this.userName = userName;
            this.action = action;
        }

        public void AcceptMessage(string message, IUser sender)
        {
            string senderId = sender.GetUserName() ?? sender.GetUserNumber().ToString();
            string msg = $"{senderId}: {message}\n";
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
