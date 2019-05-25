using System.Collections.Generic;
using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Logging;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Responses;
using RestSharp;

namespace ES.AscomAlpaca.Client.Devices
{
    public sealed class Focuser : DeviceBase, IFocuser
    {
        public Focuser(DeviceConfiguration configuration) : base(configuration)
        {
        }

        public Focuser(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        public Focuser(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        public Focuser(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        internal Focuser(DeviceConfiguration configuration, ICommandSender commandSender) : 
            base(configuration, commandSender)
        {
        }

        internal Focuser(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : 
            base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.Focuser;
        
        public bool IsAbsolute() => ExecuteRequest<bool, BoolResponse>(BuildIsAbsoluteRequest);  
        public async Task<bool> IsAbsoluteAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAbsoluteRequest);  
        private IRestRequest BuildIsAbsoluteRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.Absolute, Method.GET, GetClientTransactionId());
        
        public bool IsMoving() => ExecuteRequest<bool, BoolResponse>(BuildIsMovingRequest);  
        public async Task<bool> IsMovingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsMovingRequest);  
        private IRestRequest BuildIsMovingRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.IsMoving, Method.GET, GetClientTransactionId());
        
        public int GetMaxIncrement() => ExecuteRequest<int, IntResponse>(BuildGetMaxIncrementRequest);
        public async Task<int> GetMaxIncrementAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxIncrementRequest); 
        private IRestRequest BuildGetMaxIncrementRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.MaxIncrement, Method.GET, GetClientTransactionId());
        
        public int GetMaxStep() => ExecuteRequest<int, IntResponse>(BuildGetMaxStepRequest);
        public async Task<int> GetMaxStepAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxStepRequest);
        private IRestRequest BuildGetMaxStepRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.MaxStep, Method.GET, GetClientTransactionId());
        
        public int GetPosition() => ExecuteRequest<int, IntResponse>(BuildGetPositionRequest);
        public async Task<int> GetPositionAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetPositionRequest);
        private IRestRequest BuildGetPositionRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.Position, Method.GET, GetClientTransactionId());
        
        public double GetStepSize() => ExecuteRequest<double, DoubleResponse>(BuildGetStepSizeRequest);
        public async Task<double> GetStepSizeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetStepSizeRequest);
        private IRestRequest BuildGetStepSizeRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.StepSize, Method.GET, GetClientTransactionId());
        
        public bool IsTempComp() => ExecuteRequest<bool, BoolResponse>(BuildIsTempCompRequest); 
        public async Task<bool> IsTempCompAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsTempCompRequest); 
        private IRestRequest BuildIsTempCompRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.TempComp, Method.GET, GetClientTransactionId());

        public void SetTempComp(bool tempComp) => ExecuteRequest(BuildSetTempCompRequest, tempComp);
        public async Task SetTempCompAsync(bool tempComp) => await ExecuteRequestAsync(BuildSetTempCompRequest, tempComp);
        private IRestRequest BuildSetTempCompRequest(bool tempComp)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {FocuserCommandParameters.TempComp, tempComp.ToString()}
            };
            
            return RequestBuilder.BuildRestRequest(FocuserCommand.TempComp, Method.PUT, parameters, GetClientTransactionId());
        }

        public bool IsTempCompAvailable() => ExecuteRequest<bool, BoolResponse>(BuildIsTempCompAvailableRequest); 
        public async Task<bool> IsTempCompAvailableAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsTempCompAvailableRequest); 
        private IRestRequest BuildIsTempCompAvailableRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.TempCompAvailable, Method.GET, GetClientTransactionId());
        
        public double GetTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetTemperatureRequest); 
        public async Task<double> GetTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTemperatureRequest); 
        private IRestRequest BuildGetTemperatureRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.Temperature, Method.GET, GetClientTransactionId());

        public void Halt() => ExecuteRequest(BuildHaltRequest);
        public async Task HaltAsync() => await ExecuteRequestAsync(BuildHaltRequest);
        private IRestRequest BuildHaltRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.Halt, Method.PUT, GetClientTransactionId());

        public void Move(int position) => ExecuteRequest(BuildMoveRequest, position);
        public async Task MoveAsync(int position) => await ExecuteRequestAsync(BuildMoveRequest, position);
        private IRestRequest BuildMoveRequest(int position)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {FocuserCommandParameters.Position, position.ToString()}
            };
            
            return RequestBuilder.BuildRestRequest(FocuserCommand.Move, Method.PUT, parameters, GetClientTransactionId());
        }
    }
}