using System;
using System.Collections.Generic;
using static MoscowRest.Managers.PlacesManager;

namespace MoscowRest.Models
{
    public class PlacesEventArgs : EventArgs
    {
        public PlacesEventArgs(Place[] places)
        {
            Places = places;
        }
        public Place[] Places { get; }
    }
    public class RecomendedEventArgs : EventArgs
    {
        public RecomendedEventArgs(Dictionary<Category, Place[]> places)
        {
            Places = places;
        }
        public Dictionary<Category, Place[]> Places { get; }
    }

    public class PlacesErrorEventArgs : EventArgs
    {
        public PlacesErrorEventArgs(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public string ErrorMessage { get; }
    }
}
