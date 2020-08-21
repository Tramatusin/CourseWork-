using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;
using System.Collections.ObjectModel;
using MoscowRest.Models;

namespace MoscowRest.Pages
{
    public partial class MapPage : ContentPage
    {
        ObservableCollection<PinLocation> pins;
        public MapPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            pins = new ObservableCollection<PinLocation>();
            //pins = MainPage.allPlacesManager.AllPlaces.Select(x => new PinLocation(x.Address, x.Name, new Position(x.Lat, x.Lng))).ToList();
            InitializeComponent();
            Position position = new Position(55.753960, 37.620393);
            MapSpan mapSpan = new MapSpan(position, 0.1, 0.1);
            map.MoveToRegion(mapSpan);
            map.ItemsSource = pins;
        }
        public void SetCollection(object sender, PlacesEventArgs args)
        {
            pins.Clear();
            foreach (var item in args.Places)
            {
                pins.Add(new PinLocation(item.Address, item.Name, new Position(item.Lat, item.Lng)));
            }
        }
        public class PinLocation
        {
            Position _position;

            public string Address { get; }
            public string Description { get; }

            public Position Position
            {
                get => _position;
                set
                {
                    if (!_position.Equals(value))
                    {
                        _position = value;
                    }
                }
            }

            public PinLocation(string address, string description, Position position)
            {
                Address = address;
                Description = description;
                Position = position;
            }
        }
    }
}
