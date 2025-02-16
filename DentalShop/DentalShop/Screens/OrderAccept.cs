using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DentalShop
{
  public  class OrderAccept : PopupPage
    {
        int w;
        int h;
        AbsoluteLayout Container;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.White;
        Image ImgBackground;
        Image ImgEdit;
        Label LBData;
        Image ImgExit;
        Label LBEdit;
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
        public OrderAccept(int w, int h, HomePage home)
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
            ImgBackground.HeightRequest = h * 0.5;
            ImgBackground.Aspect = Aspect.Fill;
            ImgBackground.Source = ImageSource.FromResource("DentalShop.Images.BlueBackground.png");
            ImgBackground.HorizontalOptions = LayoutOptions.Center;
            Point ImgBackgroundLocation = new Point(10, h*.25);
            Container.Children.Add(ImgBackground, ImgBackgroundLocation);


            ImgExit = new Image();
            //ImgExit.WidthRequest = h * .1 - 25;
            //ImgExit.HeightRequest = h * .1 - 25;
            ImgExit.WidthRequest = 50;
            ImgExit.HeightRequest = 50;
            ImgExit.InputTransparent = false;
            ImgExit.Aspect = Aspect.Fill;
            //ImgExit.BackgroundColor = Color.Black;
            //ImgExit.Source = ImageSource.FromResource("DentalShop.Images.ExitIcon.png");
            ImgExit.Source = ImageSource.FromResource("DentalShop.Images.close.png");
            ImgExit.HorizontalOptions = LayoutOptions.Center;
            Point ImgExitLocation = new Point(w - 10 - ImgExit.WidthRequest - 10, ypoint+15);
            Container.Children.Add(ImgExit, ImgExitLocation);

            //ypoint += 30;
            ypoint += 70;

            //data
            LBData = new Label();
            LBData.WidthRequest = w - 20;
            LBData.TextColor = Color.White;
            //LBData.HeightRequest = h * .25;
            LBData.HeightRequest = h * .25;
            LBData.FontSize = FontSize;
            LBData.Text = "تم ارسال طلبكم بنجاح " +
                "يمكنكم تعديل طلبكم حتي يتم " +
                "الموافقة علية من قبل الادارة";
            LBData.FontAttributes = FontAttributes.Bold;
            LBData.FontFamily = Settings.ArabicFontFamily;
            LBData.HorizontalTextAlignment = TextAlignment.Center;
            LBData.VerticalTextAlignment = TextAlignment.Center;
            Container.Children.Add(LBData, new Point(10, ypoint));
            ypoint += 5+LBData.HeightRequest;

            ImgEdit = new Image();
            ImgEdit.WidthRequest = ImgExit.WidthRequest*1.5;
            ImgEdit.HeightRequest = ImgExit.WidthRequest * 1.5;
            ImgEdit.Aspect = Aspect.Fill;
            ImgEdit.Source = ImageSource.FromResource("DentalShop.Images.edit-icon.png");
            ImgEdit.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgEdit, new Point((w-20-ImgEdit.WidthRequest/2) / 2, ypoint));

            ypoint +=5+ ImgEdit.HeightRequest;


            LBData = new Label();
            LBData.WidthRequest = ImgEdit.WidthRequest+10;
            LBData.TextColor = Color.White;
            LBData.HeightRequest = Labelheight * 2;
            LBData.FontSize = FontSize;
            LBData.Text = "تعديل";
            LBData.FontAttributes = FontAttributes.Bold;
            LBData.FontFamily = Settings.ArabicFontFamily;
            LBData.HorizontalTextAlignment = TextAlignment.Center;
            LBData.VerticalTextAlignment = TextAlignment.Center;
            Container.Children.Add(LBData, new Point((w - 20 - ImgEdit.WidthRequest / 2) / 2, ypoint));

            order = new Order();
            //events
            ImgExit.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgExitClick())
            });
            ImgEdit.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgEditClickAsync())
            });


        }

        private async void ImgEditClickAsync()
        {
            Settings.PageStack.Pop();
           
            Settings.editOrder.order = order;
            Settings.EditProudctList.Clear();
            for (int i=0;i<prouductEntity.Length;i++)
            {
                Settings.EditProudctList.Add(prouductEntity[i]);
            }
            Settings.editOrder.ProudctEntity = Settings.EditProudctList.ToArray();
            Settings.editOrder.GetDataAsync();
            home.Content = Settings.editOrder.MainLayout;
            await home.Navigation.PopPopupAsync(true);
        }

        protected override bool OnBackButtonPressed()
        {
            Settings.PageStack.Pop();
            Settings.PageStack.Pop();
            home.Content = Settings.mainPage.MainLayout;
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

        public async void ImgExitClick()
        {
            await home.Navigation.PopPopupAsync(true);
            Settings.PageStack.Pop();
            Settings.PageStack.Pop();
            home.Content = Settings.mainPage.MainLayout;
        }
    }

}
