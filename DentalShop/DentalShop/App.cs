using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DentalShop
{
    public partial class App : Application
    {
        public static int w = 0;
        public static int h = 0;
        public App()
        {
            Settings.homePage = new HomePage();
            MainPage = Settings.homePage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            Settings.homePage.RefreshContent();
        }
        public static void setScreenSize(int width, int height)
        {
            App.w = width;
            App.h = height;
        }
    }
}
