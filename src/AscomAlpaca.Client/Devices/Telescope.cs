using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Logging;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Devices;
using ES.AscomAlpaca.Exceptions;
using ES.AscomAlpaca.Responses;
using RestSharp;

namespace ES.AscomAlpaca.Client.Devices
{
    /// <summary>
    /// Client implementation of an ASCOM Alpaca Telescope device.
    /// <para>This class is meant to be use in a client application that need to control an ASCOM Alpaca Telescope</para>
    /// </summary>
    public sealed class Telescope : DeviceBase, ITelescope, ITelescopeAsync
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Telescope" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        public Telescope(DeviceConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Telescope" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public Telescope(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Telescope" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        public Telescope(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Telescope" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public Telescope(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        internal Telescope(DeviceConfiguration configuration, ICommandSender commandSender) : 
            base(configuration, commandSender)
        {
        }

        internal Telescope(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : 
            base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }

        /// <inheritdoc/>
        protected override DeviceType DeviceType { get; } = DeviceType.Telescope;

        /// <inheritdoc/>
        public AlignmentMode GetAlignmentMode() => ExecuteRequest<AlignmentMode, AlignmentModeResponse>(BuildGetAlignmentModeRequest);    
        /// <inheritdoc/>
        public async Task<AlignmentMode> GetAlignmentModeAsync() => await ExecuteRequestAsync<AlignmentMode, AlignmentModeResponse>(BuildGetAlignmentModeRequest);   
        private IRestRequest BuildGetAlignmentModeRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.AlignmentMode, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetAltitude() => ExecuteRequest<double, DoubleResponse>(BuildGetAltitudeRequest);
        /// <inheritdoc/>
        public async Task<double> GetAltitudeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetAltitudeRequest);    
        private IRestRequest BuildGetAltitudeRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.Altitude, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetApertureArea() => ExecuteRequest<double, DoubleResponse>(BuildGetApertureAreaRequest);
        /// <inheritdoc/>
        public async Task<double> GetApertureAreaAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetApertureAreaRequest);
        private IRestRequest BuildGetApertureAreaRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.ApertureArea, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetApertureDiameter() => ExecuteRequest<double, DoubleResponse>(BuildGetApertureDiameterRequest);
        /// <inheritdoc/>
        public async Task<double> GetApertureDiameterAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetApertureDiameterRequest);
        private IRestRequest BuildGetApertureDiameterRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.ApertureDiameter, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool IsAtHome() => ExecuteRequest<bool, BoolResponse>(BuildIsAtHomeRequest);
        /// <inheritdoc/>
        public async Task<bool> IsAtHomeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAtHomeRequest);
        private IRestRequest BuildIsAtHomeRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.AtHome, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool IsAtPark() => ExecuteRequest<bool, BoolResponse>(BuildIsAtParkRequest);
        /// <inheritdoc/>
        public async Task<bool> IsAtParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsAtParkRequest);
        private IRestRequest BuildIsAtParkRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.AtPark, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetAzimuth() => ExecuteRequest<double, DoubleResponse>(BuildGetAzimuthRequest);
        /// <inheritdoc/>
        public async Task<double> GetAzimuthAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetAzimuthRequest);
        private IRestRequest BuildGetAzimuthRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.Azimuth, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanFindHome() => ExecuteRequest<bool, BoolResponse>(BuildCanFindHomeRequest);
        /// <inheritdoc/>
        public async Task<bool> CanFindHomeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanFindHomeRequest);
        private IRestRequest BuildCanFindHomeRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanFindHome, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanPark() => ExecuteRequest<bool, BoolResponse>(BuildCanParkRequest);
        /// <inheritdoc/>
        public async Task<bool> CanParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanParkRequest);
        private IRestRequest BuildCanParkRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanPark, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanPulseGuide() => ExecuteRequest<bool, BoolResponse>(BuildCanPulseGuideRequest);
        /// <inheritdoc/>
        public async Task<bool> CanPulseGuideAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanPulseGuideRequest);
        private IRestRequest BuildCanPulseGuideRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanPulseGuide, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanSetDeclinationRate() => ExecuteRequest<bool, BoolResponse>(BuildCanSetDeclinationRateRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSetDeclinationRateAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetDeclinationRateRequest);
        private IRestRequest BuildCanSetDeclinationRateRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSetDeclinationRate, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanSetGuideRates() => ExecuteRequest<bool, BoolResponse>(BuildCanSetGuideRatesRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSetGuideRatesAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetGuideRatesRequest);
        private IRestRequest BuildCanSetGuideRatesRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSetGuideRates, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanSetPark() => ExecuteRequest<bool, BoolResponse>(BuildCanSetParkRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSetParkAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetParkRequest);
        private IRestRequest BuildCanSetParkRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSetPark, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanSetPierSide() => ExecuteRequest<bool, BoolResponse>(BuildCanSetPierSideRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSetPierSideAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetPierSideRequest);
        private IRestRequest BuildCanSetPierSideRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSetPierSide, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanSetRightAscensionRate() => ExecuteRequest<bool, BoolResponse>(BuildCanSetRightAscensionRateRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSetRightAscensionRateAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetRightAscensionRateRequest);
        private IRestRequest BuildCanSetRightAscensionRateRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSetRightAscensionRate, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanSetTracking() => ExecuteRequest<bool, BoolResponse>(BuildCanSetTrackingRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSetTrackingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSetTrackingRequest);
        private IRestRequest BuildCanSetTrackingRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSetTracking, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanSlew()
        {
            bool canSlew = ExecuteRequest<bool, BoolResponse>(BuildCanSlewRequest);

            if (!canSlew)
            {
                canSlew = ExecuteRequest<bool, BoolResponse>(BuildCanAsyncSlewRequest);
            }

            return canSlew;
        }

        /// <inheritdoc/>
        public async Task<bool> CanSlewAsync()
        {
            bool canSlew = await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSlewRequest);
            
            if (!canSlew)
            {
                canSlew = await ExecuteRequestAsync<bool, BoolResponse>(BuildCanAsyncSlewRequest);
            }

            return canSlew;
        }

        private IRestRequest BuildCanSlewRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSlew, Method.GET, GetClientTransactionId());
        private IRestRequest BuildCanAsyncSlewRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSlewAsync, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanSlewAltAz()
        {
            bool canSlewAltAz = ExecuteRequest<bool, BoolResponse>(BuildCanSlewAltAzRequest);

            if (!canSlewAltAz)
            {
                canSlewAltAz = ExecuteRequest<bool, BoolResponse>(BuildCanAsyncSlewAltAzRequest);
            }

            return canSlewAltAz;
        }

        /// <inheritdoc/>
        public async Task<bool> CanSlewAltAzAsync()
        {
            bool canSlewAltAz = await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSlewAltAzRequest);
            
            if (!canSlewAltAz)
            {
                canSlewAltAz = await ExecuteRequestAsync<bool, BoolResponse>(BuildCanAsyncSlewAltAzRequest);
            }

            return canSlewAltAz;
        }

        private IRestRequest BuildCanSlewAltAzRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSlewAltAz, Method.GET, GetClientTransactionId());
        private IRestRequest BuildCanAsyncSlewAltAzRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSlewAltAzAsync, Method.GET, GetClientTransactionId());

        
        /// <inheritdoc/>
        public bool CanSync() => ExecuteRequest<bool, BoolResponse>(BuildCanSyncRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSyncAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSyncRequest);
        private IRestRequest BuildCanSyncRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSync, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanSyncAltAz() => ExecuteRequest<bool, BoolResponse>(BuildCanSyncAltAzRequest);
        /// <inheritdoc/>
        public async Task<bool> CanSyncAltAzAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildCanSyncAltAzRequest);
        private IRestRequest BuildCanSyncAltAzRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.CanSyncAltAz, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetDeclination() => ExecuteRequest<double, DoubleResponse>(BuildGetDeclinationRequest);
        /// <inheritdoc/>
        public async Task<double> GetDeclinationAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetDeclinationRequest);
        private IRestRequest BuildGetDeclinationRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.Declination, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetDeclinationRate() => ExecuteRequest<double, DoubleResponse>(BuildGetDeclinationRateRequest);
        /// <inheritdoc/>
        public async Task<double> GetDeclinationRateAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetDeclinationRateRequest);
        private IRestRequest BuildGetDeclinationRateRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.DeclinationRate, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetDeclinationRate(double declinationRate) => ExecuteRequest(BuildSetDeclinationRateRequest, declinationRate);
        /// <inheritdoc/>
        public async Task SetDeclinationRateAsync(double declinationRate) => await ExecuteRequestAsync(BuildSetDeclinationRateRequest, declinationRate);
        private IRestRequest BuildSetDeclinationRateRequest(double declinationRate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.DeclinationRate, declinationRate.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.DeclinationRate, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public bool DoesRefraction() => ExecuteRequest<bool, BoolResponse>(BuildDoesRefractionRequest);
        /// <inheritdoc/>
        public async Task<bool> DoesRefractionAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildDoesRefractionRequest);
        private IRestRequest BuildDoesRefractionRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.DoesRefraction, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetDoesRefraction(bool doesRefraction) => ExecuteRequest(BuildSetDoesRefractionRequest, doesRefraction);
        /// <inheritdoc/>
        public async Task SetDoesRefractionAsync(bool doesRefraction) => await ExecuteRequestAsync(BuildSetDoesRefractionRequest, doesRefraction);
        private IRestRequest BuildSetDoesRefractionRequest(bool doesRefraction)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.DoesRefraction, doesRefraction.ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.DoesRefraction, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public EquatorialCoordinateType GetEquatorialSystem() => ExecuteRequest<EquatorialCoordinateType, EquatorialCoordinateTypeResponse>(BuildGetEquatorialSystemRequest);
        /// <inheritdoc/>
        public async Task<EquatorialCoordinateType> GetEquatorialSystemAsync() => await ExecuteRequestAsync<EquatorialCoordinateType, EquatorialCoordinateTypeResponse>(BuildGetEquatorialSystemRequest);
        private IRestRequest BuildGetEquatorialSystemRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.EquatorialSystem, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetFocalLength() => ExecuteRequest<double, DoubleResponse>(BuildGetFocalLengthRequest);
        /// <inheritdoc/>
        public async Task<double> GetFocalLengthAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetFocalLengthRequest);
        private IRestRequest BuildGetFocalLengthRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.FocalLength, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetGuideRateDeclination() => ExecuteRequest<double, DoubleResponse>(BuildGetGuideRateDeclinationRequest);
        /// <inheritdoc/>
        public async Task<double> GetGuideRateDeclinationAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetGuideRateDeclinationRequest);
        private IRestRequest BuildGetGuideRateDeclinationRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.GuideRateDeclination, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetGuideRateDeclination(double guideRate) => ExecuteRequest(BuildSetGuideRateDeclinationRequest, guideRate);
        /// <inheritdoc/>
        public async Task SetGuideRateDeclinationAsync(double guideRate) => await ExecuteRequestAsync(BuildSetGuideRateDeclinationRequest, guideRate);
        private IRestRequest BuildSetGuideRateDeclinationRequest(double guideRate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.GuideRateDeclination, guideRate.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.GuideRateDeclination, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetGuideRateRightAscension() => ExecuteRequest<double, DoubleResponse>(BuildGetGuideRateRightAscensionRequest);
        /// <inheritdoc/>
        public async Task<double> GetGuideRateRightAscensionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetGuideRateRightAscensionRequest);
        private IRestRequest BuildGetGuideRateRightAscensionRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.GuideRateRightAscension, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetGuideRateRightAscension(double guideRate) => ExecuteRequest(BuildSetGuideRateRightAscensionRequest, guideRate);
        /// <inheritdoc/>
        public async Task SetGuideRateRightAscensionAsync(double guideRate) => await ExecuteRequestAsync(BuildSetGuideRateRightAscensionRequest, guideRate);
        private IRestRequest BuildSetGuideRateRightAscensionRequest(double guideRate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.GuideRateRightAscension, guideRate.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.GuideRateRightAscension, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public bool IsPulseGuiding() => ExecuteRequest<bool, BoolResponse>(BuildIsPulseGuidingRequest);
        /// <inheritdoc/>
        public async Task<bool> IsPulseGuidingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsPulseGuidingRequest);
        private IRestRequest BuildIsPulseGuidingRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.IsPulseGuiding, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetRightAscension() => ExecuteRequest<double, DoubleResponse>(BuildGetRightAscensionRequest);
        /// <inheritdoc/>
        public async Task<double> GetRightAscensionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetRightAscensionRequest);
        private IRestRequest BuildGetRightAscensionRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.RightAscension, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetRightAscensionRate() => ExecuteRequest<double, DoubleResponse>(BuildGetRightAscensionRateRequest);
        /// <inheritdoc/>
        public async Task<double> GetRightAscensionRateAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetRightAscensionRateRequest);
        private IRestRequest BuildGetRightAscensionRateRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.RightAscensionRate, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetRightAscensionRate(double rightAscensionRate) => ExecuteRequest(BuildSetRightAscensionRateRequest, rightAscensionRate);
        /// <inheritdoc/>
        public async Task SetRightAscensionRateAsync(double rightAscensionRate) => await ExecuteRequestAsync(BuildSetRightAscensionRateRequest, rightAscensionRate);
        private IRestRequest BuildSetRightAscensionRateRequest(double rightAscensionRate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.RightAscensionRate, rightAscensionRate.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.RightAscensionRate, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public PierSide GetSideOfPier() => ExecuteRequest<PierSide, PierSideResponse>(BuildGetSideOfPierRequest);
        /// <inheritdoc/>
        public async Task<PierSide> GetSideOfPierAsync() => await ExecuteRequestAsync<PierSide, PierSideResponse>(BuildGetSideOfPierRequest);
        private IRestRequest BuildGetSideOfPierRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.SideOfPier, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetSideOfPier(PierSide sideOfPier) => ExecuteRequest(BuildSetSideOfPierRequest, sideOfPier);
        /// <inheritdoc/>
        public async Task SetSideOfPierAsync(PierSide sideOfPier) => await ExecuteRequestAsync(BuildSetSideOfPierRequest, sideOfPier);
        private IRestRequest BuildSetSideOfPierRequest(PierSide sideOfPier)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.SideOfPier, ((int)sideOfPier).ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.SideOfPier, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetSiderealTime() => ExecuteRequest<double, DoubleResponse>(BuildGetSiderealTimeRequest);
        /// <inheritdoc/>
        public async Task<double> GetSiderealTimeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSiderealTimeRequest);
        private IRestRequest BuildGetSiderealTimeRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.SiderealTime, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public double GetSiteElevation() => ExecuteRequest<double, DoubleResponse>(BuildGetSiteElevationRequest);
        /// <inheritdoc/>
        public async Task<double> GetSiteElevationAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSiteElevationRequest);
        private IRestRequest BuildGetSiteElevationRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.SiteElevation, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetSiteElevation(double siteElevation) => ExecuteRequest(BuildSetSiteElevationRequest, siteElevation);
        /// <inheritdoc/>
        public async Task SetSiteElevationAsync(double siteElevation) => await ExecuteRequestAsync(BuildSetSiteElevationRequest, siteElevation);
        private IRestRequest BuildSetSiteElevationRequest(double siteElevation)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.SiteElevation, siteElevation.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.SiteElevation, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetSiteLatitude() => ExecuteRequest<double, DoubleResponse>(BuildGetSiteLatitudeRequest);
        /// <inheritdoc/>
        public async Task<double> GetSiteLatitudeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSiteLatitudeRequest);
        private IRestRequest BuildGetSiteLatitudeRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.SiteLatitude, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetSiteLatitude(double latitude) => ExecuteRequest(BuildSetSiteLatitudeRequest, latitude);
        /// <inheritdoc/>
        public async Task SetSiteLatitudeAsync(double latitude) => await ExecuteRequestAsync(BuildSetSiteLatitudeRequest, latitude);
        private IRestRequest BuildSetSiteLatitudeRequest(double latitude)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.SiteLatitude, latitude.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.SiteLatitude, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetSiteLongitude() => ExecuteRequest<double, DoubleResponse>(BuildGetSiteLongitudeRequest);
        /// <inheritdoc/>
        public async Task<double> GetSiteLongitudeAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetSiteLongitudeRequest);
        private IRestRequest BuildGetSiteLongitudeRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.SiteLongitude, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetSiteLongitude(double longitude) => ExecuteRequest(BuildSetSiteLongitudeRequest, longitude);
        /// <inheritdoc/>
        public async Task SetSiteLongitudeAsync(double longitude) => await ExecuteRequestAsync(BuildSetSiteLongitudeRequest, longitude);
        private IRestRequest BuildSetSiteLongitudeRequest(double longitude)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.SiteLongitude, longitude.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.SiteLongitude, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public bool IsSlewing() => ExecuteRequest<bool, BoolResponse>(BuildIsSlewingRequest);
        /// <inheritdoc/>
        public async Task<bool> IsSlewingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSlewingRequest);
        private IRestRequest BuildIsSlewingRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.Slewing, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetSlewSettleTime() => ExecuteRequest<int, IntResponse>(BuildGetSlewSettleTimeRequest);
        /// <inheritdoc/>
        public async Task<int> GetSlewSettleTimeAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetSlewSettleTimeRequest);
        private IRestRequest BuildGetSlewSettleTimeRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.SlewSettleTime, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetSlewSettleTime(int settleTime) => ExecuteRequest(BuildSetSlewSettleTimeRequest, settleTime);
        /// <inheritdoc/>
        public async Task SetSlewSettleTimeAsync(int settleTime) => await ExecuteRequestAsync(BuildSetSlewSettleTimeRequest, settleTime);
        private IRestRequest BuildSetSlewSettleTimeRequest(int settleTime)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.SlewSettleTime, settleTime.ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.SlewSettleTime, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetTargetDeclination() => ExecuteRequest<double, DoubleResponse>(BuildGetTargetDeclinationRequest);
        /// <inheritdoc/>
        public async Task<double> GetTargetDeclinationAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTargetDeclinationRequest);
        private IRestRequest BuildGetTargetDeclinationRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.TargetDeclination, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetTargetDeclination(double declination) => ExecuteRequest(BuildSetTargetDeclinationRequest, declination);
        /// <inheritdoc/>
        public async Task SetTargetDeclinationAsync(double declination) => await ExecuteRequestAsync(BuildSetTargetDeclinationRequest, declination);
        private IRestRequest BuildSetTargetDeclinationRequest(double declination)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.TargetDeclination, declination.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.TargetDeclination, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetTargetRightAscension() => ExecuteRequest<double, DoubleResponse>(BuildGetTargetRightAscensionRequest);
        /// <inheritdoc/>
        public async Task<double> GetTargetRightAscensionAsync() => await ExecuteRequestAsync<double, DoubleResponse>(BuildGetTargetRightAscensionRequest);
        private IRestRequest BuildGetTargetRightAscensionRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.TargetRightAscension, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetTargetRightAscension(double rightAscension) => ExecuteRequest(BuildSetTargetRightAscensionRequest, rightAscension);
        /// <inheritdoc/>
        public async Task SetTargetRightAscensionAsync(double rightAscension) => await ExecuteRequestAsync(BuildSetTargetRightAscensionRequest, rightAscension);
        private IRestRequest BuildSetTargetRightAscensionRequest(double rightAscension)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.TargetRightAscension, rightAscension.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.TargetRightAscension, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public bool IsTracking() => ExecuteRequest<bool, BoolResponse>(BuildIsTrackingRequest);
        /// <inheritdoc/>
        public async Task<bool> IsTrackingAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsTrackingRequest);
        private IRestRequest BuildIsTrackingRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.Tracking, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetTracking(bool tracking) => ExecuteRequest(BuildSetTrackingAsyncRequest, tracking);
        /// <inheritdoc/>
        public async Task SetTrackingAsync(bool tracking) => await ExecuteRequestAsync(BuildSetTrackingAsyncRequest, tracking);
        private IRestRequest BuildSetTrackingAsyncRequest(bool tracking)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.Tracking, tracking.ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.Tracking, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public DriveRate GetTrackingRate() => ExecuteRequest<DriveRate, DriveRateResponse>(BuildGetTrackingRateRequest);
        /// <inheritdoc/>
        public async Task<DriveRate> GetTrackingRateAsync() => await ExecuteRequestAsync<DriveRate, DriveRateResponse>(BuildGetTrackingRateRequest);
        private IRestRequest BuildGetTrackingRateRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.TrackingRate, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetTrackingRate(DriveRate trackingRate) => ExecuteRequest(BuildSetTrackingRateRequest, trackingRate);
        /// <inheritdoc/>
        public async Task SetTrackingRateAsync(DriveRate trackingRate) => await ExecuteRequestAsync(BuildSetTrackingRateRequest, trackingRate);
        private IRestRequest BuildSetTrackingRateRequest(DriveRate trackingRate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.TrackingRate, ((int)trackingRate).ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.TrackingRate, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public IList<DriveRate> GetTrackingRates() => ExecuteRequest<IList<DriveRate>, DriveRatesResponse>(BuildGetTrackingRatesRequest);
        /// <inheritdoc/>
        public async Task<IList<DriveRate>> GetTrackingRatesAsync() => await ExecuteRequestAsync<IList<DriveRate>, DriveRatesResponse>(BuildGetTrackingRatesRequest);
        private IRestRequest BuildGetTrackingRatesRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.TrackingRates, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public DateTime GetUtcDate()
        {
            string dateTimeString = ExecuteRequest<string, StringResponse>(BuildGetUtcDateRequest);
            return DateTime.Parse(dateTimeString, null, DateTimeStyles.AssumeUniversal);
        }
        /// <inheritdoc/>
        public async Task<DateTime> GetUtcDateAsync()
        {
            string dateTimeString = await ExecuteRequestAsync<string, StringResponse>(BuildGetUtcDateRequest);
            return DateTime.Parse(dateTimeString, null, DateTimeStyles.AssumeUniversal);
        }
        private IRestRequest BuildGetUtcDateRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.UTCDate, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public void SetUtcDate(DateTime utcDate) => ExecuteRequest(BuildSetUtcDateRequest, utcDate);
        /// <inheritdoc/>
        public async Task SetUtcDateAsync(DateTime utcDate) => await ExecuteRequestAsync(BuildSetUtcDateRequest, utcDate);
        private IRestRequest BuildSetUtcDateRequest(DateTime utcDate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.UTCDate, utcDate.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.UTCDate, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public void AbortSlew() => ExecuteRequest(BuildAbortSlewRequest);
        /// <inheritdoc/>
        public async Task AbortSlewAsync() => await ExecuteRequestAsync(BuildAbortSlewRequest);
        private IRestRequest BuildAbortSlewRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.AbortSlew, Method.PUT, GetClientTransactionId());

        /// <inheritdoc/>
        public IList<AxisRate> GetAxisRates(TelescopeAxis axis) => ExecuteRequest<IList<AxisRate>, AxisRatesResponse, TelescopeAxis>(BuildGetAxisRatesRequest, axis);
        /// <inheritdoc/>
        public async Task<IList<AxisRate>> GetAxisRatesAsync(TelescopeAxis axis) => await ExecuteRequestAsync<IList<AxisRate>, AxisRatesResponse, TelescopeAxis>(BuildGetAxisRatesRequest, axis);
        private IRestRequest BuildGetAxisRatesRequest(TelescopeAxis axis)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.Axis, ((int)axis).ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.AxisRates, Method.GET, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public bool CanMoveAxis(TelescopeAxis axis) => ExecuteRequest<bool, BoolResponse, TelescopeAxis>(BuildCanMoveAxisRequest, axis);
        /// <inheritdoc/>
        public async Task<bool> CanMoveAxisAsync(TelescopeAxis axis) => await ExecuteRequestAsync<bool, BoolResponse, TelescopeAxis>(BuildCanMoveAxisRequest, axis);
        private IRestRequest BuildCanMoveAxisRequest(TelescopeAxis axis)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.Axis, ((int)axis).ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.CanMoveAxis, Method.GET, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public PierSide GetDestinationSideOfPier(double rightAscension, double declination) => 
            ExecuteRequest<PierSide, PierSideResponse, double, double>(BuildGetDestinationSideOfPierRequest, rightAscension, declination);
            
        /// <inheritdoc/>
        public async Task<PierSide> GetDestinationSideOfPierAsync(double rightAscension, double declination) =>
            await ExecuteRequestAsync<PierSide, PierSideResponse, double, double>(BuildGetDestinationSideOfPierRequest, rightAscension, declination);
        private IRestRequest BuildGetDestinationSideOfPierRequest(double rightAscension, double declination)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.RightAscension, rightAscension.ToString(CultureInfo.InvariantCulture)},
                {TelescopeCommandParameters.Declination, declination.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.DestinationSideOfPier, Method.GET, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public void FindHome() => ExecuteRequest(BuildFindHomeRequest, Configuration.LongTimeout);
        /// <inheritdoc/>
        public async Task FindHomeAsync() => await ExecuteRequestAsync(BuildFindHomeRequest, Configuration.LongTimeout);
        private IRestRequest BuildFindHomeRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.FindHome, Method.PUT, GetClientTransactionId());

        /// <inheritdoc/>
        public void MoveAxis(TelescopeAxis axis, double rate) => ExecuteRequest(BuildMoveAxisRequest, axis, rate);
        /// <inheritdoc/>
        public async Task MoveAxisAsync(TelescopeAxis axis, double rate) => await ExecuteRequestAsync(BuildMoveAxisRequest, axis, rate);
        private IRestRequest BuildMoveAxisRequest(TelescopeAxis axis, double rate)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.Axis, ((int) axis).ToString()},
                {TelescopeCommandParameters.Rate, rate.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.MoveAxis, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public void Park() => ExecuteRequest(BuildParkRequest, Configuration.LongTimeout);
        /// <inheritdoc/>
        public async Task ParkAsync() => await ExecuteRequestAsync(BuildParkRequest, Configuration.LongTimeout);
        private IRestRequest BuildParkRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.Park, Method.PUT, GetClientTransactionId());

        /// <inheritdoc/>
        public void PulseGuide(GuideDirection direction, int duration) => ExecuteRequest(BuildPulseGuideRequest, direction, duration);
        /// <inheritdoc/>
        public async Task PulseGuideAsync(GuideDirection direction, int duration) => await ExecuteRequestAsync(BuildPulseGuideRequest, direction, duration);
        private IRestRequest BuildPulseGuideRequest(GuideDirection direction, int duration)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.Direction, ((int)direction).ToString()},
                {TelescopeCommandParameters.Duration, duration.ToString()}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.PulseGuide, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public void SetPark() => ExecuteRequest(BuildSetParkRequest);
        /// <inheritdoc/>
        public async Task SetParkAsync() => await ExecuteRequestAsync(BuildSetParkRequest);
        private IRestRequest BuildSetParkRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.SetPark, Method.PUT, GetClientTransactionId());

        /// <inheritdoc/>
        public void SlewToAltAz(double altitude, double azimuth)
        {
            try
            {
                ExecuteRequest(BuildSlewAsyncToAltAzRequest, altitude, azimuth);
            }
            catch (AlpacaNotImplementedException)
            {
                ExecuteRequest(BuildSlewToAltAzRequest, altitude, azimuth, Configuration.LongTimeout);             
            }
        }

        /// <inheritdoc/>
        public async Task SlewToAltAzAsync(double altitude, double azimuth)
        {
            try
            {
                await ExecuteRequestAsync(BuildSlewAsyncToAltAzRequest, altitude, azimuth);
            }
            catch (AlpacaNotImplementedException)
            {
                await ExecuteRequestAsync(BuildSlewToAltAzRequest, altitude, azimuth, Configuration.LongTimeout);             
            }
        }

        private IRestRequest BuildSlewToAltAzRequest(double altitude, double azimuth)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.Altitude, altitude.ToString(CultureInfo.InvariantCulture)},
                {TelescopeCommandParameters.Azimuth, azimuth.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.SlewToAltAz, Method.PUT, parameters, GetClientTransactionId());
        }
        private IRestRequest BuildSlewAsyncToAltAzRequest(double altitude, double azimuth)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.Altitude, altitude.ToString(CultureInfo.InvariantCulture)},
                {TelescopeCommandParameters.Azimuth, azimuth.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.SlewToAltAzAsync, Method.PUT, parameters, GetClientTransactionId());
        }
        
        /// <inheritdoc/>
        public void SlewToCoordinates(double rightAscension, double declination)
        {
            try
            {
                ExecuteRequest(BuildSlewAsyncToCoordinatesRequest, rightAscension, declination);
            }
            catch (AlpacaNotImplementedException)
            {
                ExecuteRequest(BuildSlewToCoordinatesRequest, rightAscension, declination, Configuration.LongTimeout);             
            }
        }
        /// <inheritdoc/>
        public async Task SlewToCoordinatesAsync(double rightAscension, double declination)
        {
            try
            {
                await ExecuteRequestAsync(BuildSlewAsyncToCoordinatesRequest, rightAscension, declination);
            }
            catch (AlpacaNotImplementedException)
            {
                await ExecuteRequestAsync(BuildSlewToCoordinatesRequest, rightAscension, declination, Configuration.LongTimeout);
            }
        }
        private IRestRequest BuildSlewToCoordinatesRequest(double rightAscension, double declination)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.RightAscension, rightAscension.ToString(CultureInfo.InvariantCulture)},
                {TelescopeCommandParameters.Declination, declination.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.SlewToCoordinates, Method.PUT, parameters, GetClientTransactionId());
        }
        private IRestRequest BuildSlewAsyncToCoordinatesRequest(double rightAscension, double declination)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.RightAscension, rightAscension.ToString(CultureInfo.InvariantCulture)},
                {TelescopeCommandParameters.Declination, declination.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.SlewToCoordinatesAsync, Method.PUT, parameters, GetClientTransactionId());
        }
        
        /// <inheritdoc/>
        public void SlewToTarget()
        {
            try
            {
                ExecuteRequest(BuildSlewAsyncToTargetRequest);
            }
            catch (AlpacaNotImplementedException)
            {
                ExecuteRequest(BuildSlewToTargetRequest, Configuration.LongTimeout);
            }
        }
        /// <inheritdoc/>
        public async Task SlewToTargetAsync()
        {
            try
            {
                await ExecuteRequestAsync(BuildSlewAsyncToTargetRequest);
            }
            catch (AlpacaNotImplementedException)
            {
                await ExecuteRequestAsync(BuildSlewToTargetRequest, Configuration.LongTimeout);
            }
        }
        private IRestRequest BuildSlewToTargetRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.SlewToTarget, Method.PUT, GetClientTransactionId());
        private IRestRequest BuildSlewAsyncToTargetRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.SlewToTargetAsync, Method.PUT, GetClientTransactionId());

        /// <inheritdoc/>
        public void SyncToAltAz(double altitude, double azimuth) => ExecuteRequest(BuildSyncToAltAzRequest, altitude, azimuth);
        /// <inheritdoc/>
        public async Task SyncToAltAzAsync(double altitude, double azimuth) => await ExecuteRequestAsync(BuildSyncToAltAzRequest, altitude, azimuth);
        private IRestRequest BuildSyncToAltAzRequest(double altitude, double azimuth)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.Altitude, altitude.ToString(CultureInfo.InvariantCulture)},
                {TelescopeCommandParameters.Azimuth, azimuth.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.SyncToAltAz, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public void SyncToCoordinates(double rightAscension, double declination) => ExecuteRequest(BuildSyncToCoordinatesRequest, rightAscension, declination);
        /// <inheritdoc/>
        public async Task SyncToCoordinatesAsync(double rightAscension, double declination) => await ExecuteRequestAsync(BuildSyncToCoordinatesRequest, rightAscension, declination);
        private IRestRequest BuildSyncToCoordinatesRequest(double rightAscension, double declination)
        {
            var parameters = new Dictionary<string, object>
            {
                {TelescopeCommandParameters.RightAscension, rightAscension.ToString(CultureInfo.InvariantCulture)},
                {TelescopeCommandParameters.Declination, declination.ToString(CultureInfo.InvariantCulture)}
            };
            return RequestBuilder.BuildRestRequest(TelescopeCommand.SyncToCoordinates, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public void SyncToTarget() => ExecuteRequest(BuildSyncToTargetRequest);
        /// <inheritdoc/>
        public async Task SyncToTargetAsync() => await ExecuteRequestAsync(BuildSyncToTargetRequest);
        private IRestRequest BuildSyncToTargetRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.SyncToTarget, Method.PUT, GetClientTransactionId());

        /// <inheritdoc/>
        public void Unpark() => ExecuteRequest(BuildUnparkRequest);
        /// <inheritdoc/>
        public async Task UnparkAsync() => await ExecuteRequestAsync(BuildUnparkRequest);
        private IRestRequest BuildUnparkRequest() => RequestBuilder.BuildRestRequest(TelescopeCommand.UnPark, Method.PUT, GetClientTransactionId());
    }
}