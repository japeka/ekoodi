using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace weather_app.model
{
    class Weather
    {
        [JsonProperty("name")]
        public string LocationName { get; set; }

        [JsonProperty("coord")]
        public Geolocation Geolocation { get; set; }

        [JsonProperty("main")]
        public MeasurementData Measurement { get; set; }

        [JsonProperty("wind")]
        public WindData Wind { get; set; }

        [JsonProperty("weather")]
        public List<WeatherDescription> Descriptions { get; set; }
    }
}
