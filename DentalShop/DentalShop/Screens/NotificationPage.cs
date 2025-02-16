using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentalShop
{
    public class NotificationPage
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
        ListView LVList;
        List<NotificationViewObject> NotificatioList;
        Notifications[] notificationEntity;
        public Notifications[] NotificationEntity
        {
            get { return notificationEntity; }
            set
            {

                notificationEntity = value;
                //GetDataAsync();
            }
        }
        public NotificationPage(int w, int h, HomePage home)
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
            MainLayout.RowDefinitions.Add(new RowDefinition { Height = LBTop.HeightRequest + 10  });
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
            MenuBar.HeightRequest = Labelheight  + 20;


            LBTop = new Label();
            LBTop.WidthRequest = w;
            LBTop.TextColor = Color.White;
            LBTop.HeightRequest = Labelheight + 20;
            LBTop.FontSize = FontSize + 8;
            LBTop.Text = "اشعاراتي";
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

            



            LVList = new ListView();
            LVList.WidthRequest = w;
            LVList.RowHeight = 150;
            Settings.OrderWidth = w;
            Settings.OrderHeight = LVList.RowHeight;
            LVList.Margin = new Thickness(0, 0, 0, 5);
            LVList.ItemTemplate = new DataTemplate(typeof(NotificationView));

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
            if (NotificatioList != null)
                NotificatioList.Clear();

            notificationEntity = await Settings.GetNotifictionAsync();
            NotificatioList = new List<NotificationViewObject>();
            for (int i = 0; i < notificationEntity.Length; i++)
            {
                NotificationViewObject notify = JsonConvert.DeserializeObject<NotificationViewObject>(notificationEntity[i].LBNotificationText);
                notify.LBNotificationText += "  " + notificationEntity[i].Time;
                NotificatioList.Add
                (
                   notify
                );


            }


            LVList.ItemsSource = NotificatioList;
            //Scroll.ScrollToAsync(0, 0, false);
            //home.RefreshContent();
            
        }
    }
}
