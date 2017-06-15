param([string]$UserName, [string]$Password)



$SecurePass = ConvertTo-SecureString -String $Password -AsPlainText -Force
$Credential = New-Object System.Management.Automation.PSCredential($UserName,$SecurePass)
$Session = New-PSSession -ConfigurationName Microsoft.Exchange -ConnectionUri https://outlook.office365.com/powershell-liveid/ -Credential $Credential -Authentication Basic -AllowRedirection

Import-PSSession $Session |Out-Null

if ($Error -ne $null){
    return [PSCustomObject]@{Error=$Error}
}

else{
    return $Session
}


