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

		docker container run -it  -p 5000:5000 --name netcoreapiindocker netcoreapiindocker
#docker stop netcoreapiindocker
#docker start netcoreapiindocker
#docker exec -it netcoreapiindocker /bin/bash
#uname -r
#cat /etc/os-release

#docker tag 98 nuboid/netcoreapiindocker:onlydll
#docker push nuboid/netcoreapiindocker:onlydll

# DockerFile
	FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base

	WORKDIR /app
	EXPOSE 80

	ENV ASPNETCORE_URLS http://+:5000

	COPY . .
	ENTRYPOINT ["dotnet", "NetCoreAPIinDocker.dll"]

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE2MzA4NjcwMjIsLTM5MDIzNTU3OF19
-->