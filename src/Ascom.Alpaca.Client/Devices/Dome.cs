using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ES.Ascom.Alpaca.Client.Logging;
using ES.Ascom.Alpaca.Client.Request;
using ES.Ascom.Alpaca.Devices;
using ES.Ascom.Alpaca.Responses;
using RestSharp;

namespace ES.Ascom.Alpaca.Client.Devices
{
    /// <summary>
    /// Client implementation of an ASCOM Alpaca Dome device.
    /// <para>This class is meant to be use in a client application that need to control an ASCOM Alpaca Dome</para>
    /// </summary>
    public sealed class Dome : DeviceBase, IDome, IDomeAsync
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dome" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        public Dome(DeviceConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dome" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public Dome(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dome" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        public Dome(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dome" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public Dome(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        internal Dome(DeviceConfiguration configuration, ICommandSender commandSender) : base(configuration, commandSender)
        {
        }

        internal Dome(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : 
            base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }

        /// <inheritdoc/>
        protected override DeviceType DeviceType { get; } = DeviceType.Dome;

        /// <inheritdoc/>
        public double GetAltitude() => ExecuteRequest<double, DoubleResponse>(BuildGetAltitudeRequest);      
        /// <inheritdoc/>
        public async Task<double> GetAltitudeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetAltitudeRequest);    
        private IRestRequest BuildGetAltitudeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Altitude, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool IsAtHome() => ExecuteRequest<bool, BoolResponse>(BuildIsAtHomeRequest);      
        /// <inheritdoc/>
        public async Task<bool> IsAtHomeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAtHomeRequest);      
        private IRestRequest BuildIsAtHomeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.AtHome, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool IsAtPark() => ExecuteRequest<bool, BoolResponse>(BuildIsAtParkRequest);      
        /// <inheritdoc/>
        public async Task<bool> IsAtParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAtParkRequest);   
        private IRestRequest BuildIsAtParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.AtPark, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetAzimuth() => ExecuteRequest<double, DoubleResponse>(BuildGetAzimuthRequest);  
        /// <inheritdoc/>
        public async Task<double> GetAzimuthAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetAzimuthRequest);  
        private IRestRequest BuildGetAzimuthRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Azimuth, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool CanFindHome() => ExecuteRequest<bool, BoolResponse>(BuildCanFindHomeRequest);   
        /// <inheritdoc/>
        public async Task<bool> CanFindHomeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanFindHomeRequest);   
        private IRestRequest BuildCanFindHomeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanFindHome, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool CanPark() => ExecuteRequest<bool, BoolResponse>(BuildCanParkRequest);
        /// <inheritdoc/>
        public async Task<bool> CanParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanParkRequest);  
        private IRestRequest BuildCanParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanPark, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool CanSetAltitude() => ExecuteRequest<bool, BoolResponse>(BuildCanSetAltitudeRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSetAltitudeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetAltitudeRequest); 
        private IRestRequest BuildCanSetAltitudeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetAltitude, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool CanSetAzimuth() => ExecuteRequest<bool, BoolResponse>(BuildCanSetAzimuthRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSetAzimuthAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetAzimuthRequest); 
        private IRestRequest BuildCanSetAzimuthRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetAzimuth, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool CanSetPark() => ExecuteRequest<bool, BoolResponse>(BuildCanSetParkRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSetParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetParkRequest); 
        private IRestRequest BuildCanSetParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetPark, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool CanSetShutter() => ExecuteRequest<bool, BoolResponse>(BuildCanSetShutterRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSetShutterAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetShutterRequest); 
        private IRestRequest BuildCanSetShutterRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetShutter, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool CanSlave() => ExecuteRequest<bool, BoolResponse>(BuildCanSlaveRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSlaveAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSlaveRequest); 
        private IRestRequest BuildCanSlaveRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSlave, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool CanSyncAzimuth() => ExecuteRequest<bool, BoolResponse>(BuildCanSyncAzimuthRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSyncAzimuthAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSyncAzimuthRequest); 
        private IRestRequest BuildCanSyncAzimuthRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSyncAzimuth, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public ShutterState GetShutterStatus() => ExecuteRequest<ShutterState, ShutterStateResponse>(BuildGetShutterStatusRequest);
        /// <inheritdoc/>
        public async Task<ShutterState> GetShutterStatusAsync() => await ExecuteRequestAsync<ShutterState, ShutterStateResponse>(BuildGetShutterStatusRequest);
        private IRestRequest BuildGetShutterStatusRequest() => RequestBuilder.BuildRestRequest(DomeMethod.ShutterStatus, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public bool IsSlaved() => ExecuteRequest<bool, BoolResponse>(BuildIsSlavedRequest); 
        /// <inheritdoc/>
        public async Task<bool> IsSlavedAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSlavedRequest); 
        private IRestRequest BuildIsSlavedRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Slaved, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetSlaved(bool slaved) => ExecuteRequest(BuildSetSlavedRequest, slaved);
        /// <inheritdoc/>
        public async Task SetSlavedAsync(bool slaved) => await ExecuteRequestAsync(BuildSetSlavedRequest, slaved) ;
        private IRestRequest BuildSetSlavedRequest(bool slaved)
        {
            var parameters = new Dictionary<string, object>
            {
                {DomeRequestParameters.Slaved, slaved.ToString()}
            };

            return RequestBuilder.BuildRestRequest(DomeMethod.Slaved, Method.PUT, parameters, GetClientTransactionId());
        }
        
        /// <inheritdoc/>
        public bool IsSlewing() => ExecuteRequest<bool, BoolResponse>(BuildIsSlewingRequest); 
        /// <inheritdoc/>
        public async Task<bool> IsSlewingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSlewingRequest); 
        private IRestRequest BuildIsSlewingRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Slewing, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void AbortSlew() => ExecuteRequest(BuildAbortSlewRequest);
        /// <inheritdoc/>
        public async Task AbortSlewAsync() => await ExecuteRequestAsync(BuildAbortSlewRequest);
        private IRestRequest BuildAbortSlewRequest() => RequestBuilder.BuildRestRequest(DomeMethod.AbortSlew, Method.PUT, GetClientTransactionId());
        
        /// <inheritdoc/>
        public void CloseShutter() => ExecuteRequest(BuildCloseShutterRequest);
        /// <inheritdoc/>
        public async Task CloseShutterAsync() => await ExecuteRequestAsync(BuildCloseShutterRequest);
        private IRestRequest BuildCloseShutterRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CloseShutter, Method.PUT, GetClientTransactionId());
        
        /// <inheritdoc/>
        public void FindHome() => ExecuteRequest(BuildFindHomeRequest);
        /// <inheritdoc/>
        public async Task FindHomeAsync() => await ExecuteRequestAsync(BuildFindHomeRequest);
        private IRestRequest BuildFindHomeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.FindHome, Method.PUT, GetClientTransactionId());
        
        /// <inheritdoc/>
        public void OpenShutter() => ExecuteRequest(BuildOpenShutterRequest);
        /// <inheritdoc/>
        public async Task OpenShutterAsync() => await ExecuteRequestAsync(BuildOpenShutterRequest);
        private IRestRequest BuildOpenShutterRequest() => RequestBuilder.BuildRestRequest(DomeMethod.OpenShutter, Method.PUT, GetClientTransactionId());
        
        /// <inheritdoc/>
        public void Park() => ExecuteRequest(BuildParkRequest);
        /// <inheritdoc/>
        public async Task ParkAsync() => await ExecuteRequestAsync(BuildParkRequest);
        private IRestRequest BuildParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Park, Method.PUT, GetClientTransactionId());
        
        /// <inheritdoc/>
        public void SetPark() => ExecuteRequest(BuildSetParkRequest);
        /// <inheritdoc/>
        public async Task SetParkAsync() => await ExecuteRequestAsync(BuildSetParkRequest);
        private IRestRequest BuildSetParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.SetPark, Method.PUT, GetClientTransactionId());

        /// <inheritdoc/>
        public void SlewToAltitude(double altitude) => ExecuteRequest(BuildSlewToAltitudeRequest, altitude);
        /// <inheritdoc/>
        public async Task SlewToAltitudeAsync(double altitude) => await ExecuteRequestAsync(BuildSlewToAltitudeRequest, altitude);
        private IRestRequest BuildSlewToAltitudeRequest(double altitude)
        {
            var parameters = new Dictionary<string, object>
            {
                {DomeRequestParameters.Altitude, altitude.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(DomeMethod.SlewToAltitude, Method.PUT, parameters, GetClientTransactionId());
        }
        
        /// <inheritdoc/>
        public void SlewToAzimuth(double azimuth) => ExecuteRequest(BuildSlewToAzimuthRequest, azimuth);
        /// <inheritdoc/>
        public async Task SlewToAzimuthAsync(double azimuth) => await ExecuteRequestAsync(BuildSlewToAzimuthRequest, azimuth);
        private IRestRequest BuildSlewToAzimuthRequest(double azimuth)
        {
            var parameters = new Dictionary<string, object>
            {
                {DomeRequestParameters.Azimuth, azimuth.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(DomeMethod.SlewToAzimuth, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public void SyncToAzimuth(double azimuth) => ExecuteRequest(BuildSyncToAzimuthRequest, azimuth);
        /// <inheritdoc/>
        public async Task SyncToAzimuthAsync(double azimuth) => await ExecuteRequestAsync(BuildSyncToAzimuthRequest, azimuth);
        private IRestRequest BuildSyncToAzimuthRequest(double azimuth)
        {
            var parameters = new Dictionary<string, object>
            {
                {DomeRequestParameters.Azimuth, azimuth.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(DomeMethod.SyncToAzimuth, Method.PUT, parameters, GetClientTransactionId());
        }
    }
}