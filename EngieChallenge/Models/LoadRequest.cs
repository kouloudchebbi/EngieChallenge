using System.Collections.Generic;
using Newtonsoft.Json;

namespace EngieChallenge.Models
{
    public class LoadRequest
    {
        public decimal Load { get; set; }
        [JsonProperty("fuels")]
        public Fuel Fuels { get; set; }
        public IEnumerable<PowerPlant> PowerPlants { get; set; }
    }
}