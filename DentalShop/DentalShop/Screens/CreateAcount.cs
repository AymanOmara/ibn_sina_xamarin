using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Services.Media;

namespace DentalShop
{
    public class CreateAcount
    {
        int counter = 1;
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
        Image ImgSecondBackground;
        Image ImgUserPhoto;
        Entry EUserName;
        Entry EEmail;
        Entry EPassword;
        Entry EPassword2;
        Entry EPhone;
        Image ImgButton;
        Label LBButton;
        Image ImgEyePassword;
        Image ImgEyePassword2;
        Image ImgUserIcon;
        Image ImgUserEmail;
        Image ImgUserPassword;
        Image ImgUserPassword2;
        Image ImgUserPhone;
        public   bool UserPhoto=false;
        private byte[] picture = new byte[0];
        public byte[] Picture
        {
            get { return picture; }
            set
            {
                picture = value;
                if (value != null && value.Length != 0)
                {
                    ImgUserPhoto.ClearValue(Image.SourceProperty);
                    ImgUserPhoto.Source = ImageSource.FromStream(() => { return new MemoryStream(picture); });
                }
            }
        }

        private bool ready1 = true;
        private ActivityIndicator AILoading;


        public CreateAcount(int w, int h, HomePage home)
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
             
            int ButtonHeight = 50;
            int width = w - 20;
            int Labelheight = 23;



            // background photo
            ImgBackground = new Image();
            ImgBackground.Aspect = Aspect.Fill;
            ImgBackground.Source = ImageSource.FromResource("DentalShop.Images.background.png");
            ImgBackground.WidthRequest = w;
            ImgBackground.HeightRequest = h;
            Container.Children.Add(ImgBackground, new Point(0, 0));



            //Title
            LBTop = new Label();
            LBTop.WidthRequest = w;
            LBTop.TextColor = Settings.MainColor;
            LBTop.HeightRequest = Labelheight+15;
            LBTop.FontSize = FontSize;
            LBTop.Text = "إنشاء حساب جديد";
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



            //second  background photo
            ImgSecondBackground = new Image();
            ImgSecondBackground.Aspect = Aspect.Fill;
            ImgSecondBackground.Source = ImageSource.FromResource("DentalShop.Images.transparent-rectangle-over-background.png");
            ImgSecondBackground.WidthRequest = w - 30;
            ImgSecondBackground.HeightRequest = h - LBTop.HeightRequest * 2.5;
            // ImgSecondBackground.Opacity = .6;
            Container.Children.Add(ImgSecondBackground, new Point(15, LBTop.HeightRequest * 2));


            double ypoint = LBTop.HeightRequest * 2 + 10;

            //user photo
            ImgUserPhoto = new Image();
            ImgUserPhoto.Aspect = Aspect.Fill;
            ImgUserPhoto.Source = ImageSource.FromResource("DentalShop.Images.DefaultPhoto.png");
            ImgUserPhoto.WidthRequest = h/5;
            ImgUserPhoto.HeightRequest = h/5;
            Container.Children.Add(ImgUserPhoto, new Point(w / 2 - (ImgUserPhoto.WidthRequest / 2), ypoint));


            ypoint += 10 + ImgUserPhoto.HeightRequest;

            //user name
            EUserName = new Entry();
            EUserName.WidthRequest = width - 20;
            EUserName.HeightRequest = ButtonHeight;
            EUserName.TextColor = Settings.MainColor;
            EUserName.FontSize = FontSize;
            EUserName.FontAttributes = FontAttributes.Bold;
            EUserName.Placeholder = "اسم المستخدم";
            //EUserName.IsPassword = true;
            //EUserName.BackgroundColor = new Color(245.0 / 255, 245.0 / 255, 245.0 / 255);
            EUserName.PlaceholderColor = Settings.MainColor;
            EUserName.HorizontalTextAlignment = TextAlignment.Center;
            //  EUserName.Opacity = .8;
            Point EUserNameLocation = new Point(20, ypoint);
            Container.Children.Add(EUserName, EUserNameLocation);


