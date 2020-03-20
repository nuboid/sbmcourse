#Start Clean		
docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)
docker rmi $(docker images -q)
docker system prune -a
docker ps
docker ps -a

#Show Images
docker images

#command prompt to directory with .csproj

dotnet publish "MyProject.csproj" -c Release -o /app/publish
cd app/publish

#copy dockerfile (below) to here	
docker build -t mydockerimage -f .\DockerFile .

docker container run -it  -p 5000:5000 --name myrunningcontainer mydockerimage

docker stop myrunningcontainer 
docker start myrunningcontainer 
	
docker tag mydockerimage nuboid/mydockerimage:1.0
docker login -u nuboid
docker push nuboid/mydockerimage:1.0


FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base

WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS http://+:5000

COPY . .
ENTRYPOINT ["dotnet", "MyResearch.WebAPIInDocker.dll"]


