using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;


namespace WindowsFormsApp1
{


    public partial class ProjectGUI : Form{
        
        private string texts; //the input command line
        private string output; //reference for error result + return values 

        public LogicManager logic = new LogicManager(); //logic behind this entire app system

        

        public ProjectGUI(){

            InitializeComponent(); //initialize GUI component
        }



        private void project_Load(object sender, EventArgs e){
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.parameterChangerGrid, "Type in placeholder name along with < and >. \n Do not type in any command name.");
            
        }


        
        private void ProjectGUI_Shown(object sender, EventArgs e){

            starter(); //when the GUI is shown, kick in
        }



        public void starter(){ //kick in

            this.Cursor = Cursors.AppStarting; //change the cursor
            
            //if theres any
            if (!logic.getUser().Equals("No user set")){

                labelChanger(); //change the label
                
                logic.connectInvoker(logic.getUser(),logic.getPass()); //connect exchange as default
                
                parameterDefaultSet(); //initialize the GUI grid 

                labelChanger(); //change the label

                this.Cursor = Cursors.Default;//change the cursor
            }

            else{

                NewUser defaultSet = new NewUser(this); //create pop up and 
                defaultSet.Show(); //show 
            }
        }


        
        public void labelChanger(){

            statusLabel.Text = logic.statusLabel; //change the label of connection status
            defaultUserLabel.Text = logic.getUser(); //change the label of default user
        }


        
        private void parameterDefaultSet()
        {
            //create 3 rows as defaulot for parameter changer
            for (int i=0; i<2; i++){
                DataGridViewRow row = (DataGridViewRow)parameterChangerGrid.Rows[0].Clone();
                row.Cells[0].Value = "";
                row.Cells[1].Value = "";
                parameterChangerGrid.Rows.Add(row);
            }

            //assign *popular* default to the first two lines 
            parameterChangerGrid.Rows[0].Cells[0].Value = "<ユーザー名>";
            parameterChangerGrid.Rows[0].Cells[1].Value = "User01";

            parameterChangerGrid.Rows[1].Cells[0].Value = "<データベース名>";
            parameterChangerGrid.Rows[1].Cells[1].Value = "Database01";

            
        }

        
        
        private void runButton_Click(object sender, EventArgs e) {
            
            this.Cursor = Cursors.AppStarting; //change the cursor
            
            output = string.Empty; //reset the output

            if (inputBox.Text != null){

                texts = parameterChanger(inputBox.Text); //get input text
                texts = logic.whatIfModifier(texts); //and modify

                placeHolderCheckAndRun(texts); //check the last placeHolder and run
            }

            this.Cursor = Cursors.Default; //change the cursor
        }



        private void placeHolderCheckAndRun(string text){

            Regex regex = new Regex(@"\<\w+\>"); 
            var founds = from Match m in regex.Matches(text) select m.Value; //get all expressions that meets < word >

            if ((founds!=null)&& (founds.Count() != 0)){ //if theres any

                MessageBox.Show("Some place holders have not declared."); //show msg

                foreach (string newText in founds){ //in each of the member
                    
                    DataGridViewRow row = (DataGridViewRow)parameterChangerGrid.Rows[0].Clone();
                    row.Cells[0].Value = newText;
                    row.Cells[1].Value = "";
                    parameterChangerGrid.Rows.Add(row); //create new line and add the placeHolder 
                }
            }

            else{ //or 
               
                output = logic.commandRun(texts); //get the result from running it
                
                detailBox.Text = output; //get two types of results
                summaryBox.Text = logic.summaryMsg();
                
                copyPasteBox.Text = texts.Replace("-whatIf", ""); //take out whatIf
            }
        }



        private string parameterChanger(string text){

            string input =text; //temporary reference to the input
            
            if (input != null){ //if the input is not null

                
                for (int i = 0; i < parameterChangerGrid.Rows.Count; i++){ //go over all the rows in the parameter changer grid

                    string from = string.Empty;
                    string to = string.Empty;

                    //if theres any input in both sides, replace the placeholder with variables 
                    if ((parameterChangerGrid.Rows[i].Cells[0].Value != null) && (parameterChangerGrid.Rows[i].Cells[1].Value != null)){

                        //argument error catcher (make sure both from and else are not length 0)
                        if (parameterChangerGrid.Rows[i].Cells[0].Value.ToString() != ""){
                            from = parameterChangerGrid.Rows[i].Cells[0].Value.ToString();
                        }

                        else{
                            from = " ";
                        }

                        if (parameterChangerGrid.Rows[i].Cells[1].Value.ToString() != ""){
                            to = parameterChangerGrid.Rows[i].Cells[1].Value.ToString();
                        }

                        else{
                            to = " ";
                        }

                        //then replace from to to 
                        input = input.Replace(from, to);
                    }
                }
            }

            //return the input where all placeholders and variables are replaced
            return input;
        }
        

        
        private void copyPasteBox_KeyDown(object sender, KeyEventArgs e){
            
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control){//check whether it is Ctrl + A
                
                copyPasteBox.SelectAll(); //select all
            }
        }
        

        
        private void inputBox_MouseDoubleClick(object sender, MouseEventArgs e){
            
            inputBox.SelectAll(); //double click and select all
        }

        

        private void newConnection_Click(object sender, EventArgs e){

            DialogueBox subForm = new DialogueBox(this); //create the popup
            subForm.Show(); //and show it 
            labelChanger(); //change label 
        }


        
        private void optionButton_Click(object sender, EventArgs e){

            Options option = new Options(this); //create pop up
            option.Show(); //and show it
            labelChanger(); //change label
        }

        

        private void reconnectButton_Click(object sender, EventArgs e){

            logic.disconnector(); //disconnect first
            logic.statusLabel = "Connecting..."; //change the label status
            labelChanger(); //and update GUI
            this.Cursor = Cursors.AppStarting; //change the cursor

            logic.connectInvoker(logic.getUser(), logic.getPass()); //invoke the connection

            labelChanger(); //change the label
            this.Cursor = Cursors.Default; //change the cursor
        }

        

        private void button1_Click(object sender, EventArgs e){

            logic.disconnector(); //disconnect 
            Properties.Settings.Default.Reset(); //reset the defaulot
            MessageBox.Show("The settings habe been reset."); //show message
            labelChanger(); //change the GUI label
        }



        private void project_FormClosed(object sender, FormClosedEventArgs e){

            logic.disconnector();//disconnect
            logic.Dispose();//invoke disopose
        }
        
    }
}