            //img user icon
            ImgUserIcon = new Image();
            ImgUserIcon.Aspect = Aspect.Fill;
            ImgUserIcon.Source = ImageSource.FromResource("DentalShop.Images.small-user-icon.png");
            ImgUserIcon.WidthRequest = Labelheight + 10;
            ImgUserIcon.HeightRequest = Labelheight + 10;
            Container.Children.Add(ImgUserIcon, new Point(w - 40 - ImgUserIcon.WidthRequest, ypoint));



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
            ImgUserEmail.WidthRequest = Labelheight + 10;
            ImgUserEmail.HeightRequest = Labelheight + 10;
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
            ImgUserPassword.WidthRequest = Labelheight + 10;
            ImgUserPassword.HeightRequest = Labelheight + 10;
            Container.Children.Add(ImgUserPassword, new Point(w - 40 - ImgUserPassword.WidthRequest, ypoint));


            //img eye
            ImgEyePassword = new Image();
            ImgEyePassword.Aspect = Aspect.Fill;
            ImgEyePassword.Source = ImageSource.FromResource("DentalShop.Images.eye-icon.png");
            ImgEyePassword.WidthRequest = Labelheight + 10;
            ImgEyePassword.HeightRequest = (Labelheight + 10) * 0.61;
            Container.Children.Add(ImgEyePassword, new Point(30, ypoint + 10));



            //user password2
            EPassword2 = new Entry();
            EPassword2.WidthRequest = width - 20;
            EPassword2.HeightRequest = ButtonHeight;
            EPassword2.TextColor = Settings.MainColor;
            EPassword2.FontSize = FontSize;
            EPassword2.FontAttributes = FontAttributes.Bold;
            EPassword2.Placeholder = "تأكيد كلمة المرور";
            EPassword2.IsPassword = true;
            EPassword2.PlaceholderColor = Settings.MainColor;
            EPassword2.HorizontalTextAlignment = TextAlignment.Center;
            ypoint += (ButtonHeight);
            Point EPassword2Location = new Point(20, ypoint);
            Container.Children.Add(EPassword2, EPassword2Location);




            //img password2 icon
            ImgUserPassword2 = new Image();
            ImgUserPassword2.Aspect = Aspect.Fill;
            ImgUserPassword2.Source = ImageSource.FromResource("DentalShop.Images.pass-icon.png");
            ImgUserPassword2.WidthRequest = Labelheight + 10;
            ImgUserPassword2.HeightRequest = Labelheight + 10;
            Container.Children.Add(ImgUserPassword2, new Point(w - 40 - ImgUserPassword2.WidthRequest, ypoint));



            //img eye
            ImgEyePassword2 = new Image();
            ImgEyePassword2.Aspect = Aspect.Fill;
            ImgEyePassword2.Source = ImageSource.FromResource("DentalShop.Images.eye-icon.png");
            ImgEyePassword2.WidthRequest = Labelheight + 5;
            ImgEyePassword2.HeightRequest = (Labelheight + 5) * 0.61;
            Container.Children.Add(ImgEyePassword2, new Point(30, ypoint + 10));


            //user phone
            EPhone = new Entry();
            EPhone.WidthRequest = width - 20;
            EPhone.HeightRequest = ButtonHeight;
            EPhone.TextColor = Settings.MainColor;
            EPhone.FontSize = FontSize;
            EPhone.FontAttributes = FontAttributes.Bold;
            EPhone.Placeholder = "رقم الموبيل";
            EPhone.PlaceholderColor = Settings.MainColor;
            EPhone.HorizontalTextAlignment = TextAlignment.Center;
            EPhone.Keyboard = Keyboard.Telephone;
            ypoint += (ButtonHeight);
            Point EPhoneLocation = new Point(20, ypoint);
            Container.Children.Add(EPhone, EPhoneLocation);



