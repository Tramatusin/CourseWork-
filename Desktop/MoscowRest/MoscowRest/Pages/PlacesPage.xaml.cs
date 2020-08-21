using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MoscowRest.Models;
using Xamarin.Forms;

namespace MoscowRest.Pages
{
    public partial class PlacesPage : ContentPage
    {
        //Place[] places;
        ObservableCollection<Place> oPlaces;
        public PlacesPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            Console.WriteLine("111");
            //places = MainPage.allPlacesManager.AllPlaces;
            oPlaces = new ObservableCollection<Place>();
            Place[] ass = { new Place() { Name = "djasdja", Address = "sdajdhjas" }, new Place() { Name = "djasdja", Address = "sdajdhjas" } };
            AllPlacesCol.ItemsSource = oPlaces;

        }
        Place[] test = {
            new Place(){ Name="djasdja", Address="sdajdhjas"},
            new Place(){ Name="djasdja", Address="sdajdhjas"},
            new Place(){ Name="djasdja", Address="sdajdhjas"},
            new Place(){ Name="djasdja", Address="sdajdhjas"}
        };
        public void SetCollection(object sender, PlacesEventArgs args)
        {
            Console.WriteLine(AllPlacesCol == null);
            //places = args.Places;

            oPlaces.Clear();
            foreach (var item in args.Places)
            {
                oPlaces.Add(item);
            }
            //test[]
            //AllPlacesCol.ItemsSource = places;
            Console.WriteLine((AllPlacesCol.ItemsSource == null) + "HCJDHAJd");
            Console.WriteLine("222");
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
