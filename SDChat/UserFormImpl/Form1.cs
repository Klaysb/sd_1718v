﻿using BrokerInterface;
using System;
using System.Runtime.Remoting;
using System.Windows.Forms;
using UserImpl;
using UserInterface;

namespace UserFormImpl
{
    public partial class Form1 : Form
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
                    broker.SendMessageToUser(destUserNumber, message, UserNumber);
                    outputTextBox.AppendText(senderMsg);
                    inputTextBox.Clear();
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

        private string UserName => usernameTextBox.Text;

        private int UserNumber => Decimal.ToInt32(numberBox.Value);

        private void PutTextByCallBack(string txt)
        {
            if (this.InvokeRequired)
            {
                Action<string> action = new Action<string>(this.PutTextByCallBack);
                object[] args = new object[] { txt };
                this.Invoke(action, args);
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
                broker = (IBroker)Activator.GetObject(entry.ObjectType, entry.ObjectUrl);
                IUser user = new User(UserNumber, UserName, this.PutTextByCallBack);
                broker.Register(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to the server.");
                broker = null;
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
