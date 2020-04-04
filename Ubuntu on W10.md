https://ubuntu.com/tutorials/tutorial-ubuntu-on-windows

see : https://docs.microsoft.com/en-us/windows/wsl/install-win10

Powershell (with admin)

	Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux

-> reboot machine

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
eyJoaXN0b3J5IjpbLTE2Mjc0MjAyMzAsNzg3MTM2NjI0XX0=
-->