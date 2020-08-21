using System;
using System.Collections.Generic;
using MoscowRest.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MoscowRest.Pages
{
    public partial class PlaceInfoPage : ContentPage
    {
        Place place;
        public PlaceInfoPage(Place place)
        {
            this.place = place;
            InitializeComponent();
            SetButtonStyle();
            info.BindingContext = place;
            Position position = new Position(place.Lat, place.Lng);
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            placeMap.MoveToRegion(mapSpan);
            placePin.Label = place.Name;
            placePin.Position = position;
        }
        void SetButtonStyle()
        {
            if (App.dataManager.Contains(place))
            {
                SetButtonStyleOn();
            }
            else
            {
                SetButtonStyleOff();
            }
        }
        void SetButtonStyleOn()
        {
            saveButton.BackgroundColor = Color.WhiteSmoke;
            saveButton.TextColor = Color.Black;
            saveButton.Text = "В избранном";

        }
        void SetButtonStyleOff()
        {
            saveButton.BackgroundColor = Color.LightSkyBlue;
            saveButton.TextColor = Color.White;
            saveButton.Text = "Добавить в избранное";


        }
        async void Button_Clicked(object sender, EventArgs eventArgs)
        {
            if (App.dataManager.Contains(place))
            {
                if (await DisplayAlert("Удалить это место из избранного?", "Выбранное место будет удалено, данное действие необратимо.", "Удалить", "Отмена"))
                {
                    App.dataManager.DeleteItem(place);
                    SetButtonStyleOff();
                }
            }
            else
            {
                App.dataManager.Add(place);
                SetButtonStyleOn();
            }
        }
        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
