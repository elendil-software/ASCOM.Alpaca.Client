using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices.Methods;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Enums.Devices;
using ASCOM.Alpaca.Enums.Devices.Dome;
using ASCOM.Alpaca.Responses;
using ASCOM.Alpaca.Responses.Boolean;
using ASCOM.Alpaca.Responses.Numeric;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices.Dome
{
    public class Dome : DeviceBase, IDome
    {
        public Dome(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger<DeviceBase> logger) : base(configuration, clientTransactionIdGenerator, commandSender, logger)
        {
        }

        public Dome(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.Dome;

        public double GetAltitude() => ExecuteRequest<double, DoubleResponse>(BuildGetAltitudeRequest);      
        public async Task<double> GetAltitudeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetAltitudeRequest);    
        private RestRequest BuildGetAltitudeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Altitude, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool IsAtHome() => ExecuteRequest<bool, BoolResponse>(BuildIsAtHomeRequest);      
        public async Task<bool> IsAtHomeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAtHomeRequest);      
        private RestRequest BuildIsAtHomeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.AtHome, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool IsAtPark() => ExecuteRequest<bool, BoolResponse>(BuildIsAtParkRequest);      
        public async Task<bool> IsAtParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAtParkRequest);   
        private RestRequest BuildIsAtParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.AtPark, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetAzimuth() => ExecuteRequest<double, DoubleResponse>(BuildGetAzimuthRequest);  
        public async Task<double> GetAzimuthAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetAzimuthRequest);  
        private RestRequest BuildGetAzimuthRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Azimuth, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool CanFindHome() => ExecuteRequest<bool, BoolResponse>(BuildCanFindHomeRequest);   
        public async Task<bool> CanFindHomeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanFindHomeRequest);   
        private RestRequest BuildCanFindHomeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanFindHome, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool CanPark() => ExecuteRequest<bool, BoolResponse>(BuildCanParkRequest);
        public async Task<bool> CanParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanParkRequest);  
        private RestRequest BuildCanParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanPark, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool CanSetAltitude() => ExecuteRequest<bool, BoolResponse>(BuildCanSetAltitudeRequest);
        public async Task<bool> CanSetAltitudeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetAltitudeRequest); 
        private RestRequest BuildCanSetAltitudeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetAltitude, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool CanSetAzimuth() => ExecuteRequest<bool, BoolResponse>(BuildCanSetAzimuthRequest);
        public async Task<bool> CanSetAzimuthAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetAzimuthRequest); 
        private RestRequest BuildCanSetAzimuthRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetAzimuth, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool CanSetPark() => ExecuteRequest<bool, BoolResponse>(BuildCanSetParkRequest);
        public async Task<bool> CanSetParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetParkRequest); 
        private RestRequest BuildCanSetParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetPark, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool CanSetShutter() => ExecuteRequest<bool, BoolResponse>(BuildCanSetShutterRequest);
        public async Task<bool> CanSetShutterAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetShutterRequest); 
        private RestRequest BuildCanSetShutterRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSetShutter, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool CanSlave() => ExecuteRequest<bool, BoolResponse>(BuildCanSlaveRequest);
        public async Task<bool> CanSlaveAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSlaveRequest); 
        private RestRequest BuildCanSlaveRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSlave, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool CanSyncAzimuth() => ExecuteRequest<bool, BoolResponse>(BuildCanSyncAzimuthRequest);
        public async Task<bool> CanSyncAzimuthAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSyncAzimuthRequest); 
        private RestRequest BuildCanSyncAzimuthRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CanSyncAzimuth, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public ShutterState GetShutterStatus() => ExecuteRequest<ShutterState, ValueResponse<ShutterState>>(BuildGetShutterStatusRequest);
        public async Task<ShutterState> GetShutterStatusAsync() => await ExecuteRequestAsync<ShutterState, ValueResponse<ShutterState>>(BuildGetShutterStatusRequest);
        private RestRequest BuildGetShutterStatusRequest() => RequestBuilder.BuildRestRequest(DomeMethod.ShutterStatus, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public bool IsSlaved() => ExecuteRequest<bool, BoolResponse>(BuildIsSlavedRequest); 
        public async Task<bool> IsSlavedAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSlavedRequest); 
        private RestRequest BuildIsSlavedRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Slaved, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetSlaved(bool slaved) => ExecuteRequest(BuildSetSlavedRequest, slaved);
        public async Task SetSlavedAsync(bool slaved) => await ExecuteRequestAsync(BuildSetSlavedRequest, slaved) ;
        private RestRequest BuildSetSlavedRequest(bool slaved)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Slaved", slaved.ToString()}
            };

            return RequestBuilder.BuildRestRequest(DomeMethod.Slaved, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
        
        public bool IsSlewing() => ExecuteRequest<bool, BoolResponse>(BuildIsSlewingRequest); 
        public async Task<bool> IsSlewingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSlewingRequest); 
        private RestRequest BuildIsSlewingRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Slewing, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void AbortSlew() => ExecuteRequest(BuildAbortSlewRequest);
        public async Task AbortSlewAsync() => await ExecuteRequestAsync(BuildAbortSlewRequest);
        private RestRequest BuildAbortSlewRequest() => RequestBuilder.BuildRestRequest(DomeMethod.AbortSlew, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());
        
        public void CloseShutter() => ExecuteRequest(BuildCloseShutterRequest);
        public async Task CloseShutterAsync() => await ExecuteRequestAsync(BuildCloseShutterRequest);
        private RestRequest BuildCloseShutterRequest() => RequestBuilder.BuildRestRequest(DomeMethod.CloseShutter, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());
        
        public void FindHome() => ExecuteRequest(BuildFindHomeRequest);
        public async Task FindHomeAsync() => await ExecuteRequestAsync(BuildFindHomeRequest);
        private RestRequest BuildFindHomeRequest() => RequestBuilder.BuildRestRequest(DomeMethod.FindHome, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());
        
        public void OpenShutter() => ExecuteRequest(BuildOpenShutterRequest);
        public async Task OpenShutterAsync() => await ExecuteRequestAsync(BuildOpenShutterRequest);
        private RestRequest BuildOpenShutterRequest() => RequestBuilder.BuildRestRequest(DomeMethod.OpenShutter, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());
        
        public void Park() => ExecuteRequest(BuildParkRequest);
        public async Task ParkAsync() => await ExecuteRequestAsync(BuildParkRequest);
        private RestRequest BuildParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.Park, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());
        
        public void SetPark() => ExecuteRequest(BuildSetParkRequest);
        public async Task SetParkAsync() => await ExecuteRequestAsync(BuildSetParkRequest);
        private RestRequest BuildSetParkRequest() => RequestBuilder.BuildRestRequest(DomeMethod.SetPark, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

        public void SlewToAltitude(double altitude) => ExecuteRequest(BuildSlewToAltitudeRequest, altitude);
        public async Task SlewToAltitudeAsync(double altitude) => await ExecuteRequestAsync(BuildSlewToAltitudeRequest, altitude);
        private RestRequest BuildSlewToAltitudeRequest(double altitude)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Altitude ", altitude.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(DomeMethod.SlewToAltitude, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
        
        public void SlewToAzimuth(double azimuth) => ExecuteRequest(BuildSlewToAzimuthRequest, azimuth);
        public async Task SlewToAzimuthAsync(double azimuth) => await ExecuteRequestAsync(BuildSlewToAzimuthRequest, azimuth);
        private RestRequest BuildSlewToAzimuthRequest(double azimuth)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Azimuth ", azimuth.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(DomeMethod.SlewToAzimuth, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void SyncToAzimuth() => ExecuteRequest(BuildSyncToAzimuthRequest);
        public async Task SyncToAzimuthAsync() => await ExecuteRequestAsync(BuildSyncToAzimuthRequest);
        private RestRequest BuildSyncToAzimuthRequest() => RequestBuilder.BuildRestRequest(DomeMethod.SyncToAzimuth, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

    }
}