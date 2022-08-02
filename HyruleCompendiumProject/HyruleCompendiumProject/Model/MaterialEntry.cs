using Newtonsoft.Json;

namespace HyruleCompendiumProject.Model
{
    public sealed class MaterialEntry : DataEntry, IHasHeartsRecovered, IHasCookingEffects
    {
        [JsonProperty(PropertyName = "hearts_recovered")]
        public string HeartsRecovered { get; set; }

        [JsonProperty(PropertyName = "cooking_effect")]
        public string CookingEffects { get; set; }
    }
}
