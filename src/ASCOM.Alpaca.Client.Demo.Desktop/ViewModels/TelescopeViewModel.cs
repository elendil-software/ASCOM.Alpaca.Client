using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ES.AscomAlpaca.Client.Demo.Desktop.Factories;
using ES.AscomAlpaca.Client.Devices;
using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Client.Demo.Desktop.ViewModels
{
    public class TelescopeViewModel : DeviceViewModelBase
    {
        private Telescope _telescope;
        private bool _canMoveAxis;
        private bool _canFindHome;
        private bool _canPark;
        private bool _canPulseGuide;
        private bool _canSetDeclinationRate;
        private bool _canSetGuideRates;
        private bool _canSetPark;
        private bool _canSetPierSide;
        private bool _canSetRightAscensionRate;
        private bool _canSetTracking;
        private bool _canSlew;
        private bool _canSlewAltAz;
        private bool _canSync;
        private bool _canSyncAltAz;
        private bool _atHome;
        private bool _atPark;
        private bool _isTracking;
        private double _moveRate = 2.0;
        private bool _isSlewing;
        private double _declination;
        private double _rightAscension;
        private double _azimuth;
        private double _altitude;
        private int _duration = 1000;

        public TelescopeViewModel(IDeviceFactory deviceFactory) : base(deviceFactory)
        {
        }

        public bool CanMoveAxis
        {
            get => _canMoveAxis;
            set
            {
                _canMoveAxis = value;
                NotifyOfPropertyChange(() => CanMoveAxis);
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

        public bool CanPulseGuide
        {
            get => _canPulseGuide;
            set
            {
                _canPulseGuide = value;
                NotifyOfPropertyChange(() => CanPulseGuide);
            }
        }

        public bool CanSetDeclinationRate
        {
            get => _canSetDeclinationRate;
            set
            {
                _canSetDeclinationRate = value;
                NotifyOfPropertyChange(() => CanSetDeclinationRate);
            }
        }

        public bool CanSetGuideRates
        {
            get => _canSetGuideRates;
            set
            {
                _canSetGuideRates = value;
                NotifyOfPropertyChange(() => CanSetGuideRates);
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

        public bool CanSetPierSide
        {
            get => _canSetPierSide;
            set
            {
                _canSetPierSide = value;
                NotifyOfPropertyChange(() => CanSetPierSide);
            }
        }

        public bool CanSetRightAscensionRate
        {
            get => _canSetRightAscensionRate;
            set
            {
                _canSetRightAscensionRate = value;
                NotifyOfPropertyChange(() => CanSetRightAscensionRate);
            }
        }

        public bool CanSetTracking
        {
            get => _canSetTracking;
            set
            {
                _canSetTracking = value;
                NotifyOfPropertyChange(() => CanSetTracking);
            }
        }

        public bool CanSlew
        {
            get => _canSlew;
            set
            {
                _canSlew = value;
                NotifyOfPropertyChange(() => CanSlew);
            }
        }

        public bool CanSlewAltAz
        {
            get => _canSlewAltAz;
            set
            {
                _canSlewAltAz = value;
                NotifyOfPropertyChange(() => CanSlewAltAz);
            }
        }

        public bool CanSync
        {
            get => _canSync;
            set
            {
                _canSync = value;
                NotifyOfPropertyChange(() => CanSync);
            }
        }

        public bool CanSyncAltAz
        {
            get => _canSyncAltAz;
            set
            {
                _canSyncAltAz = value;
                NotifyOfPropertyChange(() => CanSyncAltAz);
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

        public bool IsTracking
        {
            get => _isTracking;
            set
            {
                _isTracking = value;
                NotifyOfPropertyChange(() => IsTracking);
            }
        }
        
        public bool IsSlewing
        {
            get => _isSlewing;
            set
            {
                _isSlewing = value;
                NotifyOfPropertyChange(() => IsSlewing);
            }
        }

        public double Declination
        {
            get => _declination;
            set
            {
                _declination = value;
                NotifyOfPropertyChange(() => Declination);
            }
        }

        public double RightAscension
        {
            get => _rightAscension;
            set
            {
                _rightAscension = value;
                NotifyOfPropertyChange(() => RightAscension);
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

        public double Altitude
        {
            get => _altitude;
            set
            {
                _altitude = value;
                NotifyOfPropertyChange(() => Altitude);
            }
        }

        public double MoveRate
        {
            get => _moveRate;
            set
            {
                _moveRate = value;
                NotifyOfPropertyChange(() => MoveRate);
            }
        }

        public int Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                NotifyOfPropertyChange(() => Duration);
            }
        }

        public async Task Connect()
        {
            _telescope = DeviceFactory.CreateDeviceInstance<Telescope>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, Host = Host,
                Port = Port
            });

            try
            {
                await _telescope.SetConnectedAsync(true);
                await LoadDriverData();
                IsConnected = true;
                StartPoolTask();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartPoolTask()
        {
            Task.Run(() =>
            {
                do
                {
                    RefreshMountPosition().Wait();
                    Thread.Sleep(1000);
                } while (IsConnected);
            });
        }

        private async Task LoadDriverData()
        {
            DriverName = await _telescope.GetNameAsync();
            Description = await _telescope.GetDescriptionAsync();
            DriverInfo = await _telescope.GetDriverInfoAsync();
            DriverVersion = await _telescope.GetDriverVersionAsync();
            CanFindHome = await _telescope.CanFindHomeAsync();
            CanPark = await _telescope.CanParkAsync();
            CanSetPark = await _telescope.CanSetParkAsync();
            CanSetPierSide = await _telescope.CanSetPierSideAsync();
            CanSetGuideRates = await _telescope.CanSetGuideRatesAsync();
            CanPulseGuide = await _telescope.CanPulseGuideAsync();
            CanSetRightAscensionRate = await _telescope.CanSetRightAscensionRateAsync();
            CanSetDeclinationRate = await _telescope.CanSetDeclinationRateAsync();
            CanSetTracking = await _telescope.CanSetTrackingAsync();
            CanMoveAxis = await _telescope.CanMoveAxisAsync(TelescopeAxis.Primary);
            CanSlew = await _telescope.CanSlewAsync();
            CanSlewAltAz = await _telescope.CanSlewAltAzAsync();
            CanSync = await _telescope.CanSyncAsync();
            CanSyncAltAz = await _telescope.CanSyncAltAzAsync();

            await RefreshMountStatus();
        }
        
        public async Task FindHome()
        {
            await _telescope.FindHomeAsync();
            await RefreshMountStatus();
        }
        
        public async Task Park()
        {
            await _telescope.ParkAsync();
            await RefreshMountStatus();
        }

        public bool CanUnpark => CanPark && AtPark;
        
        public async Task Unpark()
        {
            await _telescope.UnparkAsync();
            await RefreshMountStatus();
        }

        public async Task SetPark()
        {
            await _telescope.SetParkAsync();
        }

        public bool CanStartTracking => CanSetTracking && !IsTracking;
        
        public async Task StartTracking()
        {
            await _telescope.SetTrackingAsync(true);
            await RefreshMountStatus();
        }
        
        public bool CanStopTracking => CanSetTracking && IsTracking;
        
        public async Task StopTracking()
        {
            await _telescope.SetTrackingAsync(false);
            await RefreshMountStatus();
        }

        public bool CanMoveNorth => CanMoveAxis;

        public async Task MoveNorth()
        {
            await _telescope.MoveAxisAsync(TelescopeAxis.Secondary, MoveRate);
            await RefreshMountStatus();
        }
        
        public bool CanMoveSouth => CanMoveAxis;

        public async Task MoveSouth()
        {
            await _telescope.MoveAxisAsync(TelescopeAxis.Secondary, -MoveRate);
            await RefreshMountStatus();
        }
        
        public bool CanMoveEast => CanMoveAxis;

        public async Task MoveEast()
        {
            await _telescope.MoveAxisAsync(TelescopeAxis.Primary, MoveRate);
            await RefreshMountStatus();
        }
        
        public bool CanMoveWest => CanMoveAxis;

        public async Task MoveWest()
        {
            await _telescope.MoveAxisAsync(TelescopeAxis.Primary, -MoveRate);
            await RefreshMountStatus();
        }

        public bool CanStopMove => IsSlewing;
        
        public async Task StopMove()
        {
            await _telescope.AbortSlewAsync();
            await RefreshMountStatus();
        }
        
        public bool CanGuideNorth => CanPulseGuide;

        public async Task GuideNorth()
        {
            await _telescope.PulseGuideAsync(GuideDirection.North, Duration);
            await RefreshMountStatus();
        }
        
        public bool CanGuideSouth => CanPulseGuide;

        public async Task GuideSouth()
        {
            await _telescope.PulseGuideAsync(GuideDirection.South, Duration);
            await RefreshMountStatus();
        }
        
        public bool CanGuideEast => CanPulseGuide;

        public async Task GuideEast()
        {
            await _telescope.PulseGuideAsync(GuideDirection.East, Duration);
            await RefreshMountStatus();
        }
        
        public bool CanGuideWest => CanPulseGuide;

        public async Task GuideWest()
        {
            await _telescope.PulseGuideAsync(GuideDirection.West, Duration);
            await RefreshMountStatus();
        }
        
        private async Task RefreshMountStatus()
        {
            AtPark = await _telescope.IsAtParkAsync();
            AtHome = await _telescope.IsAtHomeAsync();
            NotifyOfPropertyChange(() => CanUnpark);
            
            IsTracking = await _telescope.IsTrackingAsync();
            NotifyOfPropertyChange(() => CanStartTracking);
            NotifyOfPropertyChange(() => CanStopTracking);

            IsSlewing = await _telescope.IsSlewingAsync();
            
            NotifyOfPropertyChange(() => CanStopMove);
            NotifyOfPropertyChange(() => CanMoveEast);
            NotifyOfPropertyChange(() => CanMoveWest);
            NotifyOfPropertyChange(() => CanMoveNorth);
            NotifyOfPropertyChange(() => CanMoveSouth);
            NotifyOfPropertyChange(() => CanGuideNorth);
            NotifyOfPropertyChange(() => CanGuideSouth);
            NotifyOfPropertyChange(() => CanGuideEast);
            NotifyOfPropertyChange(() => CanGuideWest);
        }

        private async Task RefreshMountPosition()
        {
            RightAscension = await _telescope.GetRightAscensionAsync();
            Declination = await _telescope.GetDeclinationAsync();
            Azimuth = await _telescope.GetAzimuthAsync();
            Altitude = await _telescope.GetAltitudeAsync();
        }
    }
}