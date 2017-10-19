using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace weather_app.model
{
    class ForecastDescription
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("main")]
        public MeasurementData Measurement { get; set; }

        [JsonProperty("weather")]
        public List<WeatherDescription> Descriptions { get; set; }

        [JsonProperty("wind")]
        public WindData Wind { get; set; }
        
        [JsonProperty("dt_txt")]
        public string DateTxt { get; set; }

    }
}
