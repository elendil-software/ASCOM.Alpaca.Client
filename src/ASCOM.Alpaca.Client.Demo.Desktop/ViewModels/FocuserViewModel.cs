using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ES.AscomAlpaca.Client.Demo.Desktop.Factories;
using ES.AscomAlpaca.Client.Devices;

namespace ES.AscomAlpaca.Client.Demo.Desktop.ViewModels
{
    public class FocuserViewModel : DeviceViewModelBase
    {
        private IFocuser _focuser;
        private bool _isAbsolute;
        private bool _isMoving;
        private int _maxIncrement;
        private int _maxStep;
        private int _position;
        private double _stepSize;
        private bool _tempComp;
        private bool _tempCompAvailable;
        private double _temperature;
        private int _targetPosition;

        public FocuserViewModel(IDeviceFactory deviceFactory) : base(deviceFactory)
        {
        }

        public bool IsAbsolute
        {
            get => _isAbsolute;
            set
            {
                _isAbsolute = value;
                NotifyOfPropertyChange(() => IsAbsolute);
            }
        }

        public bool IsMoving
        {
            get => _isMoving;
            set
            {
                _isMoving = value;
                NotifyOfPropertyChange(() => IsMoving);
                NotifyOfPropertyChange(() => CanHalt);
                NotifyOfPropertyChange(() => CanMove);
                
            }
        }

        public int MaxIncrement
        {
            get => _maxIncrement;
            set
            {
                _maxIncrement = value;
                NotifyOfPropertyChange(() => MaxIncrement);
            }
        }

        public int MaxStep
        {
            get => _maxStep;
            set
            {
                _maxStep = value;
                NotifyOfPropertyChange(() => MaxStep);
            }
        }

        public int Position
        {
            get => _position;
            set
            {
                _position = value;
                NotifyOfPropertyChange(() => Position);
            }
        }

        public double StepSize
        {
            get => _stepSize;
            set
            {
                _stepSize = value;
                NotifyOfPropertyChange(() => StepSize);
            }
        }

        public bool TempComp
        {
            get => _tempComp;
            set
            {
                _tempComp = value;
                NotifyOfPropertyChange(() => TempComp);
            }
        }

        public bool TempCompAvailable
        {
            get => _tempCompAvailable;
            set
            {
                _tempCompAvailable = value;
                NotifyOfPropertyChange(() => TempCompAvailable);
            }
        }

        public double Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                NotifyOfPropertyChange(() => Temperature);
            }
        }

        public int TargetPosition
        {
            get => _targetPosition;
            set
            {
                _targetPosition = value;
                NotifyOfPropertyChange(() => TargetPosition);
            }
        }

        public async Task Connect()
        {
            _focuser = DeviceFactory.CreateDeviceInstance<Focuser>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, Host = Host,
                Port = Port
            });

            try
            {
                await _focuser.SetConnectedAsync(true);
                await LoadDriverData();
                IsConnected = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private async Task LoadDriverData()
        {
            DriverName = await _focuser.GetNameAsync();
            Description = await _focuser.GetDescriptionAsync();
            DriverInfo = await _focuser.GetDriverInfoAsync();
            DriverVersion = await _focuser.GetDriverVersionAsync();

            IsAbsolute = await _focuser.IsAbsoluteAsync();
            IsMoving = await _focuser.IsMovingAsync();
            MaxIncrement = await _focuser.GetMaxIncrementAsync();
            MaxStep = await _focuser.GetMaxStepAsync();
            Position = await _focuser.GetPositionAsync();
            StepSize = await _focuser.GetStepSizeAsync();
            TempComp = await _focuser.IsTempCompAsync();
            TempCompAvailable = await _focuser.IsTempCompAvailableAsync();
            Temperature = await _focuser.GetTemperatureAsync();
            
            NotifyOfPropertyChange(() => CanSetTemperatureCompensation);
        }

        public bool CanSetTemperatureCompensation => TempCompAvailable;
        
        public async Task SetTemperatureCompensation()
        {
            await _focuser.SetTempCompAsync(!TempComp);
            TempComp = await _focuser.IsTempCompAsync();
        }
            
        public bool CanHalt => IsMoving;
        
        public async Task Halt()
        {
            await _focuser.HaltAsync();
        }

        public bool CanMove => TargetPosition >= 0;

        public async Task Move()
        {
            await _focuser.MoveAsync(TargetPosition);
            await Task.Run(() =>
            {
                do
                {
                    IsMoving = _focuser.IsMoving();
                    Position = _focuser.GetPosition();
                    Thread.Sleep(1000);
                } while (IsMoving);
            });
        }
    }
}