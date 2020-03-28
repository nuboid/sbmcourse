Start
[https://docs.microsoft.com/en-us/dotnet/core/docker/build-container](https://docs.microsoft.com/en-us/dotnet/core/docker/build-container)

## Docker Commands

    docker ps
    docker run
    docker stop

https://docs.docker.com/engine/reference/commandline/docker/

[https://www.docker.com/sites/default/files/d8/2019-09/docker-cheat-sheet.pdf](https://www.docker.com/sites/default/files/d8/2019-09/docker-cheat-sheet.pdf)

## Start Clean

	docker stop $(docker ps -a -q)
	docker rm $(docker ps -a -q)
	docker system prune -a -f
	docker images
	#Should be empty
	
## Demo

	#Start Clean		
	docker stop $(docker ps -a -q)
	docker rm $(docker ps -a -q)
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

#### DockerFile
    FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base

    WORKDIR /app

    ENV ASPNETCORE_URLS http://+:5000

    COPY . .
    ENTRYPOINT ["dotnet", "MyResearch.WebApiInDocker.dll"]

## Stop and remove all containers

    docker stop $(docker ps -a -q)
	docker rm $(docker ps -a -q)
	
## Images needed

	docker login
	docker pull consul
	docker pull rabbitmq:3-management
	docker pull nuboid/generatebarcodeimage:1.0
	docker pull mongo
	docker pull redis
	
## Exercises
### Ex. 1

https://labs.play-with-docker.com/

	docker images
	docker ps
	docker ps -a
	docker pull nuboid/generatebarcodeimage:1.0

	docker run -d -p 5001:5001 --name mycontainerinstance1 nuboid/generatebarcodeimage:1.0
	docker run -d -p 5002:5001 --name mycontainerinstance2 nuboid/generatebarcodeimage:1.0

	curl --verbose http://localhost:5001/api/barcode/Lorum
	curl --verbose http://localhost:5002/api/barcode/Ipsum

	docker stop mycontainerinstance1
	docker stop mycontainerinstance2

# Also check out
http://demo.portainer.io/#/containers

## Volumes

    docker exec -it generatebarcodecontainer bash
	docker container run -it -v //c/TMP/TESTDIR:/app/mydata -p 5001:5001 --name $runningcontainername $imagename

    -v //c/TMP/TESTDIR:/app/mydata

## Networks

    docker network ls
    docker network inspect bridge
    docker network create --driver bridge mynetwork
    docker container run -it -p 6379:6379 --name rediscontainer --net mynetwork redis
    docker container run -it -v //c/TMP/TESTDIR:/app/mydata -p 5001:5001 --name $runningcontainername --net mynetwork $imagename
    docker network rm mynetwork
	--net mynetwork
    
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEzNjA0NzE5MTddfQ==
-->