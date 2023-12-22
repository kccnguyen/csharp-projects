using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;


namespace Calculator.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        public MainViewModel()
        {
            HistoryItems = new ObservableCollection<string>();
        }

        [ObservableProperty]
        ObservableCollection<string> historyItems;

        [ObservableProperty]
        string text;
        readonly string result;


        [RelayCommand]
        void Add()
        {
            HistoryItems.Add(Text);
            Text = string.Empty;
        }

        async Task Navigate() =>
               await AppShell.Current.GoToAsync(nameof(HistoryPage));
    }
}
