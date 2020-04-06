#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MyResearch.GraphQL.Server/MyResearch.GraphQL.Server.csproj", "MyResearch.GraphQL.Server/"]
RUN dotnet restore "MyResearch.GraphQL.Server/MyResearch.GraphQL.Server.csproj"
COPY . .
WORKDIR "/src/MyResearch.GraphQL.Server"
RUN dotnet build "MyResearch.GraphQL.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyResearch.GraphQL.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyResearch.GraphQL.Server.dll"]