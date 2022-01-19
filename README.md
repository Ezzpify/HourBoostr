<p align="center">
  <img src="https://i.imgur.com/1Py0CWT.png"/>
</p>
 
<p align="center">
  <h2 align="center"><a href="https://github.com/Ni1kko/HourBoostr/releases">DOWNLOAD HERE</a></h2>
</p>

<p align="center">
  <img src="https://img.shields.io/github/release/Ni1kko/HourBoostr.svg?label=Latest"/>
  <img src="https://img.shields.io/github/downloads/Ni1kko/HourBoostr/latest/total.svg?label=Downloads%20for%20latest"/>
  <br/>
  <img src="https://img.shields.io/github/license/Ni1kko/HourBoostr.svg?label=License"/>
</p>

# General information
HourBoostr and SingleBoostr are two applications developed to idle games on your Steam accounts. The two programs work differently - and depending on how you to idle, you may want to pick one over the other. Neither applications require you to have the game you want to boost installed, but you do need to own the game in your library.

## HourBoostr
This program acts like a stand-alone Steam client and will require you to enter your Steam account details. The perks of this application is that you can idle several accounts at once, and you do not need to have Steam installed on the PC you are running it on, which means you can rent a VPS and keep it running for weeks on end. So if you're looking to boost multiple accounts at once on accounts you are not using at the time, this is perfect for you. However, if you are only using one account and you also want to be online and play other games or chat with friends, this will not work very well since you can not be logged in at two locations at the same time. If you want this feature, scroll down and read about SingleBoostr. There is no option to farm trading cards with HourBoostr. If you are looking for this feature then check out SingleBoostr. If you want to farm cards on multiple accounts at once I recommend checking out [Archi Steam Farm](https://github.com/JustArchi/ArchiSteamFarm). You can emualate the OS you want to idle hours on (Steam since 2019 allows tracking playtime on different operating system) you can select between three options 'Windows', 'Linux', 'Mac' you can have each account idle with a diferent emualated OS

Video preview of HourBoostr: 
<p align="center">
  <a href="https://www.youtube.com/watch?v=eqhPBEVMPDM"><img src="https://i.imgur.com/kRr5QhO.png"/></a>
</p>

## SingleBoostr
This program is perfect for you if you only have one account that you want to boost. This program requires you to have Steam installed, however you can be logged into your account and play games and chat with your friends while you are boosting other games with SingleBoostr at the same time. SingleBoostr also offers a great way to farm Trading Cards.

Program preview of SingleBoostr: 

<p align="center">
  <img src="https://i.imgur.com/DJAn1iV.png"/> 
</p>

## Getting started

### Prerequisites
Microsoft Visual Studio 2022 17.0 (or newer), <a href="https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48">.net framework 4.8</a> and Windows SDK 11.0.x.x are required in order to compile HourBoostr. If you don't have Visual Studio, you can download it <a href="https://visualstudio.microsoft.com/vs/">here</a> (Windows SDK is installed during Visual Studio Setup)

### Downloading
There are two options of downloading the source code:

#### Without [git](https://git-scm.com)
Choose this option if you want pure source and you're not going to contribute to the repo. Download size ~600 kB.
To download source code this way [click here](https://github.com/Ni1kko/HourBoostr/archive/master.zip).

#### With [git](https://git-scm.com)
Choose this option if you're going to contribute to the repo or you want to use version control system. Download size ~4 MB. Git is required to step further, if not installed download it [here](https://git-scm.com).

Open git command prompt and enter following command:

    git clone --depth=1 https://github.com/Ni1kko/HourBoostr.git

`HourBoostr` folder should have been successfully created, containing all the source files.

### Compiling source
When you have equipped a copy of the source code, next step is opening **HourBooster.sln** in Microsoft Visual Studio 2022.
Then change build configuration to `Release | x86` and simply press **Build solution**.
If everything went right you should receive `HourBooster.exe` executable file.

### Compiling installer
When you have `HourBooster.exe`, next step is opening **HourBoostr.iss** with [innosetup](https://jrsoftware.org/isinfo.php).
Then simply press **CTRL + F9 (Build Script)**.
If everything went right you should receive `HourBooster_Setup.exe` executable file.

## License
> Copyright (c) 2015-2022 [Ezzpify](https://github.com/Ezzpify), [Ni1kko](https://github.com/Ni1kko) & [Spodini](https://github.com/Spodini)
This project is licensed under the [GNU License](https://opensource.org/licenses/gnu-license.php) - see the [LICENSE](https://github.com/Ni1kko/HourBoostr/blob/master/LICENSE) file for details.
