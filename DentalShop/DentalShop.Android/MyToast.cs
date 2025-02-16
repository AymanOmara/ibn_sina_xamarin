using System;
using Android.Widget;

using DentalShop.Droid;
[assembly: Xamarin.Forms.Dependency(typeof(MyToast))]
namespace DentalShop.Droid
{
    public class MyToast : IMyToast
    {
        public void MakeText(String Text, bool Short)
        {
            Toast.MakeText(MainActivity.Main, Text, (Short) ? ToastLength.Short : ToastLength.Long).Show();
        }
    }
}