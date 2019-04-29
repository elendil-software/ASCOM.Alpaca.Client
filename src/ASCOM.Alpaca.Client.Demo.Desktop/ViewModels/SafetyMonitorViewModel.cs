using System;
using System.Threading.Tasks;
using System.Windows;
using ASCOM.Alpaca.Client.Demo.Desktop.Factories;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Devices;

namespace ASCOM.Alpaca.Client.Demo.Desktop.ViewModels
{
    public class SafetyMonitorViewModel : DeviceViewModelBase
    {
        private bool _isSafe;
        private ISafetyMonitor _safetyMonitor;

        public SafetyMonitorViewModel(IDeviceFactory deviceFactory) : base(deviceFactory)
        {
        }

        public bool IsSafe
        {
            get => _isSafe;
            set
            {
                _isSafe = value;
                NotifyOfPropertyChange(() => IsSafe);
            }
        }
        
        public async Task Connect()
        {
            _safetyMonitor = DeviceFactory.CreateDeviceInstance<SafetyMonitor>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, DeviceType = DeviceType.SafetyMonitor, Host = Host,
                Port = Port
            });

            try
            {
                await _safetyMonitor.SetConnectedAsync(true);
                await LoadDriverData();
                
                IsConnected = true;
                NotifyOfPropertyChange(() => CanRefresh);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private async Task LoadDriverData()
        {
            DriverName = await _safetyMonitor.GetNameAsync();
            Description = await _safetyMonitor.GetDescriptionAsync();
            DriverInfo = await _safetyMonitor.GetDriverInfoAsync();
            DriverVersion = await _safetyMonitor.GetDriverVersionAsync();

            IsSafe = await _safetyMonitor.IsSafeAsync();
        }

        public bool CanRefresh => IsConnected;

        public async Task RefreshData()
        {
            try
            {
                IsSafe = await _safetyMonitor.IsSafeAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}