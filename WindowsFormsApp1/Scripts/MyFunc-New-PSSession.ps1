# ファイル名：MyFunc-New-PSSession.ps1
#
# リモートホストとセッションを作成する
#
# arg 1 : hostname       接続リモートホスト名
# arg 2 : auth_myselt    $true:ユーザーとパスワードを指定する
# arg 3 : userid         auth_windowsがtrueの場合 例）administrator, user01@domain, domain\user01) 
# arg 4 : password       auth_windowsがtrueの場合
#
param([string]$hostname, [Boolean]$auth_myselt, [string]$username, [string]$passwd)
 
# ユーザーとパスワードを設定しない場合
if($auth_myselt -eq $false) { 
 
    $sess    = New-PSSession -ComputerName $hostname   
     
# ユーザーとパスワードを設定して接続する場合
} else {
     
    $sec_str = ConvertTo-SecureString $passwd -AsPlainText -Force
    $psc     = New-Object System.Management.Automation.PsCredential($username, $sec_str)
    $sess    = New-PSSession -ComputerName $hostname -Credential $psc
}
     
return $sess