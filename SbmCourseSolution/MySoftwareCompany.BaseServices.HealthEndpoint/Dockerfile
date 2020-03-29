#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MySoftwareCompany.BaseServices.HealthEndpoint/MySoftwareCompany.BaseServices.HealthEndpoint.csproj", "MySoftwareCompany.BaseServices.HealthEndpoint/"]
RUN dotnet restore "MySoftwareCompany.BaseServices.HealthEndpoint/MySoftwareCompany.BaseServices.HealthEndpoint.csproj"
COPY . .
WORKDIR "/src/MySoftwareCompany.BaseServices.HealthEndpoint"
RUN dotnet build "MySoftwareCompany.BaseServices.HealthEndpoint.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MySoftwareCompany.BaseServices.HealthEndpoint.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MySoftwareCompany.BaseServices.HealthEndpoint.dll"]