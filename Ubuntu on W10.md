# Install Ubuntu (Linux) on W10
Follow instructions on   https://ubuntu.com/tutorials/tutorial-ubuntu-on-windows

Also see : https://docs.microsoft.com/en-us/windows/wsl/install-win10

Enable Linux with Powershell (open PS with admin privileges)

	Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux


### Now reboot machine

open command prompt and type :

	ubuntu
	
-> create username and pasword

-> on W10 create a C:\TMP folder

### Inside Ubuntu

    cat /etc/*-release
    cd /mnt/c
    cd TMP
    mkdir linuxmount
    cd /mnt/c/TMP/linuxmountls    
    ls
    dotnet
    
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTIwMzIwNTgzNDddfQ==
-->