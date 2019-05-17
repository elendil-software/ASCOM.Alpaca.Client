using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Devices.Dome;
using ASCOM.Alpaca.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public sealed class Dome : DeviceBase, IDome
    {
        public Dome(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.Dome;

        public double GetAltitude() => ExecuteRequest<double, DoubleResponse>(BuildGetAltitudeRequest);      
        public async Task<double> GetAltitudeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetAltitudeRequest);    
        private IRestRequest BuildGetAltitudeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Altitude, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool IsAtHome() => ExecuteRequest<bool, BoolResponse>(BuildIsAtHomeRequest);      
        public async Task<bool> IsAtHomeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAtHomeRequest);      
        private IRestRequest BuildIsAtHomeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.AtHome, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));

        public bool IsAtPark() => ExecuteRequest<bool, BoolResponse>(BuildIsAtParkRequest);      
        public async Task<bool> IsAtParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAtParkRequest);   
        private IRestRequest BuildIsAtParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.AtPark, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));

        public double GetAzimuth() => ExecuteRequest<double, DoubleResponse>(BuildGetAzimuthRequest);  
        public async Task<double> GetAzimuthAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetAzimuthRequest);  
        private IRestRequest BuildGetAzimuthRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Azimuth, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool CanFindHome() => ExecuteRequest<bool, BoolResponse>(BuildCanFindHomeRequest);   
        public async Task<bool> CanFindHomeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanFindHomeRequest);   
        private IRestRequest BuildCanFindHomeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanFindHome, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool CanPark() => ExecuteRequest<bool, BoolResponse>(BuildCanParkRequest);
        public async Task<bool> CanParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanParkRequest);  
        private IRestRequest BuildCanParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanPark, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool CanSetAltitude() => ExecuteRequest<bool, BoolResponse>(BuildCanSetAltitudeRequest);
        public async Task<bool> CanSetAltitudeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetAltitudeRequest); 
        private IRestRequest BuildCanSetAltitudeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetAltitude, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool CanSetAzimuth() => ExecuteRequest<bool, BoolResponse>(BuildCanSetAzimuthRequest);
        public async Task<bool> CanSetAzimuthAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetAzimuthRequest); 
        private IRestRequest BuildCanSetAzimuthRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetAzimuth, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool CanSetPark() => ExecuteRequest<bool, BoolResponse>(BuildCanSetParkRequest);
        public async Task<bool> CanSetParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetParkRequest); 
        private IRestRequest BuildCanSetParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetPark, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool CanSetShutter() => ExecuteRequest<bool, BoolResponse>(BuildCanSetShutterRequest);
        public async Task<bool> CanSetShutterAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetShutterRequest); 
        private IRestRequest BuildCanSetShutterRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetShutter, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool CanSlave() => ExecuteRequest<bool, BoolResponse>(BuildCanSlaveRequest);
        public async Task<bool> CanSlaveAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSlaveRequest); 
        private IRestRequest BuildCanSlaveRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSlave, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool CanSyncAzimuth() => ExecuteRequest<bool, BoolResponse>(BuildCanSyncAzimuthRequest);
        public async Task<bool> CanSyncAzimuthAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSyncAzimuthRequest); 
        private IRestRequest BuildCanSyncAzimuthRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSyncAzimuth, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public ShutterState GetShutterStatus() => ExecuteRequest<ShutterState, ShutterStateResponse>(BuildGetShutterStatusRequest);
        public async Task<ShutterState> GetShutterStatusAsync() => await ExecuteRequestAsync<ShutterState, ShutterStateResponse>(BuildGetShutterStatusRequest);
        private IRestRequest BuildGetShutterStatusRequest() => RequestBuilder.BuildRestRequest(DomeMethod.ShutterStatus, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public bool IsSlaved() => ExecuteRequest<bool, BoolResponse>(BuildIsSlavedRequest); 
        public async Task<bool> IsSlavedAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSlavedRequest); 
        private IRestRequest BuildIsSlavedRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Slaved, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));

        public void SetSlaved(bool slaved) => ExecuteRequest(BuildSetSlavedRequest, slaved);
        public async Task SetSlavedAsync(bool slaved) => await ExecuteRequestAsync(BuildSetSlavedRequest, slaved) ;
        private IRestRequest BuildSetSlavedRequest(bool slaved)
        {
            var parameters = new Dictionary<string, object>
            {
                {DomeRequestParameters.Slaved, slaved.ToString()}
            };

            return RequestBuilder.BuildRestRequest(DomeMethod.Slaved, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        }
        
        public bool IsSlewing() => ExecuteRequest<bool, BoolResponse>(BuildIsSlewingRequest); 
        public async Task<bool> IsSlewingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSlewingRequest); 
        private IRestRequest BuildIsSlewingRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Slewing, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));

        public void AbortSlew() => ExecuteRequest(BuildAbortSlewRequest);
        public async Task AbortSlewAsync() => await ExecuteRequestAsync(BuildAbortSlewRequest);
        private IRestRequest BuildAbortSlewRequest() => RequestBuilder.BuildRestRequest(DomeMethod.AbortSlew, Method.PUT, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public void CloseShutter() => ExecuteRequest(BuildCloseShutterRequest);
        public async Task CloseShutterAsync() => await ExecuteRequestAsync(BuildCloseShutterRequest);
        private IRestRequest BuildCloseShutterRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CloseShutter, Method.PUT, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public void FindHome() => ExecuteRequest(BuildFindHomeRequest);
        public async Task FindHomeAsync() => await ExecuteRequestAsync(BuildFindHomeRequest);
        private IRestRequest BuildFindHomeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.FindHome, Method.PUT, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public void OpenShutter() => ExecuteRequest(BuildOpenShutterRequest);
        public async Task OpenShutterAsync() => await ExecuteRequestAsync(BuildOpenShutterRequest);
        private IRestRequest BuildOpenShutterRequest() => RequestBuilder.BuildRestRequest(DomeMethod.OpenShutter, Method.PUT, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public void Park() => ExecuteRequest(BuildParkRequest);
        public async Task ParkAsync() => await ExecuteRequestAsync(BuildParkRequest);
        private IRestRequest BuildParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Park, Method.PUT, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        
        public void SetPark() => ExecuteRequest(BuildSetParkRequest);
        public async Task SetParkAsync() => await ExecuteRequestAsync(BuildSetParkRequest);
        private IRestRequest BuildSetParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.SetPark, Method.PUT, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));

        public void SlewToAltitude(double altitude) => ExecuteRequest(BuildSlewToAltitudeRequest, altitude);
        public async Task SlewToAltitudeAsync(double altitude) => await ExecuteRequestAsync(BuildSlewToAltitudeRequest, altitude);
        private IRestRequest BuildSlewToAltitudeRequest(double altitude)
        {
            var parameters = new Dictionary<string, object>
            {
                {DomeRequestParameters.Altitude, altitude.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(DomeMethod.SlewToAltitude, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        }
        
        public void SlewToAzimuth(double azimuth) => ExecuteRequest(BuildSlewToAzimuthRequest, azimuth);
        public async Task SlewToAzimuthAsync(double azimuth) => await ExecuteRequestAsync(BuildSlewToAzimuthRequest, azimuth);
        private IRestRequest BuildSlewToAzimuthRequest(double azimuth)
        {
            var parameters = new Dictionary<string, object>
            {
                {DomeRequestParameters.Azimuth, azimuth.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(DomeMethod.SlewToAzimuth, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        }

        public void SyncToAzimuth(double azimuth) => ExecuteRequest(BuildSyncToAzimuthRequest, azimuth);
        public async Task SyncToAzimuthAsync(double azimuth) => await ExecuteRequestAsync(BuildSyncToAzimuthRequest, azimuth);
        private IRestRequest BuildSyncToAzimuthRequest(double azimuth)
        {
            var parameters = new Dictionary<string, object>
            {
                {DomeRequestParameters.Azimuth, azimuth.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(DomeMethod.SyncToAzimuth, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        }
    }
}