using System;
using System.Threading.Tasks;

namespace AscomAlpacaClient.Devices
{
    public interface IObservingConditions : IDevice
    {
        /// <summary>
        /// Gets the time period over which observations will be averaged
        /// </summary>
        /// <returns></returns>
        double GetAveragePeriod();
        
        /// <summary>
        /// Gets the time period over which observations will be averaged
        /// </summary>
        /// <returns></returns>
        Task<double> GetAveragePeriodAsync();
        
        /// <summary>
        /// Sets the time period over which observations will be averaged
        /// </summary>
        /// <param name="period">Time period (hours) over which to average sensor readings</param>
        void SetAveragePeriod(double period);
        
        /// <summary>
        /// Sets the time period over which observations will be averaged
        /// </summary>
        /// <param name="period">Time period (hours) over which to average sensor readings</param>
        Task SetAveragePeriodAsync(double period);

        /// <summary>
        /// Gets the percentage of the sky obscured by cloud
        /// </summary>
        /// <returns></returns>
        double GetCloudCover();

        /// <summary>
        /// Gets the percentage of the sky obscured by cloud
        /// </summary>
        /// <returns></returns>
        Task<double> GetCloudCoverAsync();

        /// <summary>
        /// Gets the atmospheric dew point at the observatory reported in °C.
        /// </summary>
        /// <returns></returns>
        double GetDewPoint();

        /// <summary>
        /// Gets the atmospheric dew point at the observatory reported in °C.
        /// </summary>
        /// <returns></returns>
        Task<double> GetDewPointAsync();

        /// <summary>
        /// Gets the atmospheric  humidity (%) at the observatory
        /// </summary>
        /// <returns></returns>
        double GetHumidity();

        /// <summary>
        /// Gets the atmospheric  humidity (%) at the observatory
        /// </summary>
        /// <returns></returns>
        Task<double> GetHumidityAsync();

        /// <summary>
        /// Gets the atmospheric pressure in hectoPascals at the observatory's altitude - NOT reduced to sea level.
        /// </summary>
        /// <returns></returns>
        double GetPressure();

        /// <summary>
        /// Gets the atmospheric pressure in hectoPascals at the observatory's altitude - NOT reduced to sea level.
        /// </summary>
        /// <returns></returns>
        Task<double> GetPressureAsync();

        /// <summary>
        /// Gets the rain rate (mm/hour) at the observatory.
        /// </summary>
        /// <returns></returns>
        double GetRainRate();

        /// <summary>
        /// Gets the rain rate (mm/hour) at the observatory.
        /// </summary>
        /// <returns></returns>
        Task<double> GetRainRateAsync();

        /// <summary>
        /// Gets the sky brightness at the observatory (Lux)
        /// </summary>
        /// <returns></returns>
        double GetSkyBrightness();

        /// <summary>
        /// Gets the sky brightness at the observatory (Lux)
        /// </summary>
        /// <returns></returns>
        Task<double> GetSkyBrightnessAsync();

        /// <summary>
        /// Gets the sky quality at the observatory (magnitudes per square arc second)
        /// </summary>
        /// <returns></returns>
        double GetSkyQuality();

        /// <summary>
        /// Gets the sky quality at the observatory (magnitudes per square arc second)
        /// </summary>
        /// <returns></returns>
        Task<double> GetSkyQualityAsync();

        /// <summary>
        /// Gets the sky temperature(°C) at the observatory.
        /// </summary>
        /// <returns></returns>
        double GetSkyTemperature();

        /// <summary>
        /// Gets the sky temperature(°C) at the observatory.
        /// </summary>
        /// <returns></returns>
        Task<double> GetSkyTemperatureAsync();

        /// <summary>
        /// Gets the seeing at the observatory measured as star full width half maximum (FWHM) in arc secs.
        /// </summary>
        /// <returns></returns>
        double GetStarFwhm();
        
        /// <summary>
        /// Gets the seeing at the observatory measured as star full width half maximum (FWHM) in arc secs.
        /// </summary>
        /// <returns></returns>
        Task<double> GetStarFwhmAsync();

        /// <summary>
        /// Gets the temperature(°C) at the observatory.
        /// </summary>
        /// <returns></returns>
        double GetTemperature();

        /// <summary>
        /// Gets the temperature(°C) at the observatory.
        /// </summary>
        /// <returns></returns>
        Task<double> GetTemperatureAsync();

        /// <summary>
        /// Gets the wind direction. The returned value must be between 0.0 and 360.0,
        /// interpreted according to the metereological standard, where a special value
        /// of 0.0 is returned when the wind speed is 0.0. Wind direction is measured
        /// clockwise from north, through east, where East=90.0, South=180.0,
        /// West=270.0 and North=360.0.
        /// </summary>
        /// <returns></returns>
        double GetWindDirection();

        /// <summary>
        /// Gets the wind direction. The returned value must be between 0.0 and 360.0,
        /// interpreted according to the metereological standard, where a special value
        /// of 0.0 is returned when the wind speed is 0.0. Wind direction is measured
        /// clockwise from north, through east, where East=90.0, South=180.0,
        /// West=270.0 and North=360.0.
        /// </summary>
        /// <returns></returns>
        Task<double> GetWindDirectionAsync();

        /// <summary>
        /// Gets the peak 3 second wind gust(m/s) at the observatory over the last 2 minutes.
        /// </summary>
        /// <returns></returns>
        double GetWindGust();

        /// <summary>
        /// Gets the peak 3 second wind gust(m/s) at the observatory over the last 2 minutes.
        /// </summary>
        /// <returns></returns>
        Task<double> GetWindGustAsync();

        /// <summary>
        /// Gets the wind speed(m/s) at the observatory.
        /// </summary>
        /// <returns></returns>
        double GetWindSpeed();

        /// <summary>
        /// Gets the wind speed(m/s) at the observatory.
        /// </summary>
        /// <returns></returns>
        Task<double> GetWindSpeedAsync();

        /// <summary>
        /// Forces the driver to immediately query its attached hardware to refresh sensor values.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Forces the driver to immediately query its attached hardware to refresh sensor values.
        /// </summary>
        Task RefreshAsync();

        /// <summary>
        /// Gets a description of the sensor with the name specified in the PropertyName parameter
        /// </summary>
        /// <returns></returns>
        string GetSensorDescription(ObservingConditionSensorName sensorName);
        
        /// <summary>
        /// Gets a description of the sensor with the name specified in the PropertyName parameter
        /// </summary>
        /// <returns></returns>
        Task<string> GetSensorDescriptionAsync(ObservingConditionSensorName sensorName);

        /// <summary>
        /// Gets the time since the sensor was last updated
        /// </summary>
        /// <returns></returns>
        TimeSpan GetTimeSinceLastUpdate(ObservingConditionSensorName sensorName);

        /// <summary>
        /// Gets the time since the sensor was last updated
        /// </summary>
        /// <returns></returns>
        Task<TimeSpan> GetTimeSinceLastUpdateAsync(ObservingConditionSensorName sensorName);
    }
}