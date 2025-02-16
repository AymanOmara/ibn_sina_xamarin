using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DentalShop
{
    public class LaterOrder : PopupPage
    {
        int w;
        int h;
        AbsoluteLayout Container;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.White;
        Image ImgBackground;
        Image ImgStar;
        Label LBData;
        public LaterOrder(int w, int h, HomePage home)
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
            double ypoint = h * .25;


            ImgBackground = new Image();
            ImgBackground.WidthRequest = w - 20;
            ImgBackground.HeightRequest = h * 0.12;
            ImgBackground.Aspect = Aspect.Fill;
            ImgBackground.Source = ImageSource.FromResource("DentalShop.Images.button.png");
            ImgBackground.HorizontalOptions = LayoutOptions.Center;
            Point ImgBackgroundLocation = new Point(10, h * .45);
            Container.Children.Add(ImgBackground, ImgBackgroundLocation);

            ImgStar = new Image();
            ImgStar.WidthRequest = h*.09;
            ImgStar.HeightRequest = h*.09;
            ImgStar.Aspect = Aspect.Fill;
            ImgStar.Source = ImageSource.FromResource("DentalShop.Images.close.png");
            ImgStar.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgStar, new Point(15, h*.45+h*.015));



            ypoint += 30;

            //data
            LBData = new Label();
            LBData.WidthRequest = w - 20-ImgStar.WidthRequest;
            LBData.TextColor = Color.White;
            LBData.HeightRequest = h * .12;
            LBData.FontSize = FontSize;
            LBData.Text = "تم طلب الاورد في وقت لاحق" ;
            LBData.FontAttributes = FontAttributes.Bold;
            LBData.FontFamily = Settings.ArabicFontFamily;
            LBData.HorizontalTextAlignment = TextAlignment.Center;
            LBData.VerticalTextAlignment = TextAlignment.Center;
            Container.Children.Add(LBData, new Point(15+ImgStar.WidthRequest, h * .45 ));

        


            //events
            ImgStar.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgStarClickAsync())
            });
           


        }

        private async void ImgStarClickAsync()
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

       
    }
}
