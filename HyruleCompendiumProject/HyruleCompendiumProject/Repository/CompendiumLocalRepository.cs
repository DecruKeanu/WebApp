using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using HyruleCompendiumProject.Model;

namespace HyruleCompendiumProject.Repository
{
    public sealed class CompendiumLocalRepository : ICompendiumRepository
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

            //Executing assembly
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //generated embedded resourceName: namespace.subfolder.filename
            const string resourceName = "HyruleCompendiumProject.Resources.Data.LocalData.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = await reader.ReadToEndAsync();

                    JObject parsedFile = JObject.Parse(json);
                    JToken dataProperty = parsedFile.SelectToken("dataEntrys");

                    DataEntriesStored = new List<DataEntry>();

                    foreach (JToken entry in dataProperty)
                    {
                        string entryCategory = entry.SelectToken("category").ToString();

                        switch(entryCategory)
                        {
                            case "creatures":
                                CreatureNonFoodEntry creatureEntry = entry.ToObject<CreatureNonFoodEntry>();
                                HandleId(creatureEntry);
                                DataEntriesStored.Add(creatureEntry);
                                break;
                            case "monsters":
                                MonsterEntry monsterEntry = entry.ToObject<MonsterEntry>();
                                HandleId(monsterEntry);
                                DataEntriesStored.Add(monsterEntry);
                                break;
                            case "materials":
                                MaterialEntry materialEntry = entry.ToObject<MaterialEntry>();
                                HandleId(materialEntry);
                                DataEntriesStored.Add(materialEntry);
                                break;
                            case "equipment":
                                EquipmentEntry equipmentEntry = entry.ToObject<EquipmentEntry>();
                                HandleId(equipmentEntry);
                                DataEntriesStored.Add(equipmentEntry);
                                break;
                            case "treasure":
                                TreasureEntry treasureEntry = entry.ToObject<TreasureEntry>();
                                HandleId(treasureEntry);
                                DataEntriesStored.Add(treasureEntry);
                                break;
                        }
                    }
                    return DataEntriesStored;
                }
            }
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
