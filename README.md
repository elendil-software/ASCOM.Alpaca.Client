# ASCOM Alpaca Client Toolkit

This library provides methods that simplify the integration of 
[ASCOM Alpaca](https://ascom-standards.org/Developer/Alpaca.htm) in .NET Core / .NET Standard Software

**Important**
This project is under development and should not be use in production.

## Installation

This library will be available as a NuGet package when the developement will be completed. 

## How to use it

A class (most are in developement) for each ASCOM device type is provided :

- Switch
- SafetyMonitor
- Dome
- Camera
- ObservingConditions
- FilterWheel,
- Focuser
- Rotator
- Telescope

### Dependencies

To work a device require some dependencies that have to be passed to the class constructor

#### Device configuration

A device instance has to be configured with a common configuration class : 
[DeviceConfiguration](https://github.com/elendil-software/ASCOM.Alpaca.Client/blob/master/src/ASCOM.Alpaca.Client/Configuration/DeviceConfiguration.cs)

#### Client Transaction ID Generator

//TODO

#### Command sender

//TODO
