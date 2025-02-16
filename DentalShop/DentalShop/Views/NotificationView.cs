using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DentalShop
{
    public class NotificationView : ViewCell
    {
        public Image ImgNotification;
        public Label LBNotificationText;
        public Label LBOrderID;
        public Label LBPrice;
        public Label LBAmount;
        public Label LBDelivery;
        public NotificationView()
        {
            AbsoluteLayout MainLayout = new AbsoluteLayout();
            MainLayout.WidthRequest = Settings.OrderWidth;
            MainLayout.HeightRequest = Settings.OrderHeight;
            MainLayout.BackgroundColor = Color.White;
            AbsoluteLayout Container = new AbsoluteLayout();
            Container.WidthRequest = MainLayout.WidthRequest;
            Container.HeightRequest = MainLayout.HeightRequest - 5;
            Container.BackgroundColor = Color.White;

            double FontSize = 6;
             
            double ypoint = 3;

            ImgNotification = new Image();
            ImgNotification.WidthRequest =MainLayout.WidthRequest- 20;
            ImgNotification.Aspect = Aspect.Fill;
            ImgNotification.HeightRequest = MainLayout.HeightRequest;
            ImgNotification.Source = ImageSource.FromResource("DentalShop.Images.Notifcation.png");
            Container.Children.Add(ImgNotification, new Point(10, ypoint));


            LBNotificationText = new Label();
            LBNotificationText.WidthRequest = MainLayout.WidthRequest -30;
            LBNotificationText.HeightRequest = MainLayout.HeightRequest*.45;
            LBNotificationText.TextColor = Settings.MainColor;
            LBNotificationText.FontSize = FontSize + 5;
            LBNotificationText.SetBinding(Label.TextProperty, "LBNotificationText");
            LBNotificationText.FontAttributes = FontAttributes.Bold;
            LBNotificationText.HorizontalTextAlignment = TextAlignment.Center;
            LBNotificationText.VerticalTextAlignment = TextAlignment.Center;
            LBNotificationText.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBNotificationText, new Point(15, MainLayout.HeightRequest / 5));

            double Xpoint = MainLayout.WidthRequest / 4;
            double Size = MainLayout.WidthRequest / 2;
            ypoint += 20 + LBNotificationText.HeightRequest;

            LBOrderID = new Label();
            LBOrderID.WidthRequest = MainLayout.WidthRequest / 8;
            LBOrderID.HeightRequest = Settings.Labelheight * 2;
            LBOrderID.TextColor = Settings.MainColor;
            LBOrderID.FontSize = FontSize +2;
            LBOrderID.SetBinding(Label.TextProperty, "LBOrderID");
            LBOrderID.FontAttributes = FontAttributes.Bold;
            LBOrderID.HorizontalTextAlignment = TextAlignment.Center;
            LBOrderID.VerticalTextAlignment = TextAlignment.Start;
            LBOrderID.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBOrderID, new Point(Xpoint+ Size / 4 * 3 , ypoint));


            LBPrice = new Label();
            LBPrice.WidthRequest = MainLayout.WidthRequest / 8;
            LBPrice.HeightRequest = Settings.Labelheight * 2;
            LBPrice.TextColor = Settings.MainColor;
            LBPrice.FontSize = FontSize+2 ;
            LBPrice.SetBinding(Label.TextProperty, "LBPrice");
            LBPrice.FontAttributes = FontAttributes.Bold;
            LBPrice.HorizontalTextAlignment = TextAlignment.Center;
            LBPrice.VerticalTextAlignment = TextAlignment.Start;
            LBPrice.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBPrice, new Point(Xpoint+ Size / 2, ypoint));



            LBAmount = new Label();
            LBAmount.WidthRequest = 25;
            LBAmount.HeightRequest = Settings.Labelheight * 2;
            LBAmount.TextColor = Settings.MainColor;
            LBAmount.FontSize = FontSize + 2;
            LBAmount.SetBinding(Label.TextProperty, "LBAmount");
            LBAmount.FontAttributes = FontAttributes.Bold;
            LBAmount.HorizontalTextAlignment = TextAlignment.Center;
            LBAmount.VerticalTextAlignment = TextAlignment.Start;
            LBAmount.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBAmount, new Point(Xpoint+ Size / 4 +8, ypoint));




            LBDelivery = new Label();
            LBDelivery.WidthRequest = MainLayout.WidthRequest / 8;
            LBDelivery.HeightRequest = Settings.Labelheight * 2;
            LBDelivery.TextColor = Settings.MainColor;
            LBDelivery.FontSize = FontSize +2;
            LBDelivery.SetBinding(Label.TextProperty, "LBDelivery");
            LBDelivery.FontAttributes = FontAttributes.Bold;
            LBDelivery.HorizontalTextAlignment = TextAlignment.Center;
            LBDelivery.VerticalTextAlignment = TextAlignment.Start;
            LBDelivery.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBDelivery, new Point(Xpoint, ypoint));


            MainLayout.Children.Add(Container, new Point(0, 0));
            View = MainLayout;

        }
    }
}
