using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HyruleCompendiumProject.Model;

namespace HyruleCompendiumProject.Repository
{
    public sealed class CompendiumApiRepository : ICompendiumRepository
    {
        public List<DataEntry> DataEntriesStored { get; set; }

        private static void HandleId(DataEntry entry)
        {
            int id = Convert.ToInt32(entry.Id);

            if (id < 10)
                entry.Id = $"00{entry.Id}";
            else if (id < 100)
                entry.Id = $"0{entry.Id}";
        }

        public async Task<List<DataEntry>> GetDataEntries()
        {
            if (DataEntriesStored != null)
                return DataEntriesStored;

            string endpoint = "https://botw-compendium.herokuapp.com/api/v2";
            
            List<DataEntry> dataEntries = new List<DataEntry>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(endpoint);

                    if (!response.IsSuccessStatusCode)
                        throw new HttpRequestException(response.ReasonPhrase);

                    string json = await response.Content.ReadAsStringAsync();

                    JObject parsedFile = JObject.Parse(json);
                    JToken DataEntrys = parsedFile.SelectToken("data");

                    JToken creatures = DataEntrys.SelectToken("creatures");
                    
                    JToken foodCreatures = creatures.SelectToken("food");
                    foreach (JToken foodCreature in foodCreatures)
                    {
                        CreatureFoodEntry entry = JsonConvert.DeserializeObject<CreatureFoodEntry>(foodCreature.ToString());
                        HandleId(entry);
                        dataEntries.Add(entry);
                    }

                    JToken nonFoodCreatures = creatures.SelectToken("non_food");
                    foreach (JToken nonFoodCreature in nonFoodCreatures)
                    {
                        CreatureNonFoodEntry entry = JsonConvert.DeserializeObject<CreatureNonFoodEntry>(nonFoodCreature.ToString());
                        HandleId(entry);
                        dataEntries.Add(entry);
                    }

                    JToken equipment = DataEntrys.SelectToken("equipment");
                    foreach (JToken equipmentItem in equipment)
                    {
                        EquipmentEntry entry = JsonConvert.DeserializeObject<EquipmentEntry>(equipmentItem.ToString());
                        HandleId(entry);
                        dataEntries.Add(entry);
                    }

                    JToken materials = DataEntrys.SelectToken("materials");
                    foreach (JToken material in materials)
                    {
                        MaterialEntry entry = JsonConvert.DeserializeObject<MaterialEntry>(material.ToString());
                        HandleId(entry);
                        dataEntries.Add(entry);
                    }

                    JToken monsters = DataEntrys.SelectToken("monsters");
                    foreach (JToken monster in monsters)
                    {
                        MonsterEntry entry = JsonConvert.DeserializeObject<MonsterEntry>(monster.ToString());
                        HandleId(entry);
                        dataEntries.Add(entry);
                    }

                    JToken treasure = DataEntrys.SelectToken("treasure");
                    foreach (JToken treasureItem in treasure)
                    {
                        TreasureEntry entry = JsonConvert.DeserializeObject<TreasureEntry>(treasureItem.ToString());
                        HandleId(entry);
                        dataEntries.Add(entry);
                    }
                }
                catch (HttpRequestException)
                {
                    Application.Exit();
                }
            }

            SortById sort = new SortById();
            dataEntries.Sort(sort);

            DataEntriesStored = dataEntries;

            return dataEntries;
        }

        public async Task<List<string>> GetCategories()
        {
            List<DataEntry> dataEntries = await GetDataEntries();
            List<string> categorys = new List<string>();

            foreach (DataEntry entry in dataEntries)
            {
                if (categorys.Contains(entry.Category) == false)
                    categorys.Add(entry.Category);
            }
            return categorys;
        }

        public async Task<List<DataEntry>> GetDataByCategory(string category)
        {
            List<DataEntry> dataEntries = await GetDataEntries();
            List<DataEntry> dataEntriesByType = new List<DataEntry>();

            foreach (DataEntry entry in dataEntries)
            {
                if (entry.Category == category)
                    dataEntriesByType.Add(entry);
            }

            return dataEntriesByType;
        }
    }
}
