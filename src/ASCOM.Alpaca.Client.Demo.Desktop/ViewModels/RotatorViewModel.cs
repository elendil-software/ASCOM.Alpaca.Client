using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Demo.Desktop.Factories;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Devices.Providers;
using ASCOM.Alpaca.Devices;

namespace ASCOM.Alpaca.Client.Demo.Desktop.ViewModels
{
    public class RotatorViewModel : DeviceViewModelBase
    {
        private IRotator _rotator;
        private bool _canReverse;
        private bool _isMoving;
        private double _position;
        private bool _isReversed;
        private double _stepSize;
        private double _targetPosition;
        private double _newPosition;

        public RotatorViewModel(IDeviceFactory deviceFactory) : base(deviceFactory)
        {
        }

        public bool CanReverse
        {
            get => _canReverse;
            set
            {
                _canReverse = value;
                NotifyOfPropertyChange(() => CanReverse);
            }
        }

        public bool IsMoving
        {
            get => _isMoving;
            set
            {
                _isMoving = value;
                NotifyOfPropertyChange(() => IsMoving);
            }
        }

        public double Position
        {
            get => _position;
            set
            {
                _position = value;
                NotifyOfPropertyChange(() => Position);
            }
        }

        public bool IsReversed
        {
            get => _isReversed;
            set
            {
                _isReversed = value;
                NotifyOfPropertyChange(() => IsReversed);
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

        public double TargetPosition
        {
            get => _targetPosition;
            set
            {
                _targetPosition = value;
                NotifyOfPropertyChange(() => TargetPosition);
            }
        }

        public double NewPosition
        {
            get => _newPosition;
            set
            {
                _newPosition = value;
                NotifyOfPropertyChange(() => NewPosition);
            }
        }

        public async Task Connect()
        {
            _rotator = DeviceFactory.CreateDeviceInstance<Rotator>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, DeviceType = DeviceType.Rotator, Host = Host,
                Port = Port
            });

            try
            {
                await _rotator.SetConnectedAsync(true);
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
            DriverName = await _rotator.GetNameAsync();
            Description = await _rotator.GetDescriptionAsync();
            DriverInfo = await _rotator.GetDriverInfoAsync();
            DriverVersion = await _rotator.GetDriverVersionAsync();

            CanReverse = await _rotator.CanReverseAsync();
            IsMoving = await _rotator.IsMovingAsync();
            Position = await _rotator.GetPositionAsync();
            IsReversed = await _rotator.IsReversedAsync();
            StepSize = await _rotator.GetStepSizeAsync();
            TargetPosition = await _rotator.GetTargetPositionAsync();
        }

        public async Task Move()
        {
            try
            {
                await _rotator.MoveAsync(NewPosition);
                await Task.Run(() =>
                {
                    do
                    {
                        IsMoving = _rotator.IsMoving();
                        Position = _rotator.GetPosition();
                        Thread.Sleep(1000);
                    } while (IsMoving);
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public async Task MoveAbsolute()
        {
            try
            {
                await _rotator.MoveAbsoluteAsync(NewPosition);
                await Task.Run(() =>
                {
                    do
                    {
                        IsMoving = _rotator.IsMoving();
                        Position = _rotator.GetPosition();
                        Thread.Sleep(1000);
                    } while (IsMoving);
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task Halt()
        {
            try
            {
                await _rotator.HaltAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task SetReversed()
        {
            try 
            {
                await _rotator.SetReversedAsync(!IsReversed);
                IsReversed = await _rotator.IsReversedAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}