using System;
using System.Collections;
using System.Collections.Generic;
using MoscowRest.Models;
using Newtonsoft.Json;
using System.Linq;
namespace MoscowRest.Managers
{
    public class RecomendedPlacesManager : PlacesManager
    {
        public RecomendedPlacesManager()
        {
            places = new Dictionary<Category, Place[]>();

        }
        public EventHandler<RecomendedEventArgs> PlacesGot;
        public Dictionary<Category, Place[]> places;
        public void AddOrUpdate(Category category)
        {
            if (places.ContainsKey(category))

                places[category] = Place.GetPlaces(GetRecomendedPlaces(category)
                    .response.groups[0].items);
            else
                places.Add(category, Place.GetPlaces(GetRecomendedPlaces(category)
                    .response.groups[0].items));


        }
        public void AddOrUpdateAll()
        {
            AddOrUpdate(Category.ArtsAndOther);
            AddOrUpdate(Category.Food);
            AddOrUpdate(Category.NightlifeSpot);
            AddOrUpdate(Category.OutdoorsAndRecreation);
            PlacesGot?.Invoke(this, new RecomendedEventArgs(places));
        }
        public Place[] this[Category key]
        {
            get
            {
                return places[key];
            }
        }
        /// <summary>
        /// Получение рекомендованных мест.
        /// </summary>
        private RecomendedPlaces GetRecomendedPlaces(Category category)
        {
            string sCategory = GetStringCategory(category);
            return JsonConvert.DeserializeObject<RecomendedPlaces>(GetInfo(
                _recomendedPlacesRequest + _key + _version + _near + _locale + _limit + "&categoryId=" + sCategory
                ));
        }
    }
}
