using System.Collections.Generic;
using Newtonsoft.Json;

namespace HyruleCompendiumProject.Model
{
    public sealed class TreasureEntry : DataEntry, IHasDrops
    {
        [JsonProperty(PropertyName = "drops")]
        public List<string> Drops { get; set; }
    }
}
