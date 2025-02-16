using Xamarin.Forms;
using System;
using System.IO;
using XLabs.Platform.Services.Media;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace DentalShop
{
    public class ImageEntity
    {
        public String Image { get; set; }
        public ImageEntity()
        {

        }
    }
    public class ImageCropper
    {
        int w;
        int h;
        public Grid MainLayout;
        AbsoluteLayout Container;
        AbsoluteLayout MenuBar;
        Image ImgBack;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.Black;
        Color ButtonColor = Settings.DarkColor;
        Label LBTop;
        Label LBError;
        Image ImgUser;
        Label BTSave;
        Label BTCancel;
        private int width;
        private bool ready = true;
        public Stream ImgStream;
        private MediaFile mediaFile;
        private Point ImgUserLocation;
        private Point CropperLocation;
        private AbsoluteLayout Cropper;
        private ActivityIndicator AILoading;
        private Point AILoadingLocation;
        private Label Top;
        private Label Bottom;
        private Label Left;
        private Label rigth;
        private double length;
        private double startScale;
        private double currentScale = 1;
        public string Type = "Create";
        public MediaFile MediaFile
        {
            get { return mediaFile; }
            set
            {
                mediaFile = value;
                double x = mediaFile.Exif.Width;
                double y = mediaFile.Exif.Height;
                SetupImage(x, y);
                ImgUser.Source = ImageSource.FromStream(() => mediaFile.Source);

            }
        }
        private void SetupImage(double x, double y)
        {
            double height = (MainLayout.RowDefinitions[1].Height.Value == 0) ? (this.h - MainLayout.RowDefinitions[0].Height.Value) : (this.h - (MainLayout.RowDefinitions[0].Height.Value + MainLayout.RowDefinitions[1].Height.Value));
            MainLayout.RowDefinitions[2].Height = height;
            if (ImgUser != null)
            {
                Container.Children.Remove(ImgUser);
                Container.Children.Remove(Cropper);
                Container.Children.Remove(BTSave);
                Container.Children.Remove(BTCancel);
            }
            ImgUser = new Image();
            ImgUser.Aspect = Aspect.Fill;
            ImgUser.Margin = new Thickness(0, 0, 0, 0);
            if ((x / y) >= (w / height))
            {
                y = (w / x) * y;
                x = w;
                ImgUser.WidthRequest = x;
                ImgUser.HeightRequest = y;
                double ypos = (height - y) / 2;
                ImgUserLocation = new Point(0, ypos);
                Container.Children.Add(ImgUser, ImgUserLocation);
            }
            else
            {
                x = (height / y) * x;
                y = height;
                ImgUser.WidthRequest = x;
                ImgUser.HeightRequest = y;
                double xpos = (w - x) / 2;
                ImgUserLocation = new Point(xpos, 0);
                Container.Children.Add(ImgUser, ImgUserLocation);
            }
            length = ImgUser.WidthRequest;
            if (length > ImgUser.HeightRequest)
                length = ImgUser.HeightRequest;
            Cropper = new AbsoluteLayout();
            Cropper.HeightRequest = Cropper.WidthRequest = length;
            double cropX = ImgUserLocation.X;
            double cropY = ImgUserLocation.Y;
            if (length < ImgUser.HeightRequest)
            {
                cropY = (ImgUser.HeightRequest - length) / 2 + ImgUserLocation.Y;
            }
            else if (length < ImgUser.WidthRequest)
            {
                cropX = (ImgUser.WidthRequest - length) / 2 + ImgUserLocation.X;
            }
            CropperLocation = new Point(cropX, cropY);
            // Cropper.BackgroundColor = Color.Green;
            Container.Children.Add(Cropper, CropperLocation);
            Top = new Label();
            Top.BackgroundColor = Settings.MainColor;
            Top.MinimumHeightRequest = Top.MinimumWidthRequest = 1;
            Top.HeightRequest = 3;
            Top.WidthRequest = length;
            Cropper.Children.Add(Top, new Point(0, 0));
            Bottom = new Label();
            Bottom.BackgroundColor = Settings.MainColor;
            Bottom.MinimumHeightRequest = Bottom.MinimumWidthRequest = 1;
            Bottom.HeightRequest = 3;
            Bottom.WidthRequest = length;
            Cropper.Children.Add(Bottom, new Point(0, length - 2));
            Left = new Label();
            Left.BackgroundColor = Settings.MainColor;
            Left.MinimumHeightRequest = Left.MinimumWidthRequest = 1;
            Left.WidthRequest = 3;
            Left.HeightRequest = length;
            Cropper.Children.Add(Left, new Point(0, 0));

            rigth = new Label();
            rigth.BackgroundColor = Settings.MainColor;
            rigth.MinimumHeightRequest = rigth.MinimumWidthRequest = 1;
            rigth.WidthRequest = 3;
            rigth.HeightRequest = length;
            Cropper.Children.Add(rigth, new Point(length - 2, 0));
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            Cropper.GestureRecognizers.Add(panGesture);
            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += OnPinchUpdated;
            Cropper.GestureRecognizers.Add(pinchGesture);
            ///save and cancel
            {
                Point LeftButton = new Point
                {
                    X = (w - 5) / 4,
                    Y = height - (20 + Settings.ButtonHeight)
                };
                Point RightButton = new Point
                {
                    X = ((w - 5) / 4) * 2 + 5,
                    Y = height - (20 + Settings.ButtonHeight)
                };
                BTSave = new Label();
                BTSave.TextColor = Color.White;
                BTSave.BackgroundColor = Settings.MainColor;
                BTSave.WidthRequest = (w - 10) / 4;
                BTSave.HeightRequest = Settings.ButtonHeight;
                BTSave.HorizontalTextAlignment = TextAlignment.Center;
                BTSave.VerticalTextAlignment = TextAlignment.Center;
              
                    BTSave.Text = "حفظ";
                    Container.Children.Add(BTSave, RightButton);
             
                BTCancel = new Label();
                BTCancel.TextColor = Color.White;
                BTCancel.BackgroundColor = Settings.MainColor;
                BTCancel.WidthRequest = (w - 10) / 4;
                BTCancel.HeightRequest = Settings.ButtonHeight;
                BTCancel.HorizontalTextAlignment = TextAlignment.Center;
                BTCancel.VerticalTextAlignment = TextAlignment.Center;
               
                    BTCancel.Text = "إلغاء";
                    Container.Children.Add(BTCancel, LeftButton);
                BTSave.GestureRecognizers.Add
                (new TapGestureRecognizer
                {
                    Command = new Command(() => BTSaveClick()),
                });
                BTCancel.GestureRecognizers.Add
                (new TapGestureRecognizer
                {
                    Command = new Command(() => BTCancelClick()),
                });
            }
            RedrawAILoading();
        }
        private void RedrawAILoading()
        {
            if (Container.Children.Contains(AILoading))
            {
                Container.Children.Remove(AILoading);
                Container.Children.Add(AILoading, AILoadingLocation);
            }
        }
        void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            AbsoluteLayout AL = (AbsoluteLayout)(sender);
            if (e.Status == GestureStatus.Started)
            {
                // Store the current scale factor applied to the wrapped user interface element,
                // and zero the components for the center point of the translate transform.
                startScale = AL.Scale;
            }
            if (e.Status == GestureStatus.Running)
            {
                // Calculate the scale factor to be applied.
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Min(1, currentScale);
                currentScale = Math.Max(.1, currentScale);
                AL.Scale = currentScale;
            }
            if (e.Status == GestureStatus.Completed)
            {
                length = length * currentScale;
                OnPanUpdated(AL, new PanUpdatedEventArgs(GestureStatus.Running, 0, 0, 0));
            }
        }
        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            AbsoluteLayout AL = (AbsoluteLayout)(sender);
            if (e.StatusType == GestureStatus.Running)
            {

                // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                if (e.TotalX != 0 || e.TotalY != 0)
                {
                    double diff = (AL.WidthRequest - AL.WidthRequest * AL.Scale) / 2;
                    double targetX = AL.X - diff + e.TotalX;
                    double targetY = AL.Y - diff + e.TotalY;
                    if (targetX < ImgUser.X - diff)
                        targetX = ImgUser.X - diff;
                    else if (targetX > (ImgUser.X + ImgUser.WidthRequest - (AL.WidthRequest - diff)))
                    {
                        targetX = ImgUser.X + ImgUser.WidthRequest - (AL.WidthRequest - diff);
                    }
                    if (targetY < ImgUser.Y - diff)
                        targetY = ImgUser.Y - diff;
                    else if (targetY > (ImgUser.Y + ImgUser.HeightRequest - (AL.HeightRequest - diff)))
                    {
                        targetY = ImgUser.Y + ImgUser.HeightRequest - (AL.HeightRequest - diff);
                    }

                    AL.TranslateTo(targetX - AL.X, targetY - AL.Y);
                }
            }
        }
        private void BTCancelClick()
        {
            Settings.PageStack.Pop();
            home.RefreshContent();
            //home.Content = Settings.controlPanel.MainLayout;
        }
        private async void BTSaveClick()
        {
            byte[] Picture = new byte[mediaFile.Source.Length];
            mediaFile.Source.Read(Picture, 0, (int)mediaFile.Source.Length);
            var resizer = DependencyService.Get<IImageResizer>();
            double aspect = mediaFile.Exif.Height / ImgUser.HeightRequest;
            double diff = (Cropper.WidthRequest - Cropper.WidthRequest * Cropper.Scale) / 2;
            double x = (int)(((Cropper.X + Cropper.TranslationX + diff) - ImgUser.X) * aspect);
            double y = (int)(((Cropper.Y + Cropper.TranslationY + diff) - ImgUser.Y) * aspect);
            double size = (int)(length * aspect);
            Picture = resizer.CropImage(Picture, new Rectangle(x, y, size, size), 250.0, 250.0);
            if (Type == "Create")
            {
                Settings.createAcount.Picture = Picture;
                Settings.createAcount.UserPhoto = true;
            }
            else
            {
                Settings.updateUserInfo.Picture = Picture;
                Settings.updateUserInfo.UserPhoto = true;
            }
            Settings.PageStack.Pop();
            home.RefreshContent();
        }
        private static string Encode(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }
            return System.Net.WebUtility.UrlEncode(data).Replace("%20", "+");
        }
        public ImageCropper(int w, int h, HomePage home)
        {
            home.BackgroundColor = LabelColor;
            this.home = home;
            this.w = w;
            this.h = h;
            Container = new AbsoluteLayout();
            Container.WidthRequest = w;
            Container.Margin = new Thickness(0, 0, 0, 0);
            Container.Padding = new Thickness(0, 0, 0, 0);
            Container.BackgroundColor = Settings.DarkColor;
            InitializeComponents();
            MainLayout = new Grid();
            MainLayout.BackgroundColor = Settings.MainColor;
            MainLayout.RowSpacing = 0;
            MainLayout.ColumnSpacing = 0;
            MainLayout.RowDefinitions.Add(new RowDefinition { Height = LBTop.HeightRequest });
            MainLayout.RowDefinitions.Add(new RowDefinition { Height = 0 });
            MainLayout.RowDefinitions.Add(new RowDefinition { Height = 0 });
            MainLayout.Margin = new Thickness(0, 0, 0, 0);
            MainLayout.Children.Add(Container, 0, 2);
            MainLayout.Children.Add(MenuBar, 0, 0);
            MainLayout.Children.Add(LBError, 0, 1);
            LBError.Margin = new Thickness(10, 0, 10, 0);
            LBError.BackgroundColor = Settings.MainColor;
            Settings.SetFont(ref Container);
            Settings.SetFont(ref MenuBar);
        }
        private void InitializeComponents()
        {
            double FontSize = 13;
            width = w - 20;
            int Labelheight = 23;
            //Top Label
            MenuBar = new AbsoluteLayout();
            MenuBar.BackgroundColor = Settings.DarkColor;
            MenuBar.WidthRequest = w;
            MenuBar.HeightRequest = Labelheight + 20;
            LBTop = new Label();
            LBTop.WidthRequest = w;
            LBTop.HeightRequest = Labelheight + 20;
            LBTop.TextColor = Color.White;
            LBTop.FontSize = FontSize + 2;
            LBTop.Text = "قص وحفظ";
            LBTop.BackgroundColor = Settings.MainColor;
            LBTop.HorizontalTextAlignment = TextAlignment.Center;
            LBTop.VerticalTextAlignment = TextAlignment.Center;
            MenuBar.Children.Add(LBTop, new Point(0, 0));
            ImgBack = new Image();
            ImgBack.Aspect = Aspect.Fill;
            ImgBack.Source = ImageSource.FromResource("ClcexApp.Back.png");
            ImgBack.WidthRequest=ImgBack.HeightRequest=LBTop.HeightRequest - 10;;
            MenuBar.Children.Add(ImgBack, new Point(5, 5));

              Device.OnPlatform
           (
           iOS: () =>
           {
               LBTop.HeightRequest = Labelheight + 20;
               ImgBack.WidthRequest = ImgBack.HeightRequest = LBTop.HeightRequest - 30;
               MenuBar.Children.Add(ImgBack, new Point(5, 25));
           },
           Android: () =>
           {
               LBTop.HeightRequest = Labelheight + 20;
               ImgBack.WidthRequest = ImgBack.HeightRequest = LBTop.HeightRequest - 10;
               MenuBar.Children.Add(ImgBack, new Point(5, 5));
           }
       );
            LBError = new Label();
            LBError.WidthRequest = width;
            LBError.HeightRequest = Labelheight;
            LBError.BackgroundColor = Settings.DarkColor;
            LBError.FontSize = FontSize;
            Settings.Message = "";
            LBError.VerticalTextAlignment = TextAlignment.Center;
            //Main Controls
            double ypoint = 0;
            //events
            AILoading = new ActivityIndicator();
            AILoading.Color = new Color(32.0 / 255, 54.0 / 255, 67.0 / 255);
            AILoading.IsRunning = false;
            AILoading.WidthRequest = w;
            AILoadingLocation = new Point(0, (h / 2 - (LBTop.HeightRequest + 60)));
            Container.Children.Add(AILoading, AILoadingLocation);
            ImgBack.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgBackClick()),
            }
            );
        }
        private void ImgBackClick()
        {
            home.SendBackButtonPressed();
        }
  

    }
}
