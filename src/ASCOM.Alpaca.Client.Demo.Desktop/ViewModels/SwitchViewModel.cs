using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using ASCOM.Alpaca.Client.Demo.Desktop.Factories;
using ASCOM.Alpaca.Client.Devices;

namespace ASCOM.Alpaca.Client.Demo.Desktop.ViewModels
{
    public class SwitchViewModel : DeviceViewModelBase
    {
        private ISwitch _switch;
        private int _maxSwitch;

        public SwitchViewModel(IDeviceFactory deviceFactory) : base(deviceFactory)
        {
        }

        public int MaxSwitch
        {
            get => _maxSwitch;
            set
            {
                _maxSwitch = value;
                NotifyOfPropertyChange(() => MaxSwitch);
            }
        }

        public ObservableCollection<SwitchItem> Switches { get; set; } = new ObservableCollection<SwitchItem>();

        public async Task Connect()
        {
            _switch = DeviceFactory.CreateDeviceInstance<Switch>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, Host = Host,
                Port = Port
            });

            try
            {
                await _switch.SetConnectedAsync(true);
                await LoadDriverData();
                
                IsConnected = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task LoadSwitches()
        {
            Switches.Clear();
            
            for (int i = 0; i < MaxSwitch; i++)
            {
                var switchItem = new SwitchItem();
                switchItem.Id = i;
                switchItem.Name = await _switch.GetSwitchNameAsync(i);
                switchItem.Description = await _switch.GetSwitchDescriptionAsync(i);
                switchItem.Value = await _switch.GetSwitchValueAsync(i);
                switchItem.Min = await _switch.GetMinSwitchValueAsync(i);
                switchItem.Max = await _switch.GetMaxSwitchValueAsync(i);
                switchItem.StepSize = await _switch.GetSwitchStepAsync(i);
                switchItem.CanWrite = await _switch.CanWriteAsync(i);
                
                Switches.Add(switchItem);
            }
        }
        
        private async Task LoadDriverData()
        {
            DriverName = await _switch.GetNameAsync();
            Description = await _switch.GetDescriptionAsync();
            DriverInfo = await _switch.GetDriverInfoAsync();
            DriverVersion = await _switch.GetDriverVersionAsync();

            MaxSwitch = await _switch.GetMaxSwitchAsync();
            await LoadSwitches();
        }
        
        public async Task SetSwitch(SwitchItem item)
        {
            try
            {
                await _switch.SetSwitchAsync(item.Id, item.Value == 0);
                item.Value = await _switch.GetSwitchValueAsync(item.Id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class SwitchItem : INotifyPropertyChanged 
    {
        private double _value;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public double Min { get; set; }
        public double Max { get; set; }
        public double StepSize { get; set; }
        public bool CanWrite { get; set; }

        public bool IsBool => Min == 0 && Max == 1 && StepSize == 1;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}