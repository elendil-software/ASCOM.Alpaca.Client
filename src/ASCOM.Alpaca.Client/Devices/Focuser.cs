using System.Collections.Generic;
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
    public class Focuser : DeviceBase, IFocuser
    {
        public Focuser(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger<DeviceBase> logger) : base(configuration, clientTransactionIdGenerator, commandSender, logger)
        {
        }

        public Focuser(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.Focuser;
        
        public bool IsAbsolute() => ExecuteRequest<bool, BoolResponse>(BuildIsAbsoluteRequest);  
        public async Task<bool> IsAbsoluteAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAbsoluteRequest);  
        private RestRequest BuildIsAbsoluteRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.Absolute, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool IsMoving() => ExecuteRequest<bool, BoolResponse>(BuildIsMovingRequest);  
        public async Task<bool> IsMovingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsMovingRequest);  
        private RestRequest BuildIsMovingRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.IsMoving, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public int GetMaxIncrement() => ExecuteRequest<int, IntResponse>(BuildGetMaxIncrementRequest);
        public async Task<int> GetMaxIncrementAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxIncrementRequest); 
        private RestRequest BuildGetMaxIncrementRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.MaxIncrement, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public int GetMaxStep() => ExecuteRequest<int, IntResponse>(BuildGetMaxStepRequest);
        public async Task<int> GetMaxStepAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxStepRequest);
        private RestRequest BuildGetMaxStepRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.MaxStep, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public int GetPosition() => ExecuteRequest<int, IntResponse>(BuildGetPositionRequest);
        public async Task<int> GetPositionAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetPositionRequest);
        private RestRequest BuildGetPositionRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.Position, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public double GetStepSize() => ExecuteRequest<int, IntResponse>(BuildGetStepSizeRequest);
        public async Task<double> GetStepSizeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetStepSizeRequest);
        private RestRequest BuildGetStepSizeRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.StepSize, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool IsTempComp() => ExecuteRequest<bool, BoolResponse>(BuildIsTempCompRequest); 
        public async Task<bool> IsTempCompAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsTempCompRequest); 
        private RestRequest BuildIsTempCompRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.TempComp, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetTempComp(bool tempComp) => ExecuteRequest(BuildSetTempCompRequest, tempComp);
        public async Task SetTempCompAsync(bool tempComp) => await ExecuteRequestAsync(BuildSetTempCompRequest, tempComp);
        private RestRequest BuildSetTempCompRequest(bool tempComp)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {FocuserRequestParameters.TempComp, tempComp.ToString()}
            };
            
            return RequestBuilder.BuildRestRequest(FocuserMethod.TempComp, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public bool IsTempCompAvailable() => ExecuteRequest<bool, BoolResponse>(BuildIsTempCompAvailableRequest); 
        public async Task<bool> IsTempCompAvailableAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsTempCompAvailableRequest); 
        private RestRequest BuildIsTempCompAvailableRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.TempCompAvailable, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public double GetTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetTemperatureRequest); 
        public async Task<double> GetTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTemperatureRequest); 
        private RestRequest BuildGetTemperatureRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.Temperature, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void Halt() => ExecuteRequest(BuildHaltRequest);
        public async Task HaltAsync() => await ExecuteRequestAsync(BuildHaltRequest);
        private RestRequest BuildHaltRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.Halt, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

        public void Move(int position) => ExecuteRequest(BuildMoveRequest, position);
        public async Task MoveAsync(int position) => await ExecuteRequestAsync(BuildMoveRequest, position);
        private RestRequest BuildMoveRequest(int position)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {FocuserRequestParameters.Position, position.ToString()}
            };
            
            return RequestBuilder.BuildRestRequest(FocuserMethod.Move, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
    }
}