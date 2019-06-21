using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Logging;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Devices;
using ES.AscomAlpaca.Responses;
using RestSharp;

namespace ES.AscomAlpaca.Client.Devices
{
    /// <summary>
    /// Client implementation of an ASCOM Alpaca Rotator device.
    /// <para>This class is meant to be use in a client application that need to control an ASCOM Alpaca Rotator</para>
    /// </summary>
    public sealed class Rotator : DeviceBase, IRotator, IRotatorAsync
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rotator" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        public Rotator(DeviceConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rotator" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public Rotator(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rotator" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        public Rotator(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rotator" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public Rotator(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        /// <inheritdoc/>
        public Rotator(DeviceConfiguration configuration, ICommandSender commandSender) : base(configuration, commandSender)
        {
        }

        /// <inheritdoc/>
        public Rotator(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }

        /// <inheritdoc/>
        protected override DeviceType DeviceType { get; } = DeviceType.Rotator;

        /// <inheritdoc/>
        public bool CanReverse() => ExecuteRequest<bool, BoolResponse>(BuildCanReverseRequest);
        /// <inheritdoc/>
        public async Task<bool> CanReverseAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanReverseRequest);
        private IRestRequest BuildCanReverseRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.CanReverse, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool IsMoving() => ExecuteRequest<bool, BoolResponse>(BuildIsMovingRequest);
        /// <inheritdoc/>
        public async Task<bool> IsMovingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsMovingRequest);
        private IRestRequest BuildIsMovingRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.IsMoving, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetPosition() => ExecuteRequest<double, DoubleResponse>(BuildGetPositionRequest);
        /// <inheritdoc/>
        public async Task<double> GetPositionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPositionRequest);
        private IRestRequest BuildGetPositionRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.Position, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool IsReversed() => ExecuteRequest<bool, BoolResponse>(BuildIsReversedRequest);
        /// <inheritdoc/>
        public async Task<bool> IsReversedAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsReversedRequest);
        private IRestRequest BuildIsReversedRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.Reverse, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetReversed(bool reversed) => ExecuteRequest(BuildSetReversedRequest, reversed);
        /// <inheritdoc/>
        public async Task SetReversedAsync(bool reversed) => await ExecuteRequestAsync(BuildSetReversedRequest, reversed);
        private IRestRequest BuildSetReversedRequest(bool reversed)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {RotatorCommandParameters.Reverse , reversed.ToString()}
            };
            return RequestBuilder.BuildRestRequest(RotatorCommand.Reverse, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetStepSize() => ExecuteRequest<double, DoubleResponse>(BuildGetStepSizeRequest);
        /// <inheritdoc/>
        public async Task<double> GetStepSizeAsync() =>  await ExecuteRequestAsync<double, DoubleResponse>(BuildGetStepSizeRequest);
        private IRestRequest BuildGetStepSizeRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.StepSize, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetTargetPosition() => ExecuteRequest<double, DoubleResponse>(BuildGetTargetPositionRequest);
        /// <inheritdoc/>
        public async Task<double> GetTargetPositionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTargetPositionRequest);
        private IRestRequest BuildGetTargetPositionRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.TargetPosition, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void Halt() => ExecuteRequest(BuildHaltRequest);
        /// <inheritdoc/>
        public async Task HaltAsync() => await ExecuteRequestAsync(BuildHaltRequest);
        private IRestRequest BuildHaltRequest() => RequestBuilder.BuildRestRequest(RotatorCommand.Halt, Method.PUT, GetClientTransactionId());

        /// <inheritdoc/>
        public void Move(double position) => ExecuteRequest(BuildMoveRequest, position);
        /// <inheritdoc/>
        public async Task MoveAsync(double position) => await ExecuteRequestAsync(BuildMoveRequest, position);
        private IRestRequest BuildMoveRequest(double position)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {RotatorCommandParameters.Position, position.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(RotatorCommand.Move, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public void MoveAbsolute(double position) => ExecuteRequest(BuildMoveAbsoluteRequest, position);
        /// <inheritdoc/>
        public async Task MoveAbsoluteAsync(double position) => await ExecuteRequestAsync(BuildMoveAbsoluteRequest, position);
        private IRestRequest BuildMoveAbsoluteRequest(double position)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {RotatorCommandParameters.Position, position.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(RotatorCommand.MoveAbsolute, Method.PUT, parameters, GetClientTransactionId());
        }
    }
}