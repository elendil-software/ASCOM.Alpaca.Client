using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Logging;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Responses;
using RestSharp;

namespace ES.AscomAlpaca.Client.Devices
{
    /// <summary>
    /// Client implementation of an ASCOM Alpaca Observing Conditions device.
    /// <para>This class is meant to be use in a client application that need to control an ASCOM Alpaca Observing Conditions</para>
    /// </summary>
    public sealed class ObservingConditions : DeviceBase, IObservingConditions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObservingConditions" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        public ObservingConditions(DeviceConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservingConditions" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public ObservingConditions(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservingConditions" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        public ObservingConditions(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservingConditions" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public ObservingConditions(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        internal ObservingConditions(DeviceConfiguration configuration, ICommandSender commandSender) : 
            base(configuration, commandSender)
        {
        }

        internal ObservingConditions(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : 
            base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }

        /// <inheritdoc/>
        protected override DeviceType DeviceType { get; } = DeviceType.ObservingConditions;
        
        /// <inheritdoc/>
        public double GetAveragePeriod() => ExecuteRequest<double, DoubleResponse>(BuildRequest); 
        /// <inheritdoc/>
        public async Task<double> GetAveragePeriodAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildRequest); 
        private IRestRequest BuildRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.AveragePeriod, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetAveragePeriod(double period) => ExecuteRequest(BuildSetAveragePeriodRequest, period);
        /// <inheritdoc/>
        public async Task SetAveragePeriodAsync(double period) => await ExecuteRequestAsync(BuildSetAveragePeriodRequest, period);
        private IRestRequest BuildSetAveragePeriodRequest(double period)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {ObservingConditionsCommandParameters.AveragePeriod, period.ToString(CultureInfo.InvariantCulture)}
            };
            
            return RequestBuilder.BuildRestRequest(ObservingConditionsCommand.AveragePeriod, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetCloudCover() => ExecuteRequest<double, DoubleResponse>(BuildGetCloudCoverRequest); 
        /// <inheritdoc/>
        public async Task<double> GetCloudCoverAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCloudCoverRequest); 
        private IRestRequest BuildGetCloudCoverRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.CloudCover, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetDewPoint() => ExecuteRequest<double, DoubleResponse>(BuildGetDewPointRequest); 
        /// <inheritdoc/>
        public async Task<double> GetDewPointAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetDewPointRequest); 
        private IRestRequest BuildGetDewPointRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.DewPoint, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetHumidity() => ExecuteRequest<double, DoubleResponse>(BuildGetHumidityRequest); 
        /// <inheritdoc/>
        public async Task<double> GetHumidityAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetHumidityRequest); 
        private IRestRequest BuildGetHumidityRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.Humidity, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetPressure() => ExecuteRequest<double, DoubleResponse>(BuildGetPressureRequest); 
        /// <inheritdoc/>
        public async Task<double> GetPressureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPressureRequest); 
        private IRestRequest BuildGetPressureRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.Pressure, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetRainRate() => ExecuteRequest<double, DoubleResponse>(BuildGetRainRateRequest); 
        /// <inheritdoc/>
        public async Task<double> GetRainRateAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetRainRateRequest); 
        private IRestRequest BuildGetRainRateRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.RainRate, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetSkyBrightness() => ExecuteRequest<double, DoubleResponse>(BuildGetSkyBrightnessRequest); 
        /// <inheritdoc/>
        public async Task<double> GetSkyBrightnessAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSkyBrightnessRequest); 
        private IRestRequest BuildGetSkyBrightnessRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.SkyBrightness, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetSkyQuality() => ExecuteRequest<double, DoubleResponse>(BuildGetSkyQualityRequest); 
        /// <inheritdoc/>
        public async Task<double> GetSkyQualityAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSkyQualityRequest); 
        private IRestRequest BuildGetSkyQualityRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.SkyQuality, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetSkyTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetSkyTemperatureRequest); 
        /// <inheritdoc/>
        public async Task<double> GetSkyTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSkyTemperatureRequest); 
        private IRestRequest BuildGetSkyTemperatureRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.SkyTemperature, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetStarFwhm() => ExecuteRequest<double, DoubleResponse>(BuildGetStarFwhmRequest); 
        /// <inheritdoc/>
        public async Task<double> GetStarFwhmAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetStarFwhmRequest); 
        private IRestRequest BuildGetStarFwhmRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.StarFWHM, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetTemperatureRequest); 
        /// <inheritdoc/>
        public async Task<double> GetTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTemperatureRequest); 
        private IRestRequest BuildGetTemperatureRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.Temperature, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetWindDirection() => ExecuteRequest<double, DoubleResponse>(BuildGetWindDirectionRequest); 
        /// <inheritdoc/>
        public async Task<double> GetWindDirectionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetWindDirectionRequest); 
        private IRestRequest BuildGetWindDirectionRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.WindDirection, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetWindGust() => ExecuteRequest<double, DoubleResponse>(BuildGetWindGustRequest); 
        /// <inheritdoc/>
        public async Task<double> GetWindGustAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetWindGustRequest);
        private IRestRequest BuildGetWindGustRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.WindGust, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetWindSpeed() => ExecuteRequest<double, DoubleResponse>(BuildGetWindSpeedRequest); 
        /// <inheritdoc/>
        public async Task<double> GetWindSpeedAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetWindSpeedRequest); 
        private IRestRequest BuildGetWindSpeedRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.WindSpeed, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void Refresh() => ExecuteRequest(BuildRefreshRequest);
        /// <inheritdoc/>
        public async Task RefreshAsync() => await ExecuteRequestAsync(BuildRefreshRequest);
        private IRestRequest BuildRefreshRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsCommand.Refresh, Method.PUT, GetClientTransactionId());

        /// <inheritdoc/>
        public string GetSensorDescription(ObservingConditionSensorName sensorName) => ExecuteRequest<string, StringResponse, ObservingConditionSensorName>(BuildGetSensorDescriptionRequest, sensorName); 
        /// <inheritdoc/>
        public async Task<string> GetSensorDescriptionAsync(ObservingConditionSensorName sensorName) => await ExecuteRequestAsync<string, StringResponse, ObservingConditionSensorName>(BuildGetSensorDescriptionRequest, sensorName);
        private IRestRequest BuildGetSensorDescriptionRequest(ObservingConditionSensorName sensorName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {ObservingConditionsCommandParameters.SensorName, sensorName.ToString()}
            };
            return RequestBuilder.BuildRestRequest(ObservingConditionsCommand.SensorDescription, Method.GET, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public TimeSpan GetTimeSinceLastUpdate(ObservingConditionSensorName sensorName)
        {
            double dateTimeString = ExecuteRequest<double, DoubleResponse, ObservingConditionSensorName>(BuildGetTimeSinceLastUpdateRequest, sensorName);
            return TimeSpan.FromSeconds(dateTimeString);
        }
        /// <inheritdoc/>
        public async Task<TimeSpan> GetTimeSinceLastUpdateAsync(ObservingConditionSensorName sensorName)
        {
            double dateTimeString = await ExecuteRequestAsync<double, DoubleResponse, ObservingConditionSensorName>(BuildGetTimeSinceLastUpdateRequest, sensorName);
            return TimeSpan.FromSeconds(dateTimeString);
        }
        private IRestRequest BuildGetTimeSinceLastUpdateRequest(ObservingConditionSensorName sensorName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {ObservingConditionsCommandParameters.SensorName, sensorName.ToString()}
            };
            return RequestBuilder.BuildRestRequest(ObservingConditionsCommand.TimeSinceLastUpdate, Method.GET, parameters, GetClientTransactionId());
        }
    }
}