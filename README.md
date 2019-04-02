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

### Device configuration

A device instance has to be configured with a common configuration class : 
[DeviceConfiguration](https://github.com/elendil-software/ASCOM.Alpaca.Client/blob/master/src/ASCOM.Alpaca.Client/Configuration/DeviceConfiguration.cs)

### Logger

This library can use any logger that implements the 
[Microsoft.Extensions.Logging.ILogger](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) interface. (The demo project use [serilog](https://serilog.net/))

### Constructors

Each class provides three constructors 

Example with Filter wheel device :

To manually instanciate a device class, use the constructor that take a `DeviceConfiguration` and a `ILogger` instances
```cs
public FilterWheel(DeviceConfiguration configuration, ILogger<DeviceBase> logger = null)
```

The second one is usefull if you want to use the .NET Core 
[Option pattern](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options) 
and [dependency injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
```cs
public FilterWheel(IOptionsSnapshot<DeviceConfiguration> configuration, ILogger<DeviceBase> logger = null)
``` 

The last one can be use if you need to inject specific implementation of each dependency.
This can be usefull if you want to mock an ASCOM behaviour in your own software unit tests
```cs
public FilterWheel(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger<DeviceBase> logger)
```
