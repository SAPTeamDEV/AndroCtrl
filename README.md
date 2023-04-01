# AndroCtrl - Take control of your device

## Instruction
Control your device with Beautiful and Amazing tools!

This app uses underlying [SAPTeam.AndroCtrl.Adb](https://github.com/SAPTeamDEV/SAPTeam.AndroCtrl.Adb) library to communicate Directly with `adb server`. This method is very Fast and reliable than communicating with `adb.exe` executable.

Currently AndroCtrl is in Early Access stage and it's features are being developed.

## Installation
You can download latest version of AndroCtrl in Releases section in this page, then extract and run `AndroCtrl.exe`.

The zip file bundled with adb v1.0.41, you can put your own adb binary in `bin` directory and use it.

Note: least supported version of adb is `1.0.41`.

## Features
This feature list may be changed in the process of releasing the final version but currently AndroCtrl has this features:
- Fully-Supports all connection types: USB, ADB WiFi and new Wireless Debugging (Android 11+).
- Supports multi device connection and can manage all of them.
- Device pairing (Android 11+): You can pair your device Easily with QR code scanning or manually enter pair key.
- Device scanning (Android 11+): After pairing your device, AndroCtrl automatically searches for connecting to your device! You don't need to manually connect to your device every time that it disconnects from your computer.
- Manually wireless connect: You can connect to your devices using ADB TCP/IP. AndroCtrl remember your device ip address for easily connect later.
- Root access: AndroCtrl can get root access from your device and use it in all shell commands and extends it's utilities. This app gets root with `su` shell command, NOT `adb root` so you don't face with any troubles with enabling ADB root.
- Manage ADB server: with AndroCtrl you can manage adb server. If you already started an adb server, AndroCtrl identify that process and uses that process for communicating with your device, Even if there is no adb file in the app directory.
- Shell console: You can communicate with your device using shell.
- Automatically monitors adb changes and updates devices data.
(This feature is not available in Debug builds because it can cause Blocks, hangs and Unexpected behavior during Debugging. In normal running it's OK.)

## Contribution
Most features of Application is being developed and Added in the future.
You can speed up the development progress of this application with your contributions.

Feel free to open Issues, grab the source and pull requests.