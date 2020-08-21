using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoscowRest.Managers;
using MoscowRest.Models;
using Xamarin.Forms;

namespace MoscowRest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            allPlacesManager = new AllPlacesManager();


            recomendedPlacesManager = new RecomendedPlacesManager();
            //recomendedPlacesManager.AddOrUpdate(PlacesManager.Category.ArtsAndOther);
            //recomendedPlacesManager.AddOrUpdate(PlacesManager.Category.Food);
            //recomendedPlacesManager.AddOrUpdate(PlacesManager.Category.NightlifeSpot);
            //recomendedPlacesManager.AddOrUpdate(PlacesManager.Category.OutdoorsAndRecreation);


            InitializeComponent();
            allPlacesManager.PlacesGot += placesPage.SetCollection;
            allPlacesManager.Error += ShowError;
            //recomendedPlacesManager.Error+
            allPlacesManager.PlacesGot += mapPage.SetCollection;
            recomendedPlacesManager.PlacesGot += recomendationPage.SetCollection;
            Action action = allPlacesManager.Update;
            action.BeginInvoke(null, null);

            Action action1 = recomendedPlacesManager.AddOrUpdateAll;
            action1.BeginInvoke(null, null);

        }
        bool isFirstError = true;
        public void ShowError(object sender, PlacesErrorEventArgs args)
        {
            if (isFirstError)
            {
                DisplayAlert("Ошибка", args.ErrorMessage, "ОК");
                isFirstError = false;
            }
        }
        public static AllPlacesManager allPlacesManager;
        public static RecomendedPlacesManager recomendedPlacesManager;
    }
}
