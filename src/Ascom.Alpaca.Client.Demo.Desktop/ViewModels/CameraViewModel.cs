using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ES.AscomAlpaca.Client.Demo.Desktop.Factories;
using ES.AscomAlpaca.Client.Devices;
using ES.AscomAlpaca.Devices;
using ES.AscomAlpaca.Exceptions;

namespace ES.AscomAlpaca.Client.Demo.Desktop.ViewModels
{
    public class CameraViewModel : DeviceViewModelBase
    {
        private Camera _camera;
        private int _cameraXSize;
        private int _cameraYSize;
        private int _bayerOffsetX;
        private int _bayerOffsetY;
        private int _binX;
        private int _binY;
        private CameraState _cameraState;
        private bool _canAbortExposure;
        private bool _canAsymmetricBin;
        private bool _canFastReadout;
        private bool _canGetCoolerPower;
        private bool _canPulseGuide;
        private bool _canSetCCDTemperature;
        private bool _canStopExposure;
        private double _ccdTemperature;
        private bool _coolerOn;
        private double _coolerPower;
        private double _electronsPerADU;
        private double _exposureMax;
        private double _exposureMin;
        private double _exposureResolution;
        private bool _fastReadout;
        private double _fullWellCapacity;
        private int _gain = -1;
        private int _gainMax;
        private int _gainMin;
        private IList<string> _gains;
        private bool _hasShutter;
        private double _heatSinkTemperature;
        private bool _isImageReady;
        private bool _isPulseGuiding;
        private double _lastExposureDuration;
        private DateTime _lastExposureStartTime;
        private int _maxADU;
        private int _maxBinX;
        private int _maxBinY;
        private int _numX;
        private int _numY;
        private int _percentCompleted;
        private double _pixelSizeX;
        private double _pixelSizeY;
        private int _readoutMode;
        private IList<string> _readoutModes;
        private string _sensorName;
        private SensorType _sensorType;
        private double _setCCDTemperature;
        private int _startX;
        private int _startY;
        private double _exposureDuration;
        private string _lastImageInformations;

        public CameraViewModel(IDeviceFactory deviceFactory) : base(deviceFactory)
        {
        }

        #region Properties

        public int BayerOffsetX
        {
            get => _bayerOffsetX;
            set
            {
                _bayerOffsetX = value;
                NotifyOfPropertyChange(() => BayerOffsetX);
            }
        }

        public int BayerOffsetY
        {
            get => _bayerOffsetY;
            set
            {
                _bayerOffsetY = value;
                NotifyOfPropertyChange(() => BayerOffsetY);
            }
        }

        public int BinX
        {
            get => _binX;
            set
            {
                _binX = value;
                NotifyOfPropertyChange(() => BinX);
            }
        }

        public int BinY
        {
            get => _binY;
            set
            {
                _binY = value;
                NotifyOfPropertyChange(() => BinY);
            }
        }

        public CameraState CameraState
        {
            get => _cameraState;
            set
            {
                _cameraState = value;
                NotifyOfPropertyChange(() => CameraState);
            }
        }

        public int CameraXSize
        {
            get => _cameraXSize;
            set
            {
                _cameraXSize = value;
                NotifyOfPropertyChange(() => CameraXSize);
            }
        }

        public int CameraYSize
        {
            get => _cameraYSize;
            set
            {
                _cameraYSize = value;
                NotifyOfPropertyChange(() => CameraYSize);
            }
        }

        public bool CanAbortExposure
        {
            get => _canAbortExposure;
            set
            {
                _canAbortExposure = value;
                NotifyOfPropertyChange(() => CanAbortExposure);
            }
        }

        public bool CanAsymmetricBin
        {
            get => _canAsymmetricBin;
            set
            {
                _canAsymmetricBin = value;
                NotifyOfPropertyChange(() => CanAsymmetricBin);
            }
        }

        public bool CanFastReadout
        {
            get => _canFastReadout;
            set
            {
                _canFastReadout = value;
                NotifyOfPropertyChange(() => CanFastReadout);
            }
        }

        public bool CanGetCoolerPower
        {
            get => _canGetCoolerPower;
            set
            {
                _canGetCoolerPower = value;
                NotifyOfPropertyChange(() => CanGetCoolerPower);
            }
        }

