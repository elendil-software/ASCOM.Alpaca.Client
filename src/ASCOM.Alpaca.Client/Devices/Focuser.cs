using System.Collections.Generic;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public sealed class Focuser : DeviceBase, IFocuser
    {
        public Focuser(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.Focuser;
        
        public bool IsAbsolute() => ExecuteRequest<bool, BoolResponse>(BuildIsAbsoluteRequest);  
        public async Task<bool> IsAbsoluteAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAbsoluteRequest);  
        private IRestRequest BuildIsAbsoluteRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.Absolute, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool IsMoving() => ExecuteRequest<bool, BoolResponse>(BuildIsMovingRequest);  
        public async Task<bool> IsMovingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsMovingRequest);  
        private IRestRequest BuildIsMovingRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.IsMoving, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public int GetMaxIncrement() => ExecuteRequest<int, IntResponse>(BuildGetMaxIncrementRequest);
        public async Task<int> GetMaxIncrementAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxIncrementRequest); 
        private IRestRequest BuildGetMaxIncrementRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.MaxIncrement, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public int GetMaxStep() => ExecuteRequest<int, IntResponse>(BuildGetMaxStepRequest);
        public async Task<int> GetMaxStepAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxStepRequest);
        private IRestRequest BuildGetMaxStepRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.MaxStep, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public int GetPosition() => ExecuteRequest<int, IntResponse>(BuildGetPositionRequest);
        public async Task<int> GetPositionAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetPositionRequest);
        private IRestRequest BuildGetPositionRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.Position, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public double GetStepSize() => ExecuteRequest<double, DoubleResponse>(BuildGetStepSizeRequest);
        public async Task<double> GetStepSizeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetStepSizeRequest);
        private IRestRequest BuildGetStepSizeRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.StepSize, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool IsTempComp() => ExecuteRequest<bool, BoolResponse>(BuildIsTempCompRequest); 
        public async Task<bool> IsTempCompAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsTempCompRequest); 
        private IRestRequest BuildIsTempCompRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.TempComp, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));

        public void SetTempComp(bool tempComp) => ExecuteRequest(BuildSetTempCompRequest, tempComp);
        public async Task SetTempCompAsync(bool tempComp) => await ExecuteRequestAsync(BuildSetTempCompRequest, tempComp);
        private IRestRequest BuildSetTempCompRequest(bool tempComp)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {FocuserRequestParameters.TempComp, tempComp.ToString()}
            };
            
            return RequestBuilder.BuildRestRequest(FocuserMethod.TempComp, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        }

        public bool IsTempCompAvailable() => ExecuteRequest<bool, BoolResponse>(BuildIsTempCompAvailableRequest); 
        public async Task<bool> IsTempCompAvailableAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsTempCompAvailableRequest); 
        private IRestRequest BuildIsTempCompAvailableRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.TempCompAvailable, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public double GetTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetTemperatureRequest); 
        public async Task<double> GetTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTemperatureRequest); 
        private IRestRequest BuildGetTemperatureRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.Temperature, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));

        public void Halt() => ExecuteRequest(BuildHaltRequest);
        public async Task HaltAsync() => await ExecuteRequestAsync(BuildHaltRequest);
        private IRestRequest BuildHaltRequest() => RequestBuilder.BuildRestRequest(FocuserMethod.Halt, Method.PUT, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));

        public void Move(int position) => ExecuteRequest(BuildMoveRequest, position);
        public async Task MoveAsync(int position) => await ExecuteRequestAsync(BuildMoveRequest, position);
        private IRestRequest BuildMoveRequest(int position)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {FocuserRequestParameters.Position, position.ToString()}
            };
            
            return RequestBuilder.BuildRestRequest(FocuserMethod.Move, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        }
    }
}