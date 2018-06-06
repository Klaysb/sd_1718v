namespace UserApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.retrieveBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.valueRichBox = new System.Windows.Forms.RichTextBox();
            this.storeRichBox = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.storeBtn = new System.Windows.Forms.Button();
            this.BrokerLabel = new System.Windows.Forms.Label();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.BrokerMenuStrip = new System.Windows.Forms.MenuStrip();
            this.BrokerComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.KeyComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.BrokerMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // retrieveBtn
            // 
            this.retrieveBtn.Location = new System.Drawing.Point(114, 108);
            this.retrieveBtn.Name = "retrieveBtn";
            this.retrieveBtn.Size = new System.Drawing.Size(75, 23);
            this.retrieveBtn.TabIndex = 0;
            this.retrieveBtn.Text = "Retrieve";
            this.retrieveBtn.UseVisualStyleBackColor = true;
            this.retrieveBtn.Click += new System.EventHandler(this.retrieveBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(4, 108);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 1;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.valueRichBox);
            this.panel1.Controls.Add(this.deleteBtn);
            this.panel1.Controls.Add(this.retrieveBtn);
            this.panel1.Location = new System.Drawing.Point(40, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 134);
            this.panel1.TabIndex = 2;
            // 
            // valueRichBox
            // 
            this.valueRichBox.Location = new System.Drawing.Point(4, 30);
            this.valueRichBox.Name = "valueRichBox";
            this.valueRichBox.ReadOnly = true;
            this.valueRichBox.Size = new System.Drawing.Size(185, 72);
            this.valueRichBox.TabIndex = 4;
            this.valueRichBox.Text = "";
            // 
            // storeRichBox
            // 
            this.storeRichBox.Location = new System.Drawing.Point(3, 3);
            this.storeRichBox.Name = "storeRichBox";
            this.storeRichBox.Size = new System.Drawing.Size(185, 88);
            this.storeRichBox.TabIndex = 3;
            this.storeRichBox.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.storeBtn);
            this.panel2.Controls.Add(this.storeRichBox);
            this.panel2.Location = new System.Drawing.Point(271, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 134);
            this.panel2.TabIndex = 4;
            // 
            // storeBtn
            // 
            this.storeBtn.Location = new System.Drawing.Point(3, 97);
            this.storeBtn.Name = "storeBtn";
            this.storeBtn.Size = new System.Drawing.Size(185, 34);
            this.storeBtn.TabIndex = 4;
            this.storeBtn.Text = "Store";
            this.storeBtn.UseVisualStyleBackColor = true;
            this.storeBtn.Click += new System.EventHandler(this.storeBtn_Click);
            // 
            // BrokerLabel
            // 
            this.BrokerLabel.AutoSize = true;
            this.BrokerLabel.Location = new System.Drawing.Point(45, 14);
            this.BrokerLabel.Name = "BrokerLabel";
            this.BrokerLabel.Size = new System.Drawing.Size(38, 13);
            this.BrokerLabel.TabIndex = 7;
            this.BrokerLabel.Text = "Broker";
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Location = new System.Drawing.Point(41, 77);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(25, 13);
            this.KeyLabel.TabIndex = 8;
            this.KeyLabel.Text = "Key";
            // 
            // BrokerMenuStrip
            // 
            this.BrokerMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.BrokerMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.BrokerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BrokerComboBox});
            this.BrokerMenuStrip.Location = new System.Drawing.Point(40, 33);
            this.BrokerMenuStrip.Name = "BrokerMenuStrip";
            this.BrokerMenuStrip.Size = new System.Drawing.Size(131, 27);
            this.BrokerMenuStrip.TabIndex = 9;
            this.BrokerMenuStrip.Text = "Select a broker";
            // 
            // BrokerComboBox
            // 
            this.BrokerComboBox.Name = "BrokerComboBox";
            this.BrokerComboBox.Size = new System.Drawing.Size(121, 23);
            this.BrokerComboBox.Text = "Select a broker";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KeyComboBox});
            this.menuStrip1.Location = new System.Drawing.Point(-3, 1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(251, 27);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "Select a broker";
            // 
            // KeyComboBox
            // 
            this.KeyComboBox.Name = "KeyComboBox";
            this.KeyComboBox.Size = new System.Drawing.Size(121, 23);
            this.KeyComboBox.Text = "Select a key";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 251);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.BrokerLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BrokerMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.BrokerMenuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.BrokerMenuStrip.ResumeLayout(false);
            this.BrokerMenuStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button retrieveBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox valueRichBox;
        private System.Windows.Forms.RichTextBox storeRichBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button storeBtn;
        private System.Windows.Forms.Label BrokerLabel;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.MenuStrip BrokerMenuStrip;
        private System.Windows.Forms.ToolStripComboBox BrokerComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox KeyComboBox;
    }
}

