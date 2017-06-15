# CommandTester
Test the input command and replace the placeholder into the variables

Functionality:
  Check the validity of the input command, and run it. 
  If the command includes whatIf property, add -whatif at the end of the command automatically and run.
  If input includes placeholder such as <User Name>, you can set new variable/example name and as the app runs the command,
  those placeholders are automatically replaces to the variable/example name that user set.
  The run result (inclding error messages), and the new example text withthe variable/exmpla name instead of placeholder will appear.
  User also can switch the credentials dynamically, and also can set the default credential.
  
Usage:
  The user need to set the username and password for the credential at his first use of this app.
  That credential will be the default user unless the user changes it by himself from the setting menu. 
  
Warning:
  In the input, the user cannot type in a command with whatIf property for multiple times.
  ex) Get-Mailbox|Set-Mailbox
      Set-Mailbox user02
      Set-Mailbox user01            
  If the user needs to check those lines as an input, the input has to be separated by line.
  Placeholder has to be expressed in such a way that <WORD>. No ZENKAKU<> will be deteected.
  
