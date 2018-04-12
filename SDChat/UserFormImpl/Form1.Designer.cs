namespace UserFormImpl
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
            this.menuStripBroker = new System.Windows.Forms.MenuStrip();
            this.brokerList = new System.Windows.Forms.ToolStripComboBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numberBox = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.anotherNumberToAdd = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.registerBtn = new System.Windows.Forms.Button();
            this.RegisterUser = new System.Windows.Forms.GroupBox();
            this.unRegisterBtn = new System.Windows.Forms.Button();
            this.AddRemoveGroupNameGroupBox = new System.Windows.Forms.GroupBox();
            this.removeGroupNameBtn = new System.Windows.Forms.Button();
            this.addGroupNameBtn = new System.Windows.Forms.Button();
            this.addOrRemoveGroupName = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.addGroupBtn = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.addGroupNameTextBox = new System.Windows.Forms.TextBox();
            this.receiverTextBox = new System.Windows.Forms.TextBox();
            this.sendMsgToUserGroupBox = new System.Windows.Forms.GroupBox();
            this.userRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupRadioBtn = new System.Windows.Forms.RadioButton();
            this.menuStripBroker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anotherNumberToAdd)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.RegisterUser.SuspendLayout();
            this.AddRemoveGroupNameGroupBox.SuspendLayout();
            this.sendMsgToUserGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripBroker
            // 
            this.menuStripBroker.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripBroker.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripBroker.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brokerList});
            this.menuStripBroker.Location = new System.Drawing.Point(13, 9);
            this.menuStripBroker.Name = "menuStripBroker";
            this.menuStripBroker.Size = new System.Drawing.Size(210, 32);
            this.menuStripBroker.TabIndex = 0;
            this.menuStripBroker.Text = "Broker1";
            // 
            // brokerList
            // 
            this.brokerList.Name = "brokerList";
            this.brokerList.Size = new System.Drawing.Size(200, 28);
            this.brokerList.Text = "Select a broker";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(275, 12);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(554, 348);
            this.outputTextBox.TabIndex = 1;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(275, 479);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(554, 88);
            this.inputTextBox.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(275, 450);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(110, 22);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Send a message";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(131, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Enter your number";
            // 
            // numberBox
            // 
            this.numberBox.Location = new System.Drawing.Point(6, 49);
            this.numberBox.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numberBox.Name = "numberBox";
            this.numberBox.Size = new System.Drawing.Size(120, 22);
            this.numberBox.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(142, 22);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Enter your username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(6, 105);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(204, 22);
            this.usernameTextBox.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 21);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(203, 22);
            this.textBox4.TabIndex = 9;
            this.textBox4.Text = "Add another user to the group";
            // 
            // anotherNumberToAdd
            // 
            this.anotherNumberToAdd.Location = new System.Drawing.Point(6, 49);
            this.anotherNumberToAdd.Name = "anotherNumberToAdd";
            this.anotherNumberToAdd.Size = new System.Drawing.Size(120, 22);
            this.anotherNumberToAdd.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addGroupNameTextBox);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.addGroupBtn);
            this.groupBox1.Controls.Add(this.anotherNumberToAdd);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Location = new System.Drawing.Point(12, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 186);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add user to another group";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(6, 133);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 28);
            this.registerBtn.TabIndex = 12;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // RegisterUser
            // 
            this.RegisterUser.Controls.Add(this.unRegisterBtn);
            this.RegisterUser.Controls.Add(this.textBox1);
            this.RegisterUser.Controls.Add(this.registerBtn);
            this.RegisterUser.Controls.Add(this.numberBox);
            this.RegisterUser.Controls.Add(this.textBox2);
            this.RegisterUser.Controls.Add(this.usernameTextBox);
            this.RegisterUser.Location = new System.Drawing.Point(13, 53);
            this.RegisterUser.Name = "RegisterUser";
            this.RegisterUser.Size = new System.Drawing.Size(216, 173);
            this.RegisterUser.TabIndex = 13;
            this.RegisterUser.TabStop = false;
            this.RegisterUser.Text = "Register a user";
            // 
            // unRegisterBtn
            // 
            this.unRegisterBtn.Location = new System.Drawing.Point(125, 133);
            this.unRegisterBtn.Name = "unRegisterBtn";
            this.unRegisterBtn.Size = new System.Drawing.Size(85, 28);
            this.unRegisterBtn.TabIndex = 13;
            this.unRegisterBtn.Text = "Unregister";
            this.unRegisterBtn.UseVisualStyleBackColor = true;
            this.unRegisterBtn.Click += new System.EventHandler(this.unRegisterBtn_Click);
            // 
            // AddRemoveGroupNameGroupBox
            // 
            this.AddRemoveGroupNameGroupBox.Controls.Add(this.removeGroupNameBtn);
            this.AddRemoveGroupNameGroupBox.Controls.Add(this.addGroupNameBtn);
            this.AddRemoveGroupNameGroupBox.Controls.Add(this.addOrRemoveGroupName);
            this.AddRemoveGroupNameGroupBox.Controls.Add(this.textBox5);
            this.AddRemoveGroupNameGroupBox.Location = new System.Drawing.Point(14, 450);
            this.AddRemoveGroupNameGroupBox.Name = "AddRemoveGroupNameGroupBox";
            this.AddRemoveGroupNameGroupBox.Size = new System.Drawing.Size(225, 124);
            this.AddRemoveGroupNameGroupBox.TabIndex = 14;
            this.AddRemoveGroupNameGroupBox.TabStop = false;
            this.AddRemoveGroupNameGroupBox.Text = "Add or remove a group";
            // 
            // removeGroupNameBtn
            // 
            this.removeGroupNameBtn.Location = new System.Drawing.Point(144, 89);
            this.removeGroupNameBtn.Name = "removeGroupNameBtn";
            this.removeGroupNameBtn.Size = new System.Drawing.Size(75, 29);
            this.removeGroupNameBtn.TabIndex = 3;
            this.removeGroupNameBtn.Text = "Remove";
            this.removeGroupNameBtn.UseVisualStyleBackColor = true;
            this.removeGroupNameBtn.Click += new System.EventHandler(this.removeGroupNameBtn_Click);
            // 
            // addGroupNameBtn
            // 
            this.addGroupNameBtn.Location = new System.Drawing.Point(6, 89);
            this.addGroupNameBtn.Name = "addGroupNameBtn";
            this.addGroupNameBtn.Size = new System.Drawing.Size(75, 29);
            this.addGroupNameBtn.TabIndex = 2;
            this.addGroupNameBtn.Text = "Add";
            this.addGroupNameBtn.UseVisualStyleBackColor = true;
            this.addGroupNameBtn.Click += new System.EventHandler(this.addGroupNameBtn_Click);
            // 
            // addOrRemoveGroupName
            // 
            this.addOrRemoveGroupName.Location = new System.Drawing.Point(7, 61);
            this.addOrRemoveGroupName.Name = "addOrRemoveGroupName";
            this.addOrRemoveGroupName.Size = new System.Drawing.Size(202, 22);
            this.addOrRemoveGroupName.TabIndex = 1;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(7, 33);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(149, 22);
            this.textBox5.TabIndex = 0;
            this.textBox5.Text = "Enter the group name";
            // 
            // addGroupBtn
            // 
            this.addGroupBtn.Location = new System.Drawing.Point(7, 140);
            this.addGroupBtn.Name = "addGroupBtn";
            this.addGroupBtn.Size = new System.Drawing.Size(54, 34);
            this.addGroupBtn.TabIndex = 12;
            this.addGroupBtn.Text = "Add";
            this.addGroupBtn.UseVisualStyleBackColor = true;
            this.addGroupBtn.Click += new System.EventHandler(this.addGroupBtn_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(7, 83);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(120, 22);
            this.textBox6.TabIndex = 13;
            this.textBox6.Text = "The group name";
            // 
            // addGroupNameTextBox
            // 
            this.addGroupNameTextBox.Location = new System.Drawing.Point(7, 112);
            this.addGroupNameTextBox.Name = "addGroupNameTextBox";
            this.addGroupNameTextBox.Size = new System.Drawing.Size(214, 22);
            this.addGroupNameTextBox.TabIndex = 14;
            // 
            // receiverTextBox
            // 
            this.receiverTextBox.Location = new System.Drawing.Point(391, 377);
            this.receiverTextBox.Name = "receiverTextBox";
            this.receiverTextBox.Size = new System.Drawing.Size(193, 22);
            this.receiverTextBox.TabIndex = 16;
            // 
            // sendMsgToUserGroupBox
            // 
            this.sendMsgToUserGroupBox.Controls.Add(this.groupRadioBtn);
            this.sendMsgToUserGroupBox.Controls.Add(this.userRadioBtn);
            this.sendMsgToUserGroupBox.Location = new System.Drawing.Point(275, 366);
            this.sendMsgToUserGroupBox.Name = "sendMsgToUserGroupBox";
            this.sendMsgToUserGroupBox.Size = new System.Drawing.Size(110, 78);
            this.sendMsgToUserGroupBox.TabIndex = 17;
            this.sendMsgToUserGroupBox.TabStop = false;
            this.sendMsgToUserGroupBox.Text = "Send to:";
            // 
            // userRadioBtn
            // 
            this.userRadioBtn.AutoSize = true;
            this.userRadioBtn.Checked = true;
            this.userRadioBtn.Location = new System.Drawing.Point(7, 22);
            this.userRadioBtn.Name = "userRadioBtn";
            this.userRadioBtn.Size = new System.Drawing.Size(59, 21);
            this.userRadioBtn.TabIndex = 0;
            this.userRadioBtn.TabStop = true;
            this.userRadioBtn.Text = "User";
            this.userRadioBtn.UseVisualStyleBackColor = true;
            // 
            // groupRadioBtn
            // 
            this.groupRadioBtn.AutoSize = true;
            this.groupRadioBtn.Location = new System.Drawing.Point(7, 50);
            this.groupRadioBtn.Name = "groupRadioBtn";
            this.groupRadioBtn.Size = new System.Drawing.Size(69, 21);
            this.groupRadioBtn.TabIndex = 1;
            this.groupRadioBtn.Text = "Group";
            this.groupRadioBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 579);
            this.Controls.Add(this.sendMsgToUserGroupBox);
            this.Controls.Add(this.receiverTextBox);
            this.Controls.Add(this.AddRemoveGroupNameGroupBox);
            this.Controls.Add(this.RegisterUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.menuStripBroker);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStripBroker.ResumeLayout(false);
            this.menuStripBroker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anotherNumberToAdd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.RegisterUser.ResumeLayout(false);
            this.RegisterUser.PerformLayout();
            this.AddRemoveGroupNameGroupBox.ResumeLayout(false);
            this.AddRemoveGroupNameGroupBox.PerformLayout();
            this.sendMsgToUserGroupBox.ResumeLayout(false);
            this.sendMsgToUserGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripBroker;
        private System.Windows.Forms.ToolStripComboBox brokerList;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numberBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.NumericUpDown anotherNumberToAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.GroupBox RegisterUser;
        private System.Windows.Forms.Button unRegisterBtn;
        private System.Windows.Forms.GroupBox AddRemoveGroupNameGroupBox;
        private System.Windows.Forms.Button removeGroupNameBtn;
        private System.Windows.Forms.Button addGroupNameBtn;
        private System.Windows.Forms.TextBox addOrRemoveGroupName;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button addGroupBtn;
        private System.Windows.Forms.TextBox addGroupNameTextBox;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox receiverTextBox;
        private System.Windows.Forms.GroupBox sendMsgToUserGroupBox;
        private System.Windows.Forms.RadioButton groupRadioBtn;
        private System.Windows.Forms.RadioButton userRadioBtn;
    }
}

