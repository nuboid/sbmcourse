# .NET Core

## EF6 vs. EFCore
[https://docs.microsoft.com/en-us/ef/efcore-and-ef6/](https://docs.microsoft.com/en-us/ef/efcore-and-ef6/)

## Self Contained

    <PropertyGroup>
      <TargetFramework>netcoreapp3.1</TargetFramework>
      <PublishTrimmed>true</PublishTrimmed>
    </PropertyGroup>

    dotnet publish -r win-x64 -c release /p:PublishSingleFile=true
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTU1MjY0NDE4MF19
-->