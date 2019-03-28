using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apixu.Models
{
    public class ApiResponse
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current")]
        public Current Current { get; set; }
    }

    public class Location {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

    }

    public class Current {

        [JsonProperty("temp_f")]
        public string Celcius { get; set; }

        [JsonProperty("temp_c")]
        public string Farenheit { get; set; }

        [JsonProperty("condition")]
        public Condition Condition { get; set; }

    }

    public class Condition {

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
