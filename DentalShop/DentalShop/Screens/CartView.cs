using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DentalShop
{
   public  class CartView : ViewCell
    {
        Image ImgProuduct;
        Label LBName;
        public Label LBPrice;
        Image ImgDown;
        public Label LBAmount=new Label();
        Image ImgUp;
        public Label LBTotalPrice;
        public Label LBID;
        public Label LBIndex;


        public CartView()
        {
            AbsoluteLayout MainLayout = new AbsoluteLayout();
            MainLayout.WidthRequest = Settings.CartWidth;
            MainLayout.HeightRequest = Settings.CartHeight;
            MainLayout.BackgroundColor = Color.White;
            AbsoluteLayout Container = new AbsoluteLayout();
            Container.WidthRequest = MainLayout.WidthRequest;
            Container.HeightRequest = MainLayout.HeightRequest - 5;
            Container.BackgroundColor = Color.White;

            double FontSize = 7;
             
            double ypoint = 3;

            ImgProuduct = new Image();
            ImgProuduct.WidthRequest = MainLayout.WidthRequest/4-10;
            ImgProuduct.Aspect = Aspect.Fill;
            ImgProuduct.HeightRequest = MainLayout.HeightRequest -5-Settings.Labelheight*2;
            ImgProuduct.SetBinding(Image.SourceProperty, "ImgProuduct");
            Container.Children.Add(ImgProuduct, new Point(MainLayout.WidthRequest/4*3-10, ypoint));


            LBName = new Label();
            LBName.WidthRequest = MainLayout.WidthRequest/4;
            LBName.HeightRequest = Settings.Labelheight*2;
            LBName.TextColor = Settings.MainColor;
            LBName.FontSize = FontSize+5;
            LBName.SetBinding(Label.TextProperty, "LBName");
            LBName.FontAttributes = FontAttributes.Bold;
            LBName.HorizontalTextAlignment = TextAlignment.Center;
            LBName.VerticalTextAlignment = TextAlignment.Center;
            LBName.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBName, new Point(MainLayout.WidthRequest / 4 * 3-10, ypoint +ImgProuduct.HeightRequest));


            LBPrice = new Label();
            LBPrice.WidthRequest = MainLayout.WidthRequest / 4;
            LBPrice.HeightRequest = Settings.Labelheight * 2;
            LBPrice.TextColor = Settings.MainColor;
            LBPrice.FontSize = FontSize + 5;
            LBPrice.SetBinding(Label.TextProperty, "LBPrice");
            LBPrice.FontAttributes = FontAttributes.Bold;
            LBPrice.HorizontalTextAlignment = TextAlignment.Center;
            LBPrice.VerticalTextAlignment = TextAlignment.Start;
            LBPrice.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBPrice, new Point(MainLayout.WidthRequest / 2,  MainLayout.HeightRequest / 3));



            ImgDown = new Image();
            ImgDown.WidthRequest = ImgDown.HeightRequest=15;
            ImgDown.Aspect = Aspect.Fill;
            ImgDown.Source = ImageSource.FromResource("DentalShop.Images.Down.png");
            Container.Children.Add(ImgDown, new Point(MainLayout.WidthRequest / 4+10, MainLayout.HeightRequest/3));

           // LBAmount = new Label();
            LBAmount.WidthRequest = ImgDown.HeightRequest;
            LBAmount.HeightRequest = ImgDown.HeightRequest*2;
            LBAmount.TextColor = Settings.MainColor;
            LBAmount.FontSize = FontSize + 6;
            LBAmount.SetBinding(Label.TextProperty, "LBAmount");
            LBAmount.FontAttributes = FontAttributes.Bold;
            LBAmount.HorizontalTextAlignment = TextAlignment.Center;
            LBAmount.VerticalTextAlignment = TextAlignment.Center;
            LBAmount.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBAmount, new Point(MainLayout.WidthRequest / 4+15+(ImgDown.WidthRequest * 1), MainLayout.HeightRequest / 3-8));

            ImgUp = new Image();
            ImgUp.WidthRequest = ImgUp.HeightRequest = ImgDown.WidthRequest;
            ImgUp.Aspect = Aspect.Fill;
            ImgUp.Source = ImageSource.FromResource("DentalShop.Images.Up.png");
            Container.Children.Add(ImgUp, new Point(MainLayout.WidthRequest / 4+10 + (ImgDown.WidthRequest * 2)+10 , MainLayout.HeightRequest /3));



            LBTotalPrice = new Label();
            LBTotalPrice.WidthRequest = MainLayout.WidthRequest / 4;
            LBTotalPrice.HeightRequest = Settings.Labelheight * 2;
            LBTotalPrice.TextColor = Settings.MainColor;
            LBTotalPrice.FontSize = FontSize + 5;
            LBTotalPrice.SetBinding(Label.TextProperty, "LBTotalPrice");
            LBTotalPrice.FontAttributes = FontAttributes.Bold;
            LBTotalPrice.HorizontalTextAlignment = TextAlignment.Center;
            LBTotalPrice.VerticalTextAlignment = TextAlignment.Start;
            LBTotalPrice.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBTotalPrice, new Point(0,  MainLayout.HeightRequest / 3));


            LBIndex = new Label();
            LBIndex.WidthRequest = Container.WidthRequest;
            LBIndex.HeightRequest = Settings.Labelheight - 3;
            LBIndex.Text = "";
            LBIndex.IsVisible = false;
            LBIndex.SetBinding(Label.TextProperty, "index");
            LBIndex.HorizontalTextAlignment = TextAlignment.Center;
            Container.Children.Add(LBIndex, new Point(0, ypoint));


            LBID = new Label();
            LBID.Text = "";
            LBID.IsVisible = false;
            LBID.SetBinding(Label.TextProperty, "LBID");
            LBID.HorizontalTextAlignment = TextAlignment.Center;
            Container.Children.Add(LBID, new Point(0, ypoint));



            MainLayout.Children.Add(Container, new Point(0, 0));
            View = MainLayout;

            //event
            ImgDown.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgDownClick())
            });
            ImgUp.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgUpClick())
            });
            Settings.cartList.Add(this);
        }
        public Double GetPrice()
        {
            string s = "";
            for (int i=0;i<LBPrice.Text.Length-4;i++)
            {
                s += LBPrice.Text[i];
            }
            return Convert.ToDouble(s);
        }
        private void ImgUpClick()
        {
            int amount = Convert.ToInt32(LBAmount.Text);
            amount++;
            LBAmount.Text = amount.ToString();
            LBTotalPrice.Text = (amount * GetPrice()).ToString()+" ج م";
        }

        private void ImgDownClick()
        {
            int amount = Convert.ToInt32(LBAmount.Text);
            amount--;
            if (amount==0)
            {
                for (int i = 0; i < Settings.cash.CartList.Count; i++)
                {
                    if (Settings.cash.CartList[i].ProductID.ToString() == LBID.Text)
                    {
                        Settings.cash.CartList.RemoveAt(i);
                     
                        Settings.SaveCash();
                        Settings.prouductPage.LBItemNumber.Text = Settings.cash.CartList.Count.ToString();
                        Settings.mainPage.LItemNumber.Text = Settings.cash.CartList.Count.ToString();
                        Settings.studentProuduct.LBItemNumber.Text = Settings.cash.CartList.Count.ToString();

                    }

                }
                
                try
                {
                    for (int i = 0; i < Settings.cartList.Count; i++)
                    {
                        if (Settings.cartList[i].LBID.Text.ToString() == LBID.Text.ToString())
                        {
                            Settings.cartList.RemoveAt(i);
                        }

                    }
                    for (int i = 0; i < Settings.EditProudctList.Count; i++)
                    {
                        if (Settings.EditProudctList[i].ProductID.ToString() == LBID.Text.ToString())
                        {
                            Settings.EditProudctList.RemoveAt(i);

                        }

                    }
                    Settings.editOrder.ProudctEntity = Settings.EditProudctList.ToArray();
                    Settings.editOrder.GetDataAsync();
                }
                catch
                {

                }
                Settings.cart.GetDataAsync();
                
                return;
            }
            LBAmount.Text = amount.ToString();
            LBTotalPrice.Text = (amount * GetPrice()).ToString() + " ج م";
        }
    }
}
