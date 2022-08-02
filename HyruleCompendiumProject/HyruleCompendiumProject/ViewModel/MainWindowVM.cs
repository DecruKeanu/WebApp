using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HyruleCompendiumProject.Model;
using HyruleCompendiumProject.View;
using System.Windows.Controls;

namespace HyruleCompendiumProject.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        public string CommandText
        {
            get
            {
                if (CurrentPage is OverviewPage)
                    return "SHOW ENTRY";
                else
                    return "BACK TO OVERVIEW";
            }
        }

        public static OverviewPage OverviewPage { get; set; } = new OverviewPage();
        public static DetailPage DataEntryPage { get; set; } = new DetailPage();
        public Page CurrentPage { get; set; } = OverviewPage;
        public RelayCommand SwitchPageCommand { get { return new RelayCommand(SwitchPage); } }

        void SwitchPage()
        {
            if (CurrentPage is OverviewPage)
            {
                OverviewVM overview = OverviewPage.DataContext as OverviewVM;
                DataEntry entry = overview.SelectedEntry;

                if (entry == null)
                    return;

                (DataEntryPage.DataContext as DetailPageVM).CurrentEntry = entry;
                CurrentPage = DataEntryPage;
            }
            else
                CurrentPage = OverviewPage;

            RaisePropertyChanged("CurrentPage");
            RaisePropertyChanged("CommandText");
        }
    }
}
