using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentalShop
{
    public class UserSidePage : PopupPage
    {
        int w;
        int h;
        AbsoluteLayout Container;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.White;
        UserEntity UserInfo = new UserEntity();
        Image ImgBackground;
        Image ImgExit;
        Image ImgUserPhoto;
        Label LBUserName;
        Label DeleteAcount;
        Image ImgHome;
        Label LBHome;
        Image ImgOrders;
        Label LBOrders;
        Image ImgFavorits;
        Label LBFavorits;
        Image ImgNotification;
        Label LBNotification;
        Image ImgSettings;
        Label LBSettings;
        Image ImgLogout;
        Label LBLogout;
        private ActivityIndicator AILoading;

        public UserSidePage(int w, int h, HomePage home)
        {
            this.w = w;
            this.h = h;
            this.home = home;
            Container = new AbsoluteLayout();
            Container.WidthRequest = w;
            Container.HeightRequest = h;
            Container.BackgroundColor = Color.Transparent;
            InitializeComponents();
            this.Content = Container;

        }

        private void InitializeComponents()
        {
            double FontSize = Settings.FontSize + 4;
             
            int ButtonHeight = 55;
            int width = w;
            int Labelheight = 30;
            double ypoint = 10;

            ImgBackground = new Image();
            ImgBackground.WidthRequest = w * 0.6;
            ImgBackground.HeightRequest = h -20;
            ImgBackground.Aspect = Aspect.Fill;
            ImgBackground.Source = ImageSource.FromResource("DentalShop.Images.OrangeBackground.png");
            ImgBackground.HorizontalOptions = LayoutOptions.Center;
            Point ImgBackgroundLocation = new Point(w * 0.4 - 10,  10);
            Container.Children.Add(ImgBackground, ImgBackgroundLocation);


            ImgExit = new Image();
            ImgExit.WidthRequest = ImgBackground.WidthRequest/8;
            ImgExit.HeightRequest = ImgBackground.WidthRequest / 8;
            ImgExit.Aspect = Aspect.Fill;
            ImgExit.Source = ImageSource.FromResource("DentalShop.Images.ExitIcon.png");
            ImgExit.HorizontalOptions = LayoutOptions.Center;
            Point ImgExitLocation = new Point(w * 0.4 + 5, ypoint + 10);
            Container.Children.Add(ImgExit, ImgExitLocation);


            ypoint += ImgBackground.HeightRequest * .075;


            //user photo
            ImgUserPhoto = new Image();
            ImgUserPhoto.Aspect = Aspect.Fill;
            ImgUserPhoto.Source = ImageSource.FromResource("DentalShop.Images.user.png");
            ImgUserPhoto.WidthRequest = ImgBackground.HeightRequest/5;
            ImgUserPhoto.HeightRequest = ImgBackground.HeightRequest / 5;
            Container.Children.Add(ImgUserPhoto, new Point(w * .4 -10+ (ImgBackground.WidthRequest / 2 - (ImgUserPhoto.WidthRequest / 2)), ypoint));


            ypoint += 13 + ImgUserPhoto.HeightRequest;


            //Name
            LBUserName = new Label();
            LBUserName.WidthRequest = ImgBackground.WidthRequest;
            LBUserName.TextColor = Color.White;
            LBUserName.HeightRequest = Labelheight+10;
            LBUserName.FontSize = FontSize;
            LBUserName.Text = UserInfo.UserName;
            LBUserName.FontAttributes = FontAttributes.Bold;
            LBUserName.HorizontalTextAlignment = TextAlignment.Center;
            LBUserName.VerticalTextAlignment = TextAlignment.Center;
            LBUserName.FontFamily = Settings.CofiFontFamily;

            Container.Children.Add(LBUserName, new Point(w * 0.4-10, ypoint ));


            ypoint += LBUserName.HeightRequest + 30;



            //home icon
            ImgHome = new Image();
            ImgHome.WidthRequest = Labelheight + 5;
            ImgHome.HeightRequest = Labelheight + 5;
            ImgHome.Aspect = Aspect.Fill;
            ImgHome.Source = ImageSource.FromResource("DentalShop.Images.home-icon.png");
            ImgHome.HorizontalOptions = LayoutOptions.Center;
            Point ImgHomeLocation = new Point(w -20-ImgHome.WidthRequest, ypoint );
            Container.Children.Add(ImgHome, ImgHomeLocation);


            LBHome = new Label();
            LBHome.WidthRequest = ImgBackground.WidthRequest- ImgHome.WidthRequest;
            LBHome.TextColor = Color.White;
            LBHome.HeightRequest = Labelheight;
            LBHome.FontSize = FontSize;
            LBHome.Text = "الصفحة الرئيسية";
            LBHome.FontAttributes = FontAttributes.Bold;
            LBHome.HorizontalTextAlignment = TextAlignment.Center;
            LBHome.VerticalTextAlignment = TextAlignment.Center;
            LBHome.FontFamily = Settings.CofiFontFamily;

            Container.Children.Add(LBHome, new Point(w * 0.4 - 10, ypoint));

            ypoint += ImgHome.HeightRequest + 15;




            //orders icon
            ImgOrders = new Image();
            ImgOrders.WidthRequest = Labelheight + 5;
            ImgOrders.HeightRequest = Labelheight + 5;
            ImgOrders.Aspect = Aspect.Fill;
            ImgOrders.Source = ImageSource.FromResource("DentalShop.Images.orders.png");
            ImgOrders.HorizontalOptions = LayoutOptions.Center;
            Point ImgOrdersLocation = new Point(w - 20 - ImgHome.WidthRequest, ypoint);
            Container.Children.Add(ImgOrders, ImgOrdersLocation);


            LBOrders = new Label();
            LBOrders.WidthRequest = ImgBackground.WidthRequest - ImgHome.WidthRequest;
            LBOrders.TextColor = Color.White;
            LBOrders.HeightRequest = Labelheight;
            LBOrders.FontSize = FontSize;
            LBOrders.Text = "طلباتي             ";
            LBOrders.FontAttributes = FontAttributes.Bold;
            LBOrders.HorizontalTextAlignment = TextAlignment.Center;
            LBOrders.VerticalTextAlignment = TextAlignment.Center;
            LBOrders.FontFamily = Settings.CofiFontFamily;

            Container.Children.Add(LBOrders, new Point(w * 0.4 - 10, ypoint));

            ypoint += ImgHome.HeightRequest + 15;


            //Favorits icon
            ImgFavorits = new Image();
            ImgFavorits.WidthRequest = Labelheight + 5;
            ImgFavorits.HeightRequest = Labelheight + 5;
            ImgFavorits.Aspect = Aspect.Fill;
            ImgFavorits.Source = ImageSource.FromResource("DentalShop.Images.heart.png");
            ImgFavorits.HorizontalOptions = LayoutOptions.Center;
            Point ImgFavoritsLocation = new Point(w - 20 - ImgHome.WidthRequest, ypoint);
            Container.Children.Add(ImgFavorits, ImgFavoritsLocation);


            LBFavorits = new Label();
            LBFavorits.WidthRequest = ImgBackground.WidthRequest - ImgHome.WidthRequest;
            LBFavorits.TextColor = Color.White;
            LBFavorits.HeightRequest = Labelheight;
            LBFavorits.FontSize = FontSize;
            LBFavorits.Text = "المفضلة            ";
            LBFavorits.FontAttributes = FontAttributes.Bold;
            LBFavorits.HorizontalTextAlignment = TextAlignment.Center;
            LBFavorits.VerticalTextAlignment = TextAlignment.Center;
            LBFavorits.FontFamily = Settings.CofiFontFamily;

            Container.Children.Add(LBFavorits, new Point(w * 0.4 - 10, ypoint));

            ypoint += ImgHome.HeightRequest + 15;




            //notification icon
            ImgNotification = new Image();
            ImgNotification.WidthRequest = Labelheight + 5;
            ImgNotification.HeightRequest = Labelheight + 5;
            ImgNotification.Aspect = Aspect.Fill;
            ImgNotification.Source = ImageSource.FromResource("DentalShop.Images.message.png");
            ImgNotification.HorizontalOptions = LayoutOptions.Center;
            Point ImgNotificationLocation = new Point(w - 20 - ImgHome.WidthRequest, ypoint-5);
            Container.Children.Add(ImgNotification, ImgNotificationLocation);


            LBNotification = new Label();
            LBNotification.WidthRequest = ImgBackground.WidthRequest - ImgHome.WidthRequest;
            LBNotification.TextColor = Color.White;
            LBNotification.HeightRequest = Labelheight;
            LBNotification.FontSize = FontSize;
            LBNotification.Text = " اشعارات             ";
            LBNotification.FontAttributes = FontAttributes.Bold;
            LBNotification.HorizontalTextAlignment = TextAlignment.Center;
            LBNotification.VerticalTextAlignment = TextAlignment.Center;
            LBNotification.FontFamily = Settings.CofiFontFamily;

            Container.Children.Add(LBNotification, new Point(w * 0.4 - 10, ypoint));

            ypoint += ImgHome.HeightRequest + 15;



            //Settings icon
            ImgSettings = new Image();
            ImgSettings.WidthRequest = Labelheight + 5;
            ImgSettings.HeightRequest = Labelheight + 5;
            ImgSettings.Aspect = Aspect.Fill;
            ImgSettings.Source = ImageSource.FromResource("DentalShop.Images.setting.png");
            ImgSettings.HorizontalOptions = LayoutOptions.Center;
            Point ImgSettingsLocation = new Point(w - 20 - ImgHome.WidthRequest, ypoint);
            Container.Children.Add(ImgSettings, ImgSettingsLocation);


            LBSettings = new Label();
            LBSettings.WidthRequest = ImgBackground.WidthRequest - ImgHome.WidthRequest;
            LBSettings.TextColor = Color.White;
            LBSettings.HeightRequest = Labelheight;
            LBSettings.FontSize = FontSize;
            LBSettings.Text = "اعدادات الحساب";
            LBSettings.FontAttributes = FontAttributes.Bold;
            LBSettings.HorizontalTextAlignment = TextAlignment.Center;
            LBSettings.VerticalTextAlignment = TextAlignment.Center;
            LBSettings.FontFamily = Settings.CofiFontFamily;

            Container.Children.Add(LBSettings, new Point(w * 0.4 - 10, ypoint));

            ypoint += ImgHome.HeightRequest + 15;



            //logout icon
            ImgLogout = new Image();
            ImgLogout.WidthRequest = Labelheight + 5;
            ImgLogout.HeightRequest = Labelheight + 5;
            ImgLogout.Aspect = Aspect.Fill;
            ImgLogout.Source = ImageSource.FromResource("DentalShop.Images.logout-icon.png");
            ImgLogout.HorizontalOptions = LayoutOptions.Center;
            Point ImgLogoutLocation = new Point(w - 20 - ImgHome.WidthRequest, ypoint);
            Container.Children.Add(ImgLogout, ImgLogoutLocation);


            LBLogout = new Label();
            LBLogout.WidthRequest = ImgBackground.WidthRequest - ImgHome.WidthRequest;
            LBLogout.TextColor = Color.White;
            LBLogout.HeightRequest = Labelheight;
            LBLogout.FontSize = FontSize;
            LBLogout.Text = "تسجيل الخروج  ";
            LBLogout.FontAttributes = FontAttributes.Bold;
            LBLogout.HorizontalTextAlignment = TextAlignment.Center;
            LBLogout.VerticalTextAlignment = TextAlignment.Center;
            LBLogout.FontFamily = Settings.CofiFontFamily;

            Container.Children.Add(LBLogout, new Point(w * 0.4 - 10, ypoint));
            ypoint += ImgHome.HeightRequest + 15;
            ////////////////////////////////delete acount////////////////////////////////////////////////
            DeleteAcount = new Label();
            DeleteAcount.WidthRequest = ImgBackground.WidthRequest - ImgHome.WidthRequest;
            DeleteAcount.TextColor = Color.White;
            DeleteAcount.HeightRequest = Labelheight;
            DeleteAcount.FontSize = FontSize;
            DeleteAcount.Text = "حذف الحساب ";
            DeleteAcount.FontAttributes = FontAttributes.Bold;
            DeleteAcount.HorizontalTextAlignment = TextAlignment.Center;
            DeleteAcount.VerticalTextAlignment = TextAlignment.Center;
            DeleteAcount.FontFamily = Settings.CofiFontFamily;

            Container.Children.Add(DeleteAcount, new Point(w * 0.4 - 10, ypoint));
            /////////////////////////////////////////////////////////////////////////
            AILoading = new ActivityIndicator();
            AILoading.Color = Settings.GrayColor;
            AILoading.IsRunning = false; 
            AILoading.WidthRequest = Labelheight * 6;
            AILoading.HeightRequest = Labelheight * 6;
            Container.Children.Add(AILoading, new Point(w / 2 - AILoading.WidthRequest / 2, h / 2 - AILoading.HeightRequest / 2));


            ImgExit.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgExitClick())
            });
            LBHome.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBHomeClick())
            });
            LBSettings.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBSettingsClick())
            });
            LBLogout.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBLogoutClickAsync())
            });
            LBFavorits.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBFavoritsClickAsync())
            });
            LBOrders.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBOrdersClickAsync())
            });
            LBNotification.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBNotificationClickAsync())
            });
            DeleteAcount.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBDeleteAcountClickAsync())
            });
        }

        private async void LBNotificationClickAsync()
        {
            AILoading.IsRunning = true;
            await Settings.notification.GetData();
            home.Content = Settings.notification.MainLayout;
            ImgExitClick();
            AILoading.IsRunning = false;
        }

        private async void LBDeleteAcountClickAsync()
        {
            AILoading.IsRunning = true;

            var UserID = Settings.cash.UserInfo.UserId;

            // Call the delete function and wait for the result
            string result = await Settings.DeleteAccountAsync(UserID);

            AILoading.IsRunning = false;

            if (result == "true")
            {
                await Application.Current.MainPage.DisplayAlert("Account Deleted", "Your account has been successfully deleted.", "OK");
                LBLogoutClickAsync();
                // Navigate the user to the login page or exit the app
                home.Content = Settings.login.MainLayout;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to delete your account. Please try again.", "OK");
            }

            ImgExitClick();
        }


        private async Task LBOrdersClickAsync()
        {
            AILoading.IsRunning = true;
            await Settings.myOrders.GetData();
            await Settings.GetDeliveryFees();            
            home.Content = Settings.myOrders.MainLayout;
            ImgExitClick();
            AILoading.IsRunning = false;
        }

        private async void LBFavoritsClickAsync()
        {
            AILoading.IsRunning = true;
            await Settings.favorites.GetDataAsync();           
            home.Content = Settings.favorites.MainLayout;
            ImgExitClick();
            AILoading.IsRunning = false;
        }

        private async void LBLogoutClickAsync()
        {
            Settings.cash.LoggedIn = false;
            Settings.cash.FavoriteList.Clear();
            Settings.SaveCash();
            await home.Navigation.PopPopupAsync(true);
            Settings.mainPage.LItemNumber.Text = "0";
            Settings.Message = "تم تسجيل الخروج";

        }

        private void LBSettingsClick()
        {
            ImgExitClick();
            Settings.updateUserInfo.UserInfo = Settings.cash.UserInfo;
            Settings.updateUserInfo.SetData(); ;
            home.Content = Settings.updateUserInfo.MainLayout;
        }

        private void LBHomeClick()
        {
            ImgExitClick();
        }

        public async void ImgExitClick()
        {
            await home.Navigation.PopPopupAsync(true);

        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        protected override bool OnBackgroundClicked()
        {
            bool IsIOS = false;
            Device.OnPlatform(iOS: () =>
            {
                IsIOS = true;
            });
            if (IsIOS)
                return base.OnBackgroundClicked();
            return false;
        }


        public void SetData()
        {
            if (Settings.cash.UserInfo.UserPhoto!=null)
            ImgUserPhoto.Source = Settings.cash.UserInfo.UserPhoto;
            LBUserName.Text = Settings.cash.UserInfo.UserName;
        }
    }
}
