/**
 * Created by Shion Kubota on 6/15/2017
 * 
 * Class for running the Script
 */

using System;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ScriptRunner : IDisposable
    {

        private PowerShell powerShell;
        private Runspace runSpace;

        public string summary = "No error occured"; 



        public ScriptRunner(PowerShell ps, Runspace rs){

            powerShell = ps;//set ps and rs first
            runSpace = rs;
        }


        public string whatIfChecker(string text){
            
            Regex regex = new Regex(@"\w+-\w+");//create the pattern of the command which is Word-Word
            var founds = from Match m in regex.Matches(text) select m.Value; //and find pharses match
            
            foreach (string newText in founds){
               
                PSCommand checkPS = new PSCommand(); //powershell object to check the whatIf
                checkPS.AddCommand("WhatIfCheck");//add scripts to the check powershell
                
                checkPS.AddParameter("CommandName", newText);//as for parameter CommandName, use the single command phrase
                
                powerShell.Commands = checkPS;//set the commands of the pipieline to the checkPS
                
                Object temp = powerShell.Invoke()[0]; //get the first element
                bool whatif = temp.Equals(true); //and see whether it has whatIf or not
                
                if (whatif){
                    string newTemp = newText + " -whatIf";
                    text = text.Replace(newText, newTemp);//if yes, add whatIf
                }
            }
            return text;//return the modified input
        }



        public string commandRunner(string text){
            
            Collection<PSObject> runResult;//collection of the run results
            ScriptBlock scriptBlock;//ScriptBlock maker
            
            string[] sentence = text.Split('\n');//devide the sentece by line
            string tempstr;
            string output= string.Empty;
            
            foreach (string line in sentence){
                
                tempstr = line.TrimEnd('\r'); //get only the string part
                
                PSCommand myPS;//create new command for each line
                myPS = new PSCommand();
                myPS.AddCommand("MessageExtracter");//Adds a cmdlet as the last command of the pipeline

                try{
                    scriptBlock = ScriptBlock.Create(tempstr);//create scriptBlock based on the input
                    myPS.AddParameter("script", scriptBlock);
                }

                catch(System.Management.Automation.ParseException){
                    MessageBox.Show("Some inputs are not allowed please review."); //if prohibbited expression exists
                }


                powerShell.Commands = myPS;
                powerShell.Runspace = runSpace; //make runspace, powershell
                
                runResult = powerShell.Invoke();//get the runResults

                output = output + Environment.NewLine + messageGetter(runResult, tempstr,  output)+ Environment.NewLine;//output msg
            }
            
            return output; //return the output message
        }



        //add up error msg and result msg for each line
        private string messageGetter(Collection<PSObject> result, string command, string ans){

            string errorVal;
            string returnVal;
            
            foreach (var item in result){
                
                errorVal = errorGetter(item);//get both error and result msg
                returnVal = returnGetter(item);
                
                ans =  "from line '" + command + " ' the error below found" + Environment.NewLine + errorVal + Environment.NewLine + "from command line '" + command + " ' the result below found" + Environment.NewLine + returnVal + Environment.NewLine;
            }
            
            return ans;//retur output for a line
        }




        //return error msg
        private string errorGetter(PSObject item)
        {
            string errormsg = string.Empty;

            //If something is in Error property
            if (item.Properties["Error"].Value != null){
                
                ArrayList errors = item.Properties["Error"].Value as ArrayList;

                if(errors.Count!=0){

                    errormsg = Environment.NewLine + "Error below occurred:"; //write out all the errors
                    
                    summary = "There is an error in"; //maker summarized ver.

                    
                    foreach (var i in errors){
                        
                        string source = (string)((ErrorRecord)i).TargetObject; //get the source of the error
                        
                        errormsg = "from command named '" + source + "' error below found";
                        summary = summary + source;//add the error source to the output msg
                        
                        string tempSt = i.ToString(); //change the error msg into string
                        errormsg = errormsg + System.Environment.NewLine + tempSt;//and add it to the line of string
                    }
                }
                
                return errormsg;//return error msg
            }
            
            else{ //if theres no error property return nothing

                return null;
            }
        }


        
        private string returnGetter(PSObject item){

            string resultmsg = string.Empty;

            
            if (item.Properties["Result"].Value != null){//If something is in the Result
                
                Object[] answers;
                
                if (!item.Properties["Result"].Value.GetType().IsArray){//if array is not returned
                    
                    Object answer = item.Properties["Result"].Value; //create an Object object
                    answers = new Object[1];//set asnwers to be one length array
                    answers[0] = answer; //and add the result object into the 1st element of the array
                }

                else{
                    //else the output would be the array
                    answers = item.Properties["Result"].Value as Object[];
                }
                
                if (answers[0] != null){//if anything is in that array
                   
                    resultmsg = System.Environment.NewLine; //write out everyting

                    foreach (var i in answers)
                    {

                        string newSt = i.ToString();//chaneg it to string
                        resultmsg = resultmsg + Environment.NewLine + newSt;//and add it to the resultmsg
                    }
                }
            }
            return resultmsg;
        }



        public void Dispose()
        {
            if (powerShell != null){
                powerShell.Dispose(); //dispose powershell
            }

            if (runSpace != null){
                runSpace.Dispose(); //dispose runspace
            }
        }
    }
}
