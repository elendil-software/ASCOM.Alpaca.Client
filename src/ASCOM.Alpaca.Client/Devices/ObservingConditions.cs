using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Logging;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Transactions;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public sealed class ObservingConditions : DeviceBase, IObservingConditions
    {
        public ObservingConditions(DeviceConfiguration configuration) : base(configuration)
        {
        }

        public ObservingConditions(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        public ObservingConditions(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

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

        protected override DeviceType DeviceType { get; } = DeviceType.ObservingConditions;
        
        public double GetAveragePeriod() => ExecuteRequest<double, DoubleResponse>(BuildRequest); 
        public async Task<double> GetAveragePeriodAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildRequest); 
        private IRestRequest BuildRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.AveragePeriod, Method.GET, GetClientTransactionId());

        public void SetAveragePeriod(double period) => ExecuteRequest(BuildSetAveragePeriodRequest, period);
        public async Task SetAveragePeriodAsync(double period) => await ExecuteRequestAsync(BuildSetAveragePeriodRequest, period);
        private IRestRequest BuildSetAveragePeriodRequest(double period)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {ObservingConditionsParameters.AveragePeriod, period.ToString(CultureInfo.InvariantCulture)}
            };
            
            return RequestBuilder.BuildRestRequest(ObservingConditionsMethod.AveragePeriod, Method.PUT, parameters, GetClientTransactionId());
        }

        public double GetCloudCover() => ExecuteRequest<double, DoubleResponse>(BuildGetCloudCoverRequest); 
        public async Task<double> GetCloudCoverAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCloudCoverRequest); 
        private IRestRequest BuildGetCloudCoverRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.CloudCover, Method.GET, GetClientTransactionId());

        public double GetDewPoint() => ExecuteRequest<double, DoubleResponse>(BuildGetDewPointRequest); 
        public async Task<double> GetDewPointAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetDewPointRequest); 
        private IRestRequest BuildGetDewPointRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.DewPoint, Method.GET, GetClientTransactionId());

        public double GetHumidity() => ExecuteRequest<double, DoubleResponse>(BuildGetHumidityRequest); 
        public async Task<double> GetHumidityAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetHumidityRequest); 
        private IRestRequest BuildGetHumidityRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.Humidity, Method.GET, GetClientTransactionId());

        public double GetPressure() => ExecuteRequest<double, DoubleResponse>(BuildGetPressureRequest); 
        public async Task<double> GetPressureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPressureRequest); 
        private IRestRequest BuildGetPressureRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.Pressure, Method.GET, GetClientTransactionId());

        public double GetRainRate() => ExecuteRequest<double, DoubleResponse>(BuildGetRainRateRequest); 
        public async Task<double> GetRainRateAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetRainRateRequest); 
        private IRestRequest BuildGetRainRateRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.RainRate, Method.GET, GetClientTransactionId());

        public double GetSkyBrightness() => ExecuteRequest<double, DoubleResponse>(BuildGetSkyBrightnessRequest); 
        public async Task<double> GetSkyBrightnessAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSkyBrightnessRequest); 
        private IRestRequest BuildGetSkyBrightnessRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.SkyBrightness, Method.GET, GetClientTransactionId());

        public double GetSkyQuality() => ExecuteRequest<double, DoubleResponse>(BuildGetSkyQualityRequest); 
        public async Task<double> GetSkyQualityAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSkyQualityRequest); 
        private IRestRequest BuildGetSkyQualityRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.SkyQuality, Method.GET, GetClientTransactionId());

        public double GetSkyTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetSkyTemperatureRequest); 
        public async Task<double> GetSkyTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSkyTemperatureRequest); 
        private IRestRequest BuildGetSkyTemperatureRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.SkyTemperature, Method.GET, GetClientTransactionId());

        public double GetStarFwhm() => ExecuteRequest<double, DoubleResponse>(BuildGetStarFwhmRequest); 
        public async Task<double> GetStarFwhmAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetStarFwhmRequest); 
        private IRestRequest BuildGetStarFwhmRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.StarFWHM, Method.GET, GetClientTransactionId());

        public double GetTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetTemperatureRequest); 
        public async Task<double> GetTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTemperatureRequest); 
        private IRestRequest BuildGetTemperatureRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.Temperature, Method.GET, GetClientTransactionId());

        public double GetWindDirection() => ExecuteRequest<double, DoubleResponse>(BuildGetWindDirectionRequest); 
        public async Task<double> GetWindDirectionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetWindDirectionRequest); 
        private IRestRequest BuildGetWindDirectionRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.WindDirection, Method.GET, GetClientTransactionId());

        public double GetWindGust() => ExecuteRequest<double, DoubleResponse>(BuildGetWindGustRequest); 
        public async Task<double> GetWindGustAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetWindGustRequest);
        private IRestRequest BuildGetWindGustRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.WindGust, Method.GET, GetClientTransactionId());

        public double GetWindSpeed() => ExecuteRequest<double, DoubleResponse>(BuildGetWindSpeedRequest); 
        public async Task<double> GetWindSpeedAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetWindSpeedRequest); 
        private IRestRequest BuildGetWindSpeedRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.WindSpeed, Method.GET, GetClientTransactionId());

        public void Refresh() => ExecuteRequest(BuildRefreshRequest);
        public async Task RefreshAsync() => await ExecuteRequestAsync(BuildRefreshRequest);
        private IRestRequest BuildRefreshRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.Refresh, Method.PUT, GetClientTransactionId());

        public string GetSensorDescription(ObservingConditionSensorName sensorName) => ExecuteRequest<string, StringResponse, ObservingConditionSensorName>(BuildGetSensorDescriptionRequest, sensorName); 
        public async Task<string> GetSensorDescriptionAsync(ObservingConditionSensorName sensorName) => await ExecuteRequestAsync<string, StringResponse, ObservingConditionSensorName>(BuildGetSensorDescriptionRequest, sensorName);
        private IRestRequest BuildGetSensorDescriptionRequest(ObservingConditionSensorName sensorName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {ObservingConditionsParameters.SensorName, sensorName.ToString()}
            };
            return RequestBuilder.BuildRestRequest(ObservingConditionsMethod.SensorDescription, Method.GET, parameters, GetClientTransactionId());
        }

        public TimeSpan GetTimeSinceLastUpdate(ObservingConditionSensorName sensorName)
        {
            double dateTimeString = ExecuteRequest<double, DoubleResponse, ObservingConditionSensorName>(BuildGetTimeSinceLastUpdateRequest, sensorName);
            return TimeSpan.FromSeconds(dateTimeString);
        }
        public async Task<TimeSpan> GetTimeSinceLastUpdateAsync(ObservingConditionSensorName sensorName)
        {
            double dateTimeString = await ExecuteRequestAsync<double, DoubleResponse, ObservingConditionSensorName>(BuildGetTimeSinceLastUpdateRequest, sensorName);
            return TimeSpan.FromSeconds(dateTimeString);
        }
        private IRestRequest BuildGetTimeSinceLastUpdateRequest(ObservingConditionSensorName sensorName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {ObservingConditionsParameters.SensorName, sensorName.ToString()}
            };
            return RequestBuilder.BuildRestRequest(ObservingConditionsMethod.TimeSinceLastUpdate, Method.GET, parameters, GetClientTransactionId());
        }
    }
}