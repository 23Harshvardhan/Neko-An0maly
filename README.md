# Neko-An0maly
Extensive backdoor made for windows using Powershell

An0maly consists of 3 parts.
- 🧍 Client
- 🖥️ Server
- 💾 Azure Storage Blob

## 🧍 Client
The client is written in PowerShell Script. When the scrit is launched for the first time it will create a Scheduled Job to start itself along with the victim's PC 
during startup. The initial script needs to be edited before initializing if it's not generated via the An0maly Server. At 3 places the victim's name needs to be entered
which should be unique.  Every 5 seconds the client script will look for commands in the Azure Storage Blob with its name. If a command is found its downloaded and
executed.

## 🖥️ Server
The server is written in C# (DotNet Framework). The server has in-built commands that can be executed on the victim's PC. It dynamically creates and uploads the 
requested command in PowerShell Script and uploads it to Azure Blob Storage.

## 💾 Azure Storage Blob
All the scripts uploaded by the server stays for 7 seconds before they are deleted to avoid re-execution of the same command.
