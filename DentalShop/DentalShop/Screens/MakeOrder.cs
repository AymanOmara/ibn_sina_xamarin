using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace DentalShop
{
    public class MakeOrder : PopupPage
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
        Image ImgBag;
        public Entry EAddress;
        Image ImgAddres;
        Image ImgMap;
        Label LBTimeAvilable;
        public Entry EFrom;
        Image ImgFrom;
        Image ImgClockFrom;
        public Entry ETo;
        Image ImgTo;
        Image ImgClockTo;
        public Entry EPhone;
        Image ImgEPhone;
        Image ImgPhone;
        public Label LBPrice;
        Label LBCairoDelviry;
        Label LBOutDelviry;
        Label LBCash;
        Switch SWCash;
        Label LBOnline;
        Switch SWOnline;
        Image ImgButton;
        Label LBButton;
        Image ImgStar;
        public Picker OrderGovernorate;
        Image ImgPicker;
        public string Price = "";
        public string Cairo = "";
        public string OutCairo = "";
        public List<OrderList> orderLists;
        private bool ready1 = true;
        private ActivityIndicator AILoading;
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
        public Order order;
        public string Type = "New";
        public MakeOrder(int w, int h, HomePage home)
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
            double ypoint = h * .06;
            orderLists = new List<OrderList>();
            order = new Order();

            ImgBackground = new Image();
            ImgBackground.WidthRequest = w - 20;
            ImgBackground.HeightRequest = h * 0.9;
            ImgBackground.Aspect = Aspect.Fill;
            ImgBackground.Source = ImageSource.FromResource("DentalShop.Images.BlueBackground.png");
            ImgBackground.HorizontalOptions = LayoutOptions.Center;
            Point ImgBackgroundLocation = new Point(10, ypoint);
            Container.Children.Add(ImgBackground, ImgBackgroundLocation);



            ImgTitle = new Image();
            ImgTitle.WidthRequest = w - 20;
            ImgTitle.HeightRequest = h * .1;
            ImgTitle.Aspect = Aspect.Fill;
            ImgTitle.Source = ImageSource.FromResource("DentalShop.Images.button.png");
            ImgTitle.HorizontalOptions = LayoutOptions.Center;
            Point ImgTitleLocation = new Point(10, ypoint);
            Container.Children.Add(ImgTitle, ImgTitleLocation);


            //title
            LBTitle = new Label();
            LBTitle.WidthRequest = w - 20;
            LBTitle.TextColor = Color.White;
            LBTitle.HeightRequest = ImgTitle.HeightRequest;
            LBTitle.FontSize = FontSize;
            LBTitle.Text = "تنفيذ الطلب";
            LBTitle.FontAttributes = FontAttributes.Bold;
            LBTitle.HorizontalTextAlignment = TextAlignment.Center;
            LBTitle.VerticalTextAlignment = TextAlignment.Center;
            LBTitle.FontFamily = Settings.ArabicFontFamily;
            Container.Children.Add(LBTitle, new Point(10, ypoint));



            ImgExit = new Image();
            ImgExit.WidthRequest = ImgTitle.HeightRequest - 25;
            ImgExit.HeightRequest = ImgTitle.HeightRequest - 25;
            ImgExit.Aspect = Aspect.Fill;
            ImgExit.Source = ImageSource.FromResource("DentalShop.Images.ExitIcon.png");
            ImgExit.HorizontalOptions = LayoutOptions.Center;
            Point ImgExitLocation = new Point(w - 10 - ImgExit.WidthRequest - 10, ypoint + 15);
            Container.Children.Add(ImgExit, ImgExitLocation);

            double ImgSize = ImgTitle.HeightRequest - 25;

            ImgBag = new Image();
            ImgBag.WidthRequest = ImgTitle.HeightRequest - 25;
            ImgBag.HeightRequest = ImgTitle.HeightRequest - 25;
            ImgBag.Aspect = Aspect.Fill;
            ImgBag.Source = ImageSource.FromResource("DentalShop.Images.WhiteBag.png");
            ImgBag.HorizontalOptions = LayoutOptions.Center;
            Point ImgBagLocation = new Point(15, ypoint + 15);
            Container.Children.Add(ImgBag, ImgBagLocation);

            ypoint += ImgTitle.HeightRequest + 2;
            double hightSize = h * .70 /8 - 4;

            OrderGovernorate = new Picker();
            OrderGovernorate.WidthRequest = width - 40;
            OrderGovernorate.HeightRequest = hightSize;
            OrderGovernorate.TextColor = Settings.MainColor ;
            OrderGovernorate.BackgroundColor= Color.White;
            OrderGovernorate.Title = "المحافظة";
            OrderGovernorate.Items.Add("القاهرة");
            OrderGovernorate.Items.Add("الجيزة");
            OrderGovernorate.Items.Add("البحيرة");
            OrderGovernorate.Items.Add("الاسكندرية");
            OrderGovernorate.Items.Add("القليوبية");
            OrderGovernorate.Items.Add("الغربية");

            OrderGovernorate.Items.Add("الشرقية");
            OrderGovernorate.Items.Add("الدقهلية");
            OrderGovernorate.Items.Add("المنوفية");
            OrderGovernorate.Items.Add("كفر الشيخ");
            OrderGovernorate.Items.Add("السويس");
            OrderGovernorate.Items.Add("بورسعيد");

            OrderGovernorate.Items.Add("الاسماعلية");
            OrderGovernorate.Items.Add("مطروح");
            OrderGovernorate.Items.Add("بني سويف");
            OrderGovernorate.Items.Add("المنيا");
            OrderGovernorate.Items.Add("اسيوط");
            OrderGovernorate.Items.Add("سوهاج");

            OrderGovernorate.Items.Add("قنا");
            OrderGovernorate.Items.Add("الاقصر");
            OrderGovernorate.Items.Add("اسوان");
            OrderGovernorate.Items.Add("الوادي الجديد");
            OrderGovernorate.Items.Add("دمياط");
            OrderGovernorate.Items.Add("شمال سيناء");
            OrderGovernorate.Items.Add("جنوب سيناء");
           
            Point PServiceTypeLocation = new Point(20, ypoint);
            Container.Children.Add(OrderGovernorate, PServiceTypeLocation);

            ImgPicker = new Image();
            ImgPicker.WidthRequest = OrderGovernorate.WidthRequest;
            ImgPicker.HeightRequest = OrderGovernorate.HeightRequest * .3;
            ImgPicker.Aspect = Aspect.Fill;
            ImgPicker.Source = ImageSource.FromResource("DentalShop.Images.WihteBox.png");
            ImgPicker.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgPicker, new Point(20, ypoint + OrderGovernorate.HeightRequest * .7));

            ypoint += OrderGovernorate.HeightRequest + 4;
            //Address
            EAddress = new Entry();
            EAddress.WidthRequest = width - 40;
            EAddress.HeightRequest = hightSize;
            EAddress.TextColor = Settings.MainColor;
            EAddress.FontSize = FontSize;
            EAddress.FontAttributes = FontAttributes.Bold;
            EAddress.Placeholder = "العنوان";
            EAddress.PlaceholderColor = Settings.GrayColor;
            EAddress.BackgroundColor = Color.White;
            EAddress.HorizontalTextAlignment = TextAlignment.End;
            Point EAddressLocation = new Point(20, ypoint);
            Container.Children.Add(EAddress, EAddressLocation);


            ImgAddres = new Image();
            ImgAddres.WidthRequest = EAddress.WidthRequest;
            ImgAddres.HeightRequest = EAddress.HeightRequest*.3;
            ImgAddres.Aspect = Aspect.Fill;
            ImgAddres.Source = ImageSource.FromResource("DentalShop.Images.WihteBox.png");
            ImgAddres.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgAddres, new Point(20, ypoint +EAddress.HeightRequest*.7));

            ImgMap = new Image();
            ImgMap.WidthRequest = ImgSize-2;
            ImgMap.HeightRequest = ImgSize-2;
            ImgMap.Aspect = Aspect.Fill;
            ImgMap.Source = ImageSource.FromResource("DentalShop.Images.map.png");
            ImgMap.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgMap, new Point(24, ypoint + 4));


            ypoint += hightSize + 4;

            //time
            LBTimeAvilable = new Label();
            LBTimeAvilable.WidthRequest = w - 20;
            LBTimeAvilable.TextColor = Color.White;
            LBTimeAvilable.HeightRequest = hightSize;
            LBTimeAvilable.FontSize = FontSize;
            LBTimeAvilable.Text = "التواجد في العيادة";
            LBTimeAvilable.FontAttributes = FontAttributes.Bold;
            LBTimeAvilable.HorizontalTextAlignment = TextAlignment.Center;
            LBTimeAvilable.VerticalTextAlignment = TextAlignment.Center;
            LBTimeAvilable.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBTimeAvilable, new Point(10, ypoint));
            ypoint += hightSize + 4;


            //Address
            ETo = new Entry();
            ETo.WidthRequest = (width - 40) / 2 - 10;
            ETo.HeightRequest = hightSize;
            ETo.TextColor = Settings.MainColor;
            ETo.FontSize = FontSize;
            ETo.FontAttributes = FontAttributes.Bold;
            ETo.Placeholder = "الي";
            ETo.PlaceholderColor = Settings.GrayColor;
            ETo.HorizontalTextAlignment = TextAlignment.End;
            ETo.BackgroundColor = Color.White;
            Container.Children.Add(ETo, new Point(20, ypoint));

            ImgTo = new Image();
            ImgTo.WidthRequest = ETo.WidthRequest;
            ImgTo.HeightRequest = ETo.HeightRequest * .3;
            ImgTo.Aspect = Aspect.Fill;
            ImgTo.Source = ImageSource.FromResource("DentalShop.Images.WihteBox.png");
            ImgTo.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgTo, new Point(20, ypoint + ETo.HeightRequest * .7));

            ImgClockTo = new Image();
            ImgClockTo.WidthRequest = ImgSize;
            ImgClockTo.HeightRequest = ImgSize;
            ImgClockTo.Aspect = Aspect.Fill;
            ImgClockTo.Source = ImageSource.FromResource("DentalShop.Images.time-to.png");
            ImgClockTo.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgClockTo, new Point(24, ypoint + 7));

            EFrom = new Entry();
            EFrom.WidthRequest = (width - 40) / 2 - 10;
            EFrom.HeightRequest = hightSize;
            EFrom.TextColor = Settings.MainColor;
            EFrom.FontSize = FontSize;
            EFrom.FontAttributes = FontAttributes.Bold;
            EFrom.Placeholder = "من";
            EFrom.PlaceholderColor = Settings.GrayColor;
            EFrom.HorizontalTextAlignment = TextAlignment.End;
            EFrom.BackgroundColor = Color.White;
            Container.Children.Add(EFrom, new Point(20 + EFrom.WidthRequest + 20, ypoint));


            ImgFrom = new Image();
            ImgFrom.WidthRequest = EFrom.WidthRequest;
            ImgFrom.HeightRequest = EFrom.HeightRequest * .3;
            ImgFrom.Aspect = Aspect.Fill;
            ImgFrom.Source = ImageSource.FromResource("DentalShop.Images.WihteBox.png");
            ImgFrom.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgFrom, new Point(20 + EFrom.WidthRequest + 20, ypoint + EFrom.HeightRequest * .7));

            ImgClockFrom = new Image();
            ImgClockFrom.WidthRequest = ImgSize;
            ImgClockFrom.HeightRequest = ImgSize;
            ImgClockFrom.Aspect = Aspect.Fill;
            ImgClockFrom.Source = ImageSource.FromResource("DentalShop.Images.time-from.png");
            ImgClockFrom.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgClockFrom, new Point(24 + EFrom.WidthRequest + 20, ypoint + 7));

            ypoint += hightSize + 4;

            //Phone
            EPhone = new Entry();
            EPhone.WidthRequest = width - 40;
            EPhone.HeightRequest = hightSize;
            EPhone.TextColor = Settings.MainColor;
            EPhone.FontSize = FontSize;
            EPhone.FontAttributes = FontAttributes.Bold;
            EPhone.Placeholder = "رقم التليفون";
            EPhone.PlaceholderColor = Settings.GrayColor;
            EPhone.HorizontalTextAlignment = TextAlignment.End;
            EPhone.Keyboard = Keyboard.Telephone;
            EPhone.BackgroundColor = Color.White;
            Container.Children.Add(EPhone, new Point(20, ypoint));

            ImgEPhone = new Image();
            ImgEPhone.WidthRequest = EPhone.WidthRequest;
            ImgEPhone.HeightRequest = EPhone.HeightRequest * .3;
            ImgEPhone.Aspect = Aspect.Fill;
            ImgEPhone.Source = ImageSource.FromResource("DentalShop.Images.WihteBox.png");
            ImgEPhone.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgEPhone, new Point(20, ypoint + EPhone.HeightRequest * .7));

            ImgPhone = new Image();
            ImgPhone.WidthRequest = ImgSize;
            ImgPhone.HeightRequest = ImgSize;
            ImgPhone.Aspect = Aspect.Fill;
            ImgPhone.Source = ImageSource.FromResource("DentalShop.Images.mobile-icon.png");
            ImgPhone.HorizontalOptions = LayoutOptions.Center;
            Container.Children.Add(ImgPhone, new Point(24, ypoint + 7));

            ypoint += hightSize + 4;

            //Price
            LBPrice = new Label();
            LBPrice.WidthRequest = w - 20;
            LBPrice.TextColor = Color.White;
            LBPrice.HeightRequest = hightSize;
            LBPrice.FontSize = FontSize;
            LBPrice.Text = "السعر الكلي " + Price + " ج م";
            LBPrice.FontAttributes = FontAttributes.Bold;
            LBPrice.HorizontalTextAlignment = TextAlignment.Center;
            LBPrice.VerticalTextAlignment = TextAlignment.Center;
            LBPrice.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBPrice, new Point(10, ypoint));
            ypoint += hightSize + 4;

            //cairo fees
            LBCairoDelviry = new Label();
            LBCairoDelviry.WidthRequest = (w - 20) / 2;
            LBCairoDelviry.TextColor = Color.White;
            LBCairoDelviry.HeightRequest = hightSize;
            LBCairoDelviry.FontSize = FontSize - 5;
            LBCairoDelviry.Text = "الشحن في القاهرة" + "100" + " ج م";
            LBCairoDelviry.FontAttributes = FontAttributes.Bold;
            LBCairoDelviry.HorizontalTextAlignment = TextAlignment.Center;
            LBCairoDelviry.VerticalTextAlignment = TextAlignment.Center;
            LBCairoDelviry.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBCairoDelviry, new Point(10, ypoint));


            //out fees
            LBOutDelviry = new Label();
            LBOutDelviry.WidthRequest = (w - 20) / 2;
            LBOutDelviry.TextColor = Color.White;
            LBOutDelviry.HeightRequest = hightSize;
            LBOutDelviry.FontSize = FontSize - 5;
            LBOutDelviry.Text = " الشحن خارج القاهرة" + "300" + " ج م";
            LBOutDelviry.FontAttributes = FontAttributes.Bold;
            LBOutDelviry.HorizontalTextAlignment = TextAlignment.Center;
            LBOutDelviry.VerticalTextAlignment = TextAlignment.Center;
            LBOutDelviry.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBOutDelviry, new Point(10 + LBCairoDelviry.WidthRequest, ypoint));
            ypoint += hightSize + 4;


            //cash
            //togle

            SWCash = new Switch();
            SWCash.WidthRequest = 50;
            SWCash.HeightRequest = hightSize;
            SWCash.Toggled += SWCash_Toggled;
            Container.Children.Add(SWCash, new Point(w/4, ypoint));
            SWCash.IsToggled = true;
            //SWCash.IsEnabled = false;

            LBCash = new Label();
            LBCash.WidthRequest = hightSize;
            LBCash.TextColor = Color.White;
            LBCash.HeightRequest = hightSize;
            LBCash.FontSize = FontSize ;
            LBCash.Text = "كاش";
            LBCash.FontAttributes = FontAttributes.Bold;
            LBCash.HorizontalTextAlignment = TextAlignment.Center;
            LBCash.VerticalTextAlignment = TextAlignment.Center;
            LBCash.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBCash, new Point(w/4 + SWCash.WidthRequest, ypoint));



            SWOnline = new Switch();
            SWOnline.WidthRequest = 50;
            SWOnline.HeightRequest = hightSize;
            SWOnline.Toggled += SWOnline_Toggled;
            Container.Children.Add(SWOnline, new Point(w/4 + SWCash.WidthRequest+LBCash.WidthRequest+15, ypoint));
            //SWOnline.IsEnabled = false;

            LBOnline = new Label();
            LBOnline.WidthRequest = hightSize;
            LBOnline.TextColor = Color.White;
            LBOnline.HeightRequest = hightSize;
            LBOnline.FontSize = FontSize;
            LBOnline.Text = "فيزا";
            LBOnline.FontAttributes = FontAttributes.Bold;
            LBOnline.HorizontalTextAlignment = TextAlignment.Center;
            LBOnline.VerticalTextAlignment = TextAlignment.Center;
            LBOnline.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBOnline, new Point(w/4 + SWCash.WidthRequest +LBCash.WidthRequest+ 15+ SWOnline.WidthRequest, ypoint));


            ypoint += hightSize + 4;


            ImgButton = new Image();
           // ImgButton.WidthRequest = w - 20;
            ImgButton.WidthRequest = w - 200;

            //ImgButton.HeightRequest = h * .1;
            ImgButton.HeightRequest = (ImgBackground.HeightRequest * .175) - 80;
            ImgButton.BackgroundColor = Color.LightBlue;
            ImgButton.Aspect = Aspect.Fill;
            ImgButton.Source = ImageSource.FromResource("DentalShop.Images.button2.png");
            ImgButton.HorizontalOptions = LayoutOptions.Center;
            //Point ImgButtonLocation = new Point(10, ypoint);
            Point ImgButtonLocation = new Point(90, ypoint + 10);

            Container.Children.Add(ImgButton, ImgButtonLocation);


            //button
            LBButton = new Label();
            LBButton.WidthRequest = w - 20;
            LBButton.TextColor = Color.White;
            LBButton.HeightRequest = ImgButton.HeightRequest;
            LBButton.FontSize = FontSize;
            LBButton.Text = "تأكيد";
            LBButton.FontAttributes = FontAttributes.Bold;
            LBButton.HorizontalTextAlignment = TextAlignment.Center;
            LBButton.VerticalTextAlignment = TextAlignment.Center;
            LBButton.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBButton, new Point(2, ypoint+5));
            //Container.Children.Add(LBButton, new Point(10, ypoint));


            //ImgStar = new Image();
            //ImgStar.WidthRequest = ImgSize + 5;
            //ImgStar.HeightRequest = ImgSize + 5;
            //ImgStar.Aspect = Aspect.Fill;
            //ImgStar.Source = ImageSource.FromResource("DentalShop.Images.RightIcon.png");
            //ImgStar.HorizontalOptions = LayoutOptions.Center;
            //Container.Children.Add(ImgStar, new Point(30, ypoint + 7));



            AILoading = new ActivityIndicator();
            AILoading.Color = Settings.MainColor;
            AILoading.IsRunning = false; 
            AILoading.WidthRequest = Labelheight * 6;
            AILoading.HeightRequest = Labelheight * 6;
            Container.Children.Add(AILoading, new Point(w / 2 - AILoading.WidthRequest / 2, h / 2 - AILoading.HeightRequest / 2));


            //events
            ImgExit.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgExitClick())
            });

            LBButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => LBButtonClick())
            });

        }

        private void SWOnline_Toggled(object sender, ToggledEventArgs e)
        {
            SWOnline.IsToggled = false;
            Settings.Message = "خدمة الدفع الالكتروني غير متوفره حاليا ";
        }

        private void SWCash_Toggled(object sender, ToggledEventArgs e)
        {
            if (!SWCash.IsToggled)
            {
                SWCash.IsToggled = true;
                Settings.Message = " عفوا الدفع النقدي الطريقة الوحيدة المتوفرة حاليا";
            }
        }
        public void SetData()
        {
            LBPrice.Text = "السعر الكلي " + Price + " ج م";
            LBOutDelviry.Text = " الشحن خارج القاهرة" + OutCairo + " ج م";
            LBCairoDelviry.Text = "الشحن في القاهرة" + Cairo + " ج م";
        }
        public async void MakeOrdersAsync()
        {
            if ( OrderGovernorate.SelectedIndex == null|| OrderGovernorate.SelectedIndex < 0)
            {
                Settings.Message = "لابد من ادخال المحافظة ";
                return;
            }
            if (EAddress.Text == ""||EAddress.Text==null)
            {
                Settings.Message = "لابد من ادخال العنوان ";
                return;
            }
            if (ETo.Text == "" || ETo.Text == null|| EFrom.Text == "" || ETo.Text == null)
            {
                Settings.Message = "لابد من ادخال مواعيد العمل ";
                return;
            }
            if (EPhone.Text == "" || EPhone.Text == null ||EPhone.Text[0]!='0'||EPhone.Text[1]!='1'||EPhone.Text.Length!=11)
            {
                Settings.Message = "لابد من ادخال رقم الهاتف ";
                return;
            }
            if (Type == "New")
            {
                order.OrderId = 0;
                order.DeliveryFees = Settings.CairoDelviryFees.ToString();
                order.OrderAcceptTime = Settings.ToMysqlTime(DateTime.Now.ToUniversalTime());
                order.OrderCompleteTime = Settings.ToMysqlTime(DateTime.Now.ToUniversalTime());
                if (order.OrderExcuteTime==null)
                order.OrderExcuteTime = Settings.ToMysqlTime(DateTime.Now.ToUniversalTime());
                order.OrderLocation = EAddress.Text;
                order.OrderPhone = EPhone.Text;
                order.OrderPrice = Price;
                order.OrderProuductList = orderLists.ToArray();
                order.OrderStatus = "Pendding";
                order.OrderTime = Settings.ToMysqlTime(DateTime.Now.ToUniversalTime());
                order.PaymentMethod = "Cash";
                order.UserAvilableTime = "من " + EFrom.Text + "  الي " + ETo.Text;
                order.UserId = Convert.ToInt32(Settings.cash.UserInfo.UserId);
                order.OrderAmount = order.OrderProuductList.Length.ToString();
               
                
            }
            if (OrderGovernorate.SelectedIndex == 0 || OrderGovernorate.SelectedIndex == 1)
                order.DeliveryFees = Settings.CairoDelviryFees.ToString();
            else
                order.DeliveryFees = Settings.OutDeliveryFees.ToString();
            order.OrderGovernorate = OrderGovernorate.Items[OrderGovernorate.SelectedIndex].ToString();
            if (ready1)
            {
                ready1 = false;
                AILoading.IsRunning = true;
                try
                {
                    Settings.Message = "";
                    
                    Settings.HttpClient = new HttpClient();
                    var httpClient = Settings.HttpClient;
                    httpClient.Timeout = new TimeSpan(0, 0, 20);
                    String Content = JsonConvert.SerializeObject(order);
                    var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Content", Content)
                    };
                    var content = new FormUrlEncodedContent(pairs);
                    string json = "";
                    if (Type == "New")
                    {
                        var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/MakeOrder"), content);
                        ServerResult.EnsureSuccessStatusCode();
                        string responseBody = await ServerResult.Content.ReadAsStringAsync();
                        json = Settings.GetJson(responseBody);
                    }
                   else
                    {
                        var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/EditOrder"), content);
                        ServerResult.EnsureSuccessStatusCode();
                        string responseBody = await ServerResult.Content.ReadAsStringAsync();
                        json = Settings.GetJson(responseBody);
                    }
                   
                    //httpClient.Dispose();
                    try
                    {
                        if (json=="true")
                        {
                            Settings.Message = "تم حذف الطلب";
                            Settings.PageStack.Pop();
                            Settings.PageStack.Pop();
                            home.Content = Settings.mainPage.MainLayout;
                            ImgExitClick();
                            return;
                        }
                        order = JsonConvert.DeserializeObject<Order>(json);
                        if (order.OrderExcuteTime==order.OrderCompleteTime)
                        Settings.cash.CartList.Clear();
                            Settings.SaveCash();
                            Settings.prouductPage.LBItemNumber.Text = Settings.cash.CartList.Count.ToString();
                            Settings.mainPage.LItemNumber.Text = Settings.cash.CartList.Count.ToString();
                            Settings.studentProuduct.LBItemNumber.Text = Settings.cash.CartList.Count.ToString();
                            Settings.cart.GetDataAsync();
                            ImgExitClick();
                            OrderAccept accept = new OrderAccept(w, h, home);
                            accept.order = order;
                            ProudctEntity = await Settings.GetOrderProuduct(order.OrderId.ToString());
                            accept.ProudctEntity = ProudctEntity;
                            home.Navigation.PushPopupAsync(accept);
                   
                    }
                    catch (Exception ex)
                    {

                        string message = "فشل في الطلب حاول مره اخري";

                        Settings.Message = message;
                    }
                }
                catch (Exception ex)
                {

                    Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                }
                ready1 = true;
                AILoading.IsRunning = false;
            }

        }

        private void LBButtonClick()
        {
             MakeOrdersAsync();
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
