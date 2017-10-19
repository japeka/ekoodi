using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace weather_app.model
{
    class MeasurementData
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_min")]
        public double TempereatureMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempereatureMax { get; set; }
    }
}
