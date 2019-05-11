using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Devices.Telescope;
using ASCOM.Alpaca.Responses;
using ASCOM.Alpaca.Logging;
using RestSharp;
using NotImplementedException = ASCOM.Alpaca.Exceptions.NotImplementedException;

namespace ASCOM.Alpaca.Client.Devices
{
    public sealed class Telescope : DeviceBase, ITelescope
    {
        public Telescope(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger logger) : base(configuration, clientTransactionIdGenerator, commandSender, logger)
        {
        }

        public Telescope(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.Telescope;

        public AlignmentMode GetAlignmentMode() => ExecuteRequest<AlignmentMode, AlignmentModeResponse>(BuildGetAlignmentModeRequest);    
        public async Task<AlignmentMode> GetAlignmentModeAsync() => await ExecuteRequestAsync<AlignmentMode, AlignmentModeResponse>(BuildGetAlignmentModeRequest);   
        private IRestRequest BuildGetAlignmentModeRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.AlignmentMode, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetAltitude() => ExecuteRequest<double, DoubleResponse>(BuildGetAltitudeRequest);
        public async Task<double> GetAltitudeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetAltitudeRequest);    
        private IRestRequest BuildGetAltitudeRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.Altitude, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetApertureArea() => ExecuteRequest<double, DoubleResponse>(BuildGetApertureAreaRequest);
        public async Task<double> GetApertureAreaAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetApertureAreaRequest);
        private IRestRequest BuildGetApertureAreaRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.ApertureArea, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetApertureDiameter() => ExecuteRequest<double, DoubleResponse>(BuildGetApertureDiameterRequest);
        public async Task<double> GetApertureDiameterAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetApertureDiameterRequest);
        private IRestRequest BuildGetApertureDiameterRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.ApertureDiameter, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool IsAtHome() => ExecuteRequest<bool, BoolResponse>(BuildIsAtHomeRequest);
        public async Task<bool> IsAtHomeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAtHomeRequest);
        private IRestRequest BuildIsAtHomeRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.AtHome, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool IsAtPark() => ExecuteRequest<bool, BoolResponse>(BuildIsAtParkRequest);
        public async Task<bool> IsAtParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAtParkRequest);
        private IRestRequest BuildIsAtParkRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.AtPark, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetAzimuth() => ExecuteRequest<double, DoubleResponse>(BuildGetAzimuthRequest);
        public async Task<double> GetAzimuthAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetAzimuthRequest);
        private IRestRequest BuildGetAzimuthRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.Azimuth, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanFindHome() => ExecuteRequest<bool, BoolResponse>(BuildCanFindHomeRequest);
        public async Task<bool> CanFindHomeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanFindHomeRequest);
        private IRestRequest BuildCanFindHomeRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanFindHome, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanPark() => ExecuteRequest<bool, BoolResponse>(BuildCanParkRequest);
        public async Task<bool> CanParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanParkRequest);
        private IRestRequest BuildCanParkRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanPark, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanPulseGuide() => ExecuteRequest<bool, BoolResponse>(BuildCanPulseGuideRequest);
        public async Task<bool> CanPulseGuideAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanPulseGuideRequest);
        private IRestRequest BuildCanPulseGuideRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanPulseGuide, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanSetDeclinationRate() => ExecuteRequest<bool, BoolResponse>(BuildCanSetDeclinationRateRequest);
        public async Task<bool> CanSetDeclinationRateAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetDeclinationRateRequest);
        private IRestRequest BuildCanSetDeclinationRateRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSetDeclinationRate, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanSetGuideRates() => ExecuteRequest<bool, BoolResponse>(BuildCanSetGuideRatesRequest);
        public async Task<bool> CanSetGuideRatesAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetGuideRatesRequest);
        private IRestRequest BuildCanSetGuideRatesRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSetGuideRates, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanSetPark() => ExecuteRequest<bool, BoolResponse>(BuildCanSetParkRequest);
        public async Task<bool> CanSetParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetParkRequest);
        private IRestRequest BuildCanSetParkRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSetPark, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanSetPierSide() => ExecuteRequest<bool, BoolResponse>(BuildCanSetPierSideRequest);
        public async Task<bool> CanSetPierSideAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetPierSideRequest);
        private IRestRequest BuildCanSetPierSideRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSetPierSide, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanSetRightAscensionRate() => ExecuteRequest<bool, BoolResponse>(BuildCanSetRightAscensionRateRequest);
        public async Task<bool> CanSetRightAscensionRateAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetRightAscensionRateRequest);
        private IRestRequest BuildCanSetRightAscensionRateRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSetRightAscensionRate, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanSetTracking() => ExecuteRequest<bool, BoolResponse>(BuildCanSetTrackingRequest);
        public async Task<bool> CanSetTrackingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetTrackingRequest);
        private IRestRequest BuildCanSetTrackingRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSetTracking, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanSlew()
        {
            bool canSlew = ExecuteRequest<bool, BoolResponse>(BuildCanSlewRequest);

            if (!canSlew)
            {
                bool canSlewAsync = ExecuteRequest<bool, BoolResponse>(BuildCanAsyncSlewRequest);
                return canSlewAsync;
            }

            return canSlew;
        }

        public async Task<bool> CanSlewAsync()
        {
            bool canSlew = await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSlewRequest);
            
            if (!canSlew)
            {
                canSlew = await ExecuteRequestAsync<bool, BoolResponse>(BuildCanAsyncSlewRequest);
            }

            return canSlew;
        }

        private IRestRequest BuildCanSlewRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSlew, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        private IRestRequest BuildCanAsyncSlewRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSlewAsync, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanSlewAltAz()
        {
            bool canSlewAltAz = ExecuteRequest<bool, BoolResponse>(BuildCanSlewAltAzRequest);

            if (!canSlewAltAz)
            {
                canSlewAltAz = ExecuteRequest<bool, BoolResponse>(BuildCanAsyncSlewAltAzRequest);
            }

            return canSlewAltAz;
        }

        public async Task<bool> CanSlewAltAzAsync()
        {
            bool canSlewAltAz = await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSlewAltAzRequest);
            
            if (!canSlewAltAz)
            {
                canSlewAltAz = await ExecuteRequestAsync<bool, BoolResponse>(BuildCanAsyncSlewAltAzRequest);
            }

            return canSlewAltAz;
        }

        private IRestRequest BuildCanSlewAltAzRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSlewAltAz, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        private IRestRequest BuildCanAsyncSlewAltAzRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSlewAltAzAsync, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        
        public bool CanSync() => ExecuteRequest<bool, BoolResponse>(BuildCanSyncRequest);
        public async Task<bool> CanSyncAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSyncRequest);
        private IRestRequest BuildCanSyncRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSync, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public bool CanSyncAltAz() => ExecuteRequest<bool, BoolResponse>(BuildCanSyncAltAzRequest);
        public async Task<bool> CanSyncAltAzAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSyncAltAzRequest);
        private IRestRequest BuildCanSyncAltAzRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.CanSyncAltAz, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetDeclination() => ExecuteRequest<double, DoubleResponse>(BuildGetDeclinationRequest);
        public async Task<double> GetDeclinationAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetDeclinationRequest);
        private IRestRequest BuildGetDeclinationRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.Declination, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetDeclinationRate() => ExecuteRequest<double, DoubleResponse>(BuildGetDeclinationRateRequest);
        public async Task<double> GetDeclinationRateAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetDeclinationRateRequest);
        private IRestRequest BuildGetDeclinationRateRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.DeclinationRate, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetDeclinationRate(double declinationRate) => ExecuteRequest(BuildSetDeclinationRateRequest, declinationRate);
        public async Task SetDeclinationRateAsync(double declinationRate) => await ExecuteRequestAsync(BuildSetDeclinationRateRequest, declinationRate);
        private IRestRequest BuildSetDeclinationRateRequest(double declinationRate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.DeclinationRate, declinationRate.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.DeclinationRate, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public bool DoesRefraction() => ExecuteRequest<bool, BoolResponse>(BuildDoesRefractionRequest);
        public async Task<bool> DoesRefractionAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildDoesRefractionRequest);
        private IRestRequest BuildDoesRefractionRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.DoesRefraction, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetDoesRefraction(bool doesRefraction) => ExecuteRequest(BuildSetDoesRefractionRequest, doesRefraction);
        public async Task SetDoesRefractionAsync(bool doesRefraction) => await ExecuteRequestAsync(BuildSetDoesRefractionRequest, doesRefraction);
        private IRestRequest BuildSetDoesRefractionRequest(bool doesRefraction)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.DoesRefraction, doesRefraction.ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.DoesRefraction, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public EquatorialCoordinateType GetEquatorialSystem() => ExecuteRequest<EquatorialCoordinateType, EquatorialCoordinateTypeResponse>(BuildGetEquatorialSystemRequest);
        public async Task<EquatorialCoordinateType> GetEquatorialSystemAsync() => await ExecuteRequestAsync<EquatorialCoordinateType, EquatorialCoordinateTypeResponse>(BuildGetEquatorialSystemRequest);
        private IRestRequest BuildGetEquatorialSystemRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.EquatorialSystem, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetFocalLength() => ExecuteRequest<double, DoubleResponse>(BuildGetFocalLengthRequest);
        public async Task<double> GetFocalLengthAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetFocalLengthRequest);
        private IRestRequest BuildGetFocalLengthRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.FocalLength, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetGuideRateDeclination() => ExecuteRequest<double, DoubleResponse>(BuildGetGuideRateDeclinationRequest);
        public async Task<double> GetGuideRateDeclinationAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetGuideRateDeclinationRequest);
        private IRestRequest BuildGetGuideRateDeclinationRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.GuideRateDeclination, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetGuideRateDeclination(double guideRate) => ExecuteRequest(BuildSetGuideRateDeclinationRequest, guideRate);
        public async Task SetGuideRateDeclinationAsync(double guideRate) => await ExecuteRequestAsync(BuildSetGuideRateDeclinationRequest, guideRate);
        private IRestRequest BuildSetGuideRateDeclinationRequest(double guideRate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.GuideRateDeclination, guideRate.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.GuideRateDeclination, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetGuideRateRightAscension() => ExecuteRequest<double, DoubleResponse>(BuildGetGuideRateRightAscensionRequest);
        public async Task<double> GetGuideRateRightAscensionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetGuideRateRightAscensionRequest);
        private IRestRequest BuildGetGuideRateRightAscensionRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.GuideRateRightAscension, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetGuideRateRightAscension(double guideRate) => ExecuteRequest(BuildSetGuideRateRightAscensionRequest, guideRate);
        public async Task SetGuideRateRightAscensionAsync(double guideRate) => await ExecuteRequestAsync(BuildSetGuideRateRightAscensionRequest, guideRate);
        private IRestRequest BuildSetGuideRateRightAscensionRequest(double guideRate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.GuideRateRightAscension, guideRate.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.GuideRateRightAscension, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public bool IsPulseGuiding() => ExecuteRequest<bool, BoolResponse>(BuildIsPulseGuidingRequest);
        public async Task<bool> IsPulseGuidingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsPulseGuidingRequest);
        private IRestRequest BuildIsPulseGuidingRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.IsPulseGuiding, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetRightAscension() => ExecuteRequest<double, DoubleResponse>(BuildGetRightAscensionRequest);
        public async Task<double> GetRightAscensionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetRightAscensionRequest);
        private IRestRequest BuildGetRightAscensionRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.RightAscension, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetRightAscensionRate() => ExecuteRequest<double, DoubleResponse>(BuildGetRightAscensionRateRequest);
        public async Task<double> GetRightAscensionRateAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetRightAscensionRateRequest);
        private IRestRequest BuildGetRightAscensionRateRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.RightAscensionRate, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetRightAscensionRate(double rightAscensionRate) => ExecuteRequest(BuildSetRightAscensionRateRequest, rightAscensionRate);
        public async Task SetRightAscensionRateAsync(double rightAscensionRate) => await ExecuteRequestAsync(BuildSetRightAscensionRateRequest, rightAscensionRate);
        private IRestRequest BuildSetRightAscensionRateRequest(double rightAscensionRate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.RightAscensionRate, rightAscensionRate.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.RightAscensionRate, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public PierSide GetSideOfPier() => ExecuteRequest<PierSide, PierSideResponse>(BuildGetSideOfPierRequest);
        public async Task<PierSide> GetSideOfPierAsync() => await ExecuteRequestAsync<PierSide, PierSideResponse>(BuildGetSideOfPierRequest);
        private IRestRequest BuildGetSideOfPierRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.SideOfPier, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetSideOfPier(PierSide sideOfPier) => ExecuteRequest(BuildSetSideOfPierRequest, sideOfPier);
        public async Task SetSideOfPierAsync(PierSide sideOfPier) => await ExecuteRequestAsync(BuildSetSideOfPierRequest, sideOfPier);
        private IRestRequest BuildSetSideOfPierRequest(PierSide sideOfPier)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.SideOfPier, ((int)sideOfPier).ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.SideOfPier, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetSiderealTime() => ExecuteRequest<double, DoubleResponse>(BuildGetSiderealTimeRequest);
        public async Task<double> GetSiderealTimeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSiderealTimeRequest);
        private IRestRequest BuildGetSiderealTimeRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.SiderealTime, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public double GetSiteElevation() => ExecuteRequest<double, DoubleResponse>(BuildGetSiteElevationRequest);
        public async Task<double> GetSiteElevationAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSiteElevationRequest);
        private IRestRequest BuildGetSiteElevationRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.SiteElevation, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetSiteElevation(double siteElevation) => ExecuteRequest(BuildSetSiteElevationRequest, siteElevation);
        public async Task SetSiteElevationAsync(double siteElevation) => await ExecuteRequestAsync(BuildSetSiteElevationRequest, siteElevation);
        private IRestRequest BuildSetSiteElevationRequest(double siteElevation)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.SiteElevation, siteElevation.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.SiteElevation, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetSiteLatitude() => ExecuteRequest<double, DoubleResponse>(BuildGetSiteLatitudeRequest);
        public async Task<double> GetSiteLatitudeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSiteLatitudeRequest);
        private IRestRequest BuildGetSiteLatitudeRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.SiteLatitude, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetSiteLatitude(double latitude) => ExecuteRequest(BuildSetSiteLatitudeRequest, latitude);
        public async Task SetSiteLatitudeAsync(double latitude) => await ExecuteRequestAsync(BuildSetSiteLatitudeRequest, latitude);
        private IRestRequest BuildSetSiteLatitudeRequest(double latitude)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.SiteLatitude, latitude.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.SiteLatitude, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetSiteLongitude() => ExecuteRequest<double, DoubleResponse>(BuildGetSiteLongitudeRequest);
        public async Task<double> GetSiteLongitudeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSiteLongitudeRequest);
        private IRestRequest BuildGetSiteLongitudeRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.SiteLongitude, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetSiteLongitude(double longitude) => ExecuteRequest(BuildSetSiteLongitudeRequest, longitude);
        public async Task SetSiteLongitudeAsync(double longitude) => await ExecuteRequestAsync(BuildSetSiteLongitudeRequest, longitude);
        private IRestRequest BuildSetSiteLongitudeRequest(double longitude)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.SiteLongitude, longitude.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.SiteLongitude, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public bool IsSlewing() => ExecuteRequest<bool, BoolResponse>(BuildIsSlewingRequest);
        public async Task<bool> IsSlewingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSlewingRequest);
        private IRestRequest BuildIsSlewingRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.Slewing, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetSlewSettleTime() => ExecuteRequest<int, IntResponse>(BuildGetSlewSettleTimeRequest);
        public async Task<int> GetSlewSettleTimeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetSlewSettleTimeRequest);
        private IRestRequest BuildGetSlewSettleTimeRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.SlewSettleTime, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetSlewSettleTime(int settleTime) => ExecuteRequest(BuildSetSlewSettleTimeRequest, settleTime);
        public async Task SetSlewSettleTimeAsync(int settleTime) => await ExecuteRequestAsync(BuildSetSlewSettleTimeRequest, settleTime);
        private IRestRequest BuildSetSlewSettleTimeRequest(int settleTime)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.SlewSettleTime, settleTime.ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.SlewSettleTime, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetTargetDeclination() => ExecuteRequest<double, DoubleResponse>(BuildGetTargetDeclinationRequest);
        public async Task<double> GetTargetDeclinationAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTargetDeclinationRequest);
        private IRestRequest BuildGetTargetDeclinationRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.TargetDeclination, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetTargetDeclination(double declination) => ExecuteRequest(BuildSetTargetDeclinationRequest, declination);
        public async Task SetTargetDeclinationAsync(double declination) => await ExecuteRequestAsync(BuildSetTargetDeclinationRequest, declination);
        private IRestRequest BuildSetTargetDeclinationRequest(double declination)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.TargetDeclination, declination.ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.TargetDeclination, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public double GetTargetRightAscension() => ExecuteRequest<double, DoubleResponse>(BuildGetTargetRightAscensionRequest);
        public async Task<double> GetTargetRightAscensionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTargetRightAscensionRequest);
        private IRestRequest BuildGetTargetRightAscensionRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.TargetRightAscension, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetTargetRightAscension(double rightAscension) => ExecuteRequest(BuildSetTargetRightAscensionRequest, rightAscension);
        public async Task SetTargetRightAscensionAsync(double rightAscension) => await ExecuteRequestAsync(BuildSetTargetRightAscensionRequest, rightAscension);
        private IRestRequest BuildSetTargetRightAscensionRequest(double rightAscension)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.TargetRightAscension, rightAscension.ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.TargetRightAscension, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public bool IsTracking() => ExecuteRequest<bool, BoolResponse>(BuildIsTrackingRequest);
        public async Task<bool> IsTrackingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsTrackingRequest);
        private IRestRequest BuildIsTrackingRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.Tracking, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetTracking(bool tracking) => ExecuteRequest(BuildSetTrackingAsyncRequest, tracking);
        public async Task SetTrackingAsync(bool tracking) => await ExecuteRequestAsync(BuildSetTrackingAsyncRequest, tracking);
        private IRestRequest BuildSetTrackingAsyncRequest(bool tracking)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.Tracking, tracking.ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.Tracking, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public DriveRate GetTrackingRate() => ExecuteRequest<DriveRate, DriveRateResponse>(BuildGetTrackingRateRequest);
        public async Task<DriveRate> GetTrackingRateAsync() => await ExecuteRequestAsync<DriveRate, DriveRateResponse>(BuildGetTrackingRateRequest);
        private IRestRequest BuildGetTrackingRateRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.TrackingRate, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetTrackingRate(DriveRate trackingRate) => ExecuteRequest(BuildSetTrackingRateRequest, trackingRate);
        public async Task SetTrackingRateAsync(DriveRate trackingRate) => await ExecuteRequestAsync(BuildSetTrackingRateRequest, trackingRate);
        private IRestRequest BuildSetTrackingRateRequest(DriveRate trackingRate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.TrackingRate, ((int)trackingRate).ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.TrackingRate, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public List<DriveRate> GetTrackingRates() => ExecuteRequest<List<DriveRate>, DriveRatesResponse>(BuildGetTrackingRatesRequest);
        public async Task<List<DriveRate>> GetTrackingRatesAsync() => await ExecuteRequestAsync<List<DriveRate>, DriveRatesResponse>(BuildGetTrackingRatesRequest);
        private IRestRequest BuildGetTrackingRatesRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.TrackingRates, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public DateTime GetUtcDate()
        {
            string dateTimeString = ExecuteRequest<string, StringResponse>(BuildGetUtcDateRequest);
            return DateTime.Parse(dateTimeString, null, DateTimeStyles.AssumeUniversal);
        }
        public async Task<DateTime> GetUtcDateAsync()
        {
            string dateTimeString = await ExecuteRequestAsync<string, StringResponse>(BuildGetUtcDateRequest);
            return DateTime.Parse(dateTimeString, null, DateTimeStyles.AssumeUniversal);
        }
        private IRestRequest BuildGetUtcDateRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.UTCDate, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetUtcDate(DateTime utcDate) => ExecuteRequest(BuildSetUtcDateRequest, utcDate);
        public async Task SetUtcDateAsync(DateTime utcDate) => await ExecuteRequestAsync(BuildSetUtcDateRequest, utcDate);
        private IRestRequest BuildSetUtcDateRequest(DateTime utcDate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.UTCDate, utcDate.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.UTCDate, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void AbortSlew() => ExecuteRequest(BuildAbortSlewRequest);
        public async Task AbortSlewAsync() => await ExecuteRequestAsync(BuildAbortSlewRequest);
        private IRestRequest BuildAbortSlewRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.AbortSlew, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

        public List<AxisRate> GetAxisRates(TelescopeAxis axis) => ExecuteRequest<List<AxisRate>, AxisRatesResponse, TelescopeAxis>(BuildGetAxisRatesRequest, axis);
        public async Task<List<AxisRate>> GetAxisRatesAsync(TelescopeAxis axis) => await ExecuteRequestAsync<List<AxisRate>, AxisRatesResponse, TelescopeAxis>(BuildGetAxisRatesRequest, axis);
        private IRestRequest BuildGetAxisRatesRequest(TelescopeAxis axis)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.Axis, ((int)axis).ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.AxisRates, Method.GET, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public bool CanMoveAxis(TelescopeAxis axis) => ExecuteRequest<bool, BoolResponse, TelescopeAxis>(BuildCanMoveAxisRequest, axis);
        public async Task<bool> CanMoveAxisAsync(TelescopeAxis axis) => await ExecuteRequestAsync<bool, BoolResponse, TelescopeAxis>(BuildCanMoveAxisRequest, axis);
        private IRestRequest BuildCanMoveAxisRequest(TelescopeAxis axis)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.Axis, ((int)axis).ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.CanMoveAxis, Method.GET, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public PierSide GetDestinationSideOfPier(double rightAscension, double declination) => 
            ExecuteRequest<PierSide, PierSideResponse, double, double>(BuildGetDestinationSideOfPierRequest, rightAscension, declination);
            
        public async Task<PierSide> GetDestinationSideOfPierAsync(double rightAscension, double declination) =>
            await ExecuteRequestAsync<PierSide, PierSideResponse, double, double>(BuildGetDestinationSideOfPierRequest, rightAscension, declination);
        private IRestRequest BuildGetDestinationSideOfPierRequest(double rightAscension, double declination)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.RightAscension, rightAscension.ToString(CultureInfo.InvariantCulture)},
                {TelescopeMethodParameter.Declination, declination.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.DestinationSideOfPier, Method.GET, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void FindHome() => ExecuteRequest(BuildFindHomeRequest);
        public async Task FindHomeAsync() => await ExecuteRequestAsync(BuildFindHomeRequest);
        private IRestRequest BuildFindHomeRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.FindHome, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

        public void MoveAxis(TelescopeAxis axis, double rate) => ExecuteRequest(BuildMoveAxisRequest, axis, rate);
        public async Task MoveAxisAsync(TelescopeAxis axis, double rate) => await ExecuteRequestAsync(BuildMoveAxisRequest, axis, rate);
        private IRestRequest BuildMoveAxisRequest(TelescopeAxis axis, double rate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.Axis, ((int) axis).ToString()},
                {TelescopeMethodParameter.Rate, rate.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.MoveAxis, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void Park() => ExecuteRequest(BuildParkRequest);
        public async Task ParkAsync() => await ExecuteRequestAsync(BuildParkRequest);
        private IRestRequest BuildParkRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.Park, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

        public void PulseGuide(GuideDirection direction, int duration) => ExecuteRequest(BuildPulseGuideRequest, direction, duration);
        public async Task PulseGuideAsync(GuideDirection direction, int duration) => await ExecuteRequestAsync(BuildPulseGuideRequest, direction, duration);
        private IRestRequest BuildPulseGuideRequest(GuideDirection direction, int duration)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.Direction, ((int)direction).ToString()},
                {TelescopeMethodParameter.Duration, duration.ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.PulseGuide, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void SetPark() => ExecuteRequest(BuildSetParkRequest);
        public async Task SetParkAsync() => await ExecuteRequestAsync(BuildSetParkRequest);
        private IRestRequest BuildSetParkRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.SetPark, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

        public void SlewToAltAz(double altitude, double azimuth)
        {
            try
            {
                ExecuteRequest(BuildSlewAsyncToAltAzRequest, altitude, azimuth);
            }
            catch (NotImplementedException ex)
            {
                Logger.LogDebug(ex, "slewtoaltazasync is not supported, try with slewtoaltaz");
                ExecuteRequest(BuildSlewToAltAzRequest, altitude, azimuth);             
            }
        }

        public async Task SlewToAltAzAsync(double altitude, double azimuth)
        {
            try
            {
                await ExecuteRequestAsync(BuildSlewAsyncToAltAzRequest, altitude, azimuth);
            }
            catch (NotImplementedException ex)
            {
                Logger.LogDebug(ex, "slewtoaltazasync is not supported, try with slewtoaltaz");
                await ExecuteRequestAsync(BuildSlewToAltAzRequest, altitude, azimuth);             
            }
        }

        private IRestRequest BuildSlewToAltAzRequest(double altitude, double azimuth)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.Altitude, altitude.ToString(CultureInfo.InvariantCulture)},
                {TelescopeMethodParameter.Azimuth, azimuth.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.SlewToAltAz, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
        private IRestRequest BuildSlewAsyncToAltAzRequest(double altitude, double azimuth)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.Altitude, altitude.ToString(CultureInfo.InvariantCulture)},
                {TelescopeMethodParameter.Azimuth, azimuth.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.SlewToAltAzAsync, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
        
        public void SlewToCoordinates(double rightAscension, double declination)
        {
            try
            {
                ExecuteRequest(BuildSlewAsyncToCoordinatesRequest, rightAscension, declination);
            }
            catch (NotImplementedException ex)
            {
                Logger.LogDebug(ex, "slewtocoordinatesasync is not supported, try with slewtocoordinates");
                ExecuteRequest(BuildSlewToCoordinatesRequest, rightAscension, declination);             
            }
        }
        public async Task SlewToCoordinatesAsync(double rightAscension, double declination)
        {
            try
            {
                await ExecuteRequestAsync(BuildSlewAsyncToCoordinatesRequest, rightAscension, declination);
            }
            catch (NotImplementedException ex)
            {
                Logger.LogDebug(ex, "slewtocoordinatesasync is not supported, try with slewtocoordinates");
                await ExecuteRequestAsync(BuildSlewToCoordinatesRequest, rightAscension, declination);
            }
        }
        private IRestRequest BuildSlewToCoordinatesRequest(double rightAscension, double declination)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.RightAscension, rightAscension.ToString(CultureInfo.InvariantCulture)},
                {TelescopeMethodParameter.Declination, declination.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.SlewToCoordinates, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
        private IRestRequest BuildSlewAsyncToCoordinatesRequest(double rightAscension, double declination)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.RightAscension, rightAscension.ToString(CultureInfo.InvariantCulture)},
                {TelescopeMethodParameter.Declination, declination.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.SlewToCoordinatesAsync, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
        
        public void SlewToTarget()
        {
            try
            {
                ExecuteRequest(BuildSlewAsyncToTargetRequest);
            }
            catch (NotImplementedException ex)
            {
                Logger.LogDebug(ex, "slewtotargetasync is not supported, try with slewtotarget");
                ExecuteRequest(BuildSlewToTargetRequest);
            }
        }
        public async Task SlewToTargetAsync()
        {
            try
            {
                await ExecuteRequestAsync(BuildSlewAsyncToTargetRequest);
            }
            catch (NotImplementedException ex)
            {
                Logger.LogDebug(ex, "slewtotargetasync is not supported, try with slewtotarget");
                await ExecuteRequestAsync(BuildSlewToTargetRequest);
            }
        }
        private IRestRequest BuildSlewToTargetRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.SlewToTarget, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());
        private IRestRequest BuildSlewAsyncToTargetRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.SlewToTargetAsync, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

        public void SyncToAltAz(double altitude, double azimuth) => ExecuteRequest(BuildSyncToAltAzRequest, altitude, azimuth);
        public async Task SyncToAltAzAsync(double altitude, double azimuth) => await ExecuteRequestAsync(BuildSyncToAltAzRequest, altitude, azimuth);
        private IRestRequest BuildSyncToAltAzRequest(double altitude, double azimuth)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.Altitude, altitude.ToString(CultureInfo.InvariantCulture)},
                {TelescopeMethodParameter.Azimuth, azimuth.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.SyncToAltAz, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void SyncToCoordinates(double rightAscension, double declination) => ExecuteRequest(BuildSyncToCoordinatesRequest, rightAscension, declination);
        public async Task SyncToCoordinatesAsync(double rightAscension, double declination) => await ExecuteRequestAsync(BuildSyncToCoordinatesRequest, rightAscension, declination);
        private IRestRequest BuildSyncToCoordinatesRequest(double rightAscension, double declination)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeMethodParameter.RightAscension, rightAscension.ToString(CultureInfo.InvariantCulture)},
                {TelescopeMethodParameter.Declination, declination.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeMethod.SyncToCoordinates, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void SyncToTarget() => ExecuteRequest(BuildSyncToTargetRequest);
        public async Task SyncToTargetAsync() => await ExecuteRequestAsync(BuildSyncToTargetRequest);
        private IRestRequest BuildSyncToTargetRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.SyncToTarget, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());

        public void Unpark() => ExecuteRequest(BuildUnparkRequest);
        public async Task UnparkAsync() => await ExecuteRequestAsync(BuildUnparkRequest);
        private IRestRequest BuildUnparkRequest() => RequestBuilder.BuildRestRequest(TelescopeMethod.UnPark, Method.PUT, ClientTransactionIdGenerator.GetTransactionId());
    }
}