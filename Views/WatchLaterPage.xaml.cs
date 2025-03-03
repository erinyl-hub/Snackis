using MovieVaultMaui.Models;
using System.Collections.ObjectModel;

namespace MovieVaultMaui;

public partial class WatchLaterPage : ContentPage
{

    public WatchLaterPage()
    {
        InitializeComponent();
        UpdateConnectionStatus();
        Connectivity.ConnectivityChanged += (s, e) => UpdateConnectionStatus();






        ObservableCollection<Movie> MoviesToSeeObservableList = new ObservableCollection<Movie>(aplicationData.MoviesToSee);

        MoviesToSeeCollectionView.ItemsSource = MoviesToSeeObservableList;

       




    }



    private void OnItemSelected(object sender, SelectionChangedEventArgs e)  // ta bort
    {
        if (e.CurrentSelection.FirstOrDefault() is Movie selectedItem)
        {
            DisplayAlert("Valt objekt", $"Du tryckte på: {selectedItem.Poster}", "OK");
        }
    }






















    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private void UpdateConnectionStatus()
    {
        bool isConnected = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;

        ConnectionImage.Source = isConnected ? "online.png" : "offline.png";
    }
}