using System.Collections.Generic;
using HyruleCompendiumProject.Model;
using System.Threading.Tasks;

namespace HyruleCompendiumProject.Repository
{
    public interface ICompendiumRepository
    {
        List<DataEntry> DataEntriesStored { get; }

        Task<List<DataEntry>> GetDataEntries();
        Task<List<string>> GetCategories();
        Task<List<DataEntry>> GetDataByCategory(string type);
    }
}
