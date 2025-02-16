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

    public class StudentYear : PopupPage
    {

        int w;
        int h;
        AbsoluteLayout Container;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.White;
        Image ImgBackground;
        Image ImgTitle;
        Label LBTitle;
        Image ImgExit;
        Image ImgButton;
        Label LBButton;
        Label LBFirstYear;
        Label LBSecondYear;
        Label LBThirdYear;
        Label LBFourthYear;
        Label LBFifthYear;
        Label LBTeeth;
        Label LBClothes;
        Label LBOthers;
        Image ImgRight;
        Switch SWFirstYear;
        Switch SWSecondYear;
        Switch SWThirdYear;
        Switch SWFourthYear;
        Switch SWFifthYear;
        Switch SWTeeth;
        Switch SWClothes;
        Switch SWOthers;
        GetStudentProuduct getprouduct = new GetStudentProuduct();
        private ActivityIndicator AILoading;
        public StudentYear(int w, int h, HomePage home)
        {
            this.w = w;
            this.h = h+20;
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
            double FontSize = Settings.FontSize+5;
             
            int ButtonHeight = 45;
            int width = w;
            int Labelheight = 23;
            double ypoint = h/4;

            ImgBackground = new Image();
            ImgBackground.WidthRequest = w - 20;
            ImgBackground.HeightRequest = h * 0.60;
            ImgBackground.Aspect = Aspect.Fill;
            ImgBackground.Source = ImageSource.FromResource("DentalShop.Images.BlueBackground.png");
            ImgBackground.HorizontalOptions = LayoutOptions.Center;
            Point ImgBackgroundLocation = new Point(10 , ypoint);
            Container.Children.Add(ImgBackground, ImgBackgroundLocation);



            ImgTitle = new Image();
            ImgTitle.WidthRequest = w - 20;
            ImgTitle.HeightRequest = ImgBackground.HeightRequest*.175;
            ImgTitle.Aspect = Aspect.Fill;
            ImgTitle.Source = ImageSource.FromResource("DentalShop.Images.button.png");
            ImgTitle.HorizontalOptions = LayoutOptions.Center;
            Point ImgTitleLocation = new Point(10, ypoint);
            Container.Children.Add(ImgTitle, ImgTitleLocation);


            //title
            LBTitle = new Label();
            LBTitle.WidthRequest = w - 20;
            LBTitle.TextColor = Color.White;
            LBTitle.HeightRequest = ImgTitle .HeightRequest;
            LBTitle.FontSize = FontSize;
            LBTitle.Text = "السنة الدراسية";
            LBTitle.FontAttributes = FontAttributes.Bold;
            LBTitle.HorizontalTextAlignment = TextAlignment.Center;
            LBTitle.VerticalTextAlignment = TextAlignment.Center;
            LBTitle.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBTitle, new Point(10, ypoint ));



            ImgExit = new Image();
            ImgExit.WidthRequest = ImgTitle.HeightRequest-25;
            ImgExit.HeightRequest = ImgTitle.HeightRequest - 25;
            ImgExit.Aspect = Aspect.Fill;
            ImgExit.Source = ImageSource.FromResource("DentalShop.Images.ExitIcon.png");
            ImgExit.HorizontalOptions = LayoutOptions.Center;
            Point ImgExitLocation = new Point(w-10-ImgExit.WidthRequest-10, ypoint+15);
            Container.Children.Add(ImgExit, ImgExitLocation);


            ypoint += ImgTitle.HeightRequest;

            //first
            LBFirstYear = new Label();
            LBFirstYear.WidthRequest = w-20-Labelheight;
            LBFirstYear.TextColor = Color.White;
            LBFirstYear.HeightRequest = ImgBackground.HeightRequest*.1083;
            LBFirstYear.FontSize = FontSize;
            LBFirstYear.Text = "سنة اولي";
            LBFirstYear.FontAttributes = FontAttributes.Bold;
            LBFirstYear.HorizontalTextAlignment = TextAlignment.Start;
            LBFirstYear.VerticalTextAlignment = TextAlignment.Center;
            LBFirstYear.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBFirstYear, new Point(w - 10 - LBFirstYear.WidthRequest - 15, ypoint ));



            //togle

            SWFirstYear = new Switch();
            SWFirstYear.WidthRequest = 50;
            SWFirstYear.HeightRequest = LBFirstYear.HeightRequest ;
            SWFirstYear.Toggled += SWFirstYear_Toggled;
            Container.Children.Add(SWFirstYear, new Point(25, ypoint));

            ypoint += LBFirstYear.HeightRequest;

            //second
            LBSecondYear = new Label();
            LBSecondYear.WidthRequest = w - 20 - Labelheight; ;
            LBSecondYear.TextColor = Color.White;
            LBSecondYear.HeightRequest = ImgBackground.HeightRequest * .1083;
            LBSecondYear.FontSize = FontSize;
            LBSecondYear.Text = "سنة تانية";
            LBSecondYear.FontAttributes = FontAttributes.Bold;
            LBSecondYear.HorizontalTextAlignment = TextAlignment.Start;
            LBSecondYear.VerticalTextAlignment = TextAlignment.Center;
            LBSecondYear.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBSecondYear, new Point(w - 10 - LBSecondYear.WidthRequest - 15, ypoint));


            //toggle

            SWSecondYear = new Switch();
            SWSecondYear.WidthRequest = 50;
            SWSecondYear.HeightRequest = LBFirstYear.HeightRequest;
            SWSecondYear.Toggled += SWSecondYear_Toggled;
            Container.Children.Add(SWSecondYear, new Point(25, ypoint));


            ypoint += LBFirstYear.HeightRequest;

            //third
            LBThirdYear = new Label();
            LBThirdYear.WidthRequest = w - 20 - Labelheight;
            LBThirdYear.TextColor = Color.White;
            LBThirdYear.HeightRequest = ImgBackground.HeightRequest * .1083;
            LBThirdYear.FontSize = FontSize;
            LBThirdYear.Text = "سنة تالتة";
            LBThirdYear.FontAttributes = FontAttributes.Bold;
            LBThirdYear.HorizontalTextAlignment = TextAlignment.Start;
            LBThirdYear.VerticalTextAlignment = TextAlignment.Center;
            LBThirdYear.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBThirdYear, new Point(w - 10 - LBThirdYear.WidthRequest - 15, ypoint));



            //toggle

            SWThirdYear = new Switch();
            SWThirdYear.WidthRequest = 50;
            SWThirdYear.HeightRequest = Labelheight;
            SWThirdYear.Toggled += SWThirdYearr_Toggled;
            Container.Children.Add(SWThirdYear, new Point(25, ypoint));


            ypoint += LBFirstYear.HeightRequest;

            //forth
            LBFourthYear = new Label();
            LBFourthYear.WidthRequest = w - 20 - Labelheight;
            LBFourthYear.TextColor = Color.White;
            LBFourthYear.HeightRequest = ImgBackground.HeightRequest * .1083;
            LBFourthYear.FontSize = FontSize;
            LBFourthYear.Text = "سنة رابعه";
            LBFourthYear.FontAttributes = FontAttributes.Bold;
            LBFourthYear.HorizontalTextAlignment = TextAlignment.Start;
            LBFourthYear.VerticalTextAlignment = TextAlignment.Center;
            LBFourthYear.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBFourthYear, new Point(w - 10 - LBFourthYear.WidthRequest - 15, ypoint));


            //toggle

            SWFourthYear = new Switch();
            SWFourthYear.WidthRequest = 50;
            SWFourthYear.HeightRequest = Labelheight;
            SWFourthYear.Toggled += SWFourthYear_Toggled;
            Container.Children.Add(SWFourthYear, new Point(25, ypoint));

            ypoint += LBFirstYear.HeightRequest;

            //fifth
            LBFifthYear = new Label();
            LBFifthYear.WidthRequest = w - 20 - Labelheight;
            LBFifthYear.TextColor = Color.White;
            LBFifthYear.HeightRequest = ImgBackground.HeightRequest * .1083;
            LBFifthYear.FontSize = FontSize;
            LBFifthYear.Text = "سنة خامسة";
            LBFifthYear.FontAttributes = FontAttributes.Bold;
            LBFifthYear.HorizontalTextAlignment = TextAlignment.Start;
            LBFifthYear.VerticalTextAlignment = TextAlignment.Center;
            LBFifthYear.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBFifthYear, new Point(w - 10 - LBFifthYear.WidthRequest - 15, ypoint));


            //toggle

            SWFifthYear = new Switch();
            SWFifthYear.WidthRequest = 50;
            SWFifthYear.HeightRequest = Labelheight;
            SWFifthYear.Toggled += SWFifthYear_Toggled;
            Container.Children.Add(SWFifthYear, new Point(25, ypoint));

            ypoint += LBFirstYear.HeightRequest;

            //Teeth
            LBTeeth = new Label();
            LBTeeth.WidthRequest = w - 20 - Labelheight;
            LBTeeth.TextColor = Color.White;
            LBTeeth.HeightRequest = ImgBackground.HeightRequest * .1083;
            LBTeeth.FontSize = FontSize;
            LBTeeth.Text = "أسنان أكريل وإندو";
            LBTeeth.FontAttributes = FontAttributes.Bold;
            LBTeeth.HorizontalTextAlignment = TextAlignment.Start;
            LBTeeth.VerticalTextAlignment = TextAlignment.Center;
            LBTeeth.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBTeeth, new Point(w - 10 - LBTeeth.WidthRequest - 15, ypoint));


            //toggle

            SWTeeth = new Switch();
            SWTeeth.WidthRequest = 50;
            SWTeeth.HeightRequest = Labelheight;
            SWTeeth.Toggled += SWTeeth_Toggled;
            Container.Children.Add(SWTeeth, new Point(25, ypoint));

            ypoint += LBFirstYear.HeightRequest;

            //Clothes
            LBClothes = new Label();
            LBClothes.WidthRequest = w - 20 - Labelheight;
            LBClothes.TextColor = Color.White;
            LBClothes.HeightRequest = ImgBackground.HeightRequest * .1083;
            LBClothes.FontSize = FontSize;
            LBClothes.Text = "ملابس طبيه";
            LBClothes.FontAttributes = FontAttributes.Bold;
            LBClothes.HorizontalTextAlignment = TextAlignment.Start;
            LBClothes.VerticalTextAlignment = TextAlignment.Center;
            LBClothes.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBClothes, new Point(w - 10 - LBClothes.WidthRequest - 15, ypoint-10));


            //toggle

            SWClothes = new Switch();
            SWClothes.WidthRequest = 50;
            SWClothes.HeightRequest = Labelheight;
            SWClothes.Toggled += SWClothes_Toggled;
            Container.Children.Add(SWClothes, new Point(25, ypoint));

            ypoint += LBFirstYear.HeightRequest-20;


            //fifth
            LBOthers = new Label();
            LBOthers.WidthRequest = w - 20 - Labelheight;
            LBOthers.TextColor = Color.White;
            LBOthers.HeightRequest = ImgBackground.HeightRequest * .1083;
            LBOthers.FontSize = FontSize;
            LBOthers.Text = "ادوات اخري";
            LBOthers.FontAttributes = FontAttributes.Bold;
            LBOthers.HorizontalTextAlignment = TextAlignment.Start;
            LBOthers.VerticalTextAlignment = TextAlignment.Center;
            LBOthers.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBOthers, new Point(w - 10 - LBOthers.WidthRequest - 15, ypoint));


            //toggle

            SWOthers = new Switch();
            SWOthers.WidthRequest = 50;
            SWOthers.HeightRequest = Labelheight;
            SWOthers.Toggled += SWOthers_Toggled;
            Container.Children.Add(SWOthers, new Point(25, ypoint));

            ypoint += LBFirstYear.HeightRequest;

            //ypoint = h * 0.85 - Labelheight * 2.5;



            ImgButton = new Image();
           // ImgButton.WidthRequest = w - 20;
            ImgButton.WidthRequest = w - 200;
           // ImgButton.HeightRequest = ImgBackground.HeightRequest * .175;
            ImgButton.HeightRequest = (ImgBackground.HeightRequest * .175)-30;
            ImgButton.Aspect = Aspect.Fill;
            ImgButton.Source = ImageSource.FromResource("DentalShop.Images.button.png");
            ImgButton.HorizontalOptions = LayoutOptions.Center;
            //Point ImgButtonLocation = new Point(10, ypoint);
            Point ImgButtonLocation = new Point(90, ypoint+10);
            Container.Children.Add(ImgButton, ImgButtonLocation);


            //button
            LBButton = new Label();
            LBButton.WidthRequest = w - 20;
            LBButton.TextColor = Color.White;
            LBButton.HeightRequest = ImgButton .HeightRequest;
            LBButton.FontSize = FontSize;
            LBButton.Text = "دخول";
            LBButton.FontAttributes = FontAttributes.Bold;
            LBButton.HorizontalTextAlignment = TextAlignment.Center;
            LBButton.VerticalTextAlignment = TextAlignment.Center;
            LBButton.FontFamily = Settings.ArabicFontFamily;

           // Container.Children.Add(LBButton, new Point(10, ypoint));
            Container.Children.Add(LBButton, new Point(2, ypoint+5));

            //ImgRight = new Image();
            //ImgRight.WidthRequest = ImgButton.HeightRequest-20;
            //ImgRight.HeightRequest = ImgButton.HeightRequest - 20;
            //ImgRight.Aspect = Aspect.Fill;
            //ImgRight.Source = ImageSource.FromResource("DentalShop.Images.RightIcon.png");
            //ImgRight.HorizontalOptions = LayoutOptions.Center;
            //Point ImgRightLocation = new Point(30, ypoint + 7.5);
            //Container.Children.Add(ImgRight, ImgRightLocation);


            AILoading = new ActivityIndicator();
            AILoading.Color = Settings.MainColor;
            AILoading.IsRunning = false; 
            AILoading.WidthRequest = Labelheight * 6;
            AILoading.HeightRequest = Labelheight * 6;
            Container.Children.Add(AILoading, new Point(w / 2 - AILoading.WidthRequest / 2, h / 2 - AILoading.HeightRequest / 2));

            getprouduct.FirstYear = getprouduct.SecondYear = getprouduct.ThirdYear = getprouduct.FourthYear = getprouduct.FifthYear =getprouduct.Others= getprouduct.Clothes = getprouduct.Teeth=  "";
            //events
            ImgExit.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgExitClick())
            });

            LBButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBButtonClickAsync())
            });

        }

        private void SWOthers_Toggled(object sender, ToggledEventArgs e)
        {
            if (SWOthers.IsToggled == true)
            {
                getprouduct.Others = "T";
            }
            else
            {
                getprouduct.Others = "";
            }
        }

        private async void LBButtonClickAsync()
        {

            AILoading.IsRunning = true;
            getprouduct.Type = "Student";
            Settings.prouductPage.Type = "Student";
            Settings.studentProuduct.getProuduct = getprouduct;
            await Settings.studentProuduct.SetDataAsync();
            AILoading.IsRunning = false;
            
            home.Content = Settings.studentProuduct.MainLayout;
            ImgExitClick();
        }

        private void SWClothes_Toggled(object sender, ToggledEventArgs e)
        {
            if (SWClothes.IsToggled == true)
            {
                getprouduct.Clothes = "T";
            }
            else
            {
                getprouduct.Clothes = "";
            }
        }
        private void SWTeeth_Toggled(object sender, ToggledEventArgs e)
        {
            if (SWTeeth.IsToggled == true)
            {
                getprouduct.Teeth = "T";
            }
            else
            {
                getprouduct.Teeth = "";
            }
        }
        private void SWFifthYear_Toggled(object sender, ToggledEventArgs e)
        {
            if (SWFifthYear.IsToggled == true)
            {
                getprouduct.FifthYear = "T";
            }
            else
            {
                getprouduct.FifthYear = "";
            }
        }

        private void SWFourthYear_Toggled(object sender, ToggledEventArgs e)
        {
            if (SWFourthYear.IsToggled == true)
            {
                getprouduct.FourthYear = "T";
            }
            else
            {
                getprouduct.FourthYear = "";
            }
        }

        private void SWThirdYearr_Toggled(object sender, ToggledEventArgs e)
        {
            if (SWThirdYear.IsToggled == true)
            {
                getprouduct.ThirdYear = "T";
            }
            else
            {
                getprouduct.ThirdYear = "";
            }
        }

        private void SWSecondYear_Toggled(object sender, ToggledEventArgs e)
        {
            if (SWSecondYear.IsToggled == true)
            {
                getprouduct.SecondYear = "T";
            }
            else
            {
                getprouduct.SecondYear = "";
            }
        }

        private void SWFirstYear_Toggled(object sender, ToggledEventArgs e)
        {
            if (SWFirstYear.IsToggled==true)
            {
                getprouduct.FirstYear = "T";
            }
            else
            {
                getprouduct.FirstYear = "";
            }
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

        public async void ImgExitClick()
        {
            await home.Navigation.PopPopupAsync(true);
        }
    }
}
