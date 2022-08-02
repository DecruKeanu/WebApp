using Newtonsoft.Json;

namespace HyruleCompendiumProject.Model
{
    public sealed class EquipmentEntry : DataEntry, IHasAttack, IHasDefense
    {
        [JsonProperty(PropertyName = "attack")]
        public string Attack { get; set; }

        [JsonProperty(PropertyName = "defense")]
        public string Defense { get; set; }
    }
}
