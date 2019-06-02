## Basic

This is the the example shown on the [Getting Started]((https://github.com/elendil-software/ASCOM.Alpaca.Client/wiki/Getting-Started#basic-usage)) page. This is the simplest way to use a device client.

```csharp
var configuration = new DeviceConfiguration
{
    Protocol = "http://",
    Host = "127.0.0.1",
    Port = 11111,
    ApiVersion = "v1",
    DeviceNumber = 0
};

ITelescope telescope = new Telescope(configuration);
```

More simple, if the device parameters match the default configuration

```csharp
var configuration = new DeviceConfiguration();
ITelescope telescope = new Telescope(configuration);
```

## Add a logger

A logger is only necessary if you want to log the raw responses coming from a device.

The constructor accept logger that implements `ASCOMAlpacaClient.Logging.ILogger`. For conveniency, adapters for common logger are provided in additional NuGet packages. Currently NLog and Serilog are available. Feel free to open an issue or a Pull Request if you need implementation for other logger

```csharp
var serilogLogger = new LoggerConfiguration().CreateLogger();
ASCOMAlpacaClient.Logging.ILogger logger = new SerilogAdapter(serilogLogger);

telescope = new Telescope(configuration, logger);
```

## Put the ClientID and ClientTransactionID in the requests

To put the ClientID and ClientTransactionID in the request, the `ClientId` has to be set in the configuration object and a `ClientTransactionIdGenerator` has to be passed to the device constructor. ClientTransactionIdGenerator instance should be unique (same instance used for each device) unless each device has his own ClientId

```csharp
var configuration = new DeviceConfiguration
{
    Protocol = "http://",
    Host = "127.0.0.1",
    Port = 11111,
    ApiVersion = "v1",
    DeviceNumber = 0,
    ClientId = 1
};

IClientTransactionIdGenerator clientTransactionIdGenerator = new ClientTransactionIdGenerator();

telescope = new Telescope(configuration, clientTransactionIdGenerator);
```

## Combine ClientTransactionIdGenerator and Logger

The most complete constructor allows using a ClientTransactionIdGenerator and a Logger

```csharp
var configuration = new DeviceConfiguration
{
    Protocol = "http://",
    Host = "127.0.0.1",
    Port = 11111,
    ApiVersion = "v1",
    DeviceNumber = 0,
    ClientId = 1
};

IClientTransactionIdGenerator clientTransactionIdGenerator = new ClientTransactionIdGenerator();

var serilogLogger = new LoggerConfiguration().CreateLogger();
ASCOMAlpacaClient.Logging.ILogger logger = new SerilogAdapter(serilogLogger);

telescope = new Telescope(configuration, clientTransactionIdGenerator, logger);
```