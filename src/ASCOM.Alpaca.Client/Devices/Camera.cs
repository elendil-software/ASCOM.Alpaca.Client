using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices.Methods;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Enums.Devices;
using ASCOM.Alpaca.Enums.Devices.Camera;
using ASCOM.Alpaca.Enums.Devices.Telescope;
using ASCOM.Alpaca.Responses;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;

namespace ASCOM.Alpaca.Client.Devices
{
    public class Camera : DeviceBase, ICamera
    {
        public Camera(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger<DeviceBase> logger) : base(configuration, clientTransactionIdGenerator, commandSender, logger)
        {
        }

        public Camera(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.Camera;

        public int GetBayerOffsetX() => ExecuteRequest<int, IntResponse>(BuildGetBayerOffsetXRequest);
        public async Task<int> GetBayerOffsetXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBayerOffsetXRequest);
        private RestRequest BuildGetBayerOffsetXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.BayerOffsetX, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetBayerOffsetY() => ExecuteRequest<int, IntResponse>(BuildGetBayerOffsetYRequest);
        public async Task<int> GetBayerOffsetYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBayerOffsetXRequest);
        private RestRequest BuildGetBayerOffsetYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.BayerOffsetY, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetBinX() => ExecuteRequest<int, IntResponse>(BuildGetBinXRequest);
        public async Task<int> GetBinXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBinXRequest);
        private RestRequest BuildGetBinXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.BinX, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetBinX(int binX) => ExecuteRequest(BuildSetBinXRequest, binX);
        public async Task SetBinXAsync(int binX) => await ExecuteRequestAsync(BuildSetBinXRequest, binX);
        private RestRequest BuildSetBinXRequest(int binX)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.BinX, binX.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.BinX, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public int GetBinY() => ExecuteRequest<int, IntResponse>(BuildGetBinYRequest);
        public async Task<int> GetBinYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBinYRequest);
        private RestRequest BuildGetBinYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.BinY, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetBinY(int binY) => ExecuteRequest(BuildSetBinYRequest, binY);
        public async Task SetBinYAsync(int binY) => await ExecuteRequestAsync(BuildSetBinYRequest, binY);
        private RestRequest BuildSetBinYRequest(int binY)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.BinY, binY.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.BinY, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public CameraState GetCameraState() => ExecuteRequest<CameraState, ValueResponse<CameraState>>(BuildGetCameraStateRequest);
        public async Task<CameraState> GetCameraStateAsync() => await ExecuteRequestAsync<CameraState, ValueResponse<CameraState>>(BuildGetCameraStateRequest);
        private RestRequest BuildGetCameraStateRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CameraState, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetCameraXSize() => ExecuteRequest<int, IntResponse>(BuildGetCameraXSizeRequest);
        public async Task<int> GetCameraXSizeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetCameraXSizeRequest);
        private RestRequest BuildGetCameraXSizeRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CameraXSize, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetCameraYSize() => ExecuteRequest<int, IntResponse>(BuildGetCameraYSizeRequest);
        public async Task<int> GetCameraYSizeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetCameraYSizeRequest);
        private RestRequest BuildGetCameraYSizeRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CameraYSize, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanAbortExposure() => ExecuteRequest<bool, BoolResponse>(BuildCanAbortExposureRequest);
        public async Task<bool> CanAbortExposureAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanAbortExposureRequest);
        private RestRequest BuildCanAbortExposureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanAbortExposure, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanAsymmetricBin() => ExecuteRequest<bool, BoolResponse>(BuildCanAsymmetricBinRequest);
        public async Task<bool> CanAsymmetricBinAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanAsymmetricBinRequest);
        private RestRequest BuildCanAsymmetricBinRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanAsymmetricBin, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool CanFastReadout() => ExecuteRequest<bool, BoolResponse>(BuildCanFastReadoutRequest);
        public async Task<bool> CanFastReadoutAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanFastReadoutRequest);
        private RestRequest BuildCanFastReadoutRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanFastReadout, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanGetCoolerPower() => ExecuteRequest<bool, BoolResponse>(BuildCanGetCoolerPowerRequest);
        public async Task<bool> CanGetCoolerPowerAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanGetCoolerPowerRequest);
        private RestRequest BuildCanGetCoolerPowerRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanGetCoolerPower, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanPulseGuide() => ExecuteRequest<bool, BoolResponse>(BuildCanPulseGuideRequest);
        public async Task<bool> CanPulseGuideAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanPulseGuideRequest);
        private RestRequest BuildCanPulseGuideRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanPulseGuide, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanSetCCDTemperature() => ExecuteRequest<bool, BoolResponse>(BuildCanSetCCDTemperatureRequest);
        public async Task<bool> CanSetCCDTemperatureAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetCCDTemperatureRequest);
        private RestRequest BuildCanSetCCDTemperatureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanSetCCDTemperature, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanStopExposure() => ExecuteRequest<bool, BoolResponse>(BuildCanStopExposureRequest);
        public async Task<bool> CanStopExposureAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanStopExposureRequest);
        private RestRequest BuildCanStopExposureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CanStopExposure, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetCCDTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetCCDTemperatureRequest);
        public async Task<double> GetCCDTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCCDTemperatureRequest);
        private RestRequest BuildGetCCDTemperatureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CCDTemperature, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool IsCoolerOn() => ExecuteRequest<bool, BoolResponse>(BuildIsCoolerOnRequest);
        public async Task<bool> IsCoolerOnAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsCoolerOnRequest);
        private RestRequest BuildIsCoolerOnRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CoolerOn, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetCoolerOn(bool coolerOn) => ExecuteRequest(BuildSetCoolerOnRequest, coolerOn);
        public async Task SetCoolerOnAsync(bool coolerOn) => await ExecuteRequestAsync(BuildSetCoolerOnRequest, coolerOn);
        private RestRequest BuildSetCoolerOnRequest(bool coolerOn)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.CoolerOn, coolerOn.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.CoolerOn, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetCoolerPower() => ExecuteRequest<double, DoubleResponse>(BuildGetCoolerPowerRequest);
        public async Task<double> GetCoolerPowerAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCoolerPowerRequest);
        private RestRequest BuildGetCoolerPowerRequest() => RequestBuilder.BuildRestRequest(CameraMethod.CoolerPower, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetElectronPerADU() => ExecuteRequest<double, DoubleResponse>(BuildGetElectronPerADURequest);
        public async Task<double> GetElectronPerADUAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetElectronPerADURequest);
        private RestRequest BuildGetElectronPerADURequest() => RequestBuilder.BuildRestRequest(CameraMethod.ElectronsPerADU, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetExposureMax() => ExecuteRequest<double, DoubleResponse>(BuildGetExposureMaxRequest);
        public async Task<double> GetExposureMaxAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetExposureMaxRequest);
        private RestRequest BuildGetExposureMaxRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ExposureMax, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetExposureMin() => ExecuteRequest<double, DoubleResponse>(BuildGetExposureMinRequest);
        public async Task<double> GetExposureMinAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetExposureMinRequest);
        private RestRequest BuildGetExposureMinRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ExposureMin, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetExposureResolution() => ExecuteRequest<double, DoubleResponse>(BuildGetExposureResolutionRequest);
        public async Task<double> GetExposureResolutionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetExposureResolutionRequest);
        private RestRequest BuildGetExposureResolutionRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ExposureResolution, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool IsFastReadout() => ExecuteRequest<bool, BoolResponse>(BuildIsFastReadoutRequest);
        public async Task<bool> IsFastReadoutAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsFastReadoutRequest);
        private RestRequest BuildIsFastReadoutRequest() => RequestBuilder.BuildRestRequest(CameraMethod.FastReadout, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetFastReadout(bool fastReadout) => ExecuteRequest(BuildSetFastReadoutRequest, fastReadout);
        public async Task SetFastReadoutAsync(bool fastReadout) => await ExecuteRequestAsync(BuildSetFastReadoutRequest, fastReadout);
        private RestRequest BuildSetFastReadoutRequest(bool fastReadout)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.FastReadout, fastReadout.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.FastReadout, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetFullWellCapacity() => ExecuteRequest<double, DoubleResponse>(BuildGetFullWellCapacityRequest);
        public async Task<double> GetFullWellCapacityAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetFullWellCapacityRequest);
        private RestRequest BuildGetFullWellCapacityRequest() => RequestBuilder.BuildRestRequest(CameraMethod.FullWellCapacity, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetGain() => ExecuteRequest<int, IntResponse>(BuildGetGainRequest);
        public async Task<int> GetGainAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetGainRequest);
        private RestRequest BuildGetGainRequest() => RequestBuilder.BuildRestRequest(CameraMethod.Gain, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetGain(int gain) => ExecuteRequest(BuildSetGainRequest, gain);
        public async Task SetGainAsync(int gain) => await ExecuteRequestAsync(BuildSetGainRequest, gain);
        private RestRequest BuildSetGainRequest(int gain)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.Gain, gain.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.Gain, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public int GetGainMax() => ExecuteRequest<int, IntResponse>(BuildGetGainMaxRequest);
        public async Task<int> GetGainMaxAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetGainMaxRequest);
        private RestRequest BuildGetGainMaxRequest() => RequestBuilder.BuildRestRequest(CameraMethod.GainMax, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetGainMin() => ExecuteRequest<int, IntResponse>(BuildGetGainMinRequest);
        public async Task<int> GetGainMinAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetGainMinRequest);
        private RestRequest BuildGetGainMinRequest() => RequestBuilder.BuildRestRequest(CameraMethod.GainMin, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public List<string> GetGains() => ExecuteRequest<List<string>, StringArrayResponse>(BuildGetGainsRequest);
        public async Task<List<string>> GetGainsAsync() => await ExecuteRequestAsync<List<string>, StringArrayResponse>(BuildGetGainsRequest);
        private RestRequest BuildGetGainsRequest() => RequestBuilder.BuildRestRequest(CameraMethod.Gains, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool HasShutter() => ExecuteRequest<bool, BoolResponse>(BuildHasShutterRequest);
        public async Task<bool> HasShutterAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildHasShutterRequest);
        private RestRequest BuildHasShutterRequest() => RequestBuilder.BuildRestRequest(CameraMethod.HasShutter, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetHeatSinkTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetHeatSinkTemperatureRequest);
        public async Task<double> GetHeatSinkTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetHeatSinkTemperatureRequest);
        private RestRequest BuildGetHeatSinkTemperatureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.HeatSinkTemperature, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        
        
        public Array GetImageArray()
        {
            RestRequest request = BuildGetImageArrayRequest();
            IRestResponse response = CommandSender.ExecuteRequest(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        public async Task<Array> GetImageArrayAsync()
        {
            RestRequest request = BuildGetImageArrayRequest();
            IRestResponse response = await CommandSender.ExecuteRequestAsync(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        private RestRequest BuildGetImageArrayRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ImageArray, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public Array GetImageArrayVariant()
        {
            RestRequest request = BuildGetImageArrayVariantRequest();
            IRestResponse response = CommandSender.ExecuteRequest(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        public async Task<Array> GetImageArrayVariantAsync()
        {
            RestRequest request = BuildGetImageArrayVariantRequest();
            IRestResponse response = await CommandSender.ExecuteRequestAsync(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        private RestRequest BuildGetImageArrayVariantRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ImageArrayVariant, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        
        private Array ParseImageResponse(IRestResponse response)
        {
            (ImageArrayType type, int rank) = ParseTypeAndRank(response.Content);

            if (rank == 2)
            {
                return Parse2DImageResponse(response, type);
            }
            else if (rank == 3)
            {
                return Parse3DImageResponse(response, type);
            }
            else
            {
                throw new Exception($"Image rank {rank} is not supported");
            }
        }
        private (ImageArrayType type, int rank) ParseTypeAndRank(string jsonString)
        {
            string responseString = jsonString.Substring(0, 50);
            MatchCollection matches = Regex.Matches(responseString, "^{\\s*\"Type\":\\s*(\\d),\"Rank\":\\s*(\\d*)", RegexOptions.IgnoreCase);
            ImageArrayType type = (ImageArrayType)int.Parse(matches[0].Groups[1].Value);
            int rank = int.Parse(matches[0].Groups[2].Value);

            return (type, rank);
        }

        private static Array Parse3DImageResponse(IRestResponse response, ImageArrayType type)
        {
            switch (type)
            {
                case ImageArrayType.Int:
                    var imageArrayInt3DResponse = JsonConvert.DeserializeObject<ImageArrayInt3DResponse>(response.Content);
                    return imageArrayInt3DResponse.HandleResponse<Array, ImageArrayInt3DResponse>();

                case ImageArrayType.Short:
                    var imageArrayShort3DResponse = JsonConvert.DeserializeObject<ImageArrayShort3DResponse>(response.Content);
                    return imageArrayShort3DResponse.HandleResponse<Array, ImageArrayShort3DResponse>();

                case ImageArrayType.Double:
                    var imageArrayDouble3DResponse = JsonConvert.DeserializeObject<ImageArrayDouble3DResponse>(response.Content);
                    return imageArrayDouble3DResponse.HandleResponse<Array, ImageArrayDouble3DResponse>();

                default:
                    throw new NotImplementedException();
            }
        }

        private static Array Parse2DImageResponse(IRestResponse response, ImageArrayType type)
        {
            switch (type)
            {
                case ImageArrayType.Int:
                    var imageArrayInt2DResponse = JsonConvert.DeserializeObject<ImageArrayInt2DResponse>(response.Content);
                    return imageArrayInt2DResponse.HandleResponse<Array, ImageArrayInt2DResponse>();

                case ImageArrayType.Short:
                    var imageArrayShort2DResponse = JsonConvert.DeserializeObject<ImageArrayShort2DResponse>(response.Content);
                    return imageArrayShort2DResponse.HandleResponse<Array, ImageArrayShort2DResponse>();

                case ImageArrayType.Double:
                    var imageArrayDouble2DResponse = JsonConvert.DeserializeObject<ImageArrayDouble2DResponse>(response.Content);
                    return imageArrayDouble2DResponse.HandleResponse<Array, ImageArrayDouble2DResponse>();

                default:
                    throw new NotImplementedException();
            }
        }

        public bool IsImageReady() => ExecuteRequest<bool, BoolResponse>(BuildIsImageReadyRequest);
        public async Task<bool> IsImageReadyAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsImageReadyRequest);
        private RestRequest BuildIsImageReadyRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ImageReady, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool IsPulseGuiding() => ExecuteRequest<bool, BoolResponse>(BuildIsPulseGuidingRequest);
        public async Task<bool> IsPulseGuidingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsPulseGuidingRequest);
        private RestRequest BuildIsPulseGuidingRequest() => RequestBuilder.BuildRestRequest(CameraMethod.IsPulseGuiding, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetLastExposureDuration() => ExecuteRequest<double, DoubleResponse>(BuildGetLastExposureDurationRequest);
        public async Task<double> GetLastExposureDurationAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetLastExposureDurationRequest);
        private RestRequest BuildGetLastExposureDurationRequest() => RequestBuilder.BuildRestRequest(CameraMethod.LastExposureDuration, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public DateTime GetLastExposureStartTime()
        {
            string dateTimeString = ExecuteRequest<string, StringResponse>(BuildGetLastExposureStartTimeRequest);
            return DateTime.Parse(dateTimeString);
        }
        public async Task<DateTime> GetLastExposureStartTimeAsync()
        {
            string dateTimeString = await ExecuteRequestAsync<string, StringResponse>(BuildGetLastExposureStartTimeRequest);
            return DateTime.Parse(dateTimeString);
        }
        private RestRequest BuildGetLastExposureStartTimeRequest() => RequestBuilder.BuildRestRequest(CameraMethod.LastExposureStartTime, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetMaxADU() => ExecuteRequest<int, IntResponse>(BuildGetMaxADURequest);
        public async Task<int> GetMaxADUAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxADURequest);
        private RestRequest BuildGetMaxADURequest() => RequestBuilder.BuildRestRequest(CameraMethod.MaxADU, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetMaxBinX() => ExecuteRequest<int, IntResponse>(BuildGetMaxBinXRequest);
        public async Task<int> GetMaxBinXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxBinXRequest);
        private RestRequest BuildGetMaxBinXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.MaxBinX, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetMaxBinY() => ExecuteRequest<int, IntResponse>(BuildGetMaxBinYRequest);
        public async Task<int> GetMaxBinYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxBinYRequest);
        private RestRequest BuildGetMaxBinYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.MaxBinY, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetNumX() => ExecuteRequest<int, IntResponse>(BuildGetNumXRequest);
        public async Task<int> GetNumXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetNumXRequest);
        private RestRequest BuildGetNumXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.NumX, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetNumX(int numX) => ExecuteRequest(BuildSetNumXRequest, numX);
        public async Task SetNumXAsync(int numX) => await ExecuteRequestAsync(BuildSetNumXRequest, numX);
        private RestRequest BuildSetNumXRequest(int numX)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.NumX, numX.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.NumX, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public int GetNumY() => ExecuteRequest<int, IntResponse>(BuildGetNumYRequest);
        public async Task<int> GetNumYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetNumYRequest);
        private RestRequest BuildGetNumYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.NumY, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetNumY(int numY) => ExecuteRequest(BuildSetNumYRequest, numY);
        public async Task SetNumYAsync(int numY) => await ExecuteRequestAsync(BuildSetNumYRequest, numY);
        private RestRequest BuildSetNumYRequest(int numY)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.NumY, numY.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.NumY, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public int GetPercentCompleted() => ExecuteRequest<int, IntResponse>(BuildGetPercentCompletedRequest);
        public async Task<int> GetPercentCompletedAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetPercentCompletedRequest);
        private RestRequest BuildGetPercentCompletedRequest() => RequestBuilder.BuildRestRequest(CameraMethod.PercentCompleted, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetPixelSizeX() => ExecuteRequest<double, DoubleResponse>(BuildGetPixelSizeXRequest);
        public async Task<double> GetPixelSizeXAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPixelSizeXRequest);
        private RestRequest BuildGetPixelSizeXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.PixelSizeX, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetPixelSizeY() => ExecuteRequest<double, DoubleResponse>(BuildGetPixelSizeYRequest);
        public async Task<double> GetPixelSizeYAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPixelSizeYRequest);
        private RestRequest BuildGetPixelSizeYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.PixelSizeY, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetReadoutMode() => ExecuteRequest<int, IntResponse>(BuildGetReadoutModeRequest);
        public async Task<int> GetReadoutModeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetReadoutModeRequest);
        private RestRequest BuildGetReadoutModeRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ReadoutMode, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public List<string> GetReadoutModes() => ExecuteRequest<List<string>, StringArrayResponse>(BuildGetReadoutModesRequest);
        public async Task<List<string>> GetReadoutModesAsync() => await ExecuteRequestAsync<List<string>, StringArrayResponse>(BuildGetReadoutModesRequest);
        private RestRequest BuildGetReadoutModesRequest() => RequestBuilder.BuildRestRequest(CameraMethod.ReadoutModes, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public string GetSensorName() => ExecuteRequest<string, StringResponse>(BuildGetSensorNameRequest);
        public async Task<string> GetSensorNameAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetSensorNameRequest);
        private RestRequest BuildGetSensorNameRequest() => RequestBuilder.BuildRestRequest(CameraMethod.SensorName, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public SensorType GetSensorType() => ExecuteRequest<SensorType, ValueResponse<SensorType>>(BuildGetSensorTypeRequest);
        public async Task<SensorType> GetSensorTypeAsync() => await ExecuteRequestAsync<SensorType, ValueResponse<SensorType>>(BuildGetSensorTypeRequest);
        private RestRequest BuildGetSensorTypeRequest() => RequestBuilder.BuildRestRequest(CameraMethod.SensorType, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetCCDTemperatureSetPoint() => ExecuteRequest<double, DoubleResponse>(BuildGetCCDTemperatureSetPointRequest);
        public async Task<double> GetCCDTemperatureSetPointAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCCDTemperatureSetPointRequest);
        private RestRequest BuildGetCCDTemperatureSetPointRequest() => RequestBuilder.BuildRestRequest(CameraMethod.SetCCDTemperature, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetCCDTemperatureSetPoint(double temperature) => ExecuteRequest(BuildSetCCDTemperatureSetPointRequest, temperature);
        public async Task SetCCDTemperatureSetPointAsync(double temperature) => await ExecuteRequestAsync(BuildSetCCDTemperatureSetPointRequest, temperature);
        private RestRequest BuildSetCCDTemperatureSetPointRequest(double temperature)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.SetCCDTemperature , temperature.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.SetCCDTemperature , Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public int GetStartX() => ExecuteRequest<int, IntResponse>(BuildGetStartXRequest);
        public async Task<int> GetStartXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetStartXRequest);
        private RestRequest BuildGetStartXRequest() => RequestBuilder.BuildRestRequest(CameraMethod.StartX, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetStartX(int startX) => ExecuteRequest(BuildSetStartXRequest, startX);
        public async Task SetStartXAsync(int startX) => await ExecuteRequestAsync(BuildSetStartXRequest, startX);
        private RestRequest BuildSetStartXRequest(int startX)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.StartX , startX.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.StartX, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public int GetStartY() => ExecuteRequest<int, IntResponse>(BuildGetStartYRequest);
        public async Task<int> GetStartYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetStartXRequest);
        private RestRequest BuildGetStartYRequest() => RequestBuilder.BuildRestRequest(CameraMethod.StartY, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetStartY(int startY) => ExecuteRequest(BuildSetStartYRequest, startY);
        public async Task SetStartYAsync(int startY) => await ExecuteRequestAsync(BuildSetStartYRequest, startY);
        private RestRequest BuildSetStartYRequest(int startY)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.StartY , startY.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.StartY, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void AbortExposure() => ExecuteRequest(BuildAbortExposureRequest);
        public async Task AbortExposureAsync() => await ExecuteRequestAsync(BuildAbortExposureRequest);
        private RestRequest BuildAbortExposureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.AbortExposure, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

        public void PulseGuide(Direction direction, int duration) => ExecuteRequest(BuildPulseGuideRequest, direction, duration);
        public async Task PulseGuideAsync(Direction direction, int duration) => await ExecuteRequestAsync(BuildPulseGuideRequest, direction, duration);
        private RestRequest BuildPulseGuideRequest(Direction direction, int duration)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.Direction, direction.ToString()},
                {CameraRequestParameters.Duration , duration.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.PulseGuide, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
        
        public void StartExposure(double duration, bool isLight) => ExecuteRequest(BuildStartExposureRequest, duration, isLight);
        public async Task StartExposureAsync(double duration, bool isLight) => await ExecuteRequestAsync(BuildStartExposureRequest, duration, isLight);
        private RestRequest BuildStartExposureRequest(double duration, bool isLight)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraRequestParameters.Duration, duration.ToString(CultureInfo.InvariantCulture)},
                {CameraRequestParameters.Light , isLight.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraMethod.StartExposure, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void StopExposure() => ExecuteRequest(BuildStopExposureRequest);
        public async Task StopExposureAsync() => await ExecuteRequestAsync(BuildStopExposureRequest);
        private RestRequest BuildStopExposureRequest() => RequestBuilder.BuildRestRequest(CameraMethod.StopExposure, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());
    }
}