            //img phone icon
            ImgUserPhone = new Image();
            ImgUserPhone.Aspect = Aspect.Fill;
            ImgUserPhone.Source = ImageSource.FromResource("DentalShop.Images.phone-icon.png");
            ImgUserPhone.WidthRequest = Labelheight + 10;
            ImgUserPhone.HeightRequest = Labelheight + 10;
            Container.Children.Add(ImgUserPhone, new Point(w - 40 - ImgUserPhone.WidthRequest, ypoint));




            ypoint += (ButtonHeight) + 20;


            //img button
            ImgButton = new Image();
            ImgButton.Aspect = Aspect.Fill;
            ImgButton.Source = ImageSource.FromResource("DentalShop.Images.button.png");
            ImgButton.WidthRequest = width - 20;
            ImgButton.HeightRequest = ButtonHeight;
            Container.Children.Add(ImgButton, new Point(20, ypoint));



            //button
            LBButton = new Label();
            LBButton.WidthRequest = width - 20;
            LBButton.TextColor = Color.White;
            LBButton.HeightRequest = ButtonHeight;
            LBButton.FontSize = FontSize;
            LBButton.Text = "إنشاء حساب جديد";
            LBButton.FontAttributes = FontAttributes.Bold;
            LBButton.HorizontalTextAlignment = TextAlignment.Center;
            LBButton.VerticalTextAlignment = TextAlignment.Center;
            LBTop.FontFamily = Settings.ArabicFontFamily;
            Container.Children.Add(LBButton, new Point(20, ypoint ));



      

            //events

