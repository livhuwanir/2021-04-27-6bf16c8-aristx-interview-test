using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aris.ServerTest.Models
{
    public class KoreAttribute
    {
        [JsonProperty("lines")]
        public string Lines { get; set; }

        [JsonProperty("progressive")]
        public bool Progressive { get; set; }

        [JsonProperty("feature_game")]
        public bool FeatureGame { get; set; }
    }
}
