/**
 * Created by Shion Kubota on 6/15/2017
 * 
 * Class for setting up the temporary credential
 */

using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DialogueBox : Form
    {
        private Button connectionButton;
        private Label label1;
        private Label label2;
        private TextBox newUserBox;
        private TextBox newPassBox;
        private ProjectGUI mainProject;

        public DialogueBox(ProjectGUI project){

            this.mainProject = project;
            InitializeComponent(); //initialize component
        }

        private void InitializeComponent()
        {
            this.connectionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newUserBox = new System.Windows.Forms.TextBox();
            this.newPassBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // connectionButton
            // 
            this.connectionButton.Location = new System.Drawing.Point(43, 129);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(189, 30);
            this.connectionButton.TabIndex = 0;
            this.connectionButton.Text = "Execute new Exchange connection";
            this.connectionButton.UseVisualStyleBackColor = true;
            this.connectionButton.Click += new System.EventHandler(this.connectionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "password";
            // 
            // newUserBox
            // 
            this.newUserBox.Location = new System.Drawing.Point(22, 35);
            this.newUserBox.Multiline = true;
            this.newUserBox.Name = "newUserBox";
            this.newUserBox.Size = new System.Drawing.Size(237, 20);
            this.newUserBox.TabIndex = 3;
            // 
            // newPassBox
            // 
            this.newPassBox.Location = new System.Drawing.Point(22, 86);
            this.newPassBox.Multiline = true;
            this.newPassBox.Name = "newPassBox";
            this.newPassBox.Size = new System.Drawing.Size(237, 21);
            this.newPassBox.TabIndex = 4;
            // 
            // DialogueBox
            // 
            this.ClientSize = new System.Drawing.Size(284, 192);
            this.Controls.Add(this.newPassBox);
            this.Controls.Add(this.newUserBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectionButton);
            this.Name = "DialogueBox";
            this.Load += new System.EventHandler(this.DialogueBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void DialogueBox_Load(object sender, EventArgs e){ //load

        }

        
        /**
         * when button clicked, make the new connection
         */
        private void connectionButton_Click(object sender, EventArgs e){
             
            connectionButton.Text = "Disconnecting currnet session"; //show the status in button
            
            mainProject.logic.disconnector(); //disconnect the current session
            
            connectionButton.Text = "Connecting to new session...please wait.";//and change the text while connecting
            
            string newUser = newUserBox.Text;//get new user name
            string newPass = newPassBox.Text;
            
            mainProject.logic.connectInvoker(newUser, newPass); //reconnect as new user

            MessageBox.Show("New connection established.");//show the message and close the this popup

            //change the main GUI label
            mainProject.labelChanger();
            this.Close();
        }
    }
}
