A logger can be passed passed to device implementation to log the raw responses. 
This should be necessary only if you need to log the ClientID and ClientTransactionID.

The devices constructors accept logger that implements `AscomAlpacaClient.Logging.ILogger`. 
For conveniency, adapters for common logger are provided in additional NuGet packages. 
Currently NLog and Serilog are available. Feel free to open an issue or a Pull Request if you need implementation for other logger.

## Logger adapters

* [SerilogAdapter](https://www.nuget.org/packages/AscomAlpacaClient.Logging.SerilogAdapter/)
* [NLogAdapter](https://www.nuget.org/packages/AscomAlpacaClient.Logging.NLogAdapter/)