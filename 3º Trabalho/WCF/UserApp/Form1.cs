using System;
using System.Windows.Forms;
using UserApp.BrokerService;

namespace UserApp
{
    public partial class Form1 : Form
    {

        private readonly BrokerServiceClient broker;
        private int counter = 0;

        public Form1()
        {
            InitializeComponent();
            broker = new BrokerServiceClient();
        }

        private void retrieveBtn_Click(object sender, EventArgs e)
        {
            if (dropDownList.SelectedItem == null)
            {
                MessageBox.Show("Please select a key.");
                return;
            }
            var item = dropDownList.SelectedItem as ToolStripMenuItem;
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
            try
            {
                var key = broker.StoreData(value);
                var id = $"Key {counter++}";
                var item = new ToolStripMenuItem[]
                {
                    new ToolStripMenuItem {
                        Text = id,
                        Tag = key
                    }
                };
                dropDownList.Items.AddRange(item);
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
            if (dropDownList.SelectedItem == null)
            {
                MessageBox.Show("Please select a key.");
                return;
            }
            var item = dropDownList.SelectedItem as ToolStripMenuItem;
            var key = item.Tag as Key;
            try
            {
                broker.DeleteData(key);
                dropDownList.Items.Remove(item);
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
    }
}
