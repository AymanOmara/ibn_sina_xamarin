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
    public class GuestSidePage : PopupPage
    {
        int w;
        int h;
        AbsoluteLayout Container;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.White;
        Image ImgBackground;
        private Image ImgCreateButton;
        Label LBCreateButton;
        Image ImgExit;
        Image ImgLoginButton;
        Label LBLoginButton;
        Image ImgUserPhoto;
        Label LBAboutUsButton;
        Image ImgAboutUsPhoto;
        public GuestSidePage(int w, int h, HomePage home)
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
            double FontSize = Settings.FontSize + 5;
             
            int ButtonHeight = 45;
            int width = w;
            int Labelheight = 23;
            double ypoint = h / 6;

            ImgBackground = new Image();
            ImgBackground.WidthRequest = w * 0.6;
            ImgBackground.HeightRequest = h * 0.75;
            ImgBackground.Aspect = Aspect.Fill;
            ImgBackground.Source = ImageSource.FromResource("DentalShop.Images.OrangeBackground.png");
            ImgBackground.HorizontalOptions = LayoutOptions.Center;
            Point ImgBackgroundLocation = new Point(w * 0.4 - 10, ypoint - 10);
            Container.Children.Add(ImgBackground, ImgBackgroundLocation);


            ImgExit = new Image();
            ImgExit.WidthRequest = Labelheight + 5;
            ImgExit.HeightRequest = Labelheight + 5;
            ImgExit.Aspect = Aspect.Fill;
            ImgExit.Source = ImageSource.FromResource("DentalShop.Images.ExitIcon.png");
            ImgExit.HorizontalOptions = LayoutOptions.Center;
            Point ImgExitLocation = new Point(w * 0.4 + 5, ypoint + 10);
            Container.Children.Add(ImgExit, ImgExitLocation);


            ypoint += ImgBackground.HeightRequest * .1;


            //user photo
            ImgUserPhoto = new Image();
            ImgUserPhoto.Aspect = Aspect.Fill;
            ImgUserPhoto.Source = ImageSource.FromResource("DentalShop.Images.user.png");
            ImgUserPhoto.WidthRequest = h/4;
            ImgUserPhoto.HeightRequest = h/4;
            Container.Children.Add(ImgUserPhoto, new Point(w * .4 -10+(ImgBackground.WidthRequest/2- (ImgUserPhoto.WidthRequest / 2)), ypoint));


            ypoint +=  ImgUserPhoto.HeightRequest*1.2;


            ImgLoginButton = new Image();
            ImgLoginButton.WidthRequest = ImgBackground.WidthRequest - 20;
            ImgLoginButton.HeightRequest = Labelheight * 2;
            ImgLoginButton.Aspect = Aspect.Fill;
            ImgLoginButton.Source = ImageSource.FromResource("DentalShop.Images.WhiteButton.png");
            ImgLoginButton.HorizontalOptions = LayoutOptions.Center;
            Point ImgLoginButtonLocation = new Point(w * 0.4, ypoint);
            Container.Children.Add(ImgLoginButton, ImgLoginButtonLocation);



            //Loginbutton
            LBLoginButton = new Label();
            LBLoginButton.WidthRequest = ImgLoginButton.WidthRequest;
            LBLoginButton.TextColor = Settings.MainColor;
            LBLoginButton.HeightRequest = Labelheight*2;
            LBLoginButton.FontSize = FontSize;
            LBLoginButton.Text = "تسجيل الدخول";
            LBLoginButton.FontAttributes = FontAttributes.Bold;
            LBLoginButton.HorizontalTextAlignment = TextAlignment.Center;
            LBLoginButton.VerticalTextAlignment = TextAlignment.Center;
            LBLoginButton.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBLoginButton, new Point(w*0.4, ypoint ));




            ypoint += 20 + ImgLoginButton.HeightRequest;


            ImgCreateButton = new Image();
            ImgCreateButton.WidthRequest = ImgBackground.WidthRequest - 20;
            ImgCreateButton.HeightRequest = Labelheight * 2;
            ImgCreateButton.Aspect = Aspect.Fill;
            ImgCreateButton.Source = ImageSource.FromResource("DentalShop.Images.WhiteButton.png");
            ImgCreateButton.HorizontalOptions = LayoutOptions.Center;
            Point ImgCreateButtonLocation = new Point(w * 0.4, ypoint);
            Container.Children.Add(ImgCreateButton, ImgCreateButtonLocation);



            //CreateAccountbutton
            LBCreateButton = new Label();
            LBCreateButton.WidthRequest =ImgCreateButton.WidthRequest;
            LBCreateButton.TextColor = Settings.MainColor;
            LBCreateButton.HeightRequest = Labelheight*2;
            LBCreateButton.FontSize = FontSize;
            LBCreateButton.Text = "إنشاء حساب جديد";
            LBCreateButton.FontAttributes = FontAttributes.Bold;
            LBCreateButton.HorizontalTextAlignment = TextAlignment.Center;
            LBCreateButton.VerticalTextAlignment = TextAlignment.Center;
            LBCreateButton.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBCreateButton, new Point(w*.4, ypoint ));
            ypoint += 20 + ImgLoginButton.HeightRequest;



            ImgAboutUsPhoto = new Image();
            ImgAboutUsPhoto.WidthRequest = ImgBackground.WidthRequest - 20;
            ImgAboutUsPhoto.HeightRequest = Labelheight * 2;
            ImgAboutUsPhoto.Aspect = Aspect.Fill;
            ImgAboutUsPhoto.Source = ImageSource.FromResource("DentalShop.Images.WhiteButton.png");
            ImgAboutUsPhoto.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgAboutUsPhoto, new Point(w * 0.4, ypoint));



            //CreateAccountbutton
            LBAboutUsButton = new Label();
            LBAboutUsButton.WidthRequest = ImgCreateButton.WidthRequest;
            LBAboutUsButton.TextColor = Settings.MainColor;
            LBAboutUsButton.HeightRequest = Labelheight * 2;
            LBAboutUsButton.FontSize = FontSize;
            LBAboutUsButton.Text = "تواصل معنا";
            LBAboutUsButton.FontAttributes = FontAttributes.Bold;
            LBAboutUsButton.HorizontalTextAlignment = TextAlignment.Center;
            LBAboutUsButton.VerticalTextAlignment = TextAlignment.Center;
            LBAboutUsButton.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBAboutUsButton, new Point(w * .4, ypoint));
            ypoint += 20 + LBAboutUsButton.HeightRequest;


            //event
            LBAboutUsButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBAboutUsButtonClickAsync())
            });
            LBLoginButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgLoginButtonClickAsync())
            });
            LBCreateButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgCreateButtonClickAsync())
            });
            ImgExit.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgExitClickAsync())
            });
        }

        private async void LBAboutUsButtonClickAsync()
        {
            await home.Navigation.PopPopupAsync(true);
            home.Content = Settings.aboutUs.MainLayout;
        }

        public async void ImgExitClickAsync()
        {
            await home.Navigation.PopPopupAsync(true);

        }

        public async void ImgCreateButtonClickAsync()
        {
            await home.Navigation.PopPopupAsync(true);
            home.Content = Settings.createAcount.MainLayout;
        }

        public async void ImgLoginButtonClickAsync()
        {
            await home.Navigation.PopPopupAsync(true);
            home.Content = Settings.login.MainLayout;
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
    }
}
