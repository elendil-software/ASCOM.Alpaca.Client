using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices.Methods;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Responses;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public class Switch : DeviceBase, ISwitch {
        public Switch(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger<DeviceBase> logger) : base(configuration, clientTransactionIdGenerator, commandSender, logger)
        {
        }

        public Switch(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.Switch;
        
        public int GetMaxSwitch() => ExecuteRequest<int, IntResponse>(BuildGetMaxSwitchRequest); 
        public async Task<int> GetMaxSwitchAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxSwitchRequest); 
        private RestRequest BuildGetMaxSwitchRequest() => RequestBuilder.BuildRestRequest(SwitchMethod.MaxSwitch, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanWrite(int id) => ExecuteRequest<bool, BoolResponse, int>(BuildCanWriteRequest, id);
        public async Task<bool> CanWriteAsync(int id) => await ExecuteRequestAsync<bool, BoolResponse, int>(BuildCanWriteRequest, id);
        private RestRequest BuildCanWriteRequest(int id) => RequestBuilder.BuildRestRequest(SwitchMethod.CanWrite, Method.GET, GetDefaultParameters(id), ClientTransactionIdGenerator.GetTransactionId());

        public bool GetSwitch(int id) => ExecuteRequest<bool, BoolResponse, int>(BuildGetSwitchRequest, id);
        public async Task<bool> GetSwitchAsync(int id) => await ExecuteRequestAsync<bool, BoolResponse, int>(BuildGetSwitchRequest, id);
        private RestRequest BuildGetSwitchRequest(int id) => RequestBuilder.BuildRestRequest(SwitchMethod.GetSwitch, Method.GET, GetDefaultParameters(id), ClientTransactionIdGenerator.GetTransactionId());

        public void SetSwitch(int id, bool state) => ExecuteRequest(BuildSetSwitchRequest, id, state);
        public async Task SetSwitchAsync(int id, bool state) => await ExecuteRequestAsync(BuildSetSwitchRequest, id, state);
        private RestRequest BuildSetSwitchRequest(int id, bool state)
        {
            var parameters = GetDefaultParameters(id);
            parameters.Add(SwitchRequestParameters.State, state.ToString());
            return RequestBuilder.BuildRestRequest(SwitchMethod.SetSwitch, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public string GetSwitchDescription(int id) => ExecuteRequest<string, StringResponse, int>(BuildGetSwitchDescriptionRequest, id);
        public async Task<string> GetSwitchDescriptionAsync(int id) => await ExecuteRequestAsync<string, StringResponse, int>(BuildGetSwitchDescriptionRequest, id);
        private RestRequest BuildGetSwitchDescriptionRequest(int id) => RequestBuilder.BuildRestRequest(SwitchMethod.GetSwitchDescription, Method.GET, GetDefaultParameters(id), ClientTransactionIdGenerator.GetTransactionId());

        public string GetSwitchName(int id) => ExecuteRequest<string, StringResponse, int>(BuildGetSwitchNameRequest, id);
        public async Task<string> GetSwitchNameAsync(int id) => await ExecuteRequestAsync<string, StringResponse, int>(BuildGetSwitchNameRequest, id);
        private RestRequest BuildGetSwitchNameRequest(int id) => RequestBuilder.BuildRestRequest(SwitchMethod.GetSwitchName, Method.GET, GetDefaultParameters(id), ClientTransactionIdGenerator.GetTransactionId());

        public void SetSwitchName(int id, string name) => ExecuteRequest(BuildSetSwitchNameRequest, id, name);
        public async Task SetSwitchNameAsync(int id, string name) => await ExecuteRequestAsync(BuildSetSwitchNameRequest, id, name);
        private RestRequest BuildSetSwitchNameRequest(int id, string name)
        {
            var parameters = GetDefaultParameters(id);
            parameters.Add(SwitchRequestParameters.Name, name);
            return RequestBuilder.BuildRestRequest(SwitchMethod.SetSwitchName, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetSwitchValue(int id) => ExecuteRequest<double, DoubleResponse, int>(BuildGetSwitchValueRequest, id);
        public async Task<double> GetSwitchValueAsync(int id) => await ExecuteRequestAsync<double, DoubleResponse, int>(BuildGetSwitchValueRequest, id);
        private RestRequest BuildGetSwitchValueRequest(int id) => RequestBuilder.BuildRestRequest(SwitchMethod.GetSwitchValue, Method.GET, GetDefaultParameters(id), ClientTransactionIdGenerator.GetTransactionId());

        public void SetSwitchValue(int id, double value) => ExecuteRequest(BuildSetSwitchValueRequest, id, value);
        public async Task SetSwitchValueAsync(int id, double value) => await ExecuteRequestAsync(BuildSetSwitchValueRequest, id, value);
        private RestRequest BuildSetSwitchValueRequest(int id, double value)
        {
            var parameters = GetDefaultParameters(id);
            parameters.Add(SwitchRequestParameters.Value, value.ToString(CultureInfo.InvariantCulture));
            return RequestBuilder.BuildRestRequest(SwitchMethod.SetSwitchValue, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetMinSwitchValue(int id) => ExecuteRequest<double, DoubleResponse, int>(BuildGetMinSwitchValueRequest, id);
        public async Task<double> GetMinSwitchValueAsync(int id) => await ExecuteRequestAsync<double, DoubleResponse, int>(BuildGetMinSwitchValueRequest, id);
        private RestRequest BuildGetMinSwitchValueRequest(int id) => RequestBuilder.BuildRestRequest(SwitchMethod.MinSwitchValue, Method.GET, GetDefaultParameters(id), ClientTransactionIdGenerator.GetTransactionId());

        public double GetMaxSwitchValue(int id) => ExecuteRequest<double, DoubleResponse, int>(BuildGetMaxSwitchValueRequest, id);
        public async Task<double> GetMaxSwitchValueAsync(int id) => await ExecuteRequestAsync<double, DoubleResponse, int>(BuildGetMaxSwitchValueRequest, id);
        private RestRequest BuildGetMaxSwitchValueRequest(int id) => RequestBuilder.BuildRestRequest(SwitchMethod.MaxSwitchValue, Method.GET, GetDefaultParameters(id), ClientTransactionIdGenerator.GetTransactionId());

        public double GetSwitchStep(int id) => ExecuteRequest<double, DoubleResponse, int>(BuildGetSwitchStepRequest, id);
        public async Task<double> GetSwitchStepAsync(int id) => await ExecuteRequestAsync<double, DoubleResponse, int>(BuildGetSwitchStepRequest, id);
        private RestRequest BuildGetSwitchStepRequest(int id) => RequestBuilder.BuildRestRequest(SwitchMethod.SwitchStep, Method.GET, GetDefaultParameters(id), ClientTransactionIdGenerator.GetTransactionId());
        
        private Dictionary<string, object> GetDefaultParameters(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {SwitchRequestParameters.Id, id.ToString()}
            };

            return parameters;
        }
    }
}