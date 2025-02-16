using DentalShop.Droid;
using Android.Content;
using Xamarin.Forms;
using DentalShop;
[assembly: Xamarin.Forms.Dependency(typeof(AppHider))]
namespace DentalShop.Droid
{
    public class AppHider : IAppHider
    {
        public void HideApp()
        {
            Intent main = new Intent(Intent.ActionMain);
            main.AddCategory(Intent.CategoryHome);
            Forms.Context.StartActivity(main);
        }
    }
}


