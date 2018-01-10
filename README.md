# EPL Standing Widget

Please credit the original designer of this project if you're using this design and project. Thanks

Visit my Behance profile for more UI designs: [Ankit Passi on Behance](https://www.behance.net/passiankitd8a0)

[![N|Solid](https://github.com/ankitpassi141/EPL-Standing-Widget/blob/master/Release/EPL%20Widget%20Logo.png?raw=false)](https://github.com/ankitpassi141/EPL-Standing-Widget)

* [Introduction](#1---introduction)
* [Assets](#2---assets)
* [Project Usage](#3---project-usage)
* [Running The Project](#4---running-the-project)
* [Project Issues](#5---project-issues)
* [Additional Resources](#6---additional-resources)

## 1.   Introduction

This is a basic Xamarin Android Widget which displays the RealTime Barclays Premier League Standing. User has to add widget to the screen and Click on "update" button to update and display the data. (Usage GIF below)

Design is simplistic and clean enough to display all the required Information on the go.


## 2.   Assets

All the XML files, Icons and Background Image is created from Scratch in Photoshop.
9-Patch Images are generated using [Android Asset Studio](https://romannurik.github.io/AndroidAssetStudio/index.html)

Data for EPL Standing is fetched from Custom API hosted on Heliohost.


## 3.   Project Usage

1. Add the Widget on Screen.
2. Click the "Update" button and wait for sometime it to fetch the data and update and display it.


![Usage GIF](https://github.com/ankitpassi141/EPL-Standing-Widget/blob/master/Release/How%20to%20initalise%20Widget.gif)


## 4.   Running the Project

Clone the repository and open the "FootballUpdateWidget.sln" to open the project in Visual Studio. Let it download all the packages required by project which is not a lot, just AppCompat libraries.

If for some reason Project failed to "build" , then Open Nuget Package Manager in Visual Studio and Install all the visible packages.
Then, "Clean" the project and then try to "Build".

PS: Try to keep path of Project as small as possible, because Xamarin File Path size limitations for "Building" Project.


## 5.   Project Issues

1. Sometimes API is down, thus stop updating the data on widget. Just try updating the widget or wait for sometime.
2. Application is still in experimental stage. Thus Major UI and Code changes is expected.


## 6.   Future Resources

1. Final APK release for public usage. (I still have to learn how to make Release APK.)
2. Additional of More Football Leagues such as: La Liga, Ligue 1 and UEFA Champions League Standings.
3. Different Widget UI for each League.
4. RealTime data updates from APIs.


## 7.   Additional Resources

EPL Standings can be checked on: [EPL Standing](https://www.google.com/search?q=epl+standing&rlz=1C1CHBF_enIN770IN770&oq=epl+standing+&aqs=chrome..69i57j69i60l3j0l2.3304j0j7&sourceid=chrome&ie=UTF-8#sie=lg;/g/11c74zg7g7;2;/m/02_tc;st;fp;1)
