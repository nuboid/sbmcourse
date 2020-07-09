
# README #

##  Content

- The Mobile YardAssetManagementApp (also known as YAO, Yard Operator App).

   - UWP
   - Android
   - iOS
 
* The API for supporing this App. 
*This is a Backend For Frontend. The API will call controllers in  DAMHost.*

- Some test applications as Winforms, they are here for development/testing purposes and do not make part of the realeases. 

## Development box requirements

* Clone this repo to a directory close to the root of your drive otherwise you could have issues with paths to files exceeded limits.

* Make sure your Visual Studio 2019 has installed the Mobile Workload (containing all Xamarin dependencies). See [https://www.youtube.com/watch?v=zHX0bNNJy-c](https://www.youtube.com/watch?v=zHX0bNNJy-c) for details.

* Everyting to build for Android is included in this workload.

* For building iOS you'll need a Mac paired to you Windows machine and build profiles created through an Apple Developer Account.

* No database dependencies.

* No Docker dependencies.

## Build

Pipeline: [https://behind-the-buttons.visualstudio.com/Peripass/_build/definition?definitionId=63](https://behind-the-buttons.visualstudio.com/Peripass/_build/definition?definitionId=63)

This pipeline builds both Android app and API.

## Deploy to MS Appcenter

Is done by releasepipeline : [https://behind-the-buttons.visualstudio.com/Peripass/_release?definitionId=16&_a=releases&view=mine](https://behind-the-buttons.visualstudio.com/Peripass/_release?definitionId=16&_a=releases&view=mine)
 
<!--stackedit_data:
eyJoaXN0b3J5IjpbNjI1MDg1OTY0LC0xNjExODY3MTQ4XX0=
-->