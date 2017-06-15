# ファイル名：MyFunc-Remove-PSSession.ps1
#
# セッションを削除する
#
# arg 1 : PSSession
#
param([System.Management.Automation.Runspaces.PSSession]$sess)
 
Remove-PSSession -Session $sess