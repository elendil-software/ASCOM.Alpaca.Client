using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ES.Ascom.Alpaca.Client.Logging;
using ES.Ascom.Alpaca.Client.Request;
using ES.Ascom.Alpaca.Client.Responses;
using ES.Ascom.Alpaca.Devices;
using ES.Ascom.Alpaca.Exceptions;
using ES.Ascom.Alpaca.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace ES.Ascom.Alpaca.Client.Devices
{
    /// <summary>
    /// Client implementation of an ASCOM Alpaca Camera device.
    /// <para>This class is meant to be use in a client application that need to control an ASCOM Alpaca Camera</para>
    /// </summary>
    public sealed class Camera : DeviceBase, ICamera, ICameraAsync
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Camera" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        public Camera(DeviceConfiguration configuration) : base(configuration)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Camera" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public Camera(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Camera" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        public Camera(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Camera" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public Camera(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        internal Camera(DeviceConfiguration configuration, ICommandSender commandSender) : 
            base(configuration, commandSender)
        {
        }

        internal Camera(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : 
            base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }
        
        /// <inheritdoc/>
        protected override DeviceType DeviceType { get; } = DeviceType.Camera;

        /// <inheritdoc/>
        public int GetBayerOffsetX() => ExecuteRequest<int, IntResponse>(BuildGetBayerOffsetXRequest);
        /// <inheritdoc/>
        public async Task<int> GetBayerOffsetXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBayerOffsetXRequest);
        private IRestRequest BuildGetBayerOffsetXRequest() => RequestBuilder.BuildRestRequest(CameraCommand.BayerOffsetX, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetBayerOffsetY() => ExecuteRequest<int, IntResponse>(BuildGetBayerOffsetYRequest);
        /// <inheritdoc/>
        public async Task<int> GetBayerOffsetYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBayerOffsetYRequest);
        private IRestRequest BuildGetBayerOffsetYRequest() => RequestBuilder.BuildRestRequest(CameraCommand.BayerOffsetY, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetBinX() => ExecuteRequest<int, IntResponse>(BuildGetBinXRequest);
        /// <inheritdoc/>
        public async Task<int> GetBinXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBinXRequest);
        private IRestRequest BuildGetBinXRequest() => RequestBuilder.BuildRestRequest(CameraCommand.BinX, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetBinX(int binX) => ExecuteRequest(BuildSetBinXRequest, binX);
        /// <inheritdoc/>
        public async Task SetBinXAsync(int binX) => await ExecuteRequestAsync(BuildSetBinXRequest, binX);
        private IRestRequest BuildSetBinXRequest(int binX)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.BinX, binX.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.BinX, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public int GetBinY() => ExecuteRequest<int, IntResponse>(BuildGetBinYRequest);
        /// <inheritdoc/>
        public async Task<int> GetBinYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetBinYRequest);
        private IRestRequest BuildGetBinYRequest() => RequestBuilder.BuildRestRequest(CameraCommand.BinY, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetBinY(int binY) => ExecuteRequest(BuildSetBinYRequest, binY);
        /// <inheritdoc/>
        public async Task SetBinYAsync(int binY) => await ExecuteRequestAsync(BuildSetBinYRequest, binY);
        private IRestRequest BuildSetBinYRequest(int binY)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.BinY, binY.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.BinY, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public CameraState GetCameraState() => ExecuteRequest<CameraState, CameraStateResponse>(BuildGetCameraStateRequest);
        /// <inheritdoc/>
        public async Task<CameraState> GetCameraStateAsync() => await ExecuteRequestAsync<CameraState, CameraStateResponse>(BuildGetCameraStateRequest);
        private IRestRequest BuildGetCameraStateRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CameraState, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetCameraXSize() => ExecuteRequest<int, IntResponse>(BuildGetCameraXSizeRequest);
        /// <inheritdoc/>
        public async Task<int> GetCameraXSizeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetCameraXSizeRequest);
        private IRestRequest BuildGetCameraXSizeRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CameraXSize, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetCameraYSize() => ExecuteRequest<int, IntResponse>(BuildGetCameraYSizeRequest);
        /// <inheritdoc/>
        public async Task<int> GetCameraYSizeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetCameraYSizeRequest);
        private IRestRequest BuildGetCameraYSizeRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CameraYSize, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanAbortExposure() => ExecuteRequest<bool, BoolResponse>(BuildCanAbortExposureRequest);
        /// <inheritdoc/>
        public async Task<bool> CanAbortExposureAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanAbortExposureRequest);
        private IRestRequest BuildCanAbortExposureRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CanAbortExposure, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanAsymmetricBin() => ExecuteRequest<bool, BoolResponse>(BuildCanAsymmetricBinRequest);
        /// <inheritdoc/>
        public async Task<bool> CanAsymmetricBinAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanAsymmetricBinRequest);
        private IRestRequest BuildCanAsymmetricBinRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CanAsymmetricBin, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool CanFastReadout() => ExecuteRequest<bool, BoolResponse>(BuildCanFastReadoutRequest);
        /// <inheritdoc/>
        public async Task<bool> CanFastReadoutAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanFastReadoutRequest);
        private IRestRequest BuildCanFastReadoutRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CanFastReadout, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanGetCoolerPower() => ExecuteRequest<bool, BoolResponse>(BuildCanGetCoolerPowerRequest);
        /// <inheritdoc/>
        public async Task<bool> CanGetCoolerPowerAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanGetCoolerPowerRequest);
        private IRestRequest BuildCanGetCoolerPowerRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CanGetCoolerPower, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanPulseGuide() => ExecuteRequest<bool, BoolResponse>(BuildCanPulseGuideRequest);
        /// <inheritdoc/>
        public async Task<bool> CanPulseGuideAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanPulseGuideRequest);
        private IRestRequest BuildCanPulseGuideRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CanPulseGuide, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanSetCCDTemperature() => ExecuteRequest<bool, BoolResponse>(BuildCanSetCCDTemperatureRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSetCCDTemperatureAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetCCDTemperatureRequest);
        private IRestRequest BuildCanSetCCDTemperatureRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CanSetCCDTemperature, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanStopExposure() => ExecuteRequest<bool, BoolResponse>(BuildCanStopExposureRequest);
        /// <inheritdoc/>
        public async Task<bool> CanStopExposureAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanStopExposureRequest);
        private IRestRequest BuildCanStopExposureRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CanStopExposure, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetCCDTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetCCDTemperatureRequest);
        /// <inheritdoc/>
        public async Task<double> GetCCDTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCCDTemperatureRequest);
        private IRestRequest BuildGetCCDTemperatureRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CCDTemperature, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool IsCoolerOn() => ExecuteRequest<bool, BoolResponse>(BuildIsCoolerOnRequest);
        /// <inheritdoc/>
        public async Task<bool> IsCoolerOnAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsCoolerOnRequest);
        private IRestRequest BuildIsCoolerOnRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CoolerOn, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetCoolerOn(bool coolerOn) => ExecuteRequest(BuildSetCoolerOnRequest, coolerOn);
        /// <inheritdoc/>
        public async Task SetCoolerOnAsync(bool coolerOn) => await ExecuteRequestAsync(BuildSetCoolerOnRequest, coolerOn);
        private IRestRequest BuildSetCoolerOnRequest(bool coolerOn)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.CoolerOn, coolerOn.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.CoolerOn, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetCoolerPower() => ExecuteRequest<double, DoubleResponse>(BuildGetCoolerPowerRequest);
        /// <inheritdoc/>
        public async Task<double> GetCoolerPowerAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCoolerPowerRequest);
        private IRestRequest BuildGetCoolerPowerRequest() => RequestBuilder.BuildRestRequest(CameraCommand.CoolerPower, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetElectronPerADU() => ExecuteRequest<double, DoubleResponse>(BuildGetElectronPerADURequest);
        /// <inheritdoc/>
        public async Task<double> GetElectronPerADUAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetElectronPerADURequest);
        private IRestRequest BuildGetElectronPerADURequest() => RequestBuilder.BuildRestRequest(CameraCommand.ElectronsPerADU, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetExposureMax() => ExecuteRequest<double, DoubleResponse>(BuildGetExposureMaxRequest);
        /// <inheritdoc/>
        public async Task<double> GetExposureMaxAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetExposureMaxRequest);
        private IRestRequest BuildGetExposureMaxRequest() => RequestBuilder.BuildRestRequest(CameraCommand.ExposureMax, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetExposureMin() => ExecuteRequest<double, DoubleResponse>(BuildGetExposureMinRequest);
        /// <inheritdoc/>
        public async Task<double> GetExposureMinAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetExposureMinRequest);
        private IRestRequest BuildGetExposureMinRequest() => RequestBuilder.BuildRestRequest(CameraCommand.ExposureMin, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetExposureResolution() => ExecuteRequest<double, DoubleResponse>(BuildGetExposureResolutionRequest);
        /// <inheritdoc/>
        public async Task<double> GetExposureResolutionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetExposureResolutionRequest);
        private IRestRequest BuildGetExposureResolutionRequest() => RequestBuilder.BuildRestRequest(CameraCommand.ExposureResolution, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool IsFastReadout() => ExecuteRequest<bool, BoolResponse>(BuildIsFastReadoutRequest);
        /// <inheritdoc/>
        public async Task<bool> IsFastReadoutAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsFastReadoutRequest);
        private IRestRequest BuildIsFastReadoutRequest() => RequestBuilder.BuildRestRequest(CameraCommand.FastReadout, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetFastReadout(bool fastReadout) => ExecuteRequest(BuildSetFastReadoutRequest, fastReadout);
        /// <inheritdoc/>
        public async Task SetFastReadoutAsync(bool fastReadout) => await ExecuteRequestAsync(BuildSetFastReadoutRequest, fastReadout);
        private IRestRequest BuildSetFastReadoutRequest(bool fastReadout)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.FastReadout, fastReadout.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.FastReadout, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetFullWellCapacity() => ExecuteRequest<double, DoubleResponse>(BuildGetFullWellCapacityRequest);
        /// <inheritdoc/>
        public async Task<double> GetFullWellCapacityAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetFullWellCapacityRequest);
        private IRestRequest BuildGetFullWellCapacityRequest() => RequestBuilder.BuildRestRequest(CameraCommand.FullWellCapacity, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetGain() => ExecuteRequest<int, IntResponse>(BuildGetGainRequest);
        /// <inheritdoc/>
        public async Task<int> GetGainAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetGainRequest);
        private IRestRequest BuildGetGainRequest() => RequestBuilder.BuildRestRequest(CameraCommand.Gain, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetGain(int gain) => ExecuteRequest(BuildSetGainRequest, gain);
        /// <inheritdoc/>
        public async Task SetGainAsync(int gain) => await ExecuteRequestAsync(BuildSetGainRequest, gain);
        private IRestRequest BuildSetGainRequest(int gain)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.Gain, gain.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.Gain, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public int GetGainMax() => ExecuteRequest<int, IntResponse>(BuildGetGainMaxRequest);
        /// <inheritdoc/>
        public async Task<int> GetGainMaxAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetGainMaxRequest);
        private IRestRequest BuildGetGainMaxRequest() => RequestBuilder.BuildRestRequest(CameraCommand.GainMax, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetGainMin() => ExecuteRequest<int, IntResponse>(BuildGetGainMinRequest);
        /// <inheritdoc/>
        public async Task<int> GetGainMinAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetGainMinRequest);
        private IRestRequest BuildGetGainMinRequest() => RequestBuilder.BuildRestRequest(CameraCommand.GainMin, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public IList<string> GetGains() => ExecuteRequest<IList<string>, StringListResponse>(BuildGetGainsRequest);
        /// <inheritdoc/>
        public async Task<IList<string>> GetGainsAsync() => await ExecuteRequestAsync<IList<string>, StringListResponse>(BuildGetGainsRequest);
        private IRestRequest BuildGetGainsRequest() => RequestBuilder.BuildRestRequest(CameraCommand.Gains, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool HasShutter() => ExecuteRequest<bool, BoolResponse>(BuildHasShutterRequest);
        /// <inheritdoc/>
        public async Task<bool> HasShutterAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildHasShutterRequest);
        private IRestRequest BuildHasShutterRequest() => RequestBuilder.BuildRestRequest(CameraCommand.HasShutter, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetHeatSinkTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetHeatSinkTemperatureRequest);
        /// <inheritdoc/>
        public async Task<double> GetHeatSinkTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetHeatSinkTemperatureRequest);
        private IRestRequest BuildGetHeatSinkTemperatureRequest() => RequestBuilder.BuildRestRequest(CameraCommand.HeatSinkTemperature, Method.GET, GetClientTransactionId());

        
        
        /// <inheritdoc/>
        public Array GetImageArray()
        {
            IRestRequest request = BuildGetImageArrayRequest();
            IRestResponse response = CommandSender.ExecuteRequest(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        /// <inheritdoc/>
        public async Task<Array> GetImageArrayAsync()
        {
            IRestRequest request = BuildGetImageArrayRequest();
            IRestResponse response = await CommandSender.ExecuteRequestAsync(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        private IRestRequest BuildGetImageArrayRequest() => RequestBuilder.BuildRestRequest(CameraCommand.ImageArray, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public Array GetImageArrayVariant()
        {
            IRestRequest request = BuildGetImageArrayVariantRequest();
            IRestResponse response = CommandSender.ExecuteRequest(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        /// <inheritdoc/>
        public async Task<Array> GetImageArrayVariantAsync()
        {
            IRestRequest request = BuildGetImageArrayVariantRequest();
            IRestResponse response = await CommandSender.ExecuteRequestAsync(Configuration.GetBaseUrl(), request);
            return ParseImageResponse(response);
        }
        private IRestRequest BuildGetImageArrayVariantRequest() => RequestBuilder.BuildRestRequest(CameraCommand.ImageArrayVariant, Method.GET, GetClientTransactionId());

        
        private Array ParseImageResponse(IRestResponse response)
        {
            (ImageArrayType type, int rank) = ParseTypeAndRank(response.Content);

            if (rank == 2)
            {
                return Parse2DImageResponse(response, type);
            }

            if (rank == 3)
            {
                return Parse3DImageResponse(response, type);
            }

            throw new AlpacaInvalidValueException($"Image rank {rank} is not supported");
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
                    return imageArrayInt3DResponse.HandleResponse<int[,,], ImageArrayInt3DResponse>();

                case ImageArrayType.Short:
                    var imageArrayShort3DResponse = JsonConvert.DeserializeObject<ImageArrayShort3DResponse>(response.Content);
                    return imageArrayShort3DResponse.HandleResponse<short[,,], ImageArrayShort3DResponse>();

                case ImageArrayType.Double:
                    var imageArrayDouble3DResponse = JsonConvert.DeserializeObject<ImageArrayDouble3DResponse>(response.Content);
                    return imageArrayDouble3DResponse.HandleResponse<double[,,], ImageArrayDouble3DResponse>();

                default:
                    throw new AlpacaInvalidValueException($"'ImageArrayType '{type} ({(int)type})' is not a valid value");
            }
        }

        private static Array Parse2DImageResponse(IRestResponse response, ImageArrayType type)
        {
            switch (type)
            {
                case ImageArrayType.Int:
                    var imageArrayInt2DResponse = JsonConvert.DeserializeObject<ImageArrayInt2DResponse>(response.Content);
                    return imageArrayInt2DResponse.HandleResponse<int[,], ImageArrayInt2DResponse>();

                case ImageArrayType.Short:
                    var imageArrayShort2DResponse = JsonConvert.DeserializeObject<ImageArrayShort2DResponse>(response.Content);
                    return imageArrayShort2DResponse.HandleResponse<short[,], ImageArrayShort2DResponse>();

                case ImageArrayType.Double:
                    var imageArrayDouble2DResponse = JsonConvert.DeserializeObject<ImageArrayDouble2DResponse>(response.Content);
                    return imageArrayDouble2DResponse.HandleResponse<double[,], ImageArrayDouble2DResponse>();

                default:
                    throw new AlpacaInvalidValueException($"'ImageArrayType '{type} ({(int)type})' is not a valid value");
            }
        }

        /// <inheritdoc/>
        public bool IsImageReady() => ExecuteRequest<bool, BoolResponse>(BuildIsImageReadyRequest);
        /// <inheritdoc/>
        public async Task<bool> IsImageReadyAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsImageReadyRequest);
        private IRestRequest BuildIsImageReadyRequest() => RequestBuilder.BuildRestRequest(CameraCommand.ImageReady, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool IsPulseGuiding() => ExecuteRequest<bool, BoolResponse>(BuildIsPulseGuidingRequest);
        /// <inheritdoc/>
        public async Task<bool> IsPulseGuidingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsPulseGuidingRequest);
        private IRestRequest BuildIsPulseGuidingRequest() => RequestBuilder.BuildRestRequest(CameraCommand.IsPulseGuiding, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetLastExposureDuration() => ExecuteRequest<double, DoubleResponse>(BuildGetLastExposureDurationRequest);
        /// <inheritdoc/>
        public async Task<double> GetLastExposureDurationAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetLastExposureDurationRequest);
        private IRestRequest BuildGetLastExposureDurationRequest() => RequestBuilder.BuildRestRequest(CameraCommand.LastExposureDuration, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public DateTime GetLastExposureStartTime()
        {
            string dateTimeString = ExecuteRequest<string, StringResponse>(BuildGetLastExposureStartTimeRequest);
            return DateTime.Parse(dateTimeString);
        }
        /// <inheritdoc/>
        public async Task<DateTime> GetLastExposureStartTimeAsync()
        {
            string dateTimeString = await ExecuteRequestAsync<string, StringResponse>(BuildGetLastExposureStartTimeRequest);
            return DateTime.Parse(dateTimeString);
        }
        private IRestRequest BuildGetLastExposureStartTimeRequest() => RequestBuilder.BuildRestRequest(CameraCommand.LastExposureStartTime, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetMaxADU() => ExecuteRequest<int, IntResponse>(BuildGetMaxADURequest);
        /// <inheritdoc/>
        public async Task<int> GetMaxADUAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxADURequest);
        private IRestRequest BuildGetMaxADURequest() => RequestBuilder.BuildRestRequest(CameraCommand.MaxADU, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetMaxBinX() => ExecuteRequest<int, IntResponse>(BuildGetMaxBinXRequest);
        /// <inheritdoc/>
        public async Task<int> GetMaxBinXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxBinXRequest);
        private IRestRequest BuildGetMaxBinXRequest() => RequestBuilder.BuildRestRequest(CameraCommand.MaxBinX, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetMaxBinY() => ExecuteRequest<int, IntResponse>(BuildGetMaxBinYRequest);
        /// <inheritdoc/>
        public async Task<int> GetMaxBinYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxBinYRequest);
        private IRestRequest BuildGetMaxBinYRequest() => RequestBuilder.BuildRestRequest(CameraCommand.MaxBinY, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetNumX() => ExecuteRequest<int, IntResponse>(BuildGetNumXRequest);
        /// <inheritdoc/>
        public async Task<int> GetNumXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetNumXRequest);
        private IRestRequest BuildGetNumXRequest() => RequestBuilder.BuildRestRequest(CameraCommand.NumX, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetNumX(int numX) => ExecuteRequest(BuildSetNumXRequest, numX);
        /// <inheritdoc/>
        public async Task SetNumXAsync(int numX) => await ExecuteRequestAsync(BuildSetNumXRequest, numX);
        private IRestRequest BuildSetNumXRequest(int numX)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.NumX, numX.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.NumX, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public int GetNumY() => ExecuteRequest<int, IntResponse>(BuildGetNumYRequest);
        /// <inheritdoc/>
        public async Task<int> GetNumYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetNumYRequest);
        private IRestRequest BuildGetNumYRequest() => RequestBuilder.BuildRestRequest(CameraCommand.NumY, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetNumY(int numY) => ExecuteRequest(BuildSetNumYRequest, numY);
        /// <inheritdoc/>
        public async Task SetNumYAsync(int numY) => await ExecuteRequestAsync(BuildSetNumYRequest, numY);
        private IRestRequest BuildSetNumYRequest(int numY)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.NumY, numY.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.NumY, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public int GetPercentCompleted() => ExecuteRequest<int, IntResponse>(BuildGetPercentCompletedRequest);
        /// <inheritdoc/>
        public async Task<int> GetPercentCompletedAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetPercentCompletedRequest);
        private IRestRequest BuildGetPercentCompletedRequest() => RequestBuilder.BuildRestRequest(CameraCommand.PercentCompleted, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetPixelSizeX() => ExecuteRequest<double, DoubleResponse>(BuildGetPixelSizeXRequest);
        /// <inheritdoc/>
        public async Task<double> GetPixelSizeXAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPixelSizeXRequest);
        private IRestRequest BuildGetPixelSizeXRequest() => RequestBuilder.BuildRestRequest(CameraCommand.PixelSizeX, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetPixelSizeY() => ExecuteRequest<double, DoubleResponse>(BuildGetPixelSizeYRequest);
        /// <inheritdoc/>
        public async Task<double> GetPixelSizeYAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPixelSizeYRequest);
        private IRestRequest BuildGetPixelSizeYRequest() => RequestBuilder.BuildRestRequest(CameraCommand.PixelSizeY, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetReadoutMode() => ExecuteRequest<int, IntResponse>(BuildGetReadoutModeRequest);
        /// <inheritdoc/>
        public async Task<int> GetReadoutModeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetReadoutModeRequest);
        private IRestRequest BuildGetReadoutModeRequest() => RequestBuilder.BuildRestRequest(CameraCommand.ReadoutMode, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetReadoutMode(int readoutMode) => ExecuteRequest(BuildSetReadoutModeRequest, readoutMode);
        /// <inheritdoc/>
        public async Task SetReadoutModeAsync(int readoutMode) => await ExecuteRequestAsync(BuildSetReadoutModeRequest, readoutMode);
        private IRestRequest BuildSetReadoutModeRequest(int readoutMode)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.ReadoutMode, readoutMode.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.ReadoutMode, Method.PUT, parameters, GetClientTransactionId());
        }
        
        /// <inheritdoc/>
        public IList<string> GetReadoutModes() => ExecuteRequest<IList<string>, StringListResponse>(BuildGetReadoutModesRequest);
        /// <inheritdoc/>
        public async Task<IList<string>> GetReadoutModesAsync() => await ExecuteRequestAsync<IList<string>, StringListResponse>(BuildGetReadoutModesRequest);
        private IRestRequest BuildGetReadoutModesRequest() => RequestBuilder.BuildRestRequest(CameraCommand.ReadoutModes, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public string GetSensorName() => ExecuteRequest<string, StringResponse>(BuildGetSensorNameRequest);
        /// <inheritdoc/>
        public async Task<string> GetSensorNameAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetSensorNameRequest);
        private IRestRequest BuildGetSensorNameRequest() => RequestBuilder.BuildRestRequest(CameraCommand.SensorName, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public SensorType GetSensorType() => ExecuteRequest<SensorType, SensorTypeResponse>(BuildGetSensorTypeRequest);
        /// <inheritdoc/>
        public async Task<SensorType> GetSensorTypeAsync() => await ExecuteRequestAsync<SensorType, SensorTypeResponse>(BuildGetSensorTypeRequest);
        private IRestRequest BuildGetSensorTypeRequest() => RequestBuilder.BuildRestRequest(CameraCommand.SensorType, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetCCDTemperatureSetPoint() => ExecuteRequest<double, DoubleResponse>(BuildGetCCDTemperatureSetPointRequest);
        /// <inheritdoc/>
        public async Task<double> GetCCDTemperatureSetPointAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCCDTemperatureSetPointRequest);
        private IRestRequest BuildGetCCDTemperatureSetPointRequest() => RequestBuilder.BuildRestRequest(CameraCommand.SetCCDTemperature, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetCCDTemperatureSetPoint(double temperature) => ExecuteRequest(BuildSetCCDTemperatureSetPointRequest, temperature);
        /// <inheritdoc/>
        public async Task SetCCDTemperatureSetPointAsync(double temperature) => await ExecuteRequestAsync(BuildSetCCDTemperatureSetPointRequest, temperature);
        private IRestRequest BuildSetCCDTemperatureSetPointRequest(double temperature)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.SetCCDTemperature , temperature.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.SetCCDTemperature , Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public int GetStartX() => ExecuteRequest<int, IntResponse>(BuildGetStartXRequest);
        /// <inheritdoc/>
        public async Task<int> GetStartXAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetStartXRequest);
        private IRestRequest BuildGetStartXRequest() => RequestBuilder.BuildRestRequest(CameraCommand.StartX, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetStartX(int startX) => ExecuteRequest(BuildSetStartXRequest, startX);
        /// <inheritdoc/>
        public async Task SetStartXAsync(int startX) => await ExecuteRequestAsync(BuildSetStartXRequest, startX);
        private IRestRequest BuildSetStartXRequest(int startX)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.StartX , startX.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.StartX, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public int GetStartY() => ExecuteRequest<int, IntResponse>(BuildGetStartYRequest);
        /// <inheritdoc/>
        public async Task<int> GetStartYAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetStartYRequest);
        private IRestRequest BuildGetStartYRequest() => RequestBuilder.BuildRestRequest(CameraCommand.StartY, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetStartY(int startY) => ExecuteRequest(BuildSetStartYRequest, startY);
        /// <inheritdoc/>
        public async Task SetStartYAsync(int startY) => await ExecuteRequestAsync(BuildSetStartYRequest, startY);
        private IRestRequest BuildSetStartYRequest(int startY)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.StartY , startY.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.StartY, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public void AbortExposure() => ExecuteRequest(BuildAbortExposureRequest);
        /// <inheritdoc/>
        public async Task AbortExposureAsync() => await ExecuteRequestAsync(BuildAbortExposureRequest);
        private IRestRequest BuildAbortExposureRequest() => RequestBuilder.BuildRestRequest(CameraCommand.AbortExposure, Method.PUT, GetClientTransactionId());

        /// <inheritdoc/>
        public void PulseGuide(GuideDirection direction, int duration) => ExecuteRequest(BuildPulseGuideRequest, direction, duration);
        /// <inheritdoc/>
        public async Task PulseGuideAsync(GuideDirection direction, int duration) => await ExecuteRequestAsync(BuildPulseGuideRequest, direction, duration);
        private IRestRequest BuildPulseGuideRequest(GuideDirection direction, int duration)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.Direction, direction.ToString()},
                {CameraCommandParameters.Duration , duration.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.PulseGuide, Method.PUT, parameters, GetClientTransactionId());
        }
        
        /// <inheritdoc/>
        public void StartExposure(double duration, bool isLight) => ExecuteRequest(BuildStartExposureRequest, duration, isLight);
        /// <inheritdoc/>
        public async Task StartExposureAsync(double duration, bool isLight) => await ExecuteRequestAsync(BuildStartExposureRequest, duration, isLight);
        private IRestRequest BuildStartExposureRequest(double duration, bool isLight)
        {
            var parameters = new Dictionary<string, object>
            {
                {CameraCommandParameters.Duration, duration.ToString(CultureInfo.InvariantCulture)},
                {CameraCommandParameters.Light , isLight.ToString()}
            };
            return RequestBuilder.BuildRestRequest(CameraCommand.StartExposure, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public void StopExposure() => ExecuteRequest(BuildStopExposureRequest);
        /// <inheritdoc/>
        public async Task StopExposureAsync() => await ExecuteRequestAsync(BuildStopExposureRequest);
        private IRestRequest BuildStopExposureRequest() => RequestBuilder.BuildRestRequest(CameraCommand.StopExposure, Method.PUT, GetClientTransactionId());
    }
}