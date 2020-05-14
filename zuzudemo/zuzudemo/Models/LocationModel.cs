using System;
using System.Collections.Generic;

namespace zuzudemo.Models
{
    public partial class LocationModel
    {
        public Request Request { get; set; }
        public Location Location { get; set; }
        public Current Current { get; set; }
    }

    public partial class Current
    {
        public string ObservationTime { get; set; }
        public long Temperature { get; set; }
        public long WeatherCode { get; set; }
        public List<Uri> WeatherIcons { get; set; }
        public List<string> WeatherDescriptions { get; set; }
        public long WindSpeed { get; set; }
        public long WindDegree { get; set; }
        public string WindDir { get; set; }
        public long Pressure { get; set; }
        public double Precip { get; set; }
        public long Humidity { get; set; }
        public long Cloudcover { get; set; }
        public long Feelslike { get; set; }
        public long UvIndex { get; set; }
        public long Visibility { get; set; }
        public string IsDay { get; set; }
    }

    public partial class Location
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

    public partial class Request
    {
        public string Type { get; set; }
        public string Query { get; set; }
        public string Language { get; set; }
        public string Unit { get; set; }
    }
}