cd C:\dev\WotTools\Toolchain


$wotpath = "C:\games\World_of_Tanks"

#cleanup
if((Test-Path -Path .\scripts )){
    rm .\scripts -r -fo
}

$version = .\getversion.ps1 $wotpath
echo $version

WotToolsCLI.exe extract --input C:\games\World_of_Tanks\res\packages\scripts.pkg --file scripts/item_defs/dog_tags/dog_tags.xml --decode
$xml = [xml](Get-Content "scripts/item_defs/dog_tags/dog_tags.xml")

$dogTags = $xml.SelectNodes('//component')
foreach($dogTag in $dogTags) {
    $dogTag."resourceRoot" = "";
}


$xml.Save((Resolve-Path "scripts/item_defs/dog_tags/dog_tags.xml"));
WotToolsCLI.exe wotmod --input scripts --output DogSpam.wotmod

$to = $wotpath+'\mods\releases\'+$version+'\DogSpam.wotmod'
New-Item -Force $to
copy-item DogSpam.wotmod $to -Recurse -Force

#cleanup
if((Test-Path -Path .\scripts )){
    rm .\scripts -r -fo
}

WotToolsCLI.exe extract --input C:\games\World_of_Tanks\res\packages\scripts.pkg --file scripts/item_defs/customization/paints/list.xml --decode
WotToolsCLI.Paintcolors.exe color --input ./scripts/item_defs/customization/paints/list.xml --color "255 105 180 255"
WotToolsCLI.exe wotmod --input scripts --output EVERYTHING_IS_PINK.wotmod

$to = $wotpath+'\mods\releases\'+$version+'\EVERYTHING_IS_PINK.wotmod'
New-Item -Force $to
copy-item EVERYTHING_IS_PINK.wotmod $to -Recurse -Force

WotToolsCLI.exe extract --input C:\games\World_of_Tanks\res\packages\scripts.pkg --file scripts/item_defs/customization/paints/list.xml --decode
WotToolsCLI.Paintcolors.exe color --input ./scripts/item_defs/customization/paints/list.xml --color "62 68 54 255"
WotToolsCLI.exe wotmod --input scripts --output AllPaintsSetToSwedish.wotmod

$to = $wotpath+'\mods\releases\'+$version+'\AllPaintsSetToSwedish.wotmod'
New-Item -Force $to
copy-item AllPaintsSetToSwedish.wotmod $to -Recurse -Force

WotToolsCLI.exe extract --input C:\games\World_of_Tanks\res\packages\scripts.pkg --file scripts/item_defs/customization/paints/list.xml --decode
WotToolsCLI.Paintcolors.exe color --input ./scripts/item_defs/customization/paints/list.xml --color "79 73 52 255"
WotToolsCLI.exe wotmod --input scripts --output AllPaintsSetToPolish.wotmod

$to = $wotpath+'\mods\releases\'+$version+'\AllPaintsSetToPolish.wotmod'
New-Item -Force $to
copy-item AllPaintsSetToPolish.wotmod $to -Recurse -Force

WotToolsCLI.exe extract --input C:\games\World_of_Tanks\res\packages\scripts.pkg --file scripts/item_defs/customization/paints/list.xml --decode
WotToolsCLI.Paintcolors.exe patch --input ./scripts/item_defs/customization/paints/list.xml --file tonneddowncolors.xml
WotToolsCLI.exe wotmod --input scripts --output TonnedDownNonHistoricalPaints.wotmod

$to = $wotpath+'\mods\releases\'+$version+'\TonnedDownNonHistoricalPaints.wotmod'
New-Item -Force $to
copy-item TonnedDownNonHistoricalPaints.wotmod $to -Recurse -Force

#test
$exe = $wotpath+'\WorldOfTanks.exe'


if((Test-Path -Path $wotpath\mods\$version\TonnedDownNonHistoricalPaints.wotmod )){
    rm $wotpath\mods\$version\TonnedDownNonHistoricalPaints.wotmod -r -fo
}
if((Test-Path -Path $wotpath\mods\$version\AllPaintsSetToPolish.wotmod )){
    rm $wotpath\mods\$version\AllPaintsSetToPolish.wotmod -r -fo
}

copy-item TonnedDownNonHistoricalPaints.wotmod $wotpath\mods\$version\TonnedDownNonHistoricalPaints.wotmod
& $exe | Out-Null

if((Test-Path -Path $wotpath\mods\$version\TonnedDownNonHistoricalPaints.wotmod )){
    rm $wotpath\mods\$version\TonnedDownNonHistoricalPaints.wotmod -r -fo
}

copy-item AllPaintsSetToPolish.wotmod $wotpath\mods\$version\AllPaintsSetToPolish.wotmod
& $exe | Out-Null