using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace CollectionViewBugRepro
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand { get; set; }

        public ObservableCollection<ListItem> MyList { get; set; } = new ObservableCollection<ListItem>()
        {
            new First(),
            new TheRest(),
            new TheRest(),
            new TheRest(),
        };

        public MainPage()
        {
            RefreshCommand = new Command(async () => await RefreshItemsAsync());
            InitializeComponent();
            BindingContext = this;
        }

        private async Task RefreshItemsAsync()
        {
            try
            {
                IsRefreshing = true;

                await Task.Delay(2000);
                IsRefreshing = false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
