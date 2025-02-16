using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace DentalShop
{
   public class ForgotPassword
    {

        int w;
        int h;
        public ScrollView Scroll = new ScrollView();
        AbsoluteLayout Container;
        public Grid MainLayout;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.White;
        Image ImgBackground;
        Label LBTop;
        Image ImgBack;
        Entry EEmail;
        Image ImgUserEmail;
        Image ImgButton;
        Label LBButton;
        Image ImgSecondBackGround;
        Label LBText;
        private bool ready1 = true;
        private ActivityIndicator AILoading;

        public ForgotPassword(int w, int h, HomePage home)
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
            MainLayout.RowDefinitions.Add(new RowDefinition());
            MainLayout.Margin = new Thickness(0, 0, 0, 0);
            MainLayout.Children.Add(Scroll, 0, 0);

        }

        public void InitializeComponents()
        {
            double FontSize = 20;
             
            int ButtonHeight = 55;
            int width = w - 20;
            int Labelheight = 23;



            //Title
            LBTop = new Label();
            LBTop.WidthRequest = w;
            LBTop.TextColor = Color.White;
            LBTop.BackgroundColor = Settings.MainColor;
            LBTop.HeightRequest = Labelheight + 20;
            LBTop.FontSize = FontSize;
            LBTop.Text = "إسترجاع كلمة السر";
            LBTop.FontAttributes = FontAttributes.Bold;
            LBTop.HorizontalTextAlignment = TextAlignment.Center;
            LBTop.VerticalTextAlignment = TextAlignment.Center;
            LBTop.FontFamily = Settings.ArabicFontFamily;
            Container.Children.Add(LBTop, new Point(0, 0));

            // background photo
            ImgBackground = new Image();
            ImgBackground.Aspect = Aspect.Fill;
            ImgBackground.Source = ImageSource.FromResource("DentalShop.Images.logo.png");
            ImgBackground.WidthRequest = w-40;
            ImgBackground.HeightRequest = h/4;
            Container.Children.Add(ImgBackground, new Point(20, LBTop.HeightRequest+20));



          


            //img back
            ImgBack = new Image();
            ImgBack.Aspect = Aspect.Fill;
            ImgBack.Source = ImageSource.FromResource("DentalShop.Images.whiteback.png");
            ImgBack.WidthRequest = Labelheight;
            ImgBack.HeightRequest = Labelheight;
            Container.Children.Add(ImgBack, new Point(10, 10));






            double ypoint = LBTop.HeightRequest + 20 + 20 + ImgBackground.HeightRequest;

            // background photo
            ImgSecondBackGround = new Image();
            ImgSecondBackGround.Aspect = Aspect.Fill;
            ImgSecondBackGround.Source = ImageSource.FromResource("DentalShop.Images.transparent-rectangle-over-background.png");
            ImgSecondBackGround.WidthRequest = w - 20;
            ImgSecondBackGround.HeightRequest = h /4;
            Container.Children.Add(ImgSecondBackGround, new Point(10, ypoint));


            //text
            LBText = new Label();
            LBText.WidthRequest = width - 20;
            LBText.TextColor = Settings.MainColor;
            LBText.HeightRequest = ImgSecondBackGround.HeightRequest-10;
            LBText.FontSize = FontSize-5;
            LBText.Text = "يبدو أنك قد نسيت كلمة السر فأذا كنت تمتلك هذا الحساب ادخل البريد الاكلتروني الخاص بالحساب وسيتم ارسال كلمة السر الي بريدك الالكتروني";
            LBText.FontAttributes = FontAttributes.Bold;
            LBText.HorizontalTextAlignment = TextAlignment.Center;
            LBText.VerticalTextAlignment = TextAlignment.Center;
            LBText.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBText, new Point(20, ypoint +10));

            ypoint += 20+ImgSecondBackGround.HeightRequest;

            //user email
            EEmail = new Entry();
            EEmail.WidthRequest = width - 20;
            EEmail.HeightRequest = ButtonHeight;
            EEmail.TextColor = Settings.MainColor;
            EEmail.FontSize = FontSize;
            EEmail.FontAttributes = FontAttributes.Bold;
            EEmail.Placeholder = "البريد الالكتروني";
            //EEmail.IsPassword = true;
            //EUserName.BackgroundColor = new Color(245.0 / 255, 245.0 / 255, 245.0 / 255);
            EEmail.PlaceholderColor = Settings.MainColor;
            EEmail.HorizontalTextAlignment = TextAlignment.Center;
            //  EUserName.Opacity = .8;
            Point EEmailLocation = new Point(20, ypoint);
            Container.Children.Add(EEmail, EEmailLocation);



            //img email icon
            ImgUserEmail = new Image();
            ImgUserEmail.Aspect = Aspect.Fill;
            ImgUserEmail.Source = ImageSource.FromResource("DentalShop.Images.email-icon.png");
            ImgUserEmail.WidthRequest = Labelheight + 5;
            ImgUserEmail.HeightRequest = Labelheight + 5;
            Container.Children.Add(ImgUserEmail, new Point(w - 40 - ImgUserEmail.WidthRequest, ypoint));
           
            ypoint += (ButtonHeight) + 10;




            //img button
            ImgButton = new Image();
            ImgButton.Aspect = Aspect.Fill;
            ImgButton.Source = ImageSource.FromResource("DentalShop.Images.Orangebutton.png");
            ImgButton.WidthRequest = width /3;
            ImgButton.HeightRequest = Labelheight * 2;
            Container.Children.Add(ImgButton, new Point((w ) / 2 - (ImgButton.WidthRequest / 2), ypoint));



            //button
            LBButton = new Label();
            LBButton.WidthRequest = width - 20;
            LBButton.TextColor = Color.White;
            LBButton.HeightRequest = Labelheight *2;
            LBButton.FontSize = FontSize;
            LBButton.Text = "ارسال";
            LBButton.FontAttributes = FontAttributes.Bold;
            LBButton.HorizontalTextAlignment = TextAlignment.Center;
            LBButton.VerticalTextAlignment = TextAlignment.Center;
            LBButton.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBButton, new Point(20 , ypoint ));


            ypoint += 10 + ImgButton.HeightRequest;



            //events;


            LBButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBButtonClickAsync())
            });
            ImgBack.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgBackClick())
            });



            AILoading = new ActivityIndicator();
            AILoading.Color = Settings.MainColor;
            AILoading.IsRunning = false;
            AILoading.WidthRequest = Labelheight * 6;
            AILoading.HeightRequest = Labelheight * 6;
            Container.Children.Add(AILoading, new Point(w / 2 - AILoading.WidthRequest / 2, h / 2 - AILoading.HeightRequest / 2));

            Scroll.Scrolled += Scroll_Scrolled;
        }



        private void Scroll_Scrolled(object sender, ScrolledEventArgs e)
        {
            AILoading.TranslationY = e.ScrollY;
            ImgBackground.TranslationY = e.ScrollY;
        }
        public async System.Threading.Tasks.Task LBButtonClickAsync()
        {
            AILoading.IsRunning = true;
            if (ready1)
            {
                ready1 = false;
                AILoading.IsRunning = true;
                try
                {
                    Settings.Message = "";
                    var httpClient = new HttpClient();
                    Settings.HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                    SendCode MyObject = new SendCode();
                    MyObject.UserEmail = EEmail.Text.ToString();
                    String Content = JsonConvert.SerializeObject(MyObject);
                    var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Content", Content)
                    };
                    var content = new FormUrlEncodedContent(pairs);
                    var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/SendCode"), content);
                    ServerResult.EnsureSuccessStatusCode();
                    string responseBody = await ServerResult.Content.ReadAsStringAsync();
                    string json = Settings.GetJson(responseBody);
                    httpClient.Dispose();
                    try
                    {
                        if (json=="true")
                        {
                            Settings.Message = "تم ارسال كلمة السر الي بريدك الالكتروني ";
                        }
                        else 
                        {
                            Settings.Message = "لا يوجد حساب مسجل بهذا البريد الالكتروني  ";
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Settings.Message = "حدث خطأ يرجي المحاولة مرة اخري ";
                    }
                }
                catch
                {

                    Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                }
                ready1 = true;
                AILoading.IsRunning = false;
            }
            AILoading.IsRunning = false;
        }

        public void ImgBackClick()
        {
            home.SendBackButtonPressed();
        }
    }
}
