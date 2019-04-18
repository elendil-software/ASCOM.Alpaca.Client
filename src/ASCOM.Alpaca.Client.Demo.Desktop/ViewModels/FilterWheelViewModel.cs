using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Devices.FilterWheel;
using ASCOM.Alpaca.Client.Devices.Providers;
using Caliburn.Micro;

namespace ASCOM.Alpaca.Client.Demo.Desktop.ViewModels
{
    public class FilterWheelViewModel : Screen
    {
        private string _host = "127.0.0.1";
        private int _port = 11111;
        private int _clientId = 1;
        private int _deviceId;

        private string _name = "";
        private string _description = "";
        private string _driverVersion = "";
        private string _driverInfo = "";

        private int _selectedFilter;
        private int _currentPosition;

        private IFilterWheel _filterWheel;
        private readonly IDeviceFactory _deviceFactory;

        public FilterWheelViewModel(IDeviceFactory deviceFactory)
        {
            _deviceFactory = deviceFactory ?? throw new ArgumentNullException(nameof(deviceFactory));
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);

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

        public ObservableCollection<int> FocusOffsets { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<string> Filters { get; set; } = new ObservableCollection<string>();

        public int SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                _selectedFilter = value;
                NotifyOfPropertyChange(() => SelectedFilter);

            }
        }

        public int CurrentPosition
        {
            get => _currentPosition;
            set
            {
                _currentPosition = value;
                NotifyOfPropertyChange(() => CurrentPosition);
            }
        }

        public bool CanConnect => !string.IsNullOrEmpty(Host) && Port > 0 && DeviceId >= 0 && ClientId > 0;

        public async void Connect()
        {
            _filterWheel = _deviceFactory.GetDevice<FilterWheel>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, DeviceType = DeviceType.FilterWheel, Host = Host,
                Port = Port
            });

            try
            {
                await _filterWheel.SetConnectedAsync(true);
                LoadDriverData();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void LoadDriverData()
        {
            Name = await _filterWheel.GetNameAsync();
            Description = await _filterWheel.GetDescriptionAsync();
            DriverInfo = await _filterWheel.GetDriverInfoAsync();
            DriverVersion = await _filterWheel.GetDriverVersionAsync();

            List<string> filterNames = await _filterWheel.GetNamesAsync();
            Filters.Clear();
            foreach (var filterName in filterNames)
            {
                Filters.Add(filterName);
            }

            NotifyOfPropertyChange(() => Filters);

            List<int> focusOffsets = await _filterWheel.GetFocusOffsetsAsync();
            FocusOffsets.Clear();
            foreach (var focusOffset in focusOffsets)
            {
                FocusOffsets.Add(focusOffset);
            }

            NotifyOfPropertyChange(() => FocusOffsets);

            SelectedFilter = await _filterWheel.GetPositionAsync();
            CurrentPosition = SelectedFilter;
        }

        public async void MoveToSelectedFilter()
        {
            try
            {
                await _filterWheel.SetPositionAsync(SelectedFilter);
                int currentPosition = -1;
                await Task.Run(() =>
                {
                    
                    do
                    {
                        currentPosition = _filterWheel.GetPosition();
                        Thread.Sleep(1000);
                    } while (currentPosition == -1);
                });

                CurrentPosition = currentPosition;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}