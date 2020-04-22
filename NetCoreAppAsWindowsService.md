
# Question : 

**How to host a .net Core app standalone on a windows server ?**

 Docker ? Standalone ?

https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-3.1&tabs=visual-studio

https://devblogs.microsoft.com/aspnet/net-core-workers-as-windows-services/

https://www.stevejgordon.co.uk/running-net-core-generic-host-applications-as-a-windows-service

https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/host-and-deploy/windows-service/samples/3.x/WebAppServiceSample


    dotnet publish -o c:\code\workerpub
    sc create workertest binPath=c:\code\workerpub\WorkerTest.exe

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEzNTY4MzM3MzBdfQ==
-->