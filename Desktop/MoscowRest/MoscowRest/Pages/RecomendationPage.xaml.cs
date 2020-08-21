using System;
using System.Collections.Generic;
using MoscowRest.Models;
using Xamarin.Forms;
using System.Linq;
using MoscowRest.Managers;
using System.Collections.ObjectModel;

namespace MoscowRest.Pages
{
    public partial class RecomendationPage : ContentPage
    {
        Place[] places;
        ObservableCollection<Dictionary<string, Place[]>> oPlaces;
        public RecomendationPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            oPlaces = new ObservableCollection<Dictionary<string, Place[]>>();
            //places = Place.GetPlaces(MainPage.placesManager
            //    .RecomendedPlaces.response.groups[0].items);
            RecomendedPlacesCol.ItemsSource = oPlaces;//GetDictionary(MainPage.recomendedPlacesManager.places);
        }
        private Dictionary<string, Place[]> GetDictionary(Dictionary<PlacesManager.Category, Place[]> pairs)
        {
            Dictionary<string, Place[]> places = new Dictionary<string, Place[]>();
            foreach (var item in pairs)
            {
                places.Add(GetCategoryName(item.Key), item.Value);
            }
            return places;
        }
        public void SetCollection(object sender, RecomendedEventArgs args)
        {
            oPlaces.Clear();
            oPlaces.Add(GetDictionary(args.Places));
        }
        private string GetCategoryName(PlacesManager.Category category)
        {
            switch (category)
            {
                case PlacesManager.Category.Food:
                    return "Еда";
                case PlacesManager.Category.ArtsAndOther:
                    return "Искусство";
                case PlacesManager.Category.NightlifeSpot:
                    return "Ночная жизнь";
                case PlacesManager.Category.OutdoorsAndRecreation:
                    return "Отдых на природе";
                default:
                    return null;
            }
        }

        async void RecomendedPlacesCol_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var item = e.CurrentSelection.FirstOrDefault() as Place;
            if (item == null)
            {

                RecomendedPlacesCol.SelectedItem = null;
                return;
            }
            await Navigation.PushModalAsync(new NavigationPage(new PlaceInfoPage(item)));
            RecomendedPlacesCol.SelectedItem = null;
        }
    }
}
