The object _DeviceConfiguration_ hold all necessary parameters to communicate with an ASCOM Alpaca device.
An instance of this class is required by any device class.

| Parameter    | Default value | Required |
| ------------ | ------------- | -------- |
| Protocol     | http://       | yes      |
| Host         | 127.0.0.1     | yes      |
| Port         | 11111         | yes      |
| ApiVersion   | v1            | yes      |
| DeviceNumber | 0             | yes      |
| ClientId     | -1 (Not set)  | no       |
| LongTimeout  | 120           | yes      |