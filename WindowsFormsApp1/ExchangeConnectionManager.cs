using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace WindowsFormsApp1
{
    public class ExchangeConnectionManager : IDisposable 
    {

        private PowerShell ps;
        private Runspace rs;

        public ExchangeConnectionManager(PowerShell powerShell, Runspace runSpace){

            ps = powerShell;//set and get value
            rs = runSpace;
        }



        public Collection<PSObject> connector(string user, string pass){

            PSCommand create_sess = new PSCommand();　//new command
            
            create_sess.AddCommand("ConnectExchange");//adds a cmdlet
            
            create_sess.AddParameter("Username", user);//Adds a parameter name and value to the end of the pipeline
            create_sess.AddParameter("Password", pass);
            
            ps.Commands = create_sess;//sets the commands 
            ps.Runspace = rs;//set the runspace
            
            return  ps.Invoke();//return the run result
        }



        public Collection<PSObject> disconnector(PSSession session){
            
            PSCommand disconnect_sess = new PSCommand();//another PSCommand 
            
            disconnect_sess.AddCommand("DisconnectExchange");//Adds a cmdlet 
            
            disconnect_sess.AddParameter("sess", session);//Adds a parameter name and value to the end of the pipeline
            
            ps.Commands = disconnect_sess;//sets the commands 
            ps.Runspace = rs;//set the runspace 
            
            return ps.Invoke();//retun run result
        }



        public void Dispose()
        {
            if (ps != null){
                ps.Dispose(); //dispose powershell
            }

            if (rs != null){
                rs.Dispose(); //dispose runspace
            }
        }
    }
}
