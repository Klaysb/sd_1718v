using BrokerInterface;
using System;
using System.Runtime.Remoting;
using System.Windows.Forms;
using UserInterface;

namespace UserFormImpl
{
    public partial class Form1 : Form, IUser
    {
        private static readonly string CONFIG_FILE = "UserFormImpl.exe.config";
        private IBroker broker;

        public Form1()
        {
            InitializeComponent();
            RemotingConfiguration.Configure(CONFIG_FILE, false);
            WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            BuildMenuItems(entries);
            inputTextBox.KeyPress += new KeyPressEventHandler(CheckEnterPress);
        }

        private void BuildMenuItems(WellKnownClientTypeEntry[] entries)
        {
            ToolStripMenuItem[] items = new ToolStripMenuItem[entries.Length];           
            for (int i = 0; i < items.Length; i++)
            {
                WellKnownClientTypeEntry entry = entries[i];
                items[i] = new ToolStripMenuItem()
                {
                    Name = entry.TypeName,
                    Tag = entry,
                    Text = "Broker " + (i + 1)
                    //Click += new EventHandler(MenuItemClickHandler)
                };
            }
            brokerList.Items.AddRange(items);
        }

        private void CheckEnterPress(object sender, KeyPressEventArgs e)
        {
            var message = inputTextBox.Text;
            if (e.KeyChar == (char)Keys.Enter && message.Length != 0)
                SendToUserOrGroup(message);
        }

        private void SendToUserOrGroup(string message)
        {
            if (broker == null) return;
            string senderId = UserName ?? UserNumber.ToString();
            var senderMsg = $"{senderId}: {message}";
            if (userRadioBtn.Checked)
            {
                try
                {
                    var destUserNumber = Int32.Parse(receiverTextBox.Text);
                    broker.SendMessageToUser(destUserNumber, message, UserNumber);
                    outputTextBox.AppendText(senderMsg);
                }
                catch (FormatException)
                {
                    MessageBox.Show("The user number is invalid.");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                var groupName = receiverTextBox.Text;
                if (groupName.Length == 0)
                {
                    MessageBox.Show("Please, enter the group name.");
                    return;
                }
                try
                {
                    broker.SendMessageToGroup(groupName, message, UserNumber);
                    outputTextBox.AppendText(senderMsg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            receiverTextBox.Clear();
        }

        public string UserName => usernameTextBox.Text;

        public int UserNumber => Decimal.ToInt32(numberBox.Value);

        public void AcceptMessage(string message, IUser sender)
        {
            string senderId = sender.UserName ?? sender.UserNumber.ToString();
            string msg = $"{senderId}: {message}";
            outputTextBox.AppendText(msg);
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (broker != null) return;
            if(brokerList.SelectedItem == null)
            {
                MessageBox.Show("Please select a broker.");
                return;
            }
            var item = brokerList.SelectedItem as ToolStripMenuItem;
            var entry = item.Tag as WellKnownClientTypeEntry;
            try
            {
                broker = (IBroker)Activator.GetObject(entry.ObjectType, entry.ObjectUrl);
                broker.Register(this);
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to the server.");
            }
        }

        private void unRegisterBtn_Click(object sender, EventArgs e)
        {
            if (broker == null) return;
            try
            {
                broker.Unregister(UserNumber);
                broker = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addGroupBtn_Click(object sender, EventArgs e)
        {
            if (broker == null) return;
            try
            {
                var groupName = addGroupNameTextBox.Text;
                var newMember = Decimal.ToInt32(anotherNumberToAdd.Value);
                if (groupName.Equals(""))
                {
                    MessageBox.Show("The group name is empty.");
                    return;
                }
                broker.AddUserToGroup(UserNumber, newMember, groupName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addGroupNameBtn_Click(object sender, EventArgs e)
        {
            if (broker == null) return;
            var groupName = addOrRemoveGroupName.Text;
            if (groupName.Equals(""))
            {
                MessageBox.Show("The group name is empty.");
                return;
            }
            try
            {
                broker.RegisterGroup(UserNumber, groupName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void removeGroupNameBtn_Click(object sender, EventArgs e)
        {
            if (broker == null) return;
            var groupName = addOrRemoveGroupName.Text;
            if (groupName.Equals(""))
            {
                MessageBox.Show("The group name is empty.");
                return;
            }
            try
            {
                broker.UnregisterGroup(groupName, UserNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
