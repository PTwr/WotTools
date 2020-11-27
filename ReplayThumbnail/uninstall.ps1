if (-NOT ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator"))  
{  
  $arguments = "& '" +$myinvocation.mycommand.definition + "'"
  Start-Process powershell -Verb runAs -ArgumentList $arguments
  Break
}

.$Env:windir\Microsoft.NET\Framework64\v4.0.30319\regasm.exe /u $PSScriptRoot/ReplayThumbnail.dll /tlb /nologo /codebase
start-sleep -s 5