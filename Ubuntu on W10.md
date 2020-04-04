# Install Ubuntu (Linux) on W10
Follow instructions on   https://ubuntu.com/tutorials/tutorial-ubuntu-on-windows

Also see : https://docs.microsoft.com/en-us/windows/wsl/install-win10

Enable Linux with Powershell (open PS with admin privileges)

	Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux


Nreboot machine
open command prompt

	ubuntu
Ubuntu ... create username and pasword

-> on W10 create a C:\TMP folder

Ubuntu

    cat /etc/*-release
    cd /mnt/c
    cd TMP
    mkdir linuxmount
    cd /mnt/c/TMP/linuxmountls    
    ls
    dotnet
    
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEzMDc3NjkyOCw3ODcxMzY2MjRdfQ==
-->