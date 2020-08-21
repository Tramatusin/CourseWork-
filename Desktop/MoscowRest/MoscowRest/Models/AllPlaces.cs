using System;
namespace MoscowRest.Models
{
    /// <summary>
    /// Все места.
    /// </summary>
    public class AllPlaces
    {
        public Meta meta;
        public PlacesResponse response;
    }

    public class Meta
    {
        public int code;
    }
    public class PlacesResponse
    {
        public Venue[] venues;
       
    }
}
