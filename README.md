# ASCOM Alpaca Client Toolkit

This library provides methods that simplify the integration of 
[ASCOM Alpaca](https://ascom-standards.org/Developer/Alpaca.htm) in .NET Core / .NET Standard Software

## Installation

This library will be available as a NuGet package when the developement will be completed. 

## How to use it

A class (most are in developement) for each ASCOM device type is provided :

- ~~Switch~~ (in development),
- ~~SafetyMonitor~~ (in development),
- ~~Dome~~ (in development),
- ~~Camera~~ (in development),
- ~~ObservingConditions~~ (in development),
- FilterWheel,
- ~~Focuser~~ (in development),
- ~~Rotator~~ (in development),
- ~~Telescope~~ (in development)

### Dependencies

To work a device require some dependencies that have to be passed to the class constructor

#### Device configuration

A device instance has to be configured with a common configuration class : 
[DeviceConfiguration](https://github.com/elendil-software/ASCOM.Alpaca.Client/blob/master/src/ASCOM.Alpaca.Client/Configuration/DeviceConfiguration.cs)

#### Client Transaction ID Generator

//TODO

#### Command sender

//TODO

#### Logger

This library can use any logger that implements the 
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) interface. (The demo project use [serilog](https://serilog.net/))