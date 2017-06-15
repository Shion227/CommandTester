/**
 * Created by Shion Kuboat on 6/15/2017
 * 
 * Class for credential settings
 */

using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CredentialEditor : Form
    {
        private Options option;
        private string newPass;
        private string newName;
        private string original;


        /**
         * Constructor
         */
        public CredentialEditor(Options o,string input){

            InitializeComponent(); //initialize component

            option = o; //set the values
            original = input;
        }
        

        /**
         * confirm the info typed in as 
         * the new vwesion of credential
         */
        private void editButton_Click(object sender, EventArgs e){

            //get new pass and user
            newPass = newPassword.Text;
            newName = newUsername.Text;

            //chnage the properties default
            credentialModifier();
        }


        /**
         * And set the value as new value when esitButton clicked
         */
        private void credentialModifier(){
            string[] info = original.Split(':');

            string username = info[0]; //username
            string pass = info[1]; //password

            original = original.Replace(username, newName);
            original = original.Replace(pass, newPass); //modify the entire line
            

            Properties.Settings.Default.userCredentials.Add(original); //add to the properties
            option.users.Add(original); //add to the List

            MessageBox.Show("The username/password has been updated."); //show msg box
            this.Close();
        }
    }
}
