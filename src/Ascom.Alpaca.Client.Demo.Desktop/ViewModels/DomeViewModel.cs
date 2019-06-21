using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ES.Ascom.Alpaca.Client.Demo.Desktop.Factories;
using ES.Ascom.Alpaca.Client.Devices;
using ES.Ascom.Alpaca.Devices;

namespace ES.Ascom.Alpaca.Client.Demo.Desktop.ViewModels
{
    public class DomeViewModel : DeviceViewModelBase
    {
        private Dome _dome;
        
        private double _altitude;
        private bool _atHome;
        private bool _atPark;
        private double _azimuth;
        private bool _canFindHome;
        private bool _canPark;
        private bool _canSetAltitude;
        private bool _canSetAzimuth;
        private bool _canSetPark;
        private bool _canSetShutter;
        private bool _canSlave;
        private bool _canSyncAzimuth;
        private ShutterState _shutterStatus;
        private bool _isSlaved;
        private bool _isSlewing;
        private double _targetAltitude;
        private double _targetAzimuth;

        public DomeViewModel(IDeviceFactory deviceFactory) : base(deviceFactory)
        {

        }

        public double Altitude
        {
            get => _altitude;
            set
            {
                _altitude = value;
                NotifyOfPropertyChange(() => Altitude);
            }
        }

        public bool AtHome
        {
            get => _atHome;
            set
            {
                _atHome = value;
                NotifyOfPropertyChange(() => AtHome);
            }
        }

        public bool AtPark
        {
            get => _atPark;
            set
            {
                _atPark = value;
                NotifyOfPropertyChange(() => AtPark);
            }
        }

        public double Azimuth
        {
            get => _azimuth;
            set
            {
                _azimuth = value;
                NotifyOfPropertyChange(() => Azimuth);
            }
        }

        public bool CanFindHome
        {
            get => _canFindHome;
            set
            {
                _canFindHome = value;
                NotifyOfPropertyChange(() => CanFindHome);
            }
        }

        public bool CanPark
        {
            get => _canPark;
            set
            {
                _canPark = value;
                NotifyOfPropertyChange(() => CanPark);
            }
        }

        public bool CanSetAltitude
        {
            get => _canSetAltitude;
            set
            {
                _canSetAltitude = value;
                NotifyOfPropertyChange(() => CanSetAltitude);
            }
        }

        public bool CanSetAzimuth
        {
            get => _canSetAzimuth;
            set
            {
                _canSetAzimuth = value;
                NotifyOfPropertyChange(() => CanSetAzimuth);
            }
        }

        public bool CanSetPark
        {
            get => _canSetPark;
            set
            {
                _canSetPark = value;
                NotifyOfPropertyChange(() => CanSetPark);
            }
        }

        public bool CanSetShutter
        {
            get => _canSetShutter;
            set
            {
                _canSetShutter = value;
                NotifyOfPropertyChange(() => CanSetShutter);
            }
        }

        public bool CanSlave
        {
            get => _canSlave;
            set
            {
                _canSlave = value;
                NotifyOfPropertyChange(() => CanSlave);
            }
        }

        public bool CanSyncAzimuth
        {
            get => _canSyncAzimuth;
            set
            {
                _canSyncAzimuth = value;
                NotifyOfPropertyChange(() => CanSyncAzimuth);
            }
        }

        public ShutterState ShutterStatus
        {
            get => _shutterStatus;
            set
            {
                _shutterStatus = value;
                NotifyOfPropertyChange(() => ShutterStatus);
                NotifyOfPropertyChange(() => CanCloseShutter);
                NotifyOfPropertyChange(() => CanOpenShutter);
            }
        }

        public bool IsSlaved
        {
            get => _isSlaved;
            set
            {
                _isSlaved = value;
                NotifyOfPropertyChange(() => IsSlaved);
            }
        }

        public bool IsSlewing
        {
            get => _isSlewing;
            set
            {
                _isSlewing = value;
                NotifyOfPropertyChange(() => IsSlewing);
                NotifyOfPropertyChange(() => CanAbortSlew);
            }
        }

        public async Task Connect()
        {
            _dome = DeviceFactory.CreateDeviceInstance<Dome>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, Host = Host,
                Port = Port
            });