            ImgEyePassword.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgEyePasswordClick())
            });



            ImgEyePassword2.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgEyePassword2Click())
            });

            LBButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBButtonClickAsync())
            });
            ImgUserPhoto.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgUserPhotoClickAsync())
            });
            ImgBack.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgBackClick())
            });


            AILoading = new ActivityIndicator();
            AILoading.Color = Settings.MainColor;
            AILoading.IsRunning = false;
            AILoading.WidthRequest = Labelheight*6;
            AILoading.HeightRequest = Labelheight * 6;
            Container.Children.Add(AILoading, new Point (w/2-AILoading.WidthRequest/2,h/2-AILoading.HeightRequest/2));


            Scroll.Scrolled += Scroll_Scrolled;
        }

        private void Scroll_Scrolled(object sender, ScrolledEventArgs e)
        {
            AILoading.TranslationY = e.ScrollY;
            ImgBackground.TranslationY = e.ScrollY;
            ImgSecondBackground.TranslationY = e.ScrollY;
        }

        public void ImgBackClick()
        {
            home.SendBackButtonPressed();
            //UserPhoto = false;
        }

        public void ImgEyePasswordClick()
        {
            if (EPassword.Text == "")
            {
                return;
            }
            else
                EPassword.IsPassword = !EPassword.IsPassword;
        }

        public void ImgEyePassword2Click()
        {
            if (EPassword2.Text == "")
            {
                return;
            }
            else
                EPassword2.IsPassword = !EPassword2.IsPassword;
        }

        public async void LBButtonClickAsync()
        {
            AILoading.IsRunning = true;          
            await CreateAccount();
            AILoading.IsRunning = false;
        }

        public async void ImgUserPhotoClickAsync()
        {
            Settings.imageCropper.Type = "Create";
            try
            {
                var option = new CameraMediaStorageOptions();
                var mediaPicker = Resolver.Resolve<IMediaPicker>();
                var mediaFile = await mediaPicker.SelectPhotoAsync(option);
                if (mediaFile.Exif.Width == 0 || mediaFile.Exif.Height == 0)
                {
                    Settings.Message =  "من فضلك قم بإختيار صورة اخرى" ;
                }
                else
                {
                    Settings.imageCropper.MediaFile = mediaFile;
                    home.Content = Settings.imageCropper.MainLayout;
                }

            }
            catch (Exception ex)
            {

            }
        }


        public async    Task CreateAccount()
        {
            bool goodData = false;
            if (EUserName.Text == "" || EUserName.Text == null)
            {
                Settings.Message = "من فضلك قم بكتابة الإسم .";
                return;
            }

            else if (EEmail.Text == null || EEmail.Text == "" || !EEmail.Text.Contains("@"))
            {

                Settings.Message = "من فضلك تأكد من إدخال البريد الإلكترونى بشكل صحيح.";
                return;
            }
            else if (EPassword.Text == null || EPassword.Text.Length < 6)
            {

                Settings.Message = "يجب ألا يقل عدد أحرف كلمة المرور عن 6 احرف.";
                return;

            }
            else if (EPassword.Text != EPassword2.Text)
            {

                Settings.Message = "كلمة المرور غير متطابقة. من فضلك تأكد من كتابة كلمة المرور بشكل صحيح.";
                return;

            }
            else if (EPhone.Text == "" || EPhone.Text == null||EPhone.Text[0]!='0'||EPhone.Text[1]!='1'||EPhone.Text.Length!=11)
            {
                Settings.Message = " من فضلك قم بإدخال رقم هاتفك المحمول بشكل صحيح";
                return;
            }
            else
            {
                goodData = true;
            }
            if (goodData && ready1)
            {
                ready1 = false;
                try
                {
                    Settings.Message = "";
                   Settings.HttpClient = new HttpClient(); Settings.HttpClient.Timeout = new TimeSpan(0, 0, 20);

                    UserEntity MyObject = new UserEntity();
                    MyObject.UserId = "0";
                    MyObject.UserName = EUserName.Text.ToString();
                    MyObject.UserEmail = EEmail.Text.ToString();
                    MyObject.UserPassword = EPassword.Text.ToString();
                    MyObject.UserPhone = EPhone.Text.ToString();
                    if (!UserPhoto)
                    MyObject.UserPhoto = "D";
                    else
                        MyObject.UserPhoto = Convert.ToBase64String(Picture);

                    String Content = JsonConvert.SerializeObject(MyObject);
                    var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Content", Content)
                    };
                    var content = new FormUrlEncodedContent(pairs);
                    var ServerResult = await Settings.HttpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/CreateAccount"), content);
                    ServerResult.EnsureSuccessStatusCode();
                    string responseBody = await ServerResult.Content.ReadAsStringAsync();
                    string json = Settings.GetJson(responseBody);
                    UserPhoto = false;
                    String Response = "not";
                    if (json == "email")
                        Response = "email";
                    else if (json == "phone")
                        Response = "phone";
                    else if (json == "false")
                        Response = "false";
                    else
                    {
                        Settings.Message = "تم تسجيل الحساب بنجاح";
                        ClearData();
                        Settings.PageStack.Pop();
                        home.Content = Settings.login.MainLayout;
                    }
                    if (Response == "not")
                    {

                    }
                    else if (Response == "email")
                    {

                        Settings.Message = "البريد الالكتروني الذي أدخلته ينتمي إلى حساب آخر.";
                    }
                    else if (Response == "phone")
                    {

                        Settings.Message = "رقم الهاتف المحمول الذي أدخلته ينتمي إلى حساب آخر.";
                    }
                    else
                    {

                        Settings.Message = "لقد حدث خطأ من فضلك اعد المحاولة فى وقت لاحق";
                    }
                }
                catch
                {

                    Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                }
                ready1 = true;

            }


            
        }
        public void ClearData()
        {
            EUserName.Text = "";
            EEmail.Text = "";
            EPassword.Text = EPassword2.Text = "";
            EPhone.Text = "";
            UserPhoto = false;
            ImgUserPhoto.Source = ImageSource.FromResource("DentalShop.Images.DefaultPhoto.png");
        }
    }
}