using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace zuzudemo.Models
{
    public class WeatherModel
    {
        public Request Request { get; set; }
        public Location Location { get; set; }
        public Current Current { get; set; }
        public Forecast Forecast { get; set; }
    }

    public class Current
    {
        [JsonProperty("observation_time")]
        public string ObservationTime { get; set; }
        [JsonProperty("temperature")]
        public long Temperature { get; set; }
        [JsonProperty("weather_code")]
        public long WeatherCode { get; set; }
        [JsonProperty("weather_icons")]
        public List<string> WeatherIcons { get; set; }
        [JsonProperty("weather_descriptions")]
        public List<string> WeatherDescriptions { get; set; }
        [JsonProperty("wind_speed")]
        public long WindSpeed { get; set; }
        [JsonProperty("wind_degree")]
        public long WindDegree { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDir { get; set; }
        [JsonProperty("pressure")]
        public long Pressure { get; set; }
        [JsonProperty("precip")]
        public double Precip { get; set; }
        [JsonProperty("humidity")]
        public long Humidity { get; set; }
        [JsonProperty("cloudcover")]
        public long Cloudcover { get; set; }
        [JsonProperty("feelslike")]
        public long Feelslike { get; set; }
        [JsonProperty("uv_index")]
        public long UvIndex { get; set; }
        [JsonProperty("visibility")]
        public long Visibility { get; set; }
        [JsonProperty("is_day")]
        public string IsDay { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string TimezoneId { get; set; }
        public string Localtime { get; set; }
        public long LocaltimeEpoch { get; set; }
        public string UtcOffset { get; set; }
    }

    public class Request
    {
        public string Type { get; set; }
        public string Query { get; set; }
        public string Language { get; set; }
        public string Unit { get; set; }
    }

    public class Forecast
    {
        public DateTimeOffset Date { get; set; }
        public long DateEpoch { get; set; }
        public Astro Astro { get; set; }
        public long Mintemp { get; set; }
        public long Maxtemp { get; set; }
        public long Avgtemp { get; set; }
        public long Totalsnow { get; set; }
        public double Sunhour { get; set; }
        public long UvIndex { get; set; }
        public List<Hourly> Hourly { get; set; }
    }

    public class Astro
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Moonrise { get; set; }
        public string Moonset { get; set; }
        public string MoonPhase { get; set; }
        public long MoonIllumination { get; set; }
    }

    public class Hourly
    {
        public long Time { get; set; }
        public long Temperature { get; set; }
        public long WindSpeed { get; set; }
        public long WindDegree { get; set; }
        public string WindDir { get; set; }
        public long WeatherCode { get; set; }
        public List<Uri> WeatherIcons { get; set; }
        public List<string> WeatherDescriptions { get; set; }
        public long Precip { get; set; }
        public long Humidity { get; set; }
        public long Visibility { get; set; }
        public long Pressure { get; set; }
        public long Cloudcover { get; set; }
        public long Heatindex { get; set; }
        public long Dewpoint { get; set; }
        public long Windchill { get; set; }
        public long Windgust { get; set; }
        public long Feelslike { get; set; }
        public long Chanceofrain { get; set; }
        public long Chanceofremdry { get; set; }
        public long Chanceofwindy { get; set; }
        public long Chanceofovercast { get; set; }
        public long Chanceofsunshine { get; set; }
        public long Chanceoffrost { get; set; }
        public long Chanceofhightemp { get; set; }
        public long Chanceoffog { get; set; }
        public long Chanceofsnow { get; set; }
        public long Chanceofthunder { get; set; }
        public long UvIndex { get; set; }
    }
}