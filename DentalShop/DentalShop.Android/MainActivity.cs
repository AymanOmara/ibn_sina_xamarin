using System;
using DentalShop;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Geolocation;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Media;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Android.Content;
using Plugin.LocalNotification;

namespace DentalShop.Droid
{
    [Activity(Label = "Ibn Sina Dent", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Activity Main = null;
        private bool firstRun = true;
        private MyReciever Receiver;
        protected override void OnCreate(Bundle bundle)
        {
            System.Net.ServicePointManager.DnsRefreshTimeout = 2; //for solve no internet bug as defualt is 120 sec
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            MyReciever.Main = this;
            MainActivity.Main = this;
            Register();
            // New Xlabs
            try
            {
                // register user interface class
                var container = new SimpleContainer();
                container.Register<IDevice>(t => AndroidDevice.CurrentDevice);
                container.Register<IGeolocator, Geolocator>();
                container.Register<IPhoneService, PhoneService>();
                container.Register<IMediaPicker, MediaPicker>();
                Resolver.SetResolver(container.GetResolver()); // Resolving the services
                // End new Xlabs
            }
            catch
            {

            }

           

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Rg.Plugins.Popup.Popup.Init(this, bundle);

            SetStatusBarColor(new Android.Graphics.Color(243, 119, 5)); //color of status bar  
            var metrics = Resources.DisplayMetrics;
            var w = metrics.WidthPixels;
            var h = metrics.HeightPixels;
            int statusBarHeight = 0;
            int resourceId = Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                statusBarHeight = Resources.GetDimensionPixelSize(resourceId);
                h = h - statusBarHeight;
            }
            App.setScreenSize(w, h);
            LoadApplication(new App());
        }

        protected override async void OnResume()
        {
            base.OnResume();
            try
            {
            //    //DentalServices.NotificationRecieved = false;
            //    if (DentalServices.NotificationRecieved)
            //    {
            //        DentalServices.NotificationRecieved = false;
            //        if (Settings.cash.LoggedIn)
            //        {
                       
            //            Settings.homePage.Content = Settings.notification.MainLayout;
            //            await Settings.notification.GetData();

            //        }
            //    }
            //    else
            //    {
            //        //Settings.homePage.Content = Settings.mainPage.MainLayout;
            //    }
            //    //Settings.homePage.RefreshContent();
            }
            catch
            {
                DentalServices.NotificationRecieved = false;
            }
         

        }
        private async void ReloadData()
        {
            try
            {
                
               
                if (Settings.cash.LoggedIn && !Settings.cash.DeviceInfoSaved)
                {
                    

                }
            }
            catch
            {

            }
        }
        private void Register()
        {
            if (Receiver == null)
            {
                Receiver = new MyReciever();
                RegisterReceiver(Receiver, new IntentFilter("com.alr.text"));
                if (!DentalServices.IsRunning)
                    StartService(new Intent(this, typeof(DentalServices)));
            }
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
       
    }
}

