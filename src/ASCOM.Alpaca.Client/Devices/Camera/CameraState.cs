namespace ASCOM.Alpaca.Client.Devices.Camera
{
    public enum CameraState
    {
        Idle = 0, 
        Waiting = 1, 
        Exposing = 2,
        Reading = 3, 
        Download = 4, 
        Error = 5
    }
}