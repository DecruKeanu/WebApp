using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace HyruleCompendiumProject.Model
{
    public class DataEntry
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "common_locations")]
        public List<string> CommonLocations { get; set; }

        [JsonProperty(PropertyName = "image")]
        public ImageSource Image { get { return new BitmapImage(new Uri($"https://botw-compendium.herokuapp.com/api/v2/entry/{Id}/image", UriKind.Absolute)); } }

        [JsonProperty(PropertyName = "Category")]
        public string Category { get; set; }
    }
}
