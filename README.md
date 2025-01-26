# FlashForgeUI
*WIP* Monitoring &amp; Control software for FlashForge printers, powered by [this](https://github.com/GhostTypes/ff-5mp-api) API

![GitHub last commit](https://img.shields.io/github/last-commit/Parallel-7/FlashForgeUI)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/Parallel-7/FlashForgeUI)
![GitHub language count](https://img.shields.io/github/languages/count/Parallel-7/FlashForgeUI)

![image](https://github.com/user-attachments/assets/6c7298f7-7e8f-45d0-b92b-210a944407ca)
![image](https://github.com/user-attachments/assets/ab6d4007-a5ee-4344-a403-3a22f3fb3c21)
![image](https://github.com/user-attachments/assets/97f5e9b0-004c-41ff-99d9-86570c5572e4)
![image](https://github.com/user-attachments/assets/4970d19d-c640-46fe-b3b6-c673b811ed6a)


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
   - Pause/Resume/Stop current job & clear cancelled/completed job state
   - Upload new job (.gcode or .3mf) or start a local job (from printer storage)
   - Filament swap routine (WIP)

## Additional Features
-  WebUI with the same controls/information
-  Discord notifications
    - Periodic status updates (job info + webcam capture)
    - Notify on print completion (and when job is ready for removal)
    - Notify on status changes
   
# Compatibility
- Full support for the 5M (Pro) [FW 2.7.8 - 3.1.3]
- Support for any FlashForge printer with wifi capability is possible


<a href="https://star-history.com/#Parallel-7/FlashForgeUI&Date">
 <picture>
   <source media="(prefers-color-scheme: dark)" srcset="https://api.star-history.com/svg?repos=Parallel-7/FlashForgeUI&type=Date&theme=dark" />
   <source media="(prefers-color-scheme: light)" srcset="https://api.star-history.com/svg?repos=Parallel-7/FlashForgeUI&type=Date" />
   <img alt="Star History Chart" src="https://api.star-history.com/svg?repos=Parallel-7/FlashForgeUI&type=Date" />
 </picture>
</a>
