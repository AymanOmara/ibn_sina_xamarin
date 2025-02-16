using DentalShop.Screens;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Platform.Services;
namespace DentalShop
{
    public class SplashScreen
    {
        int counter = 1;
        System.Threading.Timer t;
        Image img;
        int w;
        int h;
        public AbsoluteLayout MainLayout;
        HomePage home;
        private bool loadScreensCompleted=false;
        public SplashScreen(int w, int h, HomePage home)
        {
            this.home = home;
            home.BackgroundColor = Color.White; ;
            this.w = w;
            this.h = h;
            MainLayout = new AbsoluteLayout();
            MainLayout.WidthRequest = w;
            MainLayout.HeightRequest = h;
            img = new Image();
            img.Aspect = Aspect.Fill;
            img.WidthRequest = w;
            img.HeightRequest = h;
            img.Source = ImageSource.FromResource("DentalShop.Images.Splash.png");
            Point imgLocation = new Point(0,0);
            MainLayout.Children.Add(img, imgLocation);
          
            LoadCash();
            Device.BeginInvokeOnMainThread(() => { LoadScreensAsync(); });
          
            t = new Timer(TimerTick, new object(), 2000, 500);
            home.Content = MainLayout;
           
        }
      
        public async void LoadScreensAsync()
        {
            try
            {

                await Settings.GetPannerAsync();
                loadScreensCompleted = false;
                Settings.width = w;
                Settings.height = h;
                Settings.mainPage = new MainPage(w, h, home);
                Settings.createAcount = new CreateAcount(w, h, home);
                Settings.imageCropper = new ImageCropper(w, h, home);
                Settings.forgotPassword = new ForgotPassword(w, h, home);
                Settings.login = new Login(w, h, home);
                Settings.updateUserInfo = new UpdateUserInfo(w, h, home);
                Settings.prouductPage = new ProuductPage(w, h, home);
                Settings.proudectStudentDetails = new ProudectStudentDetails(w, h, home);
                Settings.proudectDeivceDetails = new ProudectDeivceDetails(w, h, home);
                Settings.proudectsMachinesDetails = new ProudectsMachinesDetails(w, h, home);
                Settings.proudectEquipmentDetails = new ProudectEquipmentDetails(w, h, home);
                Settings.prouductCorrectionDetails = new ProuductCorrectionDetails(w, h, home);
                Settings.proudectMaterialsDetails = new ProudectMaterialsDetails(w, h, home);
                Settings.ClothesDetails = new ClothesDetails(w, h, home);
                Settings.FilesDetails = new Files(w, h, home);
                Settings.studentProuduct = new StudentProuduct(w, h, home);
                Settings.favorites = new Favorites(w, h, home);
                Settings.cart = new Cart(w, h, home);
                Settings.editOrder = new EditOrder(w, h, home);
                Settings.myOrders = new MyOrders(w, h, home);
                Settings.notification = new NotificationPage(w, h, home);
                Settings.aboutUs = new AboutUs (w, h, home);
                loadScreensCompleted = true;
                await Settings.GetDeliveryFees();
               
                try
                {
                    Settings.ICC = DependencyService.Get<IPhoneService>().MCC;

                }
                catch { }
                loadScreensCompleted = true;
            }
            catch (Exception ex)
            {

            }
        }
        private void LoadCash()
        {
            try
            {
                string Cash = "";
                Device.OnPlatform
                (
                    iOS: () => Cash = DependencyService.Get<ISaveAndLoad>().LoadText("Cash.txt"),
                    Android: () => Cash = DependencyService.Get<ISaveAndLoad>().LoadText("Cash.txt"),
                    WinPhone: async () => { Cash = await DependencyService.Get<ISaveAndLoad>().LoadTextAsync("Cash.txt"); }
                );
                Settings.cash = JsonConvert.DeserializeObject<Cash>(Cash);
            }
            catch
            {
                Settings.cash = new Cash();
                Settings.cash.LoggedIn = false;
            }
        }
        private void TimerTick(object state)
        {
            Device.BeginInvokeOnMainThread
            (
                () =>
                {
                    counter++;
                    if (counter > 2)
                    {
                        if (loadScreensCompleted)
                        {
                            t.Dispose();
                            home.Content = Settings.mainPage.MainLayout;
                            Settings.prouductPage.LBItemNumber.Text = Settings.cash.CartList.Count.ToString();
                            Settings.mainPage.LItemNumber.Text = Settings.cash.CartList.Count.ToString();
                            Settings.studentProuduct.LBItemNumber.Text = Settings.cash.CartList.Count.ToString();
                        }
                    }
                  
                }
            );
        }
    }
}
