using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentalShop
{
    public class MainPage
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
        Image ImgTitle;
        Image ImgControlPanel;
        Image ImgCar;
        Image ImgItemNumer;
        public Label LItemNumber;
        Image ImgPanner;
        Image ImgLeftSide;
        Image ImgRightSide;
        Image ImgMaterials;
        Image ImgStudent;
        Image ImgDevices;
        Image ImgMachiens;
        Image ImgCorrection;
        Image ImgEquipment;
        Image ImgClothes;
        Image ImgFiles;
        Label LBError;
        private ActivityIndicator AILoading;
        int Count = 0;
        System.Threading.Timer timer;
        //System.Threading.Timer timer2;
        public MainPage(int w, int h, HomePage home)
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
            MainLayout = new Grid();
            MainLayout.RowSpacing = 0;
            MainLayout.BackgroundColor = Color.White;
            MainLayout.RowDefinitions.Add(new RowDefinition { Height = LBTop.HeightRequest });
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
            MenuBar.BackgroundColor = Settings.DarkColor;
            MenuBar.WidthRequest = w;
            MenuBar.HeightRequest = Labelheight + 20;


            LBTop = new Label();
            LBTop.WidthRequest = w;
            LBTop.TextColor = Color.White;
            LBTop.HeightRequest = MenuBar.HeightRequest;
            LBTop.FontSize = FontSize + 8;
            LBTop.Text = "الصفحة الرئيسية";
            LBTop.BackgroundColor = Settings.MainColor;
            LBTop.FontFamily = Settings.ArabicFontFamily;
            LBTop.HorizontalTextAlignment = TextAlignment.Center;
            LBTop.VerticalTextAlignment = TextAlignment.Center;

            MenuBar.Children.Add(LBTop, new Point(0, 0));

            ImgTitle = new Image();
            ImgTitle.WidthRequest = LBTop.WidthRequest*.5;
            ImgTitle.HeightRequest = LBTop.HeightRequest-10;
            ImgTitle.Aspect = Aspect.Fill;
            ImgTitle.Source = ImageSource.FromResource("DentalShop.Images.MainTitle.png");
            ImgTitle.HorizontalOptions = LayoutOptions.Center;
           // MenuBar.Children.Add(ImgTitle, new Point(LBTop.WidthRequest*.25, 5));



            ImgControlPanel = new Image();
            ImgControlPanel.Aspect = Aspect.Fill;
            ImgControlPanel.Source = ImageSource.FromResource("DentalShop.Images.ControlPanel.png");
            ImgControlPanel.WidthRequest = ImgControlPanel.HeightRequest = LBTop.HeightRequest - 15;
            MenuBar.Children.Add(ImgControlPanel, new Point(w - 15 - ImgControlPanel.WidthRequest, 5));


            double ypoint = 10;

            ImgCar = new Image();
            ImgCar.WidthRequest = ImgCar.HeightRequest = LBTop.HeightRequest;


            ImgItemNumer = new Image();
            ImgItemNumer.WidthRequest = ImgItemNumer.HeightRequest = LBTop.HeightRequest - 15;

    



            ImgCar.Aspect = Aspect.Fill;
            ImgCar.Source = ImageSource.FromResource("DentalShop.Images.car.png");
            ImgCar.HorizontalOptions = LayoutOptions.Center;
            Point ImgCarLocation = new Point(width - ImgCar.WidthRequest, ypoint + 2);
            Container.Children.Add(ImgCar, ImgCarLocation);



            ImgItemNumer.Aspect = Aspect.Fill;
            ImgItemNumer.Source = ImageSource.FromResource("DentalShop.Images.Circle.png");
            ImgItemNumer.HorizontalOptions = LayoutOptions.Center;
            Point ImgItemNumerLocation = new Point(width - ImgCar.WidthRequest - (ImgItemNumer.WidthRequest / 1.5) + 2, ypoint - 3);
            Container.Children.Add(ImgItemNumer, ImgItemNumerLocation);



            LItemNumber = new Label();
            LItemNumber.WidthRequest = ImgItemNumer.WidthRequest / 2 ;
            LItemNumber.HeightRequest = ImgItemNumer.HeightRequest / 2 ;
            LItemNumber.TextColor = LabelColor;
            LItemNumber.FontSize = FontSize -5;
            LItemNumber.FontAttributes = FontAttributes.Bold;
            LItemNumber.Text = "0";
            Point LItemNumberLocation = new Point(width - ImgCar.WidthRequest - (ImgItemNumer.WidthRequest / 1.5)+1 + 10, ypoint+2);
            Container.Children.Add(LItemNumber, LItemNumberLocation);

            ypoint += 10 + ImgCar.HeightRequest;

            ImgPanner = new Image();
            ImgPanner.WidthRequest = width;
            ImgPanner.HeightRequest = width * 0.64;
            ImgPanner.Aspect = Aspect.Fill;
            if (Count > 0)
            ImgPanner.Source = Settings.cash.Panner[Count];
            ImgPanner.HorizontalOptions = LayoutOptions.Center;
            Point ImgPanerLocation = new Point(10, ypoint);
            Container.Children.Add(ImgPanner, ImgPanerLocation);


            ImgLeftSide = new Image();
            ImgLeftSide.WidthRequest = ImgControlPanel.WidthRequest;
            ImgLeftSide.HeightRequest = ImgControlPanel.HeightRequest;
            ImgLeftSide.Aspect = Aspect.Fill;
            ImgLeftSide.Source = ImageSource.FromResource("DentalShop.Images.slider-left-pointer.png");
            ImgLeftSide.HorizontalOptions = LayoutOptions.Center;
            Point ImgLeftSideLocation = new Point(20, ypoint + ImgPanner.HeightRequest / 2 - ImgLeftSide.WidthRequest / 2);
            Container.Children.Add(ImgLeftSide, ImgLeftSideLocation);


            ImgRightSide = new Image();
            ImgRightSide.WidthRequest = ImgControlPanel.WidthRequest;
            ImgRightSide.HeightRequest = ImgControlPanel.HeightRequest;
            ImgRightSide.Aspect = Aspect.Fill;
            ImgRightSide.Source = ImageSource.FromResource("DentalShop.Images.slider-right-pointer.png");
            ImgRightSide.HorizontalOptions = LayoutOptions.Center;
            Point ImgRightSideLocation = new Point(width - ImgRightSide.WidthRequest, ypoint + ImgPanner.HeightRequest / 2 - ImgRightSide.WidthRequest / 2);
            Container.Children.Add(ImgRightSide, ImgRightSideLocation);


            ypoint += 10 + ImgPanner.HeightRequest;




            ImgMaterials = new Image();
            ImgMaterials.WidthRequest = width / 2 - 5;
            ImgMaterials.HeightRequest = (width / 2 - 5) * 0.447;
            ImgMaterials.Aspect = Aspect.Fill;
            ImgMaterials.Source = ImageSource.FromResource("DentalShop.Images.materials.png");
            ImgMaterials.HorizontalOptions = LayoutOptions.Center;
            Point ImgMaterialsLocation = new Point(10, ypoint);
            Container.Children.Add(ImgMaterials, ImgMaterialsLocation);

            ImgStudent = new Image();
            ImgStudent.WidthRequest = width / 2 - 5;
            ImgStudent.HeightRequest = (width / 2 - 5) * 0.447;
            ImgStudent.Aspect = Aspect.Fill;
            ImgStudent.Source = ImageSource.FromResource("DentalShop.Images.student.png");
            ImgStudent.HorizontalOptions = LayoutOptions.Center;
            Point ImgStudentLocation = new Point(10 + ImgMaterials.WidthRequest + 5, ypoint);
            Container.Children.Add(ImgStudent, ImgStudentLocation);

            ypoint += 10 + ImgMaterials.HeightRequest;



            ImgDevices = new Image();
            ImgDevices.WidthRequest = width / 2 - 5;
            ImgDevices.HeightRequest = (width / 2 - 5) * 0.447;
            ImgDevices.Aspect = Aspect.Fill;
            ImgDevices.Source = ImageSource.FromResource("DentalShop.Images.Device.png");
            ImgDevices.HorizontalOptions = LayoutOptions.Center;
            Point ImgDevicesLocation = new Point(10, ypoint);
            Container.Children.Add(ImgDevices, ImgDevicesLocation);

            ImgMachiens = new Image();
            ImgMachiens.WidthRequest = width / 2 - 5;
            ImgMachiens.HeightRequest = (width / 2 - 5) * 0.447;
            ImgMachiens.Aspect = Aspect.Fill;
            ImgMachiens.Source = ImageSource.FromResource("DentalShop.Images.Machines.png");
            ImgMachiens.HorizontalOptions = LayoutOptions.Center;
            Point ImgMachiensLocation = new Point(10 + ImgMaterials.WidthRequest + 5, ypoint);
            Container.Children.Add(ImgMachiens, ImgMachiensLocation);

            ypoint += 10 + ImgMaterials.HeightRequest;

            ImgCorrection = new Image();
            ImgCorrection.WidthRequest = width / 2 - 5;
            ImgCorrection.HeightRequest = (width / 2 - 5) * 0.447;
            ImgCorrection.Aspect = Aspect.Fill;
            ImgCorrection.Source = ImageSource.FromResource("DentalShop.Images.correction.png");
            ImgCorrection.HorizontalOptions = LayoutOptions.Center;
            Point ImgCorrectionLocation = new Point(10, ypoint);
            Container.Children.Add(ImgCorrection, ImgCorrectionLocation);

            ImgEquipment = new Image();
            ImgEquipment.WidthRequest = width / 2 - 5;
            ImgEquipment.HeightRequest = (width / 2 - 5) * 0.447;
            ImgEquipment.Aspect = Aspect.Fill;
            ImgEquipment.Source = ImageSource.FromResource("DentalShop.Images.Equipment.png");
            ImgEquipment.HorizontalOptions = LayoutOptions.Center;
            Point ImgEquipmentLocation = new Point(10 + ImgMaterials.WidthRequest + 5, ypoint);
            Container.Children.Add(ImgEquipment, ImgEquipmentLocation);

            ypoint += 10 + ImgMaterials.HeightRequest;

            ////////////////////////////////////////ملابس طبيه///////////////////
            ImgClothes = new Image();
            ImgClothes.WidthRequest = width / 2 - 5;
            ImgClothes.HeightRequest = (width / 2 - 5) * 0.447;
            ImgClothes.Aspect = Aspect.Fill;
            ImgClothes.Source = ImageSource.FromResource("DentalShop.Images.Clothes.png");
            ImgClothes.HorizontalOptions = LayoutOptions.Center;
            Point ImgClothesLocation = new Point( 10+ImgMaterials.WidthRequest +5 , ypoint);
            Container.Children.Add(ImgClothes, ImgClothesLocation);
            ////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////فايلات وبير///////////////////
            ImgFiles = new Image();
            ImgFiles.WidthRequest = width / 2 - 5;
            ImgFiles.HeightRequest = (width / 2 - 5) * 0.447;
            ImgFiles.Aspect = Aspect.Fill;
            ImgFiles.Source = ImageSource.FromResource("DentalShop.Images.Files.png");
            ImgFiles.HorizontalOptions = LayoutOptions.Center;
            Point ImgFilesLocation = new Point(10, ypoint);
            Container.Children.Add(ImgFiles, ImgFilesLocation);
            ////////////////////////////////////////////////////////////////////

            LBError = new Label();
            LBError.WidthRequest = w-20;
            LBError.HeightRequest = 25;
            LBError.FontSize = 7;
            LBError.TextColor = Settings.MainColor;
            LBError.Text = " ";
            LBError.HorizontalTextAlignment = TextAlignment.Center;
            LBError.VerticalTextAlignment = TextAlignment.Start;
            ypoint += ImgMaterials.HeightRequest;
            Container.Children.Add(LBError, new Point(10, ypoint+5));

            AILoading = new ActivityIndicator();
            AILoading.Color = Settings.MainColor;
            AILoading.IsRunning = false;
            AILoading.WidthRequest = Labelheight * 6;
            AILoading.HeightRequest = Labelheight * 6;
            Container.Children.Add(AILoading, new Point(w / 2 - AILoading.WidthRequest / 2, h / 2 - AILoading.HeightRequest / 2));




            ImgControlPanel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgControlPanelClickAsync())
            });
            ImgDevices.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgDevicesClickAsync())
            });
            ImgEquipment.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgEquipmentClickAsync())
            });
            ImgStudent.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgStudentClick())
            });
            ImgMachiens.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgMachiensClickAsync())
            });
            ImgCorrection.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgCorrectionClickAsync())
            });
            ImgMaterials.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgMaterialsClickAsync())
            });
            ImgClothes.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgClothesClickAsync())
            });
            ImgFiles.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgFilesClickAsync())
            });
            ImgLeftSide.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgLeftSideClick())
            });
            ImgRightSide.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgRightSideClick())
            });
            ImgCar.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgCarClick())
            });

            timer = new Timer(TimerTick, new object(), 5000, 5000);

            //timer2 = new Timer(TimerTick2, new object(), 500000, 500000);
           
        }
        private void TimerTick(object state)
        {
            Device.BeginInvokeOnMainThread
            (
                () =>
                {
                    Settings.mainPage.ImgRightSideClick();
                }
            );
        }
        private void TimerTick2(object state)
        {
            Device.BeginInvokeOnMainThread
            (
                async () =>
                {
                    await Settings.GetPannerAsync();
                    await Settings.GetDeliveryFees();
                }
            );
        }
        private  void ImgCarClick()
        {
            AILoading.IsRunning = true;
            
            Settings.cart.GetDataAsync();
            home.Content = Settings.cart.MainLayout;
            AILoading.IsRunning = false;
        }

        private void ImgLeftSideClick()
        {
            try
            {
                if (Count == 0)
                {
                    Count = Settings.cash.Panner.Count - 1;
                    ImgPanner.Source = Settings.cash.Panner[Count];
                }
                else
                    ImgPanner.Source = Settings.cash.Panner[--Count];
            }
            catch (Exception ex) 
            {

            }
        }
        public void ImgRightSideClick()
        {
            try
            {
                if (Count == Settings.cash.Panner.Count - 1)
                {
                    Count = 0;
                    ImgPanner.Source = Settings.cash.Panner[Count];
                }
                else
                    ImgPanner.Source = Settings.cash.Panner[++Count];
            }
            catch (Exception ex) 
            {

            }
        }
        private async System.Threading.Tasks.Task ImgMaterialsClickAsync()
        {
            AILoading.IsRunning = true;
            Settings.prouductPage.Type = "Materials";
            await Settings.prouductPage.SetDataAsync();
            AILoading.IsRunning = false;
            home.Content = Settings.prouductPage.MainLayout;
            
        }

        private async System.Threading.Tasks.Task ImgClothesClickAsync()
        {
            AILoading.IsRunning = true;
           // Settings.prouductPage.Type = "Clothes";
            Settings.prouductPage.Type = "Clothes";
            await Settings.prouductPage.SetDataAsync();
            AILoading.IsRunning = false;
            home.Content = Settings.prouductPage.MainLayout;

        }

        private async System.Threading.Tasks.Task ImgFilesClickAsync()
        {
            AILoading.IsRunning = true;
            Settings.prouductPage.Type = "Files";
            await Settings.prouductPage.SetDataAsync();
            AILoading.IsRunning = false;
            home.Content = Settings.prouductPage.MainLayout;

        }

        private async System.Threading.Tasks.Task ImgCorrectionClickAsync()
        {
            AILoading.IsRunning = true;
            Settings.prouductPage.Type = "Correction";
            await Settings.prouductPage.SetDataAsync();
            AILoading.IsRunning = false;
            home.Content = Settings.prouductPage.MainLayout;
             
        }

        private async System.Threading.Tasks.Task ImgMachiensClickAsync()
        {
            AILoading.IsRunning = true;
            Settings.prouductPage.Type = "Machines";
            await Settings.prouductPage.SetDataAsync();
            AILoading.IsRunning = false;
            home.Content = Settings.prouductPage.MainLayout;
             
        }

        public async void ImgStudentClick()
        {
            StudentYear studentYear = new StudentYear(w, h, home);
           
            await home.Navigation.PushPopupAsync(studentYear);
             
        }
        public async void ImgControlPanelClickAsync()
        {
            if (Settings.cash.LoggedIn)
            {
                UserSidePage userSidePage = new UserSidePage(w, h, home);
                userSidePage.SetData();
                await home.Navigation.PushPopupAsync(userSidePage);
            }
            else
            {
                GuestSidePage guestSidePage = new GuestSidePage(w, h, home);

                await home.Navigation.PushPopupAsync(guestSidePage);
            }
             
        }
        public async System.Threading.Tasks.Task ImgDevicesClickAsync()
        {
            AILoading.IsRunning = true;          
            Settings.prouductPage.Type="Devices";
            await Settings.prouductPage.SetDataAsync();
            AILoading.IsRunning = false;
            home.Content = Settings.prouductPage.MainLayout;
             
        }

        public async System.Threading.Tasks.Task ImgEquipmentClickAsync()
        {
            AILoading.IsRunning = true;
            Settings.prouductPage.Type = "Equipment";
            await Settings.prouductPage.SetDataAsync();
            AILoading.IsRunning = false;
            home.Content = Settings.prouductPage.MainLayout;
             
        }
    }

}
