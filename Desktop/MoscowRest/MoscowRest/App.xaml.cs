using System;
using MoscowRest.Managers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoscowRest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            dataManager = new SQLManager(dataPath);
            MainPage = new MainPage();
        }
        string dataPath= FileAccessManager.GetLocalFilePath("places.db3");
        public static SQLManager dataManager;
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
