$imagename = "generatebarcodeimage"
$runningcontainername = "generatebarcodecontainer"

docker stop $runningcontainername
docker rm $runningcontainername
docker rmi $imagename
docker rmi nuboid/generatebarcodeimage:1.0
