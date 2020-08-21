using System;
namespace MoscowRest.Models
{
    /// <summary>
    /// Место.
    /// </summary>
    public class Venue
    {
        public string id;
        public string name;
        public PlaceLocation location;
        public Categories[] categories;
    }
    /// <summary>
    /// Местоположение места.
    /// </summary>
    public class PlaceLocation
    {
        public string address;
        public string crossStreet;
        public double lat;
        public double lng;
    }
    /// <summary>
    /// Категория места.
    /// </summary>
    public class Categories
    {
        public string id;
        public string name { get; set; }
    }
}
