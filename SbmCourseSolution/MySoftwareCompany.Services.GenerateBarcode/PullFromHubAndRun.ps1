$imagename = "nuboid/generatebarcodeimage:1.0"
$runningcontainername = "generatebarcodecontainer"

docker container stop $runningcontainername
docker rm $runningcontainername
docker rmi $imagename -f
docker pull $imagename
docker container run -it  -p 5001:5001 --name $runningcontainername $imagename