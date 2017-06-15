param([scriptblock]$script)
$Error.Clear()

$Result = & ($script)


return [PSCustomObject]@{Result=$Result;Error=$Error}

