using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace weather_app.model
{
    class Geolocation
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
