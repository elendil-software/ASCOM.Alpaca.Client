using System;
using System.Threading.Tasks;
using System.Windows;
using AscomAlpacaClient.Demo.Desktop.Factories;
using AscomAlpacaClient.Devices;

namespace AscomAlpacaClient.Demo.Desktop.ViewModels
{
    public class ObservingConditionsViewModel : DeviceViewModelBase
    {
        private IObservingConditions _observingConditions;
        private double _cloudCover;
        private double _dewPoint;
        private double _humidity;
        private double _pressure;
        private double _rainRate;
        private double _skyBrightness;
        private double _skyQuality;
        private double _skyTemperature;
        private double _starFwhm;
        private double _temperature;
        private double _windDirection;
        private double _windGust;
        private double _windSpeed;
        private double _averagePeriod;
        private TimeSpan _timeSinceLastUpdate;
        private string _sensorDescription;

        public ObservingConditionsViewModel(IDeviceFactory deviceFactory) : base(deviceFactory)
        {
        }

        public double CloudCover
        {
            get => _cloudCover;
            set
            {
                _cloudCover = value;
                NotifyOfPropertyChange(() => CloudCover);
            }
        }

        public double DewPoint
        {
            get => _dewPoint;
            set
            {
                _dewPoint = value;
                NotifyOfPropertyChange(() => DewPoint);
            }
        }

        public double Humidity
        {
            get => _humidity;
            set
            {
                _humidity = value;
                NotifyOfPropertyChange(() => Humidity);
            }
        }

        public double Pressure
        {
            get => _pressure;
            set
            {
                _pressure = value;
                NotifyOfPropertyChange(() => Pressure);
            }
        }

        public double RainRate
        {
            get => _rainRate;
            set
            {
                _rainRate = value;
                NotifyOfPropertyChange(() => RainRate);
            }
        }

        public double SkyBrightness
        {
            get => _skyBrightness;
            set
            {
                _skyBrightness = value;
                NotifyOfPropertyChange(() => SkyBrightness);
            }
        }

        public double SkyQuality
        {
            get => _skyQuality;
            set
            {
                _skyQuality = value;
                NotifyOfPropertyChange(() => SkyQuality);
            }
        }

        public double SkyTemperature
        {
            get => _skyTemperature;
            set
            {
                _skyTemperature = value;
                NotifyOfPropertyChange(() => SkyTemperature);
            }
        }

        public double StarFWHM
        {
            get => _starFwhm;
            set
            {
                _starFwhm = value;
                NotifyOfPropertyChange(() => StarFWHM);
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

        public double WindDirection
        {
            get => _windDirection;
            set
            {
                _windDirection = value;
                NotifyOfPropertyChange(() => WindDirection);
            }
        }

        public double WindGust
        {
            get => _windGust;
            set
            {
                _windGust = value;
                NotifyOfPropertyChange(() => WindGust);
            }
        }

        public double WindSpeed
        {
            get => _windSpeed;
            set
            {
                _windSpeed = value;
                NotifyOfPropertyChange(() => WindSpeed);
            }
        }

        public double AveragePeriod
        {
            get => _averagePeriod;
            set
            {
                _averagePeriod = value;
                NotifyOfPropertyChange(() => AveragePeriod);
            }
        }

        public TimeSpan TimeSinceLastUpdate
        {
            get => _timeSinceLastUpdate;
            set
            {
                _timeSinceLastUpdate = value;
                NotifyOfPropertyChange(() => TimeSinceLastUpdate);
            }
        }

        public string SensorDescription
        {
            get => _sensorDescription;
            set
            {
                _sensorDescription = value;
                NotifyOfPropertyChange(() => SensorDescription);
            }
        }

        public async Task Connect()
        {
            _observingConditions = DeviceFactory.CreateDeviceInstance<ObservingConditions>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, Host = Host,
                Port = Port
            });

            try
            {
                await _observingConditions.SetConnectedAsync(true);
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
            DriverName = await _observingConditions.GetNameAsync();
            Description = await _observingConditions.GetDescriptionAsync();
            DriverInfo = await _observingConditions.GetDriverInfoAsync();
            DriverVersion = await _observingConditions.GetDriverVersionAsync();

            await RefreshData();
        }

        public bool CanRefresh => IsConnected;

        public async Task RefreshData()
        {
            try
            {
                CloudCover = await _observingConditions.GetCloudCoverAsync();
                DewPoint = await _observingConditions.GetDewPointAsync();
                Humidity = await _observingConditions.GetHumidityAsync();
                Pressure = await _observingConditions.GetPressureAsync();
                RainRate = await _observingConditions.GetRainRateAsync();
                SkyBrightness = await _observingConditions.GetSkyBrightnessAsync();
                SkyQuality = await _observingConditions.GetSkyQualityAsync();
                SkyTemperature = await _observingConditions.GetSkyTemperatureAsync();
                StarFWHM = await _observingConditions.GetStarFwhmAsync();
                Temperature = await _observingConditions.GetTemperatureAsync();
                WindDirection = await _observingConditions.GetWindDirectionAsync();
                WindGust = await _observingConditions.GetWindGustAsync();
                WindSpeed = await _observingConditions.GetWindSpeedAsync();
                AveragePeriod = await _observingConditions.GetAveragePeriodAsync();
                TimeSinceLastUpdate = await _observingConditions.GetTimeSinceLastUpdateAsync(ObservingConditionSensorName.Humidity);
                SensorDescription = await _observingConditions.GetSensorDescriptionAsync(ObservingConditionSensorName.Humidity);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}