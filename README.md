# FlashForgeUI ⚠️ DEPRECATED

> **Note**: This project has been superseded by the new Electron-based version at [FlashForgeUI-Electron](https://github.com/Parallel-7/FlashForgeUI-Electron). Please use the new version for better performance and features.

*WIP* Monitoring & Control software for FlashForge printers, powered by [this](https://github.com/GhostTypes/ff-5mp-api) API

![GitHub last commit](https://img.shields.io/github/last-commit/Parallel-7/FlashForgeUI)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/Parallel-7/FlashForgeUI)
![GitHub language count](https://img.shields.io/github/languages/count/Parallel-7/FlashForgeUI)

![image](https://github.com/user-attachments/assets/6c7298f7-7e8f-45d0-b92b-210a944407ca)
![image](https://github.com/user-attachments/assets/ab6d4007-a5ee-4344-a403-3a22f3fb3c21)
![image](https://github.com/user-attachments/assets/97f5e9b0-004c-41ff-99d9-86570c5572e4)
![image](https://github.com/user-attachments/assets/4970d19d-c640-46fe-b3b6-c673b811ed6a)

## 🚀 Setup
1. Enable LAN-only mode in `setting -> wifi -> network mode`
2. Note the pairing code displayed at the bottom left
3. Use this code during initial pairing process
4. Done! The app will auto-connect on future launches

## ✨ Features

### 📊 Main Dashboard
| Feature | Description |
|---------|------------|
| 📷 Webcam Preview | Live feed with job name and progress |
| 🎯 Nozzle Info | Current size and filament type* |
| 📈 Job Statistics | Layer count, ETA, runtime, material usage |
| 🎨 Model Preview | 3D model visualization |

*Filament type is only shown when a job is active

### 🛠️ Control Panels
| Panel | Functions |
|-------|-----------|
| 🌡️ Temperature | Monitor and control bed/extruder temps |
| 💨 Fans | View and adjust fan speeds |
| ℹ️ Printer Status | Monitor runtime and material usage |
| 🌬️ Filtration | Control modes, check TVOC levels |
| ⚙️ Speed & Z-Offset | Adjust printing parameters |

### 🎮 Additional Controls
- 🏠 Home axes functionality
- 💻 Custom G/MCode input
- 💡 LED control
- ⏯️ Job control (pause/resume/stop)
- 📤 Job upload (.gcode/.3mf)
- 🔄 Filament swap routine (WIP)

### 🌐 Extended Features
- 🖥️ WebUI interface
- 🤖 Discord Integration
  - 📊 Status updates with webcam shots
  - ✅ Print completion notifications
  - 🔔 Status change alerts

## 🔧 Compatibility
| Printer | Support Level | Firmware Versions |
|---------|---------------|------------------|
| FlashForge 5M (Pro) | ✅ Full | 2.7.8 - 3.1.5 |
| Other WiFi Models | 🟡 Possible | Varies |


<a href="https://star-history.com/#Parallel-7/FlashForgeUI&Date">
 <picture>
   <source media="(prefers-color-scheme: dark)" srcset="https://api.star-history.com/svg?repos=Parallel-7/FlashForgeUI&type=Date&theme=dark" />
   <source media="(prefers-color-scheme: light)" srcset="https://api.star-history.com/svg?repos=Parallel-7/FlashForgeUI&type=Date" />
   <img alt="Star History Chart" src="https://api.star-history.com/svg?repos=Parallel-7/FlashForgeUI&type=Date" />
 </picture>
</a>
