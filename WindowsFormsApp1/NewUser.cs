/**
 * Created by Shion Kubota on 06/15/2017
 * 
 * Class for the popup shows up at the very first time.
 * set default credential
 */

using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class NewUser : Form
    {
        public ProjectGUI mainProject;
        private bool clicked = false;
        

        /**
         * constructor
         */
        public NewUser(ProjectGUI project){

            InitializeComponent(); //initialize component
            mainProject = project; //get tyhe main GUI project
        }

        
        /**
         * load GUI
         */
        public void NewUser_Load(object sender, EventArgs e){ //load

        }


        /**
         * register a new user
         */
        private void registerButton_Click(object sender, EventArgs e){

            if ((userBox.Text == null) || (passBox.Text == null)){

                MessageBox.Show("You need to fill in both boxes.");
            }

            else{

                Properties.Settings.Default.defaultCredential = userBox.Text + ":" + passBox.Text; //set it to the default
                Properties.Settings.Default.userCredentials.Add(userBox.Text + ":" + passBox.Text); //add new user to the credential list
                Properties.Settings.Default.Save();//save the properties

                MessageBox.Show("New default credential has been set. Now we will start connecting to Exchange with this defaulot credential."); //show msgbox

                clicked = true;

                this.Close();
                mainProject.starter(); //start over
            }
        }


        /**
         * prevent user from closing the form with no input
         */
        private void NewUser_FormClosing(object sender, FormClosingEventArgs e){

            if (!clicked){

                e.Cancel=true;
                MessageBox.Show("You cannot skip default setting. In order to Cancel, please close the main window.");
            }
        }
    }
}
