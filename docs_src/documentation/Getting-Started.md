## Installing from NuGet

**TODO : Define package name**

The package is [...](http://nuget.org/packages/...). 
The supported platforms are .NET 4.7.2+, .NET Standard 2.0 and .NET Core

```
PM> Install-Package ...
```

## Basic Usage

```csharp
using AscomAlpacaClient.Devices;

var configuration = new DeviceConfiguration
{
    Protocol = "http://",
    Host = "127.0.0.1",
    Port = 11111,
    ApiVersion = "v1",
    DeviceNumber = 0
};

ITelescope telescope = new Telescope(configuration);

await telescope.SlewToCoordinatesAsync(9.9517788, 68.98033);
```