        public bool CanPulseGuide
        {
            get => _canPulseGuide;
            set
            {
                _canPulseGuide = value;
                NotifyOfPropertyChange(() => CanPulseGuide);
            }
        }

        public bool CanSetCCDTemperature
        {
            get => _canSetCCDTemperature;
            set
            {
                _canSetCCDTemperature = value;
                NotifyOfPropertyChange(() => CanSetCCDTemperature);
            }
        }

        public bool CanStopExposure
        {
            get => _canStopExposure;
            set
            {
                _canStopExposure = value;
                NotifyOfPropertyChange(() => CanStopExposure);
            }
        }

        public double CCDTemperature
        {
            get => _ccdTemperature;
            set
            {
                _ccdTemperature = value;
                NotifyOfPropertyChange(() => CCDTemperature);
            }
        }

        public bool CoolerOn
        {
            get => _coolerOn;
            set
            {
                _coolerOn = value;
                NotifyOfPropertyChange(() => CoolerOn);
            }
        }

        public double CoolerPower
        {
            get => _coolerPower;
            set
            {
                _coolerPower = value;
                NotifyOfPropertyChange(() => CoolerPower);
            }
        }


        public double ElectronsPerADU
        {
            get => _electronsPerADU;
            set
            {
                _electronsPerADU = value;
                NotifyOfPropertyChange(() => ElectronsPerADU);
            }
        }

        public double ExposureMax
        {
            get => _exposureMax;
            set
            {
                _exposureMax = value;
                NotifyOfPropertyChange(() => ExposureMax);
            }
        }

        public double ExposureMin
        {
            get => _exposureMin;
            set
            {
                _exposureMin = value;
                NotifyOfPropertyChange(() => ExposureMin);
            }
        }

        public double ExposureResolution
        {
            get => _exposureResolution;
            set
            {
                _exposureResolution = value;
                NotifyOfPropertyChange(() => ExposureResolution);
            }
        }

        public bool FastReadout
        {
            get => _fastReadout;
            set
            {
                _fastReadout = value;
                NotifyOfPropertyChange(() => FastReadout);
            }
        }

        public double FullWellCapacity
        {
            get => _fullWellCapacity;
            set
            {
                _fullWellCapacity = value;
                NotifyOfPropertyChange(() => FullWellCapacity);
            }
        }


        public int Gain
        {
            get => _gain;
            set
            {
                _gain = value;
                NotifyOfPropertyChange(() => Gain);
            }
        }

        public int GainMax
        {
            get => _gainMax;
            set
            {
                _gainMax = value;
                NotifyOfPropertyChange(() => GainMax);
            }
        }

        public int GainMin
        {
            get => _gainMin;
            set
            {
                _gainMin = value;
                NotifyOfPropertyChange(() => GainMin);
            }
        }

        public IList<string> Gains
        {
            get => _gains;
            set
            {
                _gains = value;
                NotifyOfPropertyChange(() => Gains);
            }
        }

        public bool HasShutter
        {
            get => _hasShutter;
            set
            {
                _hasShutter = value;
                NotifyOfPropertyChange(() => HasShutter);
            }
        }

        public double HeatSinkTemperature
        {
            get => _heatSinkTemperature;
            set
            {
                _heatSinkTemperature = value;
                NotifyOfPropertyChange(() => HeatSinkTemperature);
            }
        }

        public bool IsImageReady
        {
            get => _isImageReady;
            set
            {
                _isImageReady = value;
                NotifyOfPropertyChange(() => IsImageReady);
            }
        }

        public bool IsPulseGuiding
        {
            get => _isPulseGuiding;
            set
            {
                _isPulseGuiding = value;
                NotifyOfPropertyChange(() => IsPulseGuiding);
            }
        }

        public double LastExposureDuration
        {
            get => _lastExposureDuration;
            set
            {
                _lastExposureDuration = value;
                NotifyOfPropertyChange(() => LastExposureDuration);
            }
        }

        public DateTime LastExposureStartTime
        {
            get => _lastExposureStartTime;
            set
            {
                _lastExposureStartTime = value;
                NotifyOfPropertyChange(() => LastExposureStartTime);
            }
        }

        public int MaxADU
        {
            get => _maxADU;
            set
            {
                _maxADU = value;
                NotifyOfPropertyChange(() => MaxADU);
            }
        }

