using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class LogicManager : IDisposable
    {
        
        private PSSession sess; //session
        private Runspace runSpace; //runspace
        private PowerShell powerShell; //powershell
        private ExchangeConnectionManager connectionManager; //connectionManager
        private ProjectController controller; //controller
        private string defaultUserName; //default user name
        private string defaultUserPass; //default user password

        public string statusLabel=string.Empty; //conection status



        public LogicManager(){

            statusLabel = "Connecting...";
        }




        private void defaultUserFinder()
        {
            defaultUserName = string.Empty; //clear up the info
            defaultUserPass = string.Empty;
            
            Properties.Settings.Default.Reload(); 
            StringCollection credentials = Properties.Settings.Default.userCredentials; //get all the user
            
            foreach (var i in credentials){

                if (i.Equals(Properties.Settings.Default.defaultCredential)){ //seqarch whether default user is in the collection

                    string[] info = i.Split(':');
                    defaultUserName = info[0];
                    defaultUserPass = info[1];
                }
            }
        }



        public void connectInvoker(string user, string pass){

            RunspaceConfiguration myConfig = setUpper();
            setUpper2(myConfig);//create run configuration, powershell, and runspace

            connectionManager = new ExchangeConnectionManager(powerShell, runSpace);

            Collection<PSObject> result = connectionManager.connector(user, pass);//get the result of the invoke

            controller = new ProjectController(powerShell, runSpace); //declare the controller
            

            if (result == null){ //null catch

                MessageBox.Show("Script is not running correctly.");
            }

            else{
                
                if (result[0].TypeNames[0].ToString().Contains("PSSession")){ //if it is session

                    sess = (PSSession)result[0].BaseObject; //get the session
                    
                    statusLabel = "Successfully Connected"; //change the status label
                }

                
                else{ //if it is error

                    ArrayList errors = result[0].Properties["Error"].Value as ArrayList;
                    string errormsg = string.Empty; //create array of error

                    if (errors.Count != 0){

                        foreach (var i in errors){ //get all error msg

                            errormsg = errormsg + System.Environment.NewLine + i.ToString();
                        }
                    }
                    
                    MessageBox.Show("Couldn't load  Exchange" + Environment.NewLine + "Error below occured" + Environment.NewLine + errormsg); //error msg in msgBox
                    
                    statusLabel = "Connection failed. Check the default credential and reconnect again."; //change the status
                }
            }
        }


        
        private RunspaceConfiguration setUpper(){
            
            RunspaceConfiguration rsconf = RunspaceConfiguration.Create(); //runconfig
            RunspaceConfigurationEntryCollection<ScriptConfigurationEntry> scripts = rsconf.Scripts; //get scripts
            
            foreach (string stFilePath in Directory.GetFiles(Application.StartupPath + "\\Scripts", "*.ps1")){ //go over all ps1 files

                string scriptName = Path.GetFileNameWithoutExtension(stFilePath); //get the script name
 
                string strScript = string.Empty;
                
                StreamReader streamReader;
                streamReader = new StreamReader(stFilePath);
                strScript = streamReader.ReadToEnd(); //all the scripts stored
                streamReader.Close();
                
                scripts.Append(new ScriptConfigurationEntry(scriptName, strScript)); //all the scripts appended
            }
            
            return rsconf;//return runConfiguration
        }



        private void setUpper2(RunspaceConfiguration config){
            
            runSpace = RunspaceFactory.CreateRunspace(config); //create runSpace
            runSpace.Open();

            powerShell = PowerShell.Create(); //make powershell
        }
        


        public string commandRun(string texts){

            return controller.commandRunner(texts); //run commands using controller
        }



        public string summaryMsg(){

            return controller.summary; //get summary msg
        }



        public string whatIfModifier(string texts){

            if ((controller != null) && (texts != null))
            {
                return controller.whatIfChecker(texts); //check what if and run
            }

            else
            {
                MessageBox.Show("No input or no connection has established.");
                return string.Empty;
            }
        }



        public void disconnector(){

            if (connectionManager != null){
                connectionManager.disconnector(sess); //disconnect the session
                statusLabel = "Disconnected";
            }
            
        }



        public string getUser(){

            defaultUserFinder(); //go over the properties 

            if (defaultUserName.Equals(string.Empty)){ //if theres no default, no user yet

                return "No user set";
            }

            else{ //else return default user

                return defaultUserName;
            }
        }



        public string getPass(){

            defaultUserFinder();//go over the properties 

            if (defaultUserPass.Equals(string.Empty)){ //if theres no default, no user yet

                return "No user set";
            }

            else{//else return default user

                return defaultUserPass;
            }
        }



        public void Dispose()
        {
            if (runSpace != null){
                runSpace.Dispose(); //dispose runspace
            }


            if (powerShell != null){
                powerShell.Dispose(); //dispose powershell
            }
            

            if (connectionManager != null){
                connectionManager.Dispose(); //dispose connectionmanager
            }


            if (controller != null){
                controller.Dispose(); //dispose controllerS
            }
        }
    }
}
