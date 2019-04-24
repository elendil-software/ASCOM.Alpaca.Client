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
    public class Rotator : DeviceBase, IRotator
    {
        public Rotator(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger<DeviceBase> logger) : base(configuration, clientTransactionIdGenerator, commandSender, logger)
        {
        }

        public Rotator(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.Rotator;

        public bool CanReverse() => ExecuteRequest<bool, BoolResponse>(BuildCanReverseRequest);
        public async Task<bool> CanReverseAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanReverseRequest);
        private RestRequest BuildCanReverseRequest() => RequestBuilder.BuildRestRequest(RotatorMethod.CanReverse, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool IsMoving() => ExecuteRequest<bool, BoolResponse>(BuildIsMovingRequest);
        public async Task<bool> IsMovingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsMovingRequest);
        private RestRequest BuildIsMovingRequest() => RequestBuilder.BuildRestRequest(RotatorMethod.IsMoving, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetPosition() => ExecuteRequest<double, DoubleResponse>(BuildGetPositionRequest);
        public async Task<double> GetPositionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetPositionRequest);
        private RestRequest BuildGetPositionRequest() => RequestBuilder.BuildRestRequest(RotatorMethod.Position, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool IsReversed() => ExecuteRequest<bool, BoolResponse>(BuildIsReversedRequest);
        public async Task<bool> IsReversedAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsReversedRequest);
        private RestRequest BuildIsReversedRequest() => RequestBuilder.BuildRestRequest(RotatorMethod.Reverse, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetReversed(bool reversed) => ExecuteRequest(BuildSetReversedRequest, reversed);
        public async Task SetReversedAsync(bool reversed) => await ExecuteRequestAsync(BuildSetReversedRequest, reversed);
        private RestRequest BuildSetReversedRequest(bool reversed)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {RotatorParameters.Reverse , reversed.ToString()}
            };
            return RequestBuilder.BuildRestRequest(RotatorMethod.Reverse, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetStepSize() => ExecuteRequest<double, DoubleResponse>(BuildGetStepSizeRequest);
        public async Task<double> GetStepSizeAsync() =>  await ExecuteRequestAsync<double, DoubleResponse>(BuildGetStepSizeRequest);
        private RestRequest BuildGetStepSizeRequest() => RequestBuilder.BuildRestRequest(RotatorMethod.StepSize, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetTargetPosition() => ExecuteRequest<double, DoubleResponse>(BuildGetTargetPositionRequest);
        public async Task<double> GetTargetPositionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTargetPositionRequest);
        private RestRequest BuildGetTargetPositionRequest() => RequestBuilder.BuildRestRequest(RotatorMethod.TargetPosition, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void Halt() => ExecuteRequest(BuildHaltRequest);
        public async Task HaltAsync() => await ExecuteRequestAsync(BuildHaltRequest);
        private RestRequest BuildHaltRequest() => RequestBuilder.BuildRestRequest(RotatorMethod.Halt, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

        public void Move(double position) => ExecuteRequest(BuildMoveRequest, position);
        public async Task MoveAsync(double position) => await ExecuteRequestAsync(BuildMoveRequest, position);
        private RestRequest BuildMoveRequest(double position)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {RotatorParameters.Position, position.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(RotatorMethod.Move, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void MoveAbsolute(double position) => ExecuteRequest(BuildMoveAbsoluteRequest, position);
        public async Task MoveAbsoluteAsync(double position) => await ExecuteRequestAsync(BuildMoveAbsoluteRequest, position);
        private RestRequest BuildMoveAbsoluteRequest(double position)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {RotatorParameters.Position, position.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(RotatorMethod.MoveAbsolute, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
    }
}