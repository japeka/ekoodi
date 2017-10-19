using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace weather_app.model
{
    class WindData
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Degree { get; set; }

    }
}
