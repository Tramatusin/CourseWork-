using System;
using SQLite;

namespace MoscowRest.Models
{
    public class Place
    {
        public Place()
        {
        }
        public Place(Venue venue)
        {
            Id = venue.id;
            Name = venue.name;
            Address = venue.location.address;
            CrossStreet = venue.location.crossStreet;
            Lat = venue.location.lat;
            Lng = venue.location.lng;
            Categories = venue.categories;

        }
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CrossStreet { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        [Ignore]
        public Categories[] Categories { get; set; }
        public static Place[] GetPlaces(Venue[] venues)
        {
            Place[] places = new Place[venues.Length];
            int i = 0;
            foreach (var item in venues)
            {
                places[i] = new Place(item);
                i++;
            }

            return places;
        }
        public static Place[] GetPlaces(Item[] venues)
        {
            Place[] places = new Place[venues.Length];
            int i = 0;
            foreach (var item in venues)
            {
                places[i] = new Place(item.venue);
                i++;
            }

            return places;
        }
    }
}
