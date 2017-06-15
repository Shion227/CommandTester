using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
            //creating Run configuration names rsconf
            RunspaceConfiguration rsconf = RunspaceConfiguration.Create();

            Debug.WriteLine("hello");
            //RunspaceConfigurationEntryCollection class object
            //it contains collection of ScriptConfigurationEntrys
            //and that is the script of the runconfiguration
            RunspaceConfigurationEntryCollection<ScriptConfigurationEntry> scripts = rsconf.Scripts;

            /////////////////////////
            // ADD SCRIPTS INSIDE THE PS1SCRIPTS TO THE RUNSPACE
            ////////////////////////

            //for all the files in the file mentioned
            foreach (string stFilePath in Directory.GetFiles(@"C:\Users\t-shkubo\Documents\Scripts", "*.ps1")){
                //create string reference called scriptName from the each file that we are looking at at the specific time
                //get the name of the current file without extention in the format of the String
                string scriptName = Path.GetFileNameWithoutExtension(stFilePath);
                //create an empty string reference called strScript 
                string strScript = string.Empty;

                //declare sr, which is the reader of the file that we are looking at right now
                using (StreamReader sr = new StreamReader(stFilePath)){
                    //then, the pointer of the strScript is storing all the charactyers in the file
                    strScript = sr.ReadToEnd();
                }

                //Create the entry of the ScriptConfigurationEntry that contains 
                //the name of the configuration entry and the script.
                //and add that item to the scripts
                scripts.Append(new ScriptConfigurationEntry(scriptName, strScript));
            }

            ///////////////////////////////
            //CREATE THE SCRIPT IN THE RUNSPACE AFTER ADDING IT TO THE RUNSPACE
            //////////////////////////////


            //Declare rs which is a single runspace that uses the rscopnfiguration 
            using (Runspace rs = RunspaceFactory.CreateRunspace(rsconf))
            {

                //Opens the runspace synchronously, creating a Windows PowerShell execution environment.
                rs.Open();

                

                //declare PowerShell object ps with an empty pipeline
                using (PowerShell ps = PowerShell.Create()) {
                    //create new PSComand object create_sess
                    PSCommand create_sess = new PSCommand();


                    //adds a cmdlet as the last command of the pipeline
                    create_sess.AddCommand("ExScript");
                    //Adds a parameter name and value to the end of the pipeline
                    create_sess.AddParameter("Username", "t-kubosh@microsoftjp.onmicrosoft.com");
                    //Adds a parameter name and value to the end of the pipeline
                    create_sess.AddParameter("Password", "watashiUS2ikuze");


                    //sets the commands of the pipeline invoked by the PowerShell object to the PSCommand
                    ps.Commands = create_sess;
                    //also, set the runspace to rs which uses the rscopnfiguration 
                    ps.Runspace = rs;



                    //declare a collection of PSObject as result
                    //and add the result of run of the the commands of the PowerShell object pipeline
                    Collection<PSObject> result = ps.Invoke();

                    /**
                    foreach (var item in result)
                    {

                        //If something is in Error
                        if (item.Properties["Error"].Value != null)
                        {

                            //Debug.WriteLine(item.Properties["Error"].Value.ToString());
                            //change the array of the errors as ArrayList
                            ArrayList errors = item.Properties["Error"].Value as ArrayList;

                            //if anything is in that array
                            if (errors.Count != 0)
                            {

                                //write out all the errors
                                foreach (var i in errors)
                                {
                                    Debug.WriteLine("Error below occurred:");
                                    Debug.WriteLine(i.ToString());
                                }
                            }
                        }

                    }
                    **/

                    //another PSCommand created by the name of psremove
                    PSCommand myPS;


                    string texts = "Get-Mailbox | Get-Recipient";
                    //Regex regex = new Regex(@"^[^A-Za-z0-9][A-Z][a-z]{2}+\\-[A-Z][A-Za-z]+[^A-Za-z0-9]$");
                    Regex regex = new Regex(@"\w+-\w+");

                    

                    var founds = from Match m in regex.Matches(texts) select m.Value;

                    Collection<PSObject> result3;
                    ScriptBlock scriptBlock;
                    String input;

                    foreach (string newText in founds)
                    {
                        //string newText = regex.Match(texts).Value;


                        //GETTING THE INPUTS
                        ///////////////////////////////
                        input = newText;
                        //////////////////////////////

                        myPS = new PSCommand();
                        //Adds a cmdlet as the last command of the pipeline
                        myPS.AddCommand("Untitled2");

                        scriptBlock = ScriptBlock.Create(input);

                        myPS.AddParameter("script", scriptBlock);

                        //sets the commands of the pipeline invoked by the PowerShell object to the PSCommand
                        ps.Commands = myPS;
                        //also, set the runspace to rs which uses the rscopnfiguration
                        ps.Runspace = rs;

                        //Synchronously runs the commands of the PowerShell object pipeline

                        Debug.WriteLine("Command Name   " + input);
                        

                        result3 = ps.Invoke();

                        foreach (var item in result3)
                        {

                            //If something is in Error
                            if (item.Properties["Error"].Value != null)
                            {

                                //Debug.WriteLine(item.Properties["Error"].Value.ToString());
                                //change the array of the errors as ArrayList
                                ArrayList errors = item.Properties["Error"].Value as ArrayList;

                                //if anything is in that array
                                if (errors.Count != 0)
                                {

                                    //write out all the errors
                                    foreach (var i in errors)
                                    {
                                        Debug.WriteLine("Error below occurred:");
                                        Debug.WriteLine(i.ToString());
                                    }
                                }
                            }

                            //If something is in the Result
                            //Debug.WriteLine(item.Properties["Result"].Value);
                            //Debug.WriteLine("Hello");
                            if (item.Properties["Result"].Value != null)
                            {
                                //Debug.WriteLine(item.Properties["Result"].Value.ToString());
                                //change the array of the errors as ArrayList
                                //ArrayList answers = item.Properties["Result"].Value as ArrayList;

                                Object[] answers;

                                if (!item.Properties["Result"].Value.GetType().IsArray)
                                {
                                    Object answer = item.Properties["Result"].Value;
                                    answers = new Object[1];
                                    answers[0] = answer;

                                }

                                else
                                {
                                    answers = item.Properties["Result"].Value as Object[];
                                }


                                //if anything is in that array
                                if (answers.Length != 0)
                                {

                                    //write out everyting
                                    foreach (var i in answers)
                                    {
                                        Debug.WriteLine(i.ToString());
                                        
                                    }
                                }
                            }

                            /**  
                              else
                              {
                                  //Debug.WriteLine(item.Properties["name"].Value.ToString());
                                  Debug.WriteLine("Empty");
                              }
                              **/
                        }

                    }

                    //}

                    //another PSCommand created by the name of psremove
                    PSCommand ps2 = new PSCommand();
                    //Adds a cmdlet as the last command of the pipeline
                    ps2.AddCommand("MyFunc-Remove-PSSession");
                    //Adds a parameter name and value to the end of the pipeline
                    // psremove.AddParameter("sess", sess);

                    //sets the commands of the pipeline invoked by the PowerShell object to the PSCommand
                    ps.Commands = ps2;
                    //also, set the runspace to rs which uses the rscopnfiguration
                    ps.Runspace = rs;

                    //Synchronously runs the commands of the PowerShell object pipeline

                    
                    Collection<PSObject> result2 = ps.Invoke();



                }
            }

        }

        
    }
}
