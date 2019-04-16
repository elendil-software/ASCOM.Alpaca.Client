using System;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Devices.FilterWheel;
using ASCOM.Alpaca.Client.Devices.Providers;
using Caliburn.Micro;
using static System.String;

namespace ASCOM.Alpaca.Client.Demo.Desktop.ViewModels
{
    public class FilterWheelViewModel : Screen
    {
        private string _host = "127.0.0.1";
        private int _port = 11111;
        private int _clientId = 1;
        private int _deviceId;
        private IFilterWheel _filterWheel;
        private readonly IDeviceFactory _deviceFactory;

        public FilterWheelViewModel(IDeviceFactory deviceFactory)
        {
            _deviceFactory = deviceFactory ?? throw new ArgumentNullException(nameof(deviceFactory));
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

        public bool CanConnect => !IsNullOrEmpty(Host) && Port > 0 && DeviceId >= 0 && ClientId > 0;

        public async void Connect()
        {
            _filterWheel = _deviceFactory.GetDevice<FilterWheel>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, DeviceType = DeviceType.FilterWheel, Host = Host,
                Port = Port
            });

            await _filterWheel.SetConnectedAsync(true);
        }
    }
}