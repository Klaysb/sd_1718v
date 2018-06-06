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
            this.dropDownList = new System.Windows.Forms.ComboBox();
            this.valueRichBox = new System.Windows.Forms.RichTextBox();
            this.storeRichBox = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.storeBtn = new System.Windows.Forms.Button();
            this.brokerList = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel1.Controls.Add(this.dropDownList);
            this.panel1.Controls.Add(this.valueRichBox);
            this.panel1.Controls.Add(this.deleteBtn);
            this.panel1.Controls.Add(this.retrieveBtn);
            this.panel1.Location = new System.Drawing.Point(40, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 134);
            this.panel1.TabIndex = 2;
            // 
            // dropDownList
            // 
            this.dropDownList.FormattingEnabled = true;
            this.dropDownList.Location = new System.Drawing.Point(4, 3);
            this.dropDownList.MaxDropDownItems = 20;
            this.dropDownList.Name = "dropDownList";
            this.dropDownList.Size = new System.Drawing.Size(185, 21);
            this.dropDownList.TabIndex = 5;
            this.dropDownList.Text = "Select a key";
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
            this.panel2.Location = new System.Drawing.Point(271, 58);
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
            // brokerList
            // 
            this.brokerList.FormattingEnabled = true;
            this.brokerList.Location = new System.Drawing.Point(44, 19);
            this.brokerList.MaxDropDownItems = 20;
            this.brokerList.Name = "brokerList";
            this.brokerList.Size = new System.Drawing.Size(185, 21);
            this.brokerList.TabIndex = 6;
            this.brokerList.Text = "Select a broker";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 251);
            this.Controls.Add(this.brokerList);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button retrieveBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox valueRichBox;
        private System.Windows.Forms.RichTextBox storeRichBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button storeBtn;
        private System.Windows.Forms.ComboBox dropDownList;
        private System.Windows.Forms.ComboBox brokerList;
    }
}

