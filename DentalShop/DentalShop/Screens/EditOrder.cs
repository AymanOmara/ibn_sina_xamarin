using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DentalShop
{
    public class EditOrder
    {
        int w;
        int h;
        public ScrollView Scroll = new ScrollView();
        AbsoluteLayout Container;
        public Grid MainLayout;
        AbsoluteLayout MenuBar;
        AbsoluteLayout ButtonBar;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.White;
        Label LBTop;
        Image ImgBack;
        Label LBName;
        Label LBPrice;
        Label LBAmount;
        Label LBTotalPrice;
        Label LBOrder;
        Label LBCancel;

        List<CartObject> Cartlist;
        ListView LVList;
        List<CartView> cartViews;
        public Order order;
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

        List<OrderList> orderLists;

        private ActivityIndicator AILoading;
        public EditOrder(int w, int h, HomePage home)
        {
            home.BackgroundColor = LabelColor;
            this.home = home;
            this.w = w;
            this.h = h;
            Container = new AbsoluteLayout();
            Container.WidthRequest = w;
            Container.BackgroundColor = Settings.BackGroundColor;
            InitializeComponents();
            Scroll.Content = Container;
            Scroll.ScrollToAsync(0, 0, false);
            MainLayout = new Grid();
            MainLayout.RowSpacing = 0;
            MainLayout.BackgroundColor = Color.White;
            MainLayout.RowDefinitions.Add(new RowDefinition { Height = LBTop.HeightRequest + 10  + 10 + 10 + LBName.HeightRequest });
            MainLayout.RowDefinitions.Add(new RowDefinition());
            MainLayout.RowDefinitions.Add(new RowDefinition { Height = LBOrder.HeightRequest + 15 });
            MainLayout.Margin = new Thickness(0, 0, 0, 0);
            MainLayout.Children.Add(Scroll, 0, 1);
            MainLayout.Children.Add(MenuBar, 0, 0);
            MainLayout.Children.Add(ButtonBar, 0, 2);
        }



        public void InitializeComponents()
        {
            double FontSize = 13;
             
            int ButtonHeight = 45;
            int width = w - 20;
            int Labelheight = 23;
            //Top Label
            MenuBar = new AbsoluteLayout();
            MenuBar.BackgroundColor = Color.White;
            MenuBar.WidthRequest = w;
            MenuBar.HeightRequest = Labelheight * 2 + 20;


            LBTop = new Label();
            LBTop.WidthRequest = w;
            LBTop.TextColor = Color.White;
            LBTop.HeightRequest = Labelheight + 20;
            LBTop.FontSize = FontSize + 8;
            LBTop.Text = "تعديل الطلب";
            LBTop.BackgroundColor = Settings.MainColor;
            LBTop.HorizontalTextAlignment = TextAlignment.Center;
            LBTop.VerticalTextAlignment = TextAlignment.Center;
            LBTop.FontFamily = Settings.ArabicFontFamily;
            MenuBar.Children.Add(LBTop, new Point(0, 0));




            //img back
            ImgBack = new Image();
            ImgBack.Aspect = Aspect.Fill;
            ImgBack.Source = ImageSource.FromResource("DentalShop.Images.whiteback.png");
            ImgBack.WidthRequest = Labelheight;
            ImgBack.HeightRequest = Labelheight;
            MenuBar.Children.Add(ImgBack, new Point(10, 10));


            double ypoint = 1 + LBTop.HeightRequest; ;


        
            ypoint +=  Labelheight + 5;


            LBTotalPrice = new Label();
            LBTotalPrice.WidthRequest = w / 4;
            LBTotalPrice.TextColor = Settings.MainColor;
            LBTotalPrice.HeightRequest = Labelheight * 2;
            LBTotalPrice.FontSize = FontSize;
            LBTotalPrice.Text = "المجموع الكلي";
            LBTotalPrice.HorizontalTextAlignment = TextAlignment.Center;
            LBTotalPrice.VerticalTextAlignment = TextAlignment.Center;
            LBTotalPrice.FontFamily = Settings.ArabicFontFamily;
            MenuBar.Children.Add(LBTotalPrice, new Point(0, ypoint));



            LBAmount = new Label();
            LBAmount.WidthRequest = w / 4;
            LBAmount.TextColor = Settings.MainColor;
            LBAmount.HeightRequest = Labelheight * 2;
            LBAmount.FontSize = FontSize;
            LBAmount.Text = "الكمية";
            LBAmount.HorizontalTextAlignment = TextAlignment.Center;
            LBAmount.VerticalTextAlignment = TextAlignment.Center;
            LBAmount.FontFamily = Settings.ArabicFontFamily;
            MenuBar.Children.Add(LBAmount, new Point(w / 4, ypoint));


            LBPrice = new Label();
            LBPrice.WidthRequest = w / 4;
            LBPrice.TextColor = Settings.MainColor;
            LBPrice.HeightRequest = Labelheight * 2;
            LBPrice.FontSize = FontSize;
            LBPrice.Text = "السعر";
            LBPrice.HorizontalTextAlignment = TextAlignment.Center;
            LBPrice.VerticalTextAlignment = TextAlignment.Center;
            LBPrice.FontFamily = Settings.ArabicFontFamily;
            MenuBar.Children.Add(LBPrice, new Point(w / 2, ypoint));


            LBName = new Label();
            LBName.WidthRequest = w / 4;
            LBName.TextColor = Settings.MainColor;
            LBName.HeightRequest = Labelheight * 2;
            LBName.FontSize = FontSize;
            LBName.Text = "اسم المنتج";
            LBName.HorizontalTextAlignment = TextAlignment.Center;
            LBName.VerticalTextAlignment = TextAlignment.Center;
            LBName.FontFamily = Settings.ArabicFontFamily;
            MenuBar.Children.Add(LBName, new Point(w / 4 * 3, ypoint));



            ButtonBar = new AbsoluteLayout();
            ButtonBar.BackgroundColor = Color.White;
            ButtonBar.WidthRequest = w;
            ButtonBar.HeightRequest = Labelheight * 2 + 15;


            LBOrder = new Label();
            LBOrder.WidthRequest = (w - 60) / 2;
            LBOrder.BackgroundColor = Settings.MainColor;
            LBOrder.TextColor = Color.White;
            LBOrder.HeightRequest = Labelheight * 2;
            LBOrder.FontSize = FontSize;
            LBOrder.Text = "حفظ";
            LBOrder.HorizontalTextAlignment = TextAlignment.Center;
            LBOrder.VerticalTextAlignment = TextAlignment.Center;
            LBOrder.FontFamily = Settings.ArabicFontFamily;

            ButtonBar.Children.Add(LBOrder, new Point(20, 5));


            LBCancel = new Label();
            LBCancel.WidthRequest = (w - 60) / 2;
            LBCancel.BackgroundColor = Settings.BlueColor;
            LBCancel.TextColor = Color.White;
            LBCancel.HeightRequest = Labelheight * 2;
            LBCancel.FontSize = FontSize;
            LBCancel.Text = "إلغاء";
            LBCancel.HorizontalTextAlignment = TextAlignment.Center;
            LBCancel.VerticalTextAlignment = TextAlignment.Center;
            LBCancel.FontFamily = Settings.ArabicFontFamily;

            ButtonBar.Children.Add(LBCancel, new Point(20 + LBOrder.WidthRequest + 20, 5));




            LVList = new ListView();
            LVList.WidthRequest = w;
            LVList.RowHeight = 120;
            Settings.CartWidth = w;
            Settings.CartHeight = LVList.RowHeight;
            LVList.Margin = new Thickness(0, 0, 0, 5);
            LVList.ItemTemplate = new DataTemplate(typeof(CartView));

            Container.Children.Add(LVList, new Point(0, 10));
           

            AILoading = new ActivityIndicator();
            AILoading.Color = Settings.MainColor;
            AILoading.IsRunning = false; 
            AILoading.WidthRequest = Labelheight * 6;
            AILoading.HeightRequest = Labelheight * 6;
            Container.Children.Add(AILoading, new Point(w / 2 - AILoading.WidthRequest / 2, h / 2 - AILoading.HeightRequest / 2));

            orderLists = new List<OrderList>();
            order = new Order();
            //events

            ImgBack.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgBackClick())
            });
            LBCancel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBCancelClick())
            });
            LBOrder.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBOrderClickAsync())
            });
        }
        public Double GetPrice(string Price)
        {
            string s = "";
            for (int i = 0; i < Price.Length - 4; i++)
            {
                s += Price[i];
            }
            return Convert.ToDouble(s);
        }

        private async void LBOrderClickAsync()
        {
            double price = 0;
            if (orderLists != null)
                orderLists.Clear();
            cartViews = new List<CartView>();
            for (int i = 0; i < Settings.cartList.Count; i++)
            {
                int Amount = Convert.ToInt32(Settings.cartList[i].LBAmount.Text.ToString());
                orderLists.Add
                  (
                    new OrderList
                    {
                        Amount = Amount,
                        OrderId = order.OrderId,
                        Price = GetPrice(Settings.cartList[i].LBPrice.Text.ToString()),
                        ProuductId = Convert.ToInt32(Settings.cartList[i].LBID.Text)
                    }
                  );

                price += GetPrice(Settings.cartList[i].LBTotalPrice.Text.ToString());
            }

            order.OrderPrice = price.ToString();

            MakeOrder Order = new MakeOrder(w, h, home);
            Order.Price = price.ToString();
            Order.orderLists = orderLists;
            Order.order.OrderProuductList = orderLists.ToArray();
            Order.Cairo = Settings.CairoDelviryFees.ToString();
            Order.OutCairo = Settings.OutDeliveryFees.ToString();
            Order.SetData();
            Order.EAddress.Text = order.OrderLocation;
            for (int i=0;i< Order.OrderGovernorate.Items.Count;i++)
            {
                Order.OrderGovernorate.Items[i] = order.OrderGovernorate;
                Order.OrderGovernorate.SelectedIndex = i;
            }
            
            for (int i=2;i<order.UserAvilableTime.Length;i++)
            {
                if (order.UserAvilableTime[i] == 'ا')
                    break;
                Order.EFrom.Text += order.UserAvilableTime[i];
            }
            for (int i = 2; i < order.UserAvilableTime.Length; i++)
            {
                if (order.UserAvilableTime[i] == 'ي')
                {
                    for (int j = i+1; j < order.UserAvilableTime.Length; j++)
                    {
                        
                        Order.ETo.Text += order.UserAvilableTime[j];
                    }
                    break;
                }
                
               
            }
            Order.EPhone.Text = order.OrderPhone;
            Order.Type = "Edit";
            Order.order = order;

            Order.order.OrderProuductList = orderLists.ToArray();
            await home.Navigation.PushPopupAsync(Order);
        }

        private void LBCancelClick()
        {
            ImgBackClick();
        }

        public void ImgBackClick()
        {
            home.SendBackButtonPressed();
        }

        public void GetDataAsync()
        {

            if (Cartlist != null)
                Cartlist.Clear();

            if (Settings.cartList != null)
                Settings.cartList.Clear();
            if (prouductEntity == null)
                return;
            Cartlist = new List<CartObject>();

            for (int i = 0; i < prouductEntity.Length; i++)
            {
                ImageSource ImgProuduct = prouductEntity[i].FirstPhoto;
                double price = Convert.ToDouble(prouductEntity[i].Price);
                double discount = Convert.ToDouble(prouductEntity[i].Discount);
                string LBPrice = ((100 - discount) / 100 * price).ToString() + " ج م";
                int amount = 1;
                for (int j = 0; j < order.OrderProuductList.Length; j++)
                {
                    if (prouductEntity[i].ProductID == order.OrderProuductList[j].ProuductId)
                    {
                        amount = order.OrderProuductList[j].Amount;
                        break;
                    }
                }

                string LBAmount = amount.ToString();
                string LBTotalPrice = ((100 - discount) / 100 * price * amount).ToString() + " ج م";
                string LBName = prouductEntity[i].ProuductName;
                Cartlist.Add
                (
                new CartObject
                {
                    ImgProuduct = ImgProuduct,
                    LBAmount = LBAmount,
                    LBName = LBName,
                    LBPrice = LBPrice,
                    LBTotalPrice = LBTotalPrice,
                    LBID = prouductEntity[i].ProductID.ToString(),
                    index = i.ToString()
                });


            }

            LVList.ItemsSource = Cartlist;
            //Scroll.ScrollToAsync(0, 0, false);
            home.RefreshContent();
        }
     
    }
}
