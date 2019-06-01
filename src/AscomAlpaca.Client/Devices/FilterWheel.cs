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
    /// Client implementation of an ASCOM Alpaca Filter Wheel device.
    /// <para>This class is meant to be use in a client application that need to control an ASCOM Alpaca Filter Wheel</para>
    /// </summary>
    public sealed class FilterWheel : DeviceBase, IFilterWheel, IFilterWheelAsync
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterWheel" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        public FilterWheel(DeviceConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterWheel" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public FilterWheel(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterWheel" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        public FilterWheel(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterWheel" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public FilterWheel(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        internal FilterWheel(DeviceConfiguration configuration, ICommandSender commandSender) : base(configuration, commandSender)
        {
        }

        internal FilterWheel(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }
        
        /// <inheritdoc/>
        protected override DeviceType DeviceType { get; } = DeviceType.FilterWheel;

        /// <inheritdoc/>
        public IList<int> GetFocusOffsets() => ExecuteRequest<IList<int>, IntListResponse>(BuildGetFocusOffsetRequest);
        /// <inheritdoc/>
        public async Task<IList<int>> GetFocusOffsetsAsync() => await ExecuteRequestAsync<IList<int>, IntListResponse>(BuildGetFocusOffsetRequest);
        private IRestRequest BuildGetFocusOffsetRequest() => RequestBuilder.BuildRestRequest(FilterWheelCommand.FocusOffsets, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public IList<string> GetNames() => ExecuteRequest<IList<string>, StringListResponse>(BuildGetNamesRequest);
        /// <inheritdoc/>
        public async Task<IList<string>> GetNamesAsync() => await ExecuteRequestAsync<IList<string>, StringListResponse>(BuildGetNamesRequest);
        private IRestRequest BuildGetNamesRequest() => RequestBuilder.BuildRestRequest(FilterWheelCommand.Names, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetPosition() => ExecuteRequest<int, IntResponse>(BuildGetPositionRequest);
        /// <inheritdoc/>
        public async Task<int> GetPositionAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetPositionRequest);
        private IRestRequest BuildGetPositionRequest() => RequestBuilder.BuildRestRequest(FilterWheelCommand.Position, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetPosition(int position) => ExecuteRequest(BuildSetPositionRequest, position);
        /// <inheritdoc/>
        public async Task SetPositionAsync(int position) => await ExecuteRequestAsync(BuildSetPositionRequest, position);
        private IRestRequest BuildSetPositionRequest(int position)
        {
            var parameters = new Dictionary<string, object>
            {
                {FilterWheelCommandParameters.Position, position.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(FilterWheelCommand.Position, Method.PUT, parameters, GetClientTransactionId());
        }
    }
}
