using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace weather_app.model
{
    class WeatherDescription
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

    }
}