            try
            {
                await _dome.SetConnectedAsync(true);
                await LoadDriverData();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public double TargetAltitude
        {
            get => _targetAltitude;
            set
            {
                _targetAltitude = value;
                NotifyOfPropertyChange(() => TargetAltitude);
                NotifyOfPropertyChange(() => CanSlewToAltitude);
            }
        }

        public double TargetAzimuth
        {
            get => _targetAzimuth;
            set
            {
                _targetAzimuth = value;
                NotifyOfPropertyChange(() => TargetAzimuth);
                NotifyOfPropertyChange(() => CanSlewToAzimuth);
                NotifyOfPropertyChange(() => CanSyncToAzimuth);
            }
        }

        private async Task LoadDriverData()
        {
            DriverName = await _dome.GetNameAsync();
            Description = await _dome.GetDescriptionAsync();
            DriverInfo = await _dome.GetDriverInfoAsync();
            DriverVersion = await _dome.GetDriverVersionAsync();

            CanFindHome = await _dome.CanFindHomeAsync();
            CanSetShutter = await _dome.CanSetShutterAsync();
            CanPark = await _dome.CanParkAsync();
            CanSetPark = await _dome.CanSetParkAsync();
            
            CanSetAltitude = await _dome.CanSetAltitudeAsync();
            CanSetAzimuth = await _dome.CanSetAzimuthAsync();
            CanSyncAzimuth = await _dome.CanSyncAzimuthAsync();
            CanSlave = await _dome.CanSlaveAsync();

            AtHome = await _dome.IsAtHomeAsync();
            AtPark = await _dome.IsAtParkAsync();
            IsSlaved = await _dome.IsSlavedAsync();
            IsSlewing = await _dome.IsSlewingAsync();

            ShutterStatus = await _dome.GetShutterStatusAsync();

            Azimuth = await _dome.GetAzimuthAsync();

            if (CanSetAltitude && ShutterStatus != ShutterState.Closed)
            {
                Altitude = await _dome.GetAltitudeAsync();
            }

            TargetAltitude = Altitude;
            TargetAzimuth = Azimuth;

            IsConnected = true;
            
            NotifyOfPropertyChange(() => CanAbortSlew);
            NotifyOfPropertyChange(() => CanSlewToAltitude);
            NotifyOfPropertyChange(() => CanSlewToAzimuth);
            NotifyOfPropertyChange(() => CanSyncToAzimuth);
            NotifyOfPropertyChange(() => CanCloseShutter);
            NotifyOfPropertyChange(() => CanOpenShutter);
        }

        private async Task RefreshStatus()
        {
            AtHome = await _dome.IsAtHomeAsync();
            AtPark = await _dome.IsAtParkAsync();
            IsSlaved = await _dome.IsSlavedAsync();
            IsSlewing = await _dome.IsSlewingAsync();

            ShutterStatus = await _dome.GetShutterStatusAsync();
        }
        
        public bool CanAbortSlew => IsConnected && IsSlewing;
        public bool CanSlewToAltitude => IsConnected && CanSetAltitude && TargetAltitude >= 0 && TargetAltitude <= 90;
        public bool CanSlewToAzimuth => IsConnected && CanSetAzimuth && TargetAzimuth >= 0 && TargetAzimuth <= 360;
        public bool CanSyncToAzimuth => IsConnected && CanSyncAzimuth && TargetAzimuth >= 0 && TargetAzimuth <= 360;
        public bool CanCloseShutter => IsConnected && ShutterStatus == ShutterState.Open;
        public bool CanOpenShutter => IsConnected && ShutterStatus == ShutterState.Closed;

        public async Task AbortSlew()
        {
            try
            {
                await _dome.AbortSlewAsync();
                await RefreshStatus();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task CloseShutter()
        {
            try
            {
                await _dome.CloseShutterAsync();
                await Task.Run(() =>
                {
                    do
                    {
                        ShutterStatus = _dome.GetShutterStatus();
                        IsSlewing = _dome.IsSlewing();
                        Thread.Sleep(1000);
                    } while (ShutterStatus != ShutterState.Closed);
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public async Task OpenShutter()
        {
            try
            {
                await _dome.OpenShutterAsync();
                await Task.Run(() =>
                {
                    
                    do
                    {
                        ShutterStatus = _dome.GetShutterStatus();
                        IsSlewing = _dome.IsSlewing();
                        Thread.Sleep(1000);
                    } while (ShutterStatus != ShutterState.Open);
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public async Task FindHome()
        {
            try
            {
                await _dome.FindHomeAsync();
                await Task.Run(() =>
                {
                    do
                    {
                        IsSlewing = _dome.IsSlewing();
                        Azimuth = _dome.GetAzimuth();
                        AtHome = _dome.IsAtHome();
                        Thread.Sleep(1000);
                    } while (IsSlewing);
                });
                
                await RefreshStatus();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public async Task Park()
        {
            try
            {
                await _dome.ParkAsync();
                await Task.Run(() =>
                {
                    do
                    {
                        IsSlewing = _dome.IsSlewing();
                        Azimuth = _dome.GetAzimuth();
                        AtPark = _dome.IsAtPark();
                        Thread.Sleep(1000);
                    } while (IsSlewing);
                });
                
                await RefreshStatus();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public async Task SetPark()
        {
            try
            {
                await _dome.SetParkAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public async Task SlewToAltitude()
        {
            try
            {
                await _dome.SlewToAltitudeAsync(TargetAltitude);
                await Task.Run(() =>
                {
                    do
                    {
                        IsSlewing = _dome.IsSlewing();
                        Altitude = _dome.GetAltitude();
                        Thread.Sleep(1000);
                    } while (IsSlewing);
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public async Task SlewToAzimuth()
        {
            try
            {
                await _dome.SlewToAzimuthAsync(TargetAzimuth);
                await Task.Run(() =>
                {
                    do
                    {
                        IsSlewing = _dome.IsSlewing();
                        Azimuth = _dome.GetAzimuth();
                        Thread.Sleep(1000);
                    } while (IsSlewing);
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public async Task SyncToAzimuth()
        {
            try
            {
                await _dome.SyncToAzimuthAsync(TargetAzimuth);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}