        public int MaxBinX
        {
            get => _maxBinX;
            set
            {
                _maxBinX = value;
                NotifyOfPropertyChange(() => MaxBinX);
            }
        }

        public int MaxBinY
        {
            get => _maxBinY;
            set
            {
                _maxBinY = value;
                NotifyOfPropertyChange(() => MaxBinY);
            }
        }

        public int NumX
        {
            get => _numX;
            set
            {
                _numX = value;
                NotifyOfPropertyChange(() => NumX);
            }
        }

        public int NumY
        {
            get => _numY;
            set
            {
                _numY = value;
                NotifyOfPropertyChange(() => NumY);
            }
        }


        public int PercentCompleted
        {
            get => _percentCompleted;
            set
            {
                _percentCompleted = value;
                NotifyOfPropertyChange(() => PercentCompleted);
            }
        }

        public double PixelSizeX
        {
            get => _pixelSizeX;
            set
            {
                _pixelSizeX = value;
                NotifyOfPropertyChange(() => PixelSizeX);
            }
        }

        public double PixelSizeY
        {
            get => _pixelSizeY;
            set
            {
                _pixelSizeY = value;
                NotifyOfPropertyChange(() => PixelSizeY);
            }
        }

        public int ReadoutMode
        {
            get => _readoutMode;
            set
            {
                _readoutMode = value;
                NotifyOfPropertyChange(() => ReadoutMode);
            }
        }

        public IList<string> ReadoutModes
        {
            get => _readoutModes;
            set
            {
                _readoutModes = value;
                NotifyOfPropertyChange(() => ReadoutModes);
            }
        }

        public string SensorName
        {
            get => _sensorName;
            set
            {
                _sensorName = value;
                NotifyOfPropertyChange(() => SensorName);
            }
        }

        public SensorType SensorType
        {
            get => _sensorType;
            set
            {
                _sensorType = value;
                NotifyOfPropertyChange(() => SensorType);
            }
        }

        public double SetCCDTemperature
        {
            get => _setCCDTemperature;
            set
            {
                _setCCDTemperature = value;
                NotifyOfPropertyChange(() => SetCCDTemperature);
            }
        }

        public int StartX
        {
            get => _startX;
            set
            {
                _startX = value;
                NotifyOfPropertyChange(() => StartX);
            }
        }

        public int StartY
        {
            get => _startY;
            set
            {
                _startY = value;
                NotifyOfPropertyChange(() => StartY);
            }
        }

        public double ExposureDuration
        {
            get => _exposureDuration;
            set
            {
                _exposureDuration = value;
                NotifyOfPropertyChange(() => ExposureDuration);
            }
        }

        public string LastImageInformation
        {
            get => _lastImageInformations;
            set
            {
                _lastImageInformations = value;
                NotifyOfPropertyChange(() => LastImageInformation);
            }
        }

        #endregion


        public async Task Connect()
        {
            _camera = DeviceFactory.CreateDeviceInstance<Camera>(new DeviceConfiguration
            {
                ClientId = ClientId, DeviceNumber = DeviceId, Host = Host,
                Port = Port
            });

            try
            {
                await _camera.SetConnectedAsync(true);
                await LoadDriverData();

                await LoadPixelsInformation();
                await LoadCCDInformation();
                await LoadCoolingInformation();
                await LoadGainInformation();
                await LoadReadoutModesInformation();
                await LoadGuidingInformation();
                await LoadExposureInformation();
                await LoadFrameInformation();
                await LoadCurrentExposureInformation();
                
                IsConnected = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadPixelsInformation()
        {
            PixelSizeX = await _camera.GetPixelSizeXAsync();
            PixelSizeY = await _camera.GetPixelSizeYAsync();
            MaxADU = await _camera.GetMaxADUAsync();
            ElectronsPerADU = await _camera.GetElectronPerADUAsync();
            FullWellCapacity = await _camera.GetFullWellCapacityAsync();
        }

        private async Task LoadCCDInformation()
        {
            CameraXSize = await _camera.GetCameraXSizeAsync();
            CameraYSize = await _camera.GetCameraYSizeAsync();
            
            MaxBinX = await _camera.GetMaxBinXAsync();
            MaxBinY = await _camera.GetMaxBinYAsync();
            
            CanAsymmetricBin = await _camera.CanAsymmetricBinAsync();
            HasShutter = await _camera.HasShutterAsync();
            
            SensorName = await _camera.GetSensorNameAsync();
            SensorType = await _camera.GetSensorTypeAsync();

            if (SensorType != SensorType.Monochrome)
            {
                BayerOffsetX = await _camera.GetBayerOffsetXAsync();
                BayerOffsetY = await _camera.GetBayerOffsetYAsync();
            }
        }

        private async Task LoadCoolingInformation()
        {
            CanSetCCDTemperature = await _camera.CanSetCCDTemperatureAsync();
            CanGetCoolerPower = await _camera.CanGetCoolerPowerAsync();
            CoolerOn = await _camera.IsCoolerOnAsync();
            SetCCDTemperature = await _camera.GetCCDTemperatureSetPointAsync();
            
            CCDTemperature = await _camera.GetCCDTemperatureAsync();
            HeatSinkTemperature = await _camera.GetHeatSinkTemperatureAsync();
            CoolerPower = await _camera.GetCoolerPowerAsync();
        }

        private async Task LoadGainInformation()
        {
            try
            {
                Gain = await _camera.GetGainAsync();
                GainMax = await _camera.GetGainMaxAsync();
                GainMin = await _camera.GetGainMinAsync();
            }
            catch (AlpacaNotImplementedException)
            {
                //DO NOTHING
            }

            if (Gain != -1)
            {
                try
                {
                    Gains = await _camera.GetGainsAsync();
                }
                catch (Exception)
                {
                    //DO NOTHING
                }
            }
        }
        
        private async Task LoadReadoutModesInformation()
        {
            CanFastReadout = await _camera.CanFastReadoutAsync();
            if (CanFastReadout)
            {
                FastReadout = await _camera.IsFastReadoutAsync();
            }
            
            ReadoutMode = await _camera.GetReadoutModeAsync();
            ReadoutModes = await _camera.GetReadoutModesAsync();
        }
        
        private async Task LoadGuidingInformation()
        {
            CanPulseGuide = await _camera.CanPulseGuideAsync();
            if (CanPulseGuide)
            {
                IsPulseGuiding = await _camera.IsPulseGuidingAsync();
            }
        }

        private async Task LoadExposureInformation()
        {
            CanAbortExposure = await _camera.CanAbortExposureAsync();
            CanStopExposure = await _camera.CanStopExposureAsync();
            ExposureMin = await _camera.GetExposureMinAsync();
            ExposureMax = await _camera.GetExposureMaxAsync();
            ExposureResolution = await _camera.GetExposureResolutionAsync();
        }

        private async Task LoadCurrentExposureInformation()
        {
            IsImageReady = await _camera.IsImageReadyAsync();

            if (IsImageReady)
            {
                LastExposureDuration = await _camera.GetLastExposureDurationAsync();
                LastExposureStartTime = await _camera.GetLastExposureStartTimeAsync();
            }

            PercentCompleted = await _camera.GetPercentCompletedAsync();
            CameraState = await _camera.GetCameraStateAsync();
        }

        private async Task LoadFrameInformation()
        {
            StartX = await _camera.GetStartXAsync();
            StartY = await _camera.GetStartYAsync();
            NumX = await _camera.GetNumXAsync();
            NumY = await _camera.GetNumYAsync();
        }

        private async Task LoadDriverData()
        {
            DriverName = await _camera.GetNameAsync();
            Description = await _camera.GetDescriptionAsync();
            DriverInfo = await _camera.GetDriverInfoAsync();
            DriverVersion = await _camera.GetDriverVersionAsync();
        }

        public void AbortExposure()
        {
            _camera.AbortExposure();
        }

        public async Task StartExposure()
        {
            await _camera.StartExposureAsync(ExposureDuration, true);

            await Task.Run(() =>
            {
                do
                {
                    CameraState = _camera.GetCameraState();
                    PercentCompleted = _camera.GetPercentCompleted();
                    Thread.Sleep(1000);
                } while (CameraState == CameraState.Exposing);
            });

            await LoadCurrentExposureInformation();

            if (IsImageReady)
            {
                var image = await _camera.GetImageArrayAsync();
                LastImageInformation = $"Rank : {image.Rank}, Length : {image.Length}";
            }
        }
    }
}