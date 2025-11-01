# ADBRemoteX

A lightweight Windows application for controlling Android TVs via ADB over Wi-Fi. No command-line required.

<img width="1280" height="320" alt="Banner" src="https://github.com/user-attachments/assets/5c5a72b1-f823-4602-97d2-ae3731432ed1" />

## Overview

ADBRemoteX provides a simple graphical interface for controlling your Android TV using the Android Debug Bridge (ADB). Instead of typing terminal commands, you can control your TV with clickable buttons.

## Features

- **Navigation Controls**: Up, Down, Left, Right, Enter, and Back buttons
- **Media Controls**: Volume Up and Volume Down
- **Network Connection**: Connect to Android TV via IP address
- **Persistent Settings**: Automatically remembers your last connected IP
- **Portable**: Single executable with no installation required
- **Open Source**: Built in C# (.NET) with accessible source code

## How It Works

ADBRemoteX acts as a user-friendly interface for ADB commands. Each button press executes an ADB command in the background:

```bash
adb connect 192.168.x.xxx:5555
adb shell input keyevent 19  # Move Up
adb shell input keyevent 66  # Press Enter
adb shell input keyevent 24  # Volume Up
```

## Setup Instructions

### Prerequisites

Before using ADBRemoteX, you need to enable ADB on your Android TV:

1. Navigate to **Settings** > **Device Preferences** > **About**
2. Tap **Build number** 7 times to unlock Developer Options
3. Go to **Developer Options** and enable **Network debugging**
4. Note your TV's IP address from **Settings** > **Network** (e.g., 192.168.1.105)

### Running the Application

1. Download the .exe file by pressing "Code", then "Download Zip" and unzip the file
2. Ensure `adb.exe` is in the same directory as the application
3. Launch `ADBRemoteX.exe`
4. Enter your TV's IP address and click **Connect**

## Technical Details

- **Language**: C# (.NET Framework)
- **UI Framework**: Windows Forms
- **Backend**: Android Debug Bridge (ADB)
- **Platform**: Windows 11

## Contributing

Contributions are welcome. If you have suggestions for improvements or new features feel free to do them or fork this idrc tbh.


## Acknowledgments

Created by Yacine <3

If you find this project useful, consider starring the repository.

---

**Note**: This application requires ADB to be installed and accessible. ADB is part of the Android SDK Platform-Tools and can be downloaded from the [official Android developer website](https://developer.android.com/studio/releases/platform-tools).
