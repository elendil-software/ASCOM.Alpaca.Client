using System.Collections.Generic;
using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Logging;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Devices;
using ES.AscomAlpaca.Responses;
using RestSharp;

namespace ES.AscomAlpaca.Client.Devices
{
    /// <summary>
    /// Client implementation of an ASCOM Alpaca Focuser device.
    /// <para>This class is meant to be use in a client application that need to control an ASCOM Alpaca Focuser</para>
    /// </summary>
    public sealed class Focuser : DeviceBase, IFocuser, IFocuserAsync
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Focuser" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        public Focuser(DeviceConfiguration configuration) : base(configuration)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Focuser" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public Focuser(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Focuser" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        public Focuser(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Focuser" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
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

        /// <inheritdoc/>
        protected override DeviceType DeviceType { get; } = DeviceType.Focuser;
        
        /// <inheritdoc/>
        public bool IsAbsolute() => ExecuteRequest<bool, BoolResponse>(BuildIsAbsoluteRequest);  
        /// <inheritdoc/>
        public async Task<bool> IsAbsoluteAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAbsoluteRequest);  
        private IRestRequest BuildIsAbsoluteRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.Absolute, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool IsMoving() => ExecuteRequest<bool, BoolResponse>(BuildIsMovingRequest);  
        /// <inheritdoc/>
        public async Task<bool> IsMovingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsMovingRequest);  
        private IRestRequest BuildIsMovingRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.IsMoving, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public int GetMaxIncrement() => ExecuteRequest<int, IntResponse>(BuildGetMaxIncrementRequest);
        /// <inheritdoc/>
        public async Task<int> GetMaxIncrementAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxIncrementRequest); 
        private IRestRequest BuildGetMaxIncrementRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.MaxIncrement, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public int GetMaxStep() => ExecuteRequest<int, IntResponse>(BuildGetMaxStepRequest);
        /// <inheritdoc/>
        public async Task<int> GetMaxStepAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxStepRequest);
        private IRestRequest BuildGetMaxStepRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.MaxStep, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public int GetPosition() => ExecuteRequest<int, IntResponse>(BuildGetPositionRequest);
        /// <inheritdoc/>
        public async Task<int> GetPositionAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetPositionRequest);
        private IRestRequest BuildGetPositionRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.Position, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public double GetStepSize() => ExecuteRequest<double, DoubleResponse>(BuildGetStepSizeRequest);
        /// <inheritdoc/>
        public async Task<double> GetStepSizeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetStepSizeRequest);
        private IRestRequest BuildGetStepSizeRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.StepSize, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool IsTempComp() => ExecuteRequest<bool, BoolResponse>(BuildIsTempCompRequest); 
        /// <inheritdoc/>
        public async Task<bool> IsTempCompAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsTempCompRequest); 
        private IRestRequest BuildIsTempCompRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.TempComp, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetTempComp(bool tempComp) => ExecuteRequest(BuildSetTempCompRequest, tempComp);
        /// <inheritdoc/>
        public async Task SetTempCompAsync(bool tempComp) => await ExecuteRequestAsync(BuildSetTempCompRequest, tempComp);
        private IRestRequest BuildSetTempCompRequest(bool tempComp)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {FocuserCommandParameters.TempComp, tempComp.ToString()}
            };
            
            return RequestBuilder.BuildRestRequest(FocuserCommand.TempComp, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public bool IsTempCompAvailable() => ExecuteRequest<bool, BoolResponse>(BuildIsTempCompAvailableRequest); 
        /// <inheritdoc/>
        public async Task<bool> IsTempCompAvailableAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsTempCompAvailableRequest); 
        private IRestRequest BuildIsTempCompAvailableRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.TempCompAvailable, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public double GetTemperature() => ExecuteRequest<double, DoubleResponse>(BuildGetTemperatureRequest); 
        /// <inheritdoc/>
        public async Task<double> GetTemperatureAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTemperatureRequest); 
        private IRestRequest BuildGetTemperatureRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.Temperature, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void Halt() => ExecuteRequest(BuildHaltRequest);
        /// <inheritdoc/>
        public async Task HaltAsync() => await ExecuteRequestAsync(BuildHaltRequest);
        private IRestRequest BuildHaltRequest() => RequestBuilder.BuildRestRequest(FocuserCommand.Halt, Method.PUT, GetClientTransactionId());

        /// <inheritdoc/>
        public void Move(int position) => ExecuteRequest(BuildMoveRequest, position);
        /// <inheritdoc/>
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