using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Devices.Providers;
using ASCOM.Alpaca.Devices;

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
//        CanWrite,
//        GetSwitch,
//        GetSwitchDescription,
//        GetSwitchName,
//        GetSwitchValue,
//        MinSwitchValue,
//        MaxSwitchValue,
//        SetSwitch,
//        SetSwitchName,
//        SetSwitchValue,
//        SwitchStep

        public ObservableCollection<SwitchItem> Switches { get; set; } = new ObservableCollection<SwitchItem>();

        public async Task Connect()
        {
            _switch = DeviceFactory.CreateDeviceInstance<Switch>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, DeviceType = DeviceType.Switch, Host = Host,
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
            
            //NotifyOfPropertyChange(() => Switches);
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
    }

    public class SwitchItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double StepSize { get; set; }
        public bool CanWrite { get; set; }
    }
}