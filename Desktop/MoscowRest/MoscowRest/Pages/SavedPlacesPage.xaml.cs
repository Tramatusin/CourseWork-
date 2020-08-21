using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MoscowRest.Models;
using Xamarin.Forms;

namespace MoscowRest.Pages
{
    public partial class SavedPlacesPage : ContentPage
    {
        public ObservableCollection<Place> places;
        public SavedPlacesPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            places = new ObservableCollection<Place>(App.dataManager.GetPlaces());
            App.dataManager.Added += (sender,place) => places.Add(place);
            App.dataManager.Deleted += (sender, place) => places.Remove(place);
            InitializeComponent();
            AllPlacesCol.ItemsSource = places;
        }

        async void AllPlacesCol_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var item = e.CurrentSelection.FirstOrDefault() as Place;
            if (item == null)
            {

                AllPlacesCol.SelectedItem = null;
                return;
            }
            await Navigation.PushModalAsync(new NavigationPage(new PlaceInfoPage(item)));
            AllPlacesCol.SelectedItem = null;
        }
    }
}
