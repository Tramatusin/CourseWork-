using System;
using MoscowRest.Models;
using Newtonsoft.Json;

namespace MoscowRest.Managers
{
    public class AllPlacesManager : PlacesManager
    {
        public AllPlacesManager()
        {
            //SetAllPlaces();
        }
        public EventHandler<PlacesEventArgs> PlacesGot;
        private AllPlaces _allPlacesResponse;
        public AllPlaces AllPlacesResponse => _allPlacesResponse;
        private Place[] _allPlaces;
        public Place[] AllPlaces => _allPlaces;
        public void Update()
        {
            SetAllPlaces();
        }
        /// <summary>
        /// Получение всех мест.
        /// </summary>
        private void SetAllPlaces()
        {
            _allPlacesResponse = JsonConvert.DeserializeObject<AllPlaces>(GetInfo(
                _allPlacesRequest + _key + _version + _near + _limit2 + _locale + _categoryId
                ));
            _allPlaces = Place.GetPlaces(_allPlacesResponse.response.venues);
            PlacesGot?.Invoke(this, new PlacesEventArgs(_allPlaces));
        }
    }
}
