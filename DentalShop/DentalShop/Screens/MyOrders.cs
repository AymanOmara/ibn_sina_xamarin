using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentalShop
{
    public class MyOrders
    {
        int w;
        int h;
        public ScrollView Scroll = new ScrollView();
        AbsoluteLayout Container;
        public Grid MainLayout;
        AbsoluteLayout MenuBar;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.White;
        Label LBTop;
        Image ImgBack;
        Label LBOrderID;
        Label LBPrice;
        Label LBAmount;
        Label LBTotalPrice;
        Label LBDelivery;
        Order [] orderEntity;
        public Order[] OrderEntity
        {
            get { return orderEntity; }
            set
            {

                orderEntity = value;
                //GetDataAsync();
            }
        }
        ListView LVList;
        List<OrderViewObject> OrdersList;
        public MyOrders(int w, int h, HomePage home)
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
            MainLayout.RowDefinitions.Add(new RowDefinition { Height = LBTop.HeightRequest + 10 + 10 + LBOrderID.HeightRequest });
            MainLayout.RowDefinitions.Add(new RowDefinition());
            MainLayout.Margin = new Thickness(0, 0, 0, 0);
            MainLayout.Children.Add(Scroll, 0, 1);
            MainLayout.Children.Add(MenuBar, 0, 0);

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
            LBTop.Text = "طلباتي";
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



            ypoint += Labelheight + 5;

            LBDelivery = new Label();
            LBDelivery.WidthRequest = w / 5;
            LBDelivery.TextColor = Settings.MainColor;
            LBDelivery.HeightRequest = Labelheight * 2;
            LBDelivery.FontSize = FontSize;
            LBDelivery.Text = "قيمة الشحن";
            LBDelivery.HorizontalTextAlignment = TextAlignment.Center;
            LBDelivery.VerticalTextAlignment = TextAlignment.Center;
            LBDelivery.FontFamily = Settings.ArabicFontFamily;
           // MenuBar.Children.Add(LBDelivery, new Point(0, ypoint));
            MenuBar.Children.Add(LBDelivery, new Point(w / 5 * 3, ypoint));



            LBAmount = new Label();
            LBAmount.WidthRequest = w / 5;
            LBAmount.TextColor = Settings.MainColor;
            LBAmount.HeightRequest = Labelheight * 2;
            LBAmount.FontSize = FontSize;
            LBAmount.Text = "الكمية";
            LBAmount.HorizontalTextAlignment = TextAlignment.Center;
            LBAmount.VerticalTextAlignment = TextAlignment.Center;
            LBAmount.FontFamily = Settings.ArabicFontFamily;
            MenuBar.Children.Add(LBAmount, new Point(w /5, ypoint));


            LBPrice = new Label();
            LBPrice.WidthRequest = w / 5;
            LBPrice.TextColor = Settings.MainColor;
            LBPrice.HeightRequest = Labelheight * 2;
            LBPrice.FontSize = FontSize;
            LBPrice.Text = "السعر";
            LBPrice.HorizontalTextAlignment = TextAlignment.Center;
            LBPrice.VerticalTextAlignment = TextAlignment.Center;
            LBPrice.FontFamily = Settings.ArabicFontFamily;
           // MenuBar.Children.Add(LBPrice, new Point(w / 2, ypoint));
            MenuBar.Children.Add(LBPrice, new Point(w / 3, ypoint));


            LBOrderID = new Label();
            LBOrderID.WidthRequest = w / 5;
            LBOrderID.TextColor = Settings.MainColor;
            LBOrderID.HeightRequest = Labelheight * 2;
            LBOrderID.FontSize = FontSize;
            LBOrderID.Text = "كود الطلب";
            LBOrderID.HorizontalTextAlignment = TextAlignment.Center;
            LBOrderID.VerticalTextAlignment = TextAlignment.Center;
            LBOrderID.FontFamily = Settings.ArabicFontFamily;
           // MenuBar.Children.Add(LBOrderID, new Point(w / 5 * 3, ypoint));
            MenuBar.Children.Add(LBOrderID, new Point((w / 5 * 3) + 70, ypoint));

            ///////////////////////////////////////////////////////////////////
            // Add a new label for the total price
            LBTotalPrice = new Label();
            LBTotalPrice.WidthRequest = w / 5;
            LBTotalPrice.TextColor = Settings.MainColor;
            LBTotalPrice.HeightRequest = Labelheight * 2;
            LBTotalPrice.FontSize = FontSize;
            LBTotalPrice.Text = "السعر الكلي";
            LBTotalPrice.HorizontalTextAlignment = TextAlignment.Center;
            LBTotalPrice.VerticalTextAlignment = TextAlignment.Center;
            LBTotalPrice.FontFamily = Settings.ArabicFontFamily;
           // MenuBar.Children.Add(LBTotalPrice, new Point((w/5*3)+70 , ypoint)); // Adjust the position as needed
            //MenuBar.Children.Add(LBTotalPrice, new Point(w / 5 * 3, ypoint)); // Adjust the position as needed
            MenuBar.Children.Add(LBTotalPrice, new Point(0, ypoint)); // Adjust the position as needed
            /////////////////////////////////////////////////////////////////


            LVList = new ListView();
            LVList.WidthRequest = w;
            LVList.RowHeight = 100;
            Settings.OrderWidth = w;
            Settings.OrderHeight = LVList.RowHeight;
            LVList.Margin = new Thickness(0, 0, 0, 5);
            LVList.ItemTemplate = new DataTemplate(typeof(OrdersView));

            Container.Children.Add(LVList, new Point(0, 10));
            //events

            ImgBack.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgBackClick())
            });
         
        }
        public void ImgBackClick()
        {
            home.SendBackButtonPressed();
        }

        public async Task GetData()
        {
            if (OrdersList != null)
                OrdersList.Clear();

            orderEntity = await Settings.GetOrdersAsync();
            OrdersList = new List<OrderViewObject>();
            for (int i = 0; i < orderEntity.Length; i++)
            {
                bool ImgEdit = false;
                if (orderEntity[i].OrderStatus == "Pendding")
                    ImgEdit = true;

                OrdersList.Add
                (
                new OrderViewObject
                {
                    ImgEdit= ImgEdit,
                    index=i.ToString(),
                    LBAmount=orderEntity[i].OrderAmount,
                    LBDelivery = orderEntity[i].DeliveryFees + @"
ج م",
                    LBOrderID =orderEntity[i].OrderId.ToString(),
                    LBPrice=orderEntity[i].OrderPrice+@"
ج م",
                    LBDate=orderEntity[i].OrderTime,
                    LBTotalPrice = ((Convert.ToDecimal(orderEntity[i].OrderPrice)*(Convert.ToDecimal(orderEntity[i].OrderAmount)))+ Convert.ToDecimal(orderEntity[i].DeliveryFees)).ToString() + @"
ج م" // Add the total price
                });


            }

            
            LVList.ItemsSource = OrdersList;
            //Scroll.ScrollToAsync(0, 0, false);
            home.RefreshContent();
        }
    }
}
