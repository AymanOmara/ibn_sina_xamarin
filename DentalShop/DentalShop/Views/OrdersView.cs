using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DentalShop
{
    public class OrdersView : ViewCell
    {
        public Label LBOrderID;
        public Label LBPrice; 
        public Label LBAmount;
        public Label LBDelivery;
        public Image ImgEdit;
        public Label LBIndex;
        public Label LBDate;
        public Label LBTotalPrice;
        ProuductEntity[] prouductEntity;
        public ProuductEntity[] ProudctEntity
        {
            get { return prouductEntity; }
            set
            {

                prouductEntity = value;
                //GetDataAsync();
            }
        }
        public OrdersView()
        {
            AbsoluteLayout MainLayout = new AbsoluteLayout();
            MainLayout.WidthRequest = Settings.OrderWidth;
            MainLayout.HeightRequest = Settings.OrderHeight;
            MainLayout.BackgroundColor = Color.White;
            AbsoluteLayout Container = new AbsoluteLayout();
            Container.WidthRequest = MainLayout.WidthRequest;
            Container.HeightRequest = MainLayout.HeightRequest - 5;
            Container.BackgroundColor = Color.White;

            double FontSize = 7;
             
            double ypoint = 3;

            ////////////////////////////////////////////////////
            // Add the new LBTotalPrice label
            LBTotalPrice = new Label();
            LBTotalPrice.WidthRequest = MainLayout.WidthRequest / 5; // Adjust width as needed
            LBTotalPrice.HeightRequest = Settings.Labelheight * 2;
            LBTotalPrice.TextColor = Settings.MainColor;
            LBTotalPrice.FontSize = FontSize + 5;
            LBTotalPrice.SetBinding(Label.TextProperty, "LBTotalPrice"); // Bind to the total price
            LBTotalPrice.FontAttributes = FontAttributes.Bold;
            LBTotalPrice.HorizontalTextAlignment = TextAlignment.Center;
            LBTotalPrice.VerticalTextAlignment = TextAlignment.Start;
            LBTotalPrice.FontFamily = Settings.ArabicFontFamily;

            // Add the LBTotalPrice label to the container
            //Container.Children.Add(LBTotalPrice, new Point(MainLayout.WidthRequest / 5 * 4, MainLayout.HeightRequest / 3));
            //Container.Children.Add(LBTotalPrice, new Point(MainLayout.WidthRequest / 5 * 3 - 2, MainLayout.HeightRequest / 3));
            Container.Children.Add(LBTotalPrice, new Point(0, MainLayout.HeightRequest / 3));
            ///////////////////////////////////////////////////


            ImgEdit = new Image();
            ImgEdit.WidthRequest = 20;
            ImgEdit.Aspect = Aspect.Fill;
            ImgEdit.HeightRequest = 20;
            ImgEdit.Source= ImageSource.FromResource("DentalShop.Images.edit.png");
            ImgEdit.SetBinding(Image.IsVisibleProperty, "ImgEdit");
            Container.Children.Add(ImgEdit, new Point(MainLayout.WidthRequest / 4 * 3 + 20, ypoint));


            LBOrderID = new Label();
            LBOrderID.WidthRequest = MainLayout.WidthRequest / 5;
            LBOrderID.HeightRequest = Settings.Labelheight * 2;
            LBOrderID.TextColor = Settings.MainColor;
            LBOrderID.FontSize = FontSize + 5;
            LBOrderID.SetBinding(Label.TextProperty, "LBOrderID");
            LBOrderID.FontAttributes = FontAttributes.Bold;
            LBOrderID.HorizontalTextAlignment = TextAlignment.Center;
            LBOrderID.VerticalTextAlignment = TextAlignment.Start;
            LBOrderID.FontFamily = Settings.ArabicFontFamily;

            //Container.Children.Add(LBOrderID, new Point(MainLayout.WidthRequest / 5 * 3 - 10, MainLayout.HeightRequest / 3));
            Container.Children.Add(LBOrderID, new Point(MainLayout.WidthRequest / 5 * 4, MainLayout.HeightRequest / 3));


            LBPrice = new Label();
            LBPrice.WidthRequest = MainLayout.WidthRequest / 5;
            LBPrice.HeightRequest = Settings.Labelheight * 2;
            LBPrice.TextColor = Settings.MainColor;
            LBPrice.FontSize = FontSize + 5;
            LBPrice.SetBinding(Label.TextProperty, "LBPrice");
            LBPrice.FontAttributes = FontAttributes.Bold;
            LBPrice.HorizontalTextAlignment = TextAlignment.Center;
            LBPrice.VerticalTextAlignment = TextAlignment.Start;
            LBPrice.FontFamily = Settings.ArabicFontFamily;

            //Container.Children.Add(LBPrice, new Point(MainLayout.WidthRequest / 2, MainLayout.HeightRequest / 3));
            Container.Children.Add(LBPrice, new Point(MainLayout.WidthRequest / 5 +50, MainLayout.HeightRequest / 3));



            LBAmount = new Label();
            //LBAmount.WidthRequest = 25;
            LBAmount.WidthRequest = MainLayout.WidthRequest / 5;
            LBAmount.HeightRequest = Settings.Labelheight * 2;
            LBAmount.TextColor = Settings.MainColor;
            LBAmount.FontSize = FontSize + 6;
            LBAmount.SetBinding(Label.TextProperty, "LBAmount");
            LBAmount.FontAttributes = FontAttributes.Bold;
            LBAmount.HorizontalTextAlignment = TextAlignment.Center;
            LBAmount.VerticalTextAlignment = TextAlignment.Start;
            LBAmount.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBAmount, new Point(MainLayout.WidthRequest / 5  , MainLayout.HeightRequest / 3));




            LBDelivery = new Label();
            LBDelivery.WidthRequest = MainLayout.WidthRequest / 5;
            LBDelivery.HeightRequest = Settings.Labelheight * 2;
            LBDelivery.TextColor = Settings.MainColor;
            LBDelivery.FontSize = FontSize + 5;
            LBDelivery.SetBinding(Label.TextProperty, "LBDelivery");
            LBDelivery.FontAttributes = FontAttributes.Bold;
            LBDelivery.HorizontalTextAlignment = TextAlignment.Center;
            LBDelivery.VerticalTextAlignment = TextAlignment.Start;
            LBDelivery.FontFamily = Settings.ArabicFontFamily;

            //Container.Children.Add(LBDelivery, new Point(0, MainLayout.HeightRequest / 3));
            Container.Children.Add(LBDelivery, new Point(MainLayout.WidthRequest / 5 * 3 - 2, MainLayout.HeightRequest / 3));


            LBIndex = new Label();
            LBIndex.WidthRequest = Container.WidthRequest;
            LBIndex.HeightRequest = Settings.Labelheight - 3;
            LBIndex.Text = "";
            LBIndex.IsVisible = false;
            LBIndex.SetBinding(Label.TextProperty, "index");
            LBIndex.HorizontalTextAlignment = TextAlignment.Center;
            Container.Children.Add(LBIndex, new Point(0, ypoint));

            LBDate = new Label();
            LBDate.WidthRequest = MainLayout.WidthRequest -20;
            LBDate.HeightRequest = Settings.Labelheight +10;
            LBDate.TextColor = Settings.GrayColor;
            LBDate.FontSize = FontSize + 5;
            LBDate.SetBinding(Label.TextProperty, "LBDate");
            LBDate.FontAttributes = FontAttributes.Bold;
            LBDate.HorizontalTextAlignment = TextAlignment.Start;
            LBDate.VerticalTextAlignment = TextAlignment.End;
            LBDate.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBDate, new Point(10, MainLayout.HeightRequest -5- LBDate.HeightRequest));





            MainLayout.Children.Add(Container, new Point(0, 0));
            View = MainLayout;

            //event
            ImgEdit.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgEditClickAsync())
            });

        }

        private async void ImgEditClickAsync()
        {
            int id = Convert.ToInt32(LBIndex.Text);
            Settings.editOrder.order = Settings.myOrders.OrderEntity[id];
            Settings.EditProudctList.Clear();
            prouductEntity =await Settings.GetOrderProuduct(Settings.myOrders.OrderEntity[id].OrderId.ToString());
            Settings.editOrder.order.OrderProuductList = await Settings.GetOrderProuductListAsync(Settings.myOrders.OrderEntity[id].OrderId.ToString());
            for (int i = 0; i < prouductEntity.Length; i++)
            {
                Settings.EditProudctList.Add(prouductEntity[i]);
            }
            Settings.editOrder.ProudctEntity = Settings.EditProudctList.ToArray();
            Settings.editOrder.GetDataAsync();
           Settings.homePage.Content = Settings.editOrder.MainLayout;
        }
    }
}
