using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using MoscowRest.Models;
using Newtonsoft.Json;

namespace MoscowRest.Managers
{
    public abstract class PlacesManager
    {
        public PlacesManager()
        {
        }
        protected const string _key = "?client_id=YCNBJQGS5QRI3RTC4CLD2UPMTO0QP5GKREKYSWJGOL0KD11M&client_secret=RHOCZICF21D2NYFKW4ZTDFJQEZYFVBOE4RZIR5GSRRAG1FIW";
        protected const string _version = "&v=20190425";
        protected const string _near = "&near=Moscow, RU";
        protected const string _locale = "&locale=ru";
        protected const string _limit = "&limit=50";
        protected const string _limit2 = "&limit=5000";
        protected const string _categoryId = "&categoryId=4d4b7105d754a06374d81259,4d4b7104d754a06370d81259,4d4b7105d754a06376d81259,4d4b7105d754a06377d81259";
        protected const string _allPlacesRequest = "https://api.foursquare.com/v2/venues/search";
        protected const string _recomendedPlacesRequest = "https://api.foursquare.com/v2/venues/explore";
        protected const string _food = "4d4b7105d754a06374d81259";
        protected const string _artsAndOther = "4d4b7104d754a06370d81259";
        protected const string _nightlifeSpot = "4d4b7105d754a06376d81259";
        protected const string _outdoorsAndRecreation = "4d4b7105d754a06377d81259";


        public enum Category
        {
            Food,
            ArtsAndOther,
            NightlifeSpot,
            OutdoorsAndRecreation
        }
        public EventHandler<PlacesErrorEventArgs> Error;
        protected string GetStringCategory(Category category)
        {
            switch (category)
            {
                case Category.Food:
                    return _food;
                case Category.ArtsAndOther:
                    return _artsAndOther;
                case Category.NightlifeSpot:
                    return _nightlifeSpot;
                case Category.OutdoorsAndRecreation:
                    return _outdoorsAndRecreation;
                default:
                    return null;
            }
        }
        /// <summary>
        /// Получение ответа на запрос.
        /// </summary>
        /// <param name="url">Запрос.</param>
        /// <returns>Результат запроса.</returns>
        protected string GetInfo(string url)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string response;
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                return response;
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, new PlacesErrorEventArgs(ex.Message));
                throw ex;
            }
        }

    }
}
