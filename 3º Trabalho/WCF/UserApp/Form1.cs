using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel.Configuration;
using System.Windows.Forms;
using UserApp.BrokerService;

namespace UserApp
{
    public partial class Form1 : Form
    {
        private BrokerServiceClient broker;
        private int counter = 0;

        public Form1()
        {
            InitializeComponent();
            FillBrokersList();
        }

        private void FillBrokersList()
        {
            var serviceModel = ServiceModelSectionGroup.GetSectionGroup(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));
            var endpoints = serviceModel.Client.Endpoints;
            var brokers = new ToolStripMenuItem[endpoints.Count];
            for (int i = 0; i < endpoints.Count; i++)
            {
                var elem = endpoints[i];
                var item = new ToolStripMenuItem()
                {
                    Name = elem.Name,
                    Text = elem.Name,
                    Tag = elem.Address
                };
                brokers[i] = item;
            }
            BrokerComboBox.Items.AddRange(brokers);
        }

        private void retrieveBtn_Click(object sender, EventArgs e)
        {
            if (KeyComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a key.");
                return;
            }

            if (!VerifySelectedBroker()) return;
            var item = KeyComboBox.SelectedItem as ToolStripMenuItem;
            var key = item.Tag as Key;
            try
            {
                var value = broker.RetrieveData(key);
                valueRichBox.ResetText();
                valueRichBox.AppendText(value.ToString());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to server.");
            }
        }

        private void storeBtn_Click(object sender, EventArgs e)
        {
            var value = storeRichBox.Text;
            if (value == null || value.Equals(string.Empty))
            {
                MessageBox.Show("Specify the value.");
                return;
            }

            if (!VerifySelectedBroker()) return;

            try
            {
                var key = broker.StoreData(value);
                var id = $"Key {counter++}";
                var item = new ToolStripMenuItem[]
                {
                    new ToolStripMenuItem
                    {
                        Text = id,
                        Tag = key
                    }
                };
                KeyComboBox.Items.AddRange(item);
                storeRichBox.ResetText();
                MessageBox.Show("Value stored with success.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to server.");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (KeyComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a key.");
                return;
            }

            if (!VerifySelectedBroker()) return;
            var item = KeyComboBox.SelectedItem as ToolStripMenuItem;
            var key = item.Tag as Key;
            try
            {
                broker.DeleteData(key);
                KeyComboBox.Items.Remove(item);
                MessageBox.Show("Delete with success.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to server.");
            }
        }

        private bool VerifySelectedBroker()
        {
            if (BrokerComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a broker.");
                return false;
            }

            var selected = BrokerComboBox.SelectedItem as ToolStripMenuItem;
            broker = new BrokerServiceClient(selected.Name, selected.Tag.ToString());
            return true;
        }
    }
}
