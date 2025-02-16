using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace DentalShop
{
  public  class Login
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
        Entry EPassword;
        Image ImgButton;
        Label LBButton;
        Image ImgUserEmail;
        Image ImgUserPassword;
        Image ImgRememberMe;
        Label LBRememberMe;
        Label LBForgetPassword;
        bool RememberMe=false;

        private bool ready1 = true;
        private ActivityIndicator AILoading;

        public Login(int w, int h, HomePage home)
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



            // background photo
            ImgBackground = new Image();
            ImgBackground.Aspect = Aspect.Fill;
            ImgBackground.Source = ImageSource.FromResource("DentalShop.Images.Loginbackground.png");
            ImgBackground.WidthRequest = w;
            ImgBackground.HeightRequest = h;
            Container.Children.Add(ImgBackground, new Point(0, 0));



            //Title
            LBTop = new Label();
            LBTop.WidthRequest = w;
            LBTop.TextColor = Settings.MainColor;
            LBTop.HeightRequest = Labelheight+15;
            LBTop.FontSize = FontSize;
            LBTop.Text = "نسجيل الدخول";
            LBTop.FontAttributes = FontAttributes.Bold;
            LBTop.HorizontalTextAlignment = TextAlignment.Center;
            LBTop.VerticalTextAlignment = TextAlignment.Center;
            LBTop.FontFamily = Settings.ArabicFontFamily;
            Container.Children.Add(LBTop, new Point(0, 5));


            //img back
            ImgBack = new Image();
            ImgBack.Aspect = Aspect.Fill;
            ImgBack.Source = ImageSource.FromResource("DentalShop.Images.back.png");
            ImgBack.WidthRequest = Labelheight;
            ImgBack.HeightRequest = Labelheight;
            Container.Children.Add(ImgBack, new Point(10, 10));


            double ypoint = h*0.35;


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
            ypoint += (ButtonHeight);
            Point EEmailLocation = new Point(20, ypoint);
            Container.Children.Add(EEmail, EEmailLocation);



            //img email icon
            ImgUserEmail = new Image();
            ImgUserEmail.Aspect = Aspect.Fill;
            ImgUserEmail.Source = ImageSource.FromResource("DentalShop.Images.email-icon.png");
            ImgUserEmail.WidthRequest = Labelheight + 5;
            ImgUserEmail.HeightRequest = Labelheight + 5;
            Container.Children.Add(ImgUserEmail, new Point(w - 40 - ImgUserEmail.WidthRequest, ypoint));


            //user password
            EPassword = new Entry();
            EPassword.WidthRequest = width - 20;
            EPassword.HeightRequest = ButtonHeight;
            EPassword.TextColor = Settings.MainColor;
            EPassword.FontSize = FontSize;
            EPassword.FontAttributes = FontAttributes.Bold;
            EPassword.Placeholder = "كلمة المرور";
            EPassword.IsPassword = true;
            EPassword.PlaceholderColor = Settings.MainColor;
            EPassword.HorizontalTextAlignment = TextAlignment.Center;
            ypoint += (ButtonHeight);
            Point EPasswordLocation = new Point(20, ypoint);
            Container.Children.Add(EPassword, EPasswordLocation);



            //img password icon
            ImgUserPassword = new Image();
            ImgUserPassword.Aspect = Aspect.Fill;
            ImgUserPassword.Source = ImageSource.FromResource("DentalShop.Images.pass-icon.png");
            ImgUserPassword.WidthRequest = Labelheight + 5;
            ImgUserPassword.HeightRequest = Labelheight + 5;
            Container.Children.Add(ImgUserPassword, new Point(w - 40 - ImgUserPassword.WidthRequest, ypoint));         

            ypoint += (ButtonHeight) + 10;


            //img remberme icon
            ImgRememberMe = new Image();
            ImgRememberMe.Aspect = Aspect.Fill;
            ImgRememberMe.Source = ImageSource.FromResource("DentalShop.Images.checkbox.png");
            ImgRememberMe.WidthRequest = Labelheight + 5;
            ImgRememberMe.HeightRequest = Labelheight + 5;
            Container.Children.Add(ImgRememberMe, new Point(w - 40 - ImgRememberMe.WidthRequest, ypoint));



            //Label rember
            LBRememberMe = new Label();
            LBRememberMe.WidthRequest = w-5-ImgRememberMe.WidthRequest;
            LBRememberMe.TextColor = Settings.MainColor;
            LBRememberMe.HeightRequest = Labelheight + 15;
            LBRememberMe.FontSize = FontSize;
            LBRememberMe.Text = "تذكرني";
            LBRememberMe.FontAttributes = FontAttributes.Bold;
            LBRememberMe.HorizontalTextAlignment = TextAlignment.End;
            LBRememberMe.VerticalTextAlignment = TextAlignment.Center;
            LBRememberMe.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBRememberMe, new Point(w-40-ImgRememberMe.WidthRequest- LBRememberMe.WidthRequest-10, ypoint ));


          

            ypoint += (ButtonHeight) + 10;




            //img button
            ImgButton = new Image();
            ImgButton.Aspect = Aspect.Fill;
            ImgButton.Source = ImageSource.FromResource("DentalShop.Images.Orangebutton.png");
            ImgButton.WidthRequest = width - 20;
            ImgButton.HeightRequest = ButtonHeight;
            Container.Children.Add(ImgButton, new Point(20, ypoint));



            //button
            LBButton = new Label();
            LBButton.WidthRequest = width - 20;
            LBButton.TextColor = Color.White;
            LBButton.HeightRequest = ButtonHeight;
            LBButton.FontSize = FontSize;
            LBButton.Text = "تسجيل الدخول";
            LBButton.FontAttributes = FontAttributes.Bold;
            LBButton.HorizontalTextAlignment = TextAlignment.Center;
            LBButton.VerticalTextAlignment = TextAlignment.Center;
            LBButton.FontFamily = Settings.ArabicFontFamily;
            Container.Children.Add(LBButton, new Point(20, ypoint ));


            ypoint += 10 + ImgButton.HeightRequest;


            //Forget Password
            LBForgetPassword = new Label();
            LBForgetPassword.WidthRequest = width - 20;
            LBForgetPassword.TextColor = Settings.MainColor;
            LBForgetPassword.HeightRequest = Labelheight + 15;
            LBForgetPassword.FontSize = FontSize;
            LBForgetPassword.Text = "هل نسيت كلمة السر ؟";
            LBForgetPassword.FontAttributes = FontAttributes.Bold;
            LBForgetPassword.HorizontalTextAlignment = TextAlignment.Center;
            LBForgetPassword.VerticalTextAlignment = TextAlignment.Center;
            LBForgetPassword.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBForgetPassword, new Point(20, ypoint + 10));


            //events;


            LBButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBButtonClickAsync())
            });

            ImgRememberMe.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgRememberMeClick())
            });
            LBForgetPassword.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBForgetPasswordClick())
            });
            ImgBack.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgBackClick())
            });
            Scroll.Scrolled += Scroll_Scrolled;

            AILoading = new ActivityIndicator();
            AILoading.Color = Settings.MainColor;
            AILoading.IsRunning = false;
            AILoading.WidthRequest = Labelheight * 6;
            AILoading.HeightRequest = Labelheight * 6;
            Container.Children.Add(AILoading, new Point(w / 2 - AILoading.WidthRequest / 2, h / 2 - AILoading.HeightRequest / 2));

        }

        private void Scroll_Scrolled(object sender, ScrolledEventArgs e)
        {
            AILoading.TranslationY = e.ScrollY;
            ImgBackground.TranslationY = e.ScrollY;
        }

        public async System.Threading.Tasks.Task LBButtonClickAsync()
        {
            AILoading.IsRunning = true;
           await  UserLogin();
            AILoading.IsRunning = false;
           
        }

        public void ImgRememberMeClick()
        {
            if (RememberMe)
            {
                RememberMe = !RememberMe;
                ImgRememberMe.Source = ImageSource.FromResource("DentalShop.Images.checkbox.png");
            }
            else
            {
                RememberMe = !RememberMe;
                ImgRememberMe.Source = ImageSource.FromResource("DentalShop.Images.Rightcheckbox.png");
            }
        }

        public void LBForgetPasswordClick()
        {
            home.Content = Settings.forgotPassword.MainLayout;
        }

        public void ImgBackClick()
        {
            home.SendBackButtonPressed();
        }

       

          
        public async Task UserLogin()
        {

            if (ready1)
            {
                ready1 = false;
                AILoading.IsRunning = true;
                try
                {
                    Settings.Message = "";
                    var httpClient = Settings.HttpClient;
                    Settings.HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                    LogInUser MyObject = new LogInUser();
                    MyObject.phone = EEmail.Text.ToString();
                    MyObject.password = EPassword.Text.ToString();
                    String Content = JsonConvert.SerializeObject(MyObject);
                    var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Content", Content)
                    };
                    var content = new FormUrlEncodedContent(pairs);
                    var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/LogIn"), content);
                    ServerResult.EnsureSuccessStatusCode();
                    string responseBody = await ServerResult.Content.ReadAsStringAsync();
                    string json = Settings.GetJson(responseBody);
                    //httpClient.Dispose();
                    try
                    {
                        UserEntity UserData = new UserEntity();
                        UserData = JsonConvert.DeserializeObject<UserEntity>(json);
                        Settings.cash.UserInfo = UserData;
                        Settings.cash.LoggedIn = true;
                        Settings.SaveCash();
                        Settings.updateUserInfo.UserInfo = UserData;
                        Settings.updateUserInfo.SetData();
                        await Settings.GetFavorites();
                        home.Content = Settings.mainPage.MainLayout;
                        Settings.login.EPassword.Text = "";
                    }
                    catch (Exception ex)
                    {

                        string message = "برجاء التأكد من رقم البريد الالكتروني او كلمة السر";

                        Settings.Message = message;
                    }
                }
                catch
                {

                    Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                }
                ready1 = true;
                AILoading.IsRunning = false;
            }



        }


    }
}
