using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class NewUser : Form
    {
        public ProjectGUI mainProject;
        private bool clicked = false;
        
        public NewUser(ProjectGUI project){

            InitializeComponent(); //initialize component
            mainProject = project; //get tyhe main GUI project
        }

        public void NewUser_Load(object sender, EventArgs e){ //load

        }

        private void registerButton_Click(object sender, EventArgs e){

            if ((userBox.Text == null) || (passBox.Text == null))
            {

                MessageBox.Show("You need to fill in both boxes.");
            }

            else
            {
                Properties.Settings.Default.defaultCredential = userBox.Text + ":" + passBox.Text; //set it to the default
                Properties.Settings.Default.userCredentials.Add(userBox.Text + ":" + passBox.Text); //add new user to the credential list
                Properties.Settings.Default.Save();//save the properties

                MessageBox.Show("New default credential has been set. Now we will start connecting to Exchange with this defaulot credential."); //show msgbox
                this.Close();

                clicked = true;

                mainProject.starter(); //start over
            }
        }

        private void NewUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!clicked)
            {
                e.Cancel=true;
                MessageBox.Show("You cannot skip default setting. In order to Cancel, please close the main window.");
            }
        }
    }
}
