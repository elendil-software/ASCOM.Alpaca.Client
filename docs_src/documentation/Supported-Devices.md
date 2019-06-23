Ascom Alpaca Client supports all ASCOM Alpaca devices.

For each ASCOM Alpaca device two interfaces and a class have been defined

| Sync interface       | Async interface             | Class               |
| -------------------- | --------------------------- | ------------------- |
| ICamera              | ICameraAsync                | Camera              |
| IDome                | IDomeAsync                  | Dome                |
| IFilterWheel         | IFilterWheelAsync           | FilterWheel         |
| IFocuser             | IFocuserAsync               | Focuser             |
| IObservingConditions | IObservingConditionsAsync   | ObservingConditions |
| IRotator             | IRotatorAsync               | Rotator             |
| ISwitch              | ISwitchAsync                | Switch              |
| ISafetyMonitor       | ISafetyMonitorAsync         | SafetyMonitor       |
| ITelescope           | ITelescopeAsync             | Telescope           |
