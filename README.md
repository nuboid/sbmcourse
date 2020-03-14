# Architecting Microservices and cross platform apps in .NET Core 3.x on Azure

Spring 2020 edition
version : 11/04

https://sbm.be/opleiding/it-pro/architecting-microservices-and-cross-platform-apps-in-net-core-3-x-on-azure

## PC Setup

Visual Studio 2019

https://visualstudio.microsoft.com/downloads

Visual Studio Code

https://code.visualstudio.com/download

.NET Core 3.1.x

https://dotnet.microsoft.com/download/dotnet-core/3.1

Latest Blazor templates

https://docs.microsoft.com/en-us/aspnet/core/blazor/get-started?view=aspnetcore-3.1&tabs=visual-studio

Docker Desktop for Windows

https://hub.docker.com/editions/community/docker-ce-desktop-windows


## Materials

Microsoft boek '.NET Microservices Architecture for Containerized .NET'

https://dotnet.microsoft.com/download/e-book/microservices-architecture/pdf

Microsoft boek 'Buidling Cloud Apps with Microsoft Azure'

https://download.microsoft.com/download/8/F/4/8F485F6E-EA78-43B5-84DE-1392EAB13779/Microsoft_Press_eBook_Building_Cloud_Apps_with%20Microsoft_Azure_PDF.pdf


Microsoft boek 'Creating Mobile Apps with Xamarin.Forms

https://docs.microsoft.com/en-us/xamarin/xamarin-forms/creating-mobile-apps-xamarin-forms


Microsoft boek 'Blazor for ASP.NET

https://aka.ms/blazor-ebook


Website gRPC for WCF Developers

https://docs.microsoft.com/en-us/dotnet/architecture/grpc-for-wcf-developers


Microsofft boek 'Containerized Docker Application Lifecycle with Microsoft Platform and Tools'

https://download.microsoft.com/download/7/6/8/768E8E11-1C4B-4C5C-9211-96918C324722/Containerized%20Docker%20Application%20Lifecycle%20with%20Microsoft%20Platform%20and%20Tools%20(eBook).pdf


Micrsoft boek 'The Developers's Guido to Azure'

https://download.microsoft.com/download/2/C/F/2CF7401A-B9D7-4828-917D-199E0896BFE5/Azure_Developer_Guide_eBook.pdf


Mirosoft boek 'Getting Started with Entity Frameworkd 6 Code First'

http://download.microsoft.com/download/0/f/b/0fbfaa46-2bfd-478f-8e56-7bf3c672df9d/getting%20started%20with%20entity%20framework%206%20code%20first%20using%20mvc%205.pdf


Boek 'Domain Driven Design Quickly'

https://www.infoq.com/minibooks/domain-driven-design-quickly/

Identity Server documentatie

https://identityserver4.readthedocs.io/en/latest

http://docs.identityserver.io/en/stable/index.html


Azure Devops Documentation

https://docs.microsoft.com/en-us/azure/devops/index?view=azure-devops


Microsoft Azuer Devops Labs

https://azuredevopslabs.com

## Code Share
[https://codeshare.io/](https://codeshare.io/)

## Other Links


https://docs.microsoft.com/en-us/dotnet/standard/net-standard

https://docs.microsoft.com/en-us/xamarin/android/troubleshooting/questions/path-too-long-exception

## Git Commands

    git clone https://github.com/nuboid/sbmcourse.git
    git status
    git add .
    git commit -a -m "test"
    git push
    git branch
    git branch "myfeature"
    git checkout "myfeature"
    git push origin "myfeature"
    git push --set-upstream origin "myfeature"
    git push
    
Typical workflow

	git branch "branchname"
	git status
	git branch -a
	git checkout "branchname"
	git push --set-upstream origin "branchname"
	//develop ...
	git add .
	git commit -a -m "commitmessage"
	git push origin

Checkout from a commit
   
    git checkout 78298273b50fe5be33d9596d6e7e9fa65d4f1895

See all branches

	git branch -a


Creating a new branch
Delete branches

	git branch -d "branchname"
	git push origin --delete "branchname"
	
**Git UI tooling**

[https://www.syntevo.com/smartgit/](https://www.syntevo.com/smartgit/)

[https://www.gitkraken.com/](https://www.gitkraken.com/)

[https://www.sourcetreeapp.com/](https://www.sourcetreeapp.com/)

[https://tortoisegit.org/](https://tortoisegit.org/)

## Docker Commands

    docker ps
    docker run
    docker stop

https://docs.docker.com/engine/reference/commandline/docker/

---
update this file with [https://stackedit.io/app#](https://stackedit.io/app#)

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTg0MzkwNDA1LC0xODY4MDQ1NjM4LC0xMD
A0MTg5OTc2LC0zNTY4MzI3LC04MTQxMjk1NjksNzE0MDMzNjMz
LC00MDg1ODIyNDMsLTExMzk3OTM5MzMsMTM1MzIxNDk5LC0xND
Y5NTcxMzUwLC02MDIxMzI5MF19
-->