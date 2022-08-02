using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyruleCompendiumProject.Model;
using HyruleCompendiumProject.Repository;
using GalaSoft.MvvmLight;

namespace HyruleCompendiumProject.ViewModel
{
    public class OverviewVM : ViewModelBase
    {
        //public static ICompendiumRepository CompendiumRepository{get; set; } = new CompendiumLocalRepository();
        public static ICompendiumRepository CompendiumRepository { get; set; } = new CompendiumApiRepository();

        private DataEntry entry;
        public List<DataEntry> DataEntries { get; set; }

        private string category;
        public List<string> DataCategories { get; set; }

        public DataEntry SelectedEntry
        {
            get { return entry; }
            set { entry = value; }
        }

        public string SelectedCategory
        {
            get { return category; }
            set { category = value; SetDataEntriesByCategory(); }
        }

        public OverviewVM()
        {
            GetDataEntries();
        }

        public async void GetDataEntries()
        {
            DataEntries = await CompendiumRepository.GetDataEntries();
            DataCategories = await CompendiumRepository.GetCategories();
            RaisePropertyChanged("DataCategories");
            RaisePropertyChanged("DataEntries");
        }

        public async void SetDataEntriesByCategory()
        {
            DataEntries = await CompendiumRepository.GetDataByCategory(category);
            RaisePropertyChanged("DataEntries");
        }
    }
}

