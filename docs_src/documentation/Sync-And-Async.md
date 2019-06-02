# Sync and Async

Every device method is provided in two versions _synchronous_ and _asynchronous_.
For better performance and responsiveness, usage of asynchronous method is recommanded.

The async methods are suffixed by _Async_

Example : 
```csharp
//synchronous method
telescope.SlewToCoordinates(9.9517788, 68.98033);

//asynchronous method
telescope.SlewToCoordinatesAsync(9.9517788, 68.98033);
```

_Note:_ This does not mean the action will be executed asynchronously on the server side, but that the request is sent asynchronously.