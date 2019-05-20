using System;
using AscomAlpacaClient.Demo.Desktop.Factories;
using Caliburn.Micro;

namespace AscomAlpacaClient.Demo.Desktop.ViewModels
{
    public class DeviceViewModelBase : Screen
    {
        private string _host = "127.0.0.1";
        private int _port = 11111;
        private int _clientId = 1;
        private int _deviceId;

        private string _driverName = "";
        private string _description = "";
        private string _driverVersion = "";
        private string _driverInfo = "";

        protected readonly IDeviceFactory DeviceFactory;
        private bool _isConnected;

        public DeviceViewModelBase(IDeviceFactory deviceFactory)
        {
            DeviceFactory = deviceFactory ?? throw new ArgumentNullException(nameof(deviceFactory));
        }

        public string DriverName
        {
            get => _driverName;
            set
            {
                _driverName = value;
                NotifyOfPropertyChange(() => DriverName);

            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);

            }
        }

        public string DriverVersion
        {
            get => _driverVersion;
            set
            {
                _driverVersion = value;
                NotifyOfPropertyChange(() => DriverVersion);

            }
        }

        public string DriverInfo
        {
            get => _driverInfo;
            set
            {
                _driverInfo = value;
                NotifyOfPropertyChange(() => DriverInfo);

            }
        }

        public string Host
        {
            get => _host;
            set
            {
                _host = value;
                NotifyOfPropertyChange(() => Host);
                NotifyOfPropertyChange(() => CanConnect);
            }
        }

        public int Port
        {
            get => _port;
            set
            {
                _port = value;
                NotifyOfPropertyChange(() => Port);
                NotifyOfPropertyChange(() => CanConnect);
            }
        }

        public int ClientId
        {
            get => _clientId;
            set
            {
                _clientId = value;
                NotifyOfPropertyChange(() => ClientId);
                NotifyOfPropertyChange(() => CanConnect);
            }
        }

        public int DeviceId
        {
            get => _deviceId;
            set
            {
                _deviceId = value;
                NotifyOfPropertyChange(() => DeviceId);
                NotifyOfPropertyChange(() => CanConnect);
            }
        }

        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                NotifyOfPropertyChange(() => IsConnected);
            }
        }

        public bool CanConnect => !string.IsNullOrEmpty(Host) && Port > 0 && DeviceId >= 0 && ClientId > 0;
    }
}