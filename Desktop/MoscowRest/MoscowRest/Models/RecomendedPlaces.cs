using System;
namespace MoscowRest.Models
{
    /// <summary>
    /// Рекомендованные места.
    /// </summary>
    public class RecomendedPlaces
    {
        public Meta meta;
        public RecomendedPlacesResponse response;
    }
    public class RecomendedPlacesResponse
    {
        public Group[] groups;
    }
    public class Group
    {
        public Item[] items;
    }
    public class Item
    {
        public Venue venue;
    }
}
