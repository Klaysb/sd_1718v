using BrokerServiceInterface;
using System;
using System.Configuration;
using System.Runtime.Remoting;
using System.Windows.Forms;
using UserImpl;
using UserInterface;

namespace UserFormImpl
{
    public partial class Form1 : Form
    {
        private static readonly string CONFIG_FILE = "UserFormImpl.exe.config";
        private delegate void DelSendMessageToUser(int destUserNumber, string message, int srcUserNumber);
        private delegate void DelSendMessageToGroup(string groupName, string message, int srcUserNumber);
        private delegate void DelRegisterUser(IUser user);
        private delegate void DelUnregisterUser(int userNumber);
        private delegate void DelAddUserToGroup(string groupName, int destNumber, int srcNumber);
        private delegate void DelRegisterGroup(int userNumber, string groupName);
        private delegate void DelUnregisterGroup(string groupName, int userNumber);
        private DelSendMessageToUser sendMessageToUser;
        private DelSendMessageToGroup sendMessageToGroup;
        private DelRegisterUser registerUser;
        private DelUnregisterUser unregisterUser;
        private DelAddUserToGroup addUserToGroup;
        private DelRegisterGroup registerGroup;
        private DelUnregisterGroup unregisterGroup;
        private IBrokerService broker;

        public Form1()
        {
            InitializeComponent();
            RemotingConfiguration.Configure(CONFIG_FILE, false);
            BuildMenuItems();
            inputTextBox.KeyPress += new KeyPressEventHandler(CheckEnterPress);
        }

        private void InitializeDelegates()
        {
            sendMessageToUser = new DelSendMessageToUser(broker.SendMessageToUser);
            sendMessageToGroup = new DelSendMessageToGroup(broker.SendMessageToGroup);
            registerUser = new DelRegisterUser(broker.Register);
            unregisterUser = new DelUnregisterUser(broker.Unregister);
            addUserToGroup = new DelAddUserToGroup(broker.AddUserToGroup);
            registerGroup = new DelRegisterGroup(broker.RegisterGroup);
            unregisterGroup = new DelUnregisterGroup(broker.UnregisterGroup);
        }

        private void BuildMenuItems()
        {
            var config = ConfigurationSettings.AppSettings;
            var type = config["type"];
            var assembly = config["assembly"];
            ToolStripMenuItem[] items = new ToolStripMenuItem[config.Count - 2];
            for (int i = 2, j = 0; i < config.Count; i++, j++)
            {
                WellKnownClientTypeEntry entry = new WellKnownClientTypeEntry(type, assembly, config[i]);
                items[j] = new ToolStripMenuItem()
                {
                    Name = entry.TypeName,
                    Tag = entry,
                    Text = config.GetKey(i)
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
            string senderId = UserName.Length != 0 ? UserName : UserNumber.ToString();

            var senderMsg = $"{senderId}: {message}\n";
            if (userRadioBtn.Checked)
            {
                try
                {
                    var destUserNumber = Int32.Parse(receiverTextBox.Text);
                    if(destUserNumber == UserNumber)
                    {
                        MessageBox.Show("Cannot send message to yourself.");
                        return;
                    }
                    outputTextBox.AppendText(senderMsg);
                    inputTextBox.Clear();
                    sendMessageToUser.BeginInvoke(destUserNumber, message, UserNumber, ar => {
                        try
                        {
                            sendMessageToUser.EndInvoke(ar);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }, null);
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
                outputTextBox.AppendText(senderMsg);
                inputTextBox.Clear();
                sendMessageToGroup.BeginInvoke(groupName, message, UserNumber, ar => {
                    try
                    {
                        sendMessageToGroup.EndInvoke(ar);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }, null);
            }
        }

        private string UserName => usernameTextBox.Text;

        private int UserNumber => Decimal.ToInt32(numberBox.Value);

        private void PutTextByCallBack(string txt)
        {
            if (InvokeRequired)
            {
                Action<string> action = new Action<string>(PutTextByCallBack);
                object[] args = new object[] { txt };
                Invoke(action, args);
            }
            else outputTextBox.AppendText(txt);
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
                broker = (IBrokerService) Activator.GetObject(entry.ObjectType, entry.ObjectUrl);
                InitializeDelegates();
                IUser user = new User(UserNumber, UserName, PutTextByCallBack);
                registerUser.BeginInvoke(user, ar => {
                    try
                    {
                        registerUser.EndInvoke(ar);
                        MessageBox.Show("Registered with success!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        broker = null;
                    }
                }, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                broker = null;
            }
        }

        private void unRegisterBtn_Click(object sender, EventArgs e)
        {
            if (broker == null) return;
            unregisterUser.BeginInvoke(UserNumber, ar => {
                try
                {
                    unregisterUser.EndInvoke(ar);
                    broker = null;
                    MessageBox.Show("Unregistered with success!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }, null);
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
                addUserToGroup.BeginInvoke(groupName, newMember, UserNumber, ar => {
                    try
                    {
                        addUserToGroup.EndInvoke(ar);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }, null);
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
            registerGroup.BeginInvoke(UserNumber, groupName, ar => {
                try
                {
                    registerGroup.EndInvoke(ar);
                    MessageBox.Show("Group created with success!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }, null);
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
            unregisterGroup.BeginInvoke(groupName, UserNumber, ar => {
                try
                {
                    unregisterGroup.EndInvoke(ar);
                    MessageBox.Show("The group was deleted with success!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }, null);
        }
    }
}
