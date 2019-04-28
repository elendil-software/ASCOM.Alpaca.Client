using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Responses;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public class ObservingConditions : DeviceBase, IObservingConditions
    {
        public ObservingConditions(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger<DeviceBase> logger) : base(configuration, clientTransactionIdGenerator, commandSender, logger)
        {
        }

        public ObservingConditions(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.ObservingConditions;
        
        public double GetAveragePeriod() => ExecuteRequest<double, DoubleResponse>(BuildRequest); 
        public async Task<double> GetAveragePeriodAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildRequest); 
        private RestRequest BuildRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.AveragePeriod, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetAveragePeriod(double period) => ExecuteRequest(BuildSetAveragePeriodRequest, period);
        public async Task SetAveragePeriodAsync(double period) => await ExecuteRequestAsync(BuildSetAveragePeriodRequest, period);
        private RestRequest BuildSetAveragePeriodRequest(double period)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {ObservingConditionsParameters.AveragePeriod, period.ToString(CultureInfo.InvariantCulture)}
            };
            
            return RequestBuilder.BuildRestRequest(ObservingConditionsMethod.AveragePeriod, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetCloudCover() => ExecuteRequest<double, DoubleResponse>(BuildGetCloudCoverRequest); 
        public async Task<double> GetCloudCoverAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetCloudCoverRequest); 
        private RestRequest BuildGetCloudCoverRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.CloudCover, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetDewPoint() => ExecuteRequest<double, DoubleResponse>(BuildGetDewPointRequest); 
        public async Task<double> GetDewPointAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetDewPointRequest); 
        private RestRequest BuildGetDewPointRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.DewPoint, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetHumidity() => ExecuteRequest<double, DoubleResponse>(BuildGetHumidityRequest); 
        public async Task<double> GetHumidityAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetHumidityRequest); 
        private RestRequest BuildGetHumidityRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.Humidity, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetPressure() => ExecuteRequest<double, DoubleResponse>(BuildGetPressureRequest); 
        public async Task<double> GetPressureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPressureRequest); 
        private RestRequest BuildGetPressureRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.Pressure, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetRainRate() => ExecuteRequest<double, DoubleResponse>(BuildGetRainRateRequest); 
        public async Task<double> GetRainRateAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetRainRateRequest); 
        private RestRequest BuildGetRainRateRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.RainRate, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetSkyBrightness() => ExecuteRequest<double, DoubleResponse>(BuildGetSkyBrightnessRequest); 
        public async Task<double> GetSkyBrightnessAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSkyBrightnessRequest); 
        private RestRequest BuildGetSkyBrightnessRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.SkyBrightness, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetSkyQuality() => ExecuteRequest<double, DoubleResponse>(BuildGetSkyQualityRequest); 
        public async Task<double> GetSkyQualityAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSkyQualityRequest); 
        private RestRequest BuildGetSkyQualityRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.SkyQuality, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetSkyTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetSkyTemperatureRequest); 
        public async Task<double> GetSkyTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSkyTemperatureRequest); 
        private RestRequest BuildGetSkyTemperatureRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.SkyTemperature, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetStarFwhm() => ExecuteRequest<double, DoubleResponse>(BuildGetStarFwhmRequest); 
        public async Task<double> GetStarFwhmAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetStarFwhmRequest); 
        private RestRequest BuildGetStarFwhmRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.StarFWHM, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetTemperatureRequest); 
        public async Task<double> GetTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTemperatureRequest); 
        private RestRequest BuildGetTemperatureRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.Temperature, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetWindDirection() => ExecuteRequest<double, DoubleResponse>(BuildGetWindDirectionRequest); 
        public async Task<double> GetWindDirectionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetWindDirectionRequest); 
        private RestRequest BuildGetWindDirectionRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.WindDirection, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetWindGust() => ExecuteRequest<double, DoubleResponse>(BuildGetWindGustRequest); 
        public async Task<double> GetWindGustAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetWindGustRequest);
        private RestRequest BuildGetWindGustRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.WindGust, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetWindSpeed() => ExecuteRequest<double, DoubleResponse>(BuildGetWindSpeedRequest); 
        public async Task<double> GetWindSpeedAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetWindSpeedRequest); 
        private RestRequest BuildGetWindSpeedRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.WindSpeed, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void Refresh() => ExecuteRequest(BuildRefreshRequest);
        public async Task RefreshAsync() => await ExecuteRequestAsync(BuildRefreshRequest);
        private RestRequest BuildRefreshRequest() => RequestBuilder.BuildRestRequest(ObservingConditionsMethod.Refresh, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

        public string GetSensorDescription(ObservingConditionSensorName sensorName) => ExecuteRequest<string, StringResponse, ObservingConditionSensorName>(BuildGetSensorDescriptionRequest, sensorName); 
        public async Task<string> GetSensorDescriptionAsync(ObservingConditionSensorName sensorName) => await ExecuteRequestAsync<string, StringResponse, ObservingConditionSensorName>(BuildGetSensorDescriptionRequest, sensorName);
        private RestRequest BuildGetSensorDescriptionRequest(ObservingConditionSensorName sensorName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {ObservingConditionsParameters.SensorName, sensorName.ToString()}
            };
            return RequestBuilder.BuildRestRequest(ObservingConditionsMethod.SensorDescription, Method.GET, parameters, ClientTransactionIdGenerator.GetTransactionId());
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
        private RestRequest BuildGetTimeSinceLastUpdateRequest(ObservingConditionSensorName sensorName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {ObservingConditionsParameters.SensorName, sensorName.ToString()}
            };
            return RequestBuilder.BuildRestRequest(ObservingConditionsMethod.TimeSinceLastUpdate, Method.GET, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
    }
}