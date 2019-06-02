The [ASCOM Alpaca API](https://ascom-standards.org/api/) allows to send two ID with a request _ClientID_ and _ClientTransactionID_. 

> **ClientID** 
>
> Client's unique ID. (0 to 4294967295). The client should choose a value at start-up, e.g. a random value between 0 and 65535, and send this value on every transaction to help associate entries in device logs with this particular client.
> 
> **ClientTransactionID**
> 
> Client's transaction ID. (0 to 4294967295). The client should start this count at 1 and increment by one on each successive transaction. This will aid associating entries in device logs with corresponding entries in client side logs.

They can be usfull to identify a request in the log on the server and/or client side.

AscomAlpacaClient provides a Client Transaction ID Generator.

```csharp
IClientTransactionIdGenerator clientIdGenerator = new ClientTransactionIdGenerator()
```