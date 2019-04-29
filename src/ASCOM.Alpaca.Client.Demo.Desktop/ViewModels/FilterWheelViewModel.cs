using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ASCOM.Alpaca.Client.Demo.Desktop.Factories;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Devices;

namespace ASCOM.Alpaca.Client.Demo.Desktop.ViewModels
{
    public class FilterWheelViewModel : DeviceViewModelBase
    {
        private int _selectedFilter;
        private int _currentPosition;

        private IFilterWheel _filterWheel;

        public FilterWheelViewModel(IDeviceFactory deviceFactory) : base(deviceFactory)
        {
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

        public async Task Connect()
        {
            _filterWheel = DeviceFactory.CreateDeviceInstance<FilterWheel>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, Host = Host,
                Port = Port
            });

            try
            {
                await _filterWheel.SetConnectedAsync(true);
                await LoadDriverData();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadDriverData()
        {
            DriverName = await _filterWheel.GetNameAsync();
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

        public async Task MoveToSelectedFilter()
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