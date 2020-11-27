param (
    [Parameter(Mandatory=$true)][string]$wotpath = "C:\games\World_of_Tanks"
 )


$versionxmlpath = $wotpath + "\version.xml"

$xml = [xml](Get-Content $versionxmlpath)

$versionstring = $xml."version.xml".version

$version = $versionstring -match '\d+\.\d+\.\d+\.\d+'

echo $matches[0]