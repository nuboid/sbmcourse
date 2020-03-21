$buildpath = "c:\tmp\buildpath3"
$imagename = "myimage001"
$runningcontainername = "myrunningcontainer001"

If(!(test-path $buildpath))
{
     New-Item -ItemType Directory -Force -Path $buildpath
}
else
{
     Remove-Item -LiteralPath $buildpath -Recurse
     New-Item -ItemType Directory -Force -Path $buildpath
}

dotnet publish  -c Release -o $buildpath

Copy-Item -Path DockerfileToDeploy -Destination $buildpath\Dockerfile

docker stop $runningcontainername
docker rm $runningcontainername
docker rmi $imagename

docker build -t $imagename -f $buildpath\Dockerfile $buildpath

Remove-Item -LiteralPath $buildpath -Recurse

docker container run -it  -p 5000:5000 --name $runningcontainername $imagename


