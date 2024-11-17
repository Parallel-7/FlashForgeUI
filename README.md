# FlashForgeUI
Monitoring &amp; Control software for FlashForge printers in C#, powered by [this](https://github.com/CopeTypes/ff-5mp-api) API

# Read Me
This software is currently undergoing a rewrite/cleanup and will be published soon. All features shown are working/implemented at this time and planned to be included.


## Features
-  Webcam preview / Job Name / Progress (%)
-  Display current nozzle size/filament type (filament type is not sent by firmware until a job is started)
-  Job info panel (Current layer, ETA, job run time, weight used, length used)
-  Model preview panel
-  Temperature panel (Current bed/extruder temp, set/clear them)
-  Fan(s) panel (Current speed, set/clear them)
-  Printer status panel (Status, total run time, total filament used)
-  Filtration status panel (Current filtration mode, TVOC level, toggle internal/external filtration/off)
-  Adjust current speed offset/z-axis offset

- Additional controls
   - Home axes (not present in any FlashForge software for some reason..)
   - Send custom G/MCode 
   - Control built-in LEDs
   - Pause/Resume/Stop current job
   - Upload new job (.gcode or .3mf) or start a local job (from printer storage)
   - Filament swap routine (WIP)

## Additional Features
-  WebUI with the same controls/information
-  Discord notifications
    - Periodic status updates (job info + webcam capture)
    - Notify on print completion (and when job is ready for removal)
    - Notify on status changes

## Web UI
![image](https://github.com/user-attachments/assets/9c2efc93-c0e9-4857-a8e6-b2100f73a6d0)
![image](https://github.com/user-attachments/assets/31e6a0f3-4210-4159-90ea-b340e88f95b5)
## WinForms UI
![image](https://github.com/user-attachments/assets/9c22c61a-8971-4335-92e7-629e1ccb5484)
## Discord Notifications
![image](https://github.com/user-attachments/assets/afab2969-9f28-4cc7-b79f-bccdc7821c81)
