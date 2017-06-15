namespace WindowsFormsApp1
{
    partial class Options
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.addButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addPassBox = new System.Windows.Forms.TextBox();
            this.addUserBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.editButtpm = new System.Windows.Forms.Button();
            this.defaultUserLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.defaultButton = new System.Windows.Forms.Button();
            this.userSelection = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(403, 209);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.addButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.addPassBox);
            this.tabPage1.Controls.Add(this.addUserBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(395, 183);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add New User";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(155, 142);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "username";
            // 
            // addPassBox
            // 
            this.addPassBox.Location = new System.Drawing.Point(141, 82);
            this.addPassBox.Name = "addPassBox";
            this.addPassBox.PasswordChar = '*';
            this.addPassBox.Size = new System.Drawing.Size(178, 20);
            this.addPassBox.TabIndex = 1;
            // 
            // addUserBox
            // 
            this.addUserBox.Location = new System.Drawing.Point(141, 44);
            this.addUserBox.Name = "addUserBox";
            this.addUserBox.Size = new System.Drawing.Size(178, 20);
            this.addUserBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.editButtpm);
            this.tabPage2.Controls.Add(this.defaultUserLabel);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.deleteButton);
            this.tabPage2.Controls.Add(this.defaultButton);
            this.tabPage2.Controls.Add(this.userSelection);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(395, 183);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manage Users";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // editButtpm
            // 
            this.editButtpm.Location = new System.Drawing.Point(274, 118);
            this.editButtpm.Name = "editButtpm";
            this.editButtpm.Size = new System.Drawing.Size(115, 23);
            this.editButtpm.TabIndex = 5;
            this.editButtpm.Text = "Edit selected";
            this.editButtpm.UseVisualStyleBackColor = true;
            this.editButtpm.Click += new System.EventHandler(this.editButtpm_Click);
            // 
            // defaultUserLabel
            // 
            this.defaultUserLabel.AutoSize = true;
            this.defaultUserLabel.Location = new System.Drawing.Point(136, 157);
            this.defaultUserLabel.Name = "defaultUserLabel";
            this.defaultUserLabel.Size = new System.Drawing.Size(63, 13);
            this.defaultUserLabel.TabIndex = 4;
            this.defaultUserLabel.Text = "DefaultUser";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Current default user :";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(139, 118);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(114, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete selected";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // defaultButton
            // 
            this.defaultButton.Location = new System.Drawing.Point(7, 118);
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(113, 23);
            this.defaultButton.TabIndex = 1;
            this.defaultButton.Text = "Set as default";
            this.defaultButton.UseVisualStyleBackColor = true;
            this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
            // 
            // userSelection
            // 
            this.userSelection.FormattingEnabled = true;
            this.userSelection.Location = new System.Drawing.Point(7, 4);
            this.userSelection.Name = "userSelection";
            this.userSelection.Size = new System.Drawing.Size(382, 108);
            this.userSelection.TabIndex = 0;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 233);
            this.Controls.Add(this.tabControl1);
            this.Name = "Options";
            this.Text = "Options";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addPassBox;
        private System.Windows.Forms.TextBox addUserBox;
        private System.Windows.Forms.ListBox userSelection;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button defaultButton;
        private System.Windows.Forms.Label defaultUserLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button editButtpm;
    }
}