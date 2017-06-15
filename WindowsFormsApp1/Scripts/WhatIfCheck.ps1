
param([string]$CommandName)

$command = Get-Command $CommandName -ErrorAction SilentlyContinue
if ($command -ne $null)
{
	return $command.Parameters.Keys.Contains("WhatIf")
}
else
{
	return $false
} 
