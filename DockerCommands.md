## Docker Commands

    docker ps
    docker run
    docker stop

https://docs.docker.com/engine/reference/commandline/docker/


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
		#dotnet publish "MyProject.csproj" -c Release -o /app/publish

		#copy files to same directory as dockerfile
		#powershell to directory with dockerfile
		docker build -t mydockerimage -f .\DockerFile .

		docker container run -it  -p 5000:5000 --name myrunningcontainer mydockerimage

		docker stop myrunningcontainer 
		docker start myrunningcontainer 
		docker exec -it myrunningcontainer 
		/bin/bash
		uname -r
		cat /etc/os-release

#docker tag 98 nuboid/netcoreapiindocker:onlydll
#docker push nuboid/netcoreapiindocker:onlydll

# DockerFile
	FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base

	WORKDIR /app
	EXPOSE 80

	ENV ASPNETCORE_URLS http://+:5000

	COPY . .
	ENTRYPOINT ["dotnet", "NetCoreAPIinDocker.dll"]

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE5ODgzNzMyNywxMjc2MzU0MjIzXX0=
-->