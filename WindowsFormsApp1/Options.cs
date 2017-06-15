using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Options : Form
    {
        
        private ProjectGUI project;//the project object
        public List<string> users;//get the list of credentials with users and pass

        public Options(ProjectGUI project){
            
            this.project = project;//setup
            InitializeComponent();

            selectionCreater(); //setup the second tab where we can manage credentials
        }


        
        private void addButton_Click(object sender, EventArgs e){
            
            Properties.Settings.Default.userCredentials.Add(addUserBox.Text + ":" + addPassBox.Text);
            Properties.Settings.Default.Save();//add credentials to the default and save it
            
            addUserBox.Text = "";//reset the inputs and show pop up the the user has added
            addPassBox.Text = "";
            MessageBox.Show("New credential has been added");
            
            selectionCreater();//update the second tab
        }



        public void selectionCreater(){
            
            users = new List<string>();//initiate string List, users 
            userSelection.Items.Clear();//and clear up the usreSelection GUI
            
            foreach (string element in Properties.Settings.Default.userCredentials){

                string[] info = element.Split(':');//split the credential infos by : and separate username and pass

                string username = info[0]; //username
                string credential = element; //username:password
                
                userSelection.Items.Add(username);//add all the usernames existing to the userSelection
                users.Add(credential);//and update users (List),  the list of username:password
            }
            
            string[] def = Properties.Settings.Default.defaultCredential.Split(':');
            string defaultUser = def[0];
            defaultUserLabel.Text = defaultUser;//get the default user and show it on the label
        }


       
        private void defaultButton_Click(object sender, EventArgs e){
            
            int index = userSelection.SelectedIndex;
            Properties.Settings.Default.defaultCredential = users[index];//get the corresponding user:pass from users List,
            Properties.Settings.Default.Save();//and set it as default in Defaulr Properties and save it
            
            
            selectionCreater();//update the second tab and show message
            MessageBox.Show("The selected credential has been chosen as the default credential.");

            project.logic.statusLabel = "Not updated yet.";
            project.labelChanger();
        }

        

        private void deleteButton_Click(object sender, EventArgs e) {

            int index = userSelection.SelectedIndex;//get the corresponding user:pass from users List,
            string deletion = users[index]; //and remove it from userCredentials, and users List

            //make sure the default user is not removed
            if (!Properties.Settings.Default.defaultCredential.Equals(deletion)) {
                users.Remove(deletion);
                Properties.Settings.Default.userCredentials.Remove(deletion);
                Properties.Settings.Default.Save();

                //add GUI of tab2 and show pop up message
                selectionCreater();
                MessageBox.Show("The selected credential has been removed.");
            }

            else
            {
                MessageBox.Show("You can't remove default user.");
            }
        }



        private void editButtpm_Click(object sender, EventArgs e){

            int index = userSelection.SelectedIndex;//get the corresponding user:pass from users List,
            string original = users[index];//and remove it from userCredentials, and users List

            Properties.Settings.Default.userCredentials.Remove(original); //remove from both
            users.Remove(original);

            CredentialEditor editor = new CredentialEditor(this,original); //create pop up
            editor.Show();
            
        }

        
        
    }
}
