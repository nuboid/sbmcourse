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
	
	dotnet publish "MyProject.csproj" -c Release -o /app/publish
	cd app/publish
	
	#copy dockerfile (below) to here	
	docker build -t mydockerimage -f .\DockerFile .

	docker container run -it  -p 5000:5000 --name myrunningcontainer mydockerimage

	docker stop myrunningcontainer 
	docker start myrunningcontainer 
		
	docker tag mydockerimage nuboid/mydockerimage:1.0
	docker logout
	docker login
	docker push nuboid/mydockerimage:1.0

	docker pull nuboid/mydockerimage:1.0
	docker container run -it  -p 5000:5000 --name myrunningcontainer nuboid/mydockerimage:1.0

    http://localhost:5000/weatherforecast
    
    docker rmi nuboid/mydockerimage:1.1

# DockerFile
    FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base

    WORKDIR /app
    EXPOSE 443

    ENV ASPNETCORE_URLS https://+:5000

    COPY . .
    ENTRYPOINT ["dotnet", "MyResearch.WebApiInDocker.dll"]

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE2MzAzODA2MTcsMTAzNjU4NDY2XX0=
-->