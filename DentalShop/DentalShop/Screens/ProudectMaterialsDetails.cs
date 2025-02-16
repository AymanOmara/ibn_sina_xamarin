using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentalShop
{
    public class ProudectMaterialsDetails
    {
        int w;
        int h;
        public ScrollView Scroll = new ScrollView();
        AbsoluteLayout Container;
        public Grid MainLayout;
        AbsoluteLayout MenuBar;
        StackLayout MainDetails;
        StackLayout AvilableStack;
        StackLayout PriceStack;
        StackLayout EndLine;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.White;
        Label LBTop;
        Image ImgControlPanel;
        Image ImgBack;
        Image ImgMainPhoto;
        public Image ImgMarket;
        public Image ImgFavorite;
        Image ImgLeftSide;
        Image ImgRightSide;
        Label LBBriefTilte;
        Label LBBrief;
        public bool ImgFavoritrGray = true;
        public bool ImgMarketGray = true;
        Label LBMadeInTitle;
        Label LBMadeIn;
        Label LBGuarantee;
        Label LBExDateTitle;
        Label LBExDate;
        Image ImgAvilable;
        Label LBAvilable;
        Label LBPriceTitle;
        Label LBPrice;
        Image ImgStar;
        Label LBEndLine;
        Label LBError;
        public int Counter = 1;
        public ProuductEntity prouductDetails = new ProuductEntity();
        List<OrderList> orderLists;
        private ActivityIndicator AILoading;

        public ProudectMaterialsDetails(int w, int h, HomePage home)
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
            LBTop.Text = "تفاصيل المنتج";
            LBTop.BackgroundColor = Settings.MainColor;
            LBTop.HorizontalTextAlignment = TextAlignment.Center;
            LBTop.VerticalTextAlignment = TextAlignment.Center;
            LBTop.FontFamily = Settings.ArabicFontFamily;


            MenuBar.Children.Add(LBTop, new Point(0, 0));


            //ImgControlPanel = new Image();
            //ImgControlPanel.Aspect = Aspect.Fill;
            //ImgControlPanel.Source = ImageSource.FromResource("DentalShop.Images.ControlPanel.png");
            //ImgControlPanel.WidthRequest = ImgControlPanel.HeightRequest = LBTop.HeightRequest - 15;
            //MenuBar.Children.Add(ImgControlPanel, new Point(w - 15 - ImgControlPanel.WidthRequest, 5));

            //img back
            ImgBack = new Image();
            ImgBack.Aspect = Aspect.Fill;
            ImgBack.Source = ImageSource.FromResource("DentalShop.Images.whiteback.png");
            ImgBack.WidthRequest = Labelheight;
            ImgBack.HeightRequest = Labelheight;
            MenuBar.Children.Add(ImgBack, new Point(10, 10));


            //MainPhoto
            ImgMainPhoto = new Image();
            ImgMainPhoto.Aspect = Aspect.Fill;
            ImgMainPhoto.Source = ImageSource.FromResource("DentalShop.Images.23.jpg");
            ImgMainPhoto.WidthRequest = w - 20;
            ImgMainPhoto.HeightRequest = h / 3;
            Container.Children.Add(ImgMainPhoto, new Point(10, 10));


            double ypoint = 10 + ImgMainPhoto.HeightRequest;



            ImgMarket = new Image();
            ImgMarket.Aspect = Aspect.Fill;
            ImgMarket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
            ImgMarket.WidthRequest = ImgMarket.HeightRequest = LBTop.HeightRequest - 15;
            Container.Children.Add(ImgMarket, new Point(20, 15));








            ImgFavorite = new Image();
            ImgFavorite.Aspect = Aspect.Fill;
            ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
            ImgFavorite.WidthRequest = ImgFavorite.HeightRequest = LBTop.HeightRequest - 15;
            Container.Children.Add(ImgFavorite, new Point(w - 20 - ImgFavorite.WidthRequest, 15));





            ImgLeftSide = new Image();
            ImgLeftSide.WidthRequest = LBTop.HeightRequest - 15;
            ImgLeftSide.HeightRequest = LBTop.HeightRequest - 15;
            ImgLeftSide.Aspect = Aspect.Fill;
            ImgLeftSide.Source = ImageSource.FromResource("DentalShop.Images.slider-left-pointer.png");
            ImgLeftSide.HorizontalOptions = LayoutOptions.Center;
            Point ImgLeftSideLocation = new Point(15, 10 + ImgMainPhoto.HeightRequest / 2 - ImgLeftSide.WidthRequest / 2);
            //Container.Children.Add(ImgLeftSide, ImgLeftSideLocation);


            ImgRightSide = new Image();
            ImgRightSide.WidthRequest = LBTop.HeightRequest - 15;
            ImgRightSide.HeightRequest = LBTop.HeightRequest - 15;
            ImgRightSide.Aspect = Aspect.Fill;
            ImgRightSide.Source = ImageSource.FromResource("DentalShop.Images.slider-right-pointer.png");
            ImgRightSide.HorizontalOptions = LayoutOptions.Center;
            Point ImgRightSideLocation = new Point(w - ImgRightSide.WidthRequest - 20, 10 + ImgMainPhoto.HeightRequest / 2 - ImgRightSide.WidthRequest / 2);
            //Container.Children.Add(ImgRightSide, ImgRightSideLocation);



            MainDetails = new StackLayout();
            MainDetails.WidthRequest = w - 20;
            MainDetails.BackgroundColor = Settings.BackGroundColor;
            MainDetails.Padding = 0;
            Container.Children.Add(MainDetails, new Point(10, ypoint));


            LBBriefTilte = new Label();
            LBBriefTilte.WidthRequest = w - 20;
            LBBriefTilte.TextColor = Settings.MainColor;
            LBBriefTilte.FontSize = FontSize + 8;
            LBBriefTilte.Text = "نبذه عن المنتج";
            LBBriefTilte.HorizontalTextAlignment = TextAlignment.Start;
            LBBriefTilte.FontAttributes = FontAttributes.Bold;
            LBBriefTilte.VerticalTextAlignment = TextAlignment.Center;
            LBBriefTilte.FontFamily = Settings.ArabicFontFamily;

            //Container.Children.Add(LBBriefTilte, new Point(10, ypoint));
            MainDetails.Children.Add(LBBriefTilte);

            ypoint += 2 + LBBriefTilte.HeightRequest;


            LBBrief = new Label();
            LBBrief.WidthRequest = w - 30;
            LBBrief.TextColor = Settings.BlueColor;
            LBBrief.FontSize = FontSize;
            LBBrief.Text = "";
            LBBrief.HorizontalTextAlignment = TextAlignment.Start;
            LBBrief.VerticalTextAlignment = TextAlignment.Center;
            LBBrief.FontFamily = Settings.ArabicFontFamily;

            //Container.Children.Add(LBBrief, new Point(15, ypoint));
            MainDetails.Children.Add(LBBrief);

            ypoint += 5 + LBBrief.HeightRequest;


            AvilableStack = new StackLayout();
            AvilableStack.WidthRequest = w;
            AvilableStack.BackgroundColor = Settings.BackGroundColor;
            AvilableStack.Orientation = StackOrientation.Horizontal;
            AvilableStack.Padding = 5;






            LBAvilable = new Label();
            LBAvilable.WidthRequest = w;
            LBAvilable.TextColor = Settings.BlueColor;
            //LBAvilable.HeightRequest = Labelheight + 10;
            LBAvilable.FontSize = FontSize + 5;
            LBAvilable.Text = "متوفر في المخزن";
            LBAvilable.HorizontalTextAlignment = TextAlignment.Start;
            LBAvilable.FontAttributes = FontAttributes.Bold;
            LBAvilable.VerticalTextAlignment = TextAlignment.Center;
            LBAvilable.FontFamily = Settings.ArabicFontFamily;

            //Container.Children.Add(LBAvilable, new Point(10, ypoint));

            AvilableStack.Children.Add(LBAvilable);


            ImgAvilable = new Image();
            ImgAvilable.WidthRequest = LBTop.HeightRequest - 15;
            ImgAvilable.HeightRequest = LBTop.HeightRequest - 15;
            ImgAvilable.Aspect = Aspect.Fill;
            ImgAvilable.Source = ImageSource.FromResource("DentalShop.Images.Avilable.png");
            ImgAvilable.HorizontalOptions = LayoutOptions.End;

            //Container.Children.Add(ImgAvilable, new Point (w-10-ImgAvilable.WidthRequest,ypoint));
            AvilableStack.Children.Add(ImgAvilable);

            MainDetails.Children.Add(AvilableStack);


            LBMadeInTitle = new Label();
            LBMadeInTitle.WidthRequest = w - 20;
            LBMadeInTitle.TextColor = Settings.MainColor;
            // LBMadeInTitle.HeightRequest = Labelheight + 10;
            LBMadeInTitle.FontSize = FontSize + 8;
            LBMadeInTitle.Text = "بلد التصنيع";
            LBMadeInTitle.HorizontalTextAlignment = TextAlignment.Start;
            LBMadeInTitle.FontAttributes = FontAttributes.Bold;
            LBMadeInTitle.VerticalTextAlignment = TextAlignment.Center;
            LBMadeInTitle.FontFamily = Settings.ArabicFontFamily;

            MainDetails.Children.Add(LBMadeInTitle);

            //ypoint +=LBMadeInTitle.HeightRequest;


            LBMadeIn = new Label();
            LBMadeIn.WidthRequest = w - 30;
            LBMadeIn.TextColor = Settings.BlueColor;
            //LBMadeIn.HeightRequest = Labelheight + 5;
            LBMadeIn.FontSize = FontSize + 3;
            LBMadeIn.Text = "مصر";
            LBMadeIn.HorizontalTextAlignment = TextAlignment.Start;
            LBMadeIn.VerticalTextAlignment = TextAlignment.Center;
            LBMadeIn.FontFamily = Settings.ArabicFontFamily;

            MainDetails.Children.Add(LBMadeIn);

            //ypoint += 5 + LBMadeIn.HeightRequest;


            LBGuarantee = new Label();
            LBGuarantee.WidthRequest = w - 20;
            LBGuarantee.TextColor = Settings.BlueColor;
            LBGuarantee.FontSize = FontSize+5;
            LBGuarantee.Text = "داخل الضمان";
            LBGuarantee.HorizontalTextAlignment = TextAlignment.Start;
            LBGuarantee.VerticalTextAlignment = TextAlignment.Center;
            LBGuarantee.FontFamily = Settings.ArabicFontFamily;

            MainDetails.Children.Add(LBGuarantee);


            LBExDateTitle = new Label();
            LBExDateTitle.WidthRequest = w - 20;
            LBExDateTitle.TextColor = Settings.MainColor;
            LBExDateTitle.FontSize = FontSize + 8;
            LBExDateTitle.Text = "تاريخ الانتهاء";
            LBExDateTitle.HorizontalTextAlignment = TextAlignment.Start;
            LBExDateTitle.VerticalTextAlignment = TextAlignment.Center;
            LBExDateTitle.FontFamily = Settings.ArabicFontFamily;

            MainDetails.Children.Add(LBExDateTitle);



            LBExDate = new Label();
            LBExDate.WidthRequest = w - 20;
            LBExDate.TextColor = Settings.BlueColor;
            LBExDate.FontSize = FontSize + 8;
            LBExDate.Text = "19 Mar 2019";
            LBExDate.HorizontalTextAlignment = TextAlignment.End;
            LBExDate.VerticalTextAlignment = TextAlignment.Center;
            LBExDate.FontFamily = Settings.ArabicFontFamily;

            MainDetails.Children.Add(LBExDate);


            PriceStack = new StackLayout();
            PriceStack.WidthRequest = w;
            PriceStack.BackgroundColor = Settings.BackGroundColor;
            PriceStack.Orientation = StackOrientation.Horizontal;
            PriceStack.Padding = 5;




            LBPrice = new Label();
            LBPrice.WidthRequest = w - 30 - w / 6;
            LBPrice.TextColor = Settings.BlueColor;
            //LBPrice.HeightRequest = Labelheight + 10;
            LBPrice.FontSize = FontSize + 3;
            LBPrice.Text = "100 جنية مصري";
            LBPrice.HorizontalTextAlignment = TextAlignment.Start;
            LBPrice.VerticalTextAlignment = TextAlignment.Center;
            LBPrice.FontFamily = Settings.ArabicFontFamily;

            PriceStack.Children.Add(LBPrice);

            LBPriceTitle = new Label();
            LBPriceTitle.WidthRequest = w /5;
            LBPriceTitle.TextColor = Settings.MainColor;
            //LBPriceTitle.HeightRequest = Labelheight + 10;
            LBPriceTitle.FontSize = FontSize + 8;
            LBPriceTitle.Text = "السعر";
            LBPriceTitle.HorizontalTextAlignment = TextAlignment.Start;
            LBPriceTitle.FontAttributes = FontAttributes.Bold;
            LBPriceTitle.VerticalTextAlignment = TextAlignment.Center;
            LBPriceTitle.FontFamily = Settings.ArabicFontFamily;

            PriceStack.Children.Add(LBPriceTitle);

            //ypoint += 5 + LBPrice.HeightRequest;
            MainDetails.Children.Add(PriceStack);


            EndLine = new StackLayout();
            EndLine.WidthRequest = w;
            EndLine.BackgroundColor = Settings.BackGroundColor;
            EndLine.Orientation = StackOrientation.Horizontal;
            EndLine.Padding = 0;
            EndLine.HorizontalOptions = LayoutOptions.EndAndExpand;





            ImgStar = new Image();
             ImgStar.WidthRequest = LBTop.HeightRequest - 10;
            ImgStar.HeightRequest = LBTop.HeightRequest - 10;
            ImgStar.Aspect = Aspect.Fill;
            ImgStar.Source = ImageSource.FromResource("DentalShop.Images.BlueRight.png");


            EndLine.Children.Add(ImgStar);




            LBEndLine = new Label();
            LBEndLine.TextColor = Settings.MainColor;
            LBEndLine.WidthRequest = w + 30 - LBTop.HeightRequest *2;
            LBEndLine.FontSize = FontSize + 2;
            LBEndLine.Text = "هل تريد طلب هذا المنتج بعد 10 ايام من الآن ؟";
            LBEndLine.HorizontalTextAlignment = TextAlignment.Center;
            LBEndLine.FontAttributes = FontAttributes.Bold;
            LBEndLine.VerticalTextAlignment = TextAlignment.Center;
            LBEndLine.FontFamily = Settings.ArabicFontFamily;

            EndLine.Children.Add(LBEndLine);




           

            //MainDetails.Children.Add(EndLine);

            LBError = new Label();
            LBError.WidthRequest = Labelheight;
            LBError.HeightRequest = Labelheight;

            LBError.Text = "";
            MainDetails.Children.Add(LBError);
            orderLists = new List<OrderList>();
            AILoading = new ActivityIndicator();
            AILoading.Color = Settings.MainColor;
            AILoading.IsRunning = false;
            AILoading.WidthRequest = Labelheight * 6;
            AILoading.HeightRequest = Labelheight * 6;
            Container.Children.Add(AILoading, new Point(w / 2 - AILoading.WidthRequest / 2, h / 2 - AILoading.HeightRequest / 2));
            //events
            ImgMarket.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgMarketClick())
            });
            ImgFavorite.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgFavoriteClick())
            });
           
            ImgBack.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgBackClickAsync())
            });
            ImgLeftSide.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgLeftSideClick())
            });
            ImgRightSide.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgRightSideClick())
            });
            ImgStar.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgStarClickAsync())
            });
        }

        private async void ImgStarClickAsync()
        {
            if (Settings.cash.LoggedIn == false)
            {
                Settings.Message = "لابد من تسجيل الدخول اولا";
                return;
            }
            LaterNotification laterNotification = new LaterNotification();
            laterNotification.Id = Settings.cash.UserInfo.UserId;
            laterNotification.Name = prouductDetails.ProuductName;
            new Task(async () =>
            {
                await Settings.InsertNotificationAsync(laterNotification);
            }).Start();
            LaterOrder Order = new LaterOrder(w, h, home);
            await home.Navigation.PushPopupAsync(Order);
            //double price = 0;
            //if (orderLists != null)
            //    orderLists.Clear();


            //    int Amount = 1;
            //    orderLists.Add
            //      (
            //        new OrderList
            //        {
            //            Amount = Amount,
            //            OrderId = 0,
            //            Price = Convert.ToDouble(prouductDetails.Price),
            //            ProuductId = prouductDetails.ProductID
            //        }
            //      );

            //    price = Convert.ToDouble(prouductDetails.Price);

            //MakeOrder Order = new MakeOrder(w, h, home);
            //Order.Price = price.ToString();
            //Order.orderLists = orderLists;
            //Order.order.OrderExcuteTime = DateTime.UtcNow.AddDays(10).ToString("yyyy-MM-dd HH:mm:ss");
            //Order.Cairo = Settings.CairoDelviryFees.ToString();
            //Order.OutCairo = Settings.OutDeliveryFees.ToString();
            //Order.SetData();
            //Order.Type = "New";

            //await home.Navigation.PushPopupAsync(Order);

        }

        private void ImgRightSideClick()
        {

            if (Counter == 6)
            {
                Counter = 1;

                ImgMainPhoto.Source = prouductDetails.FirstYear;
            }
            else if (Counter == 1)
            {
                Counter++;
                ImgMainPhoto.Source = prouductDetails.SecondPhoto;

            }
            else if (Counter == 2)
            {
                Counter++;

                ImgMainPhoto.Source = prouductDetails.ThirdPhoto;
            }
            else if (Counter == 3)
            {
                Counter++; ;

                ImgMainPhoto.Source = prouductDetails.FourthPhoto;
            }
            else if (Counter == 4)
            {
                Counter++;

                ImgMainPhoto.Source = prouductDetails.FifthPhoto;
            }
            else if (Counter == 5)
            {
                Counter++;

                ImgMainPhoto.Source = prouductDetails.SixthPhoto;
            }
            else
            {

            }
        }

        private void ImgLeftSideClick()
        {

            if (Counter == 0)
            {
                Counter = 5;

                ImgMainPhoto.Source = prouductDetails.SixthPhoto;
            }
            else if (Counter == 1)
            {
                Counter--;
                ImgMainPhoto.Source = prouductDetails.FifthPhoto;

            }
            else if (Counter == 2)
            {
                Counter--;

                ImgMainPhoto.Source = prouductDetails.FourthPhoto;
            }
            else if (Counter == 3)
            {
                Counter--;

                ImgMainPhoto.Source = prouductDetails.ThirdPhoto;
            }
            else if (Counter == 4)
            {
                Counter--;

                ImgMainPhoto.Source = prouductDetails.SecondPhoto;
            }
            else if (Counter == 5)
            {
                Counter--;

                ImgMainPhoto.Source = prouductDetails.FirstPhoto;
            }
            else
            {

            }
        }
        public async void ImgBackClickAsync()
        {
            //home.SendBackButtonPressed();
            Settings.PageStack.Pop();
            Settings.PageStack.Pop();
            AILoading.IsRunning = true;
            Settings.prouductPage.Type = "Materials";
            await Settings.prouductPage.SetDataAsync();
            AILoading.IsRunning = false;
            home.Content = Settings.prouductPage.MainLayout;
        }


        private void ImgFavoriteClick()
        {
            try
            {
                if (Settings.cash.LoggedIn == false)
                {
                    Settings.Message = "لابد من تسجيل الدخول اولا";
                    return;
                }
                bool found = false;
                int index = prouductDetails.ProductID;
                if (!ImgFavoritrGray)
                {
                    for (int i = 0; i < Settings.cash.FavoriteList.Count; i++)
                    {
                        if (Settings.cash.FavoriteList[i].ProductID.ToString() == index.ToString())
                        {
                            Settings.cash.FavoriteList.RemoveAt(i);
                            new Task(async () =>
                            {
                                Settings.prouductPage.Type = "Materials";
                                AddFavorite MyObject = new AddFavorite();
                                MyObject.UserID = Settings.cash.UserInfo.UserId;
                                MyObject.ProuductID = index.ToString();
                                String Content = JsonConvert.SerializeObject(MyObject);
                                Settings.DeleteFavoriteAsync(MyObject);
                            }).Start();
                            Settings.SaveCash();

                            break;
                        }

                    }


                    ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                    Settings.Message = "تم حذف المنتج من المفضلة";
                    ImgFavoritrGray = true;
                }
                else
                {
                    for (int i = 0; i < Settings.cash.FavoriteList.Count; i++)
                    {
                        if (Settings.cash.FavoriteList[i].ProductID.ToString() == index.ToString())
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {


                        Settings.cash.FavoriteList.Add(prouductDetails);





                        ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                        new Task(async () =>
                        {
                            Settings.prouductPage.Type = "Materials";
                            AddFavorite MyObject = new AddFavorite();
                            MyObject.UserID = Settings.cash.UserInfo.UserId;
                            MyObject.ProuductID = index.ToString();
                            String Content = JsonConvert.SerializeObject(MyObject);
                            Settings.AddFavoriteAsync(MyObject);
                        }).Start();
                        Settings.SaveCash();

                        Settings.Message = "تم اضافة المنتج للمفضلة";
                        ImgFavoritrGray = false;
                    }

                    else
                    {
                        //Settings.Message = "  لم تتم اضافة المنتج للمفضلة";
                        ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                    }
                }
            }
            catch
            {

            }
        }

        private void ImgMarketClick()
        {
            try
            {
                if (Settings.cash.LoggedIn == false)
                {
                    Settings.Message = "لابد من تسجيل الدخول اولا";
                    return;
                }
                bool found = false;
                int index = prouductDetails.ProductID;
                if (!ImgMarketGray)
                {
                    for (int i = 0; i < Settings.cash.CartList.Count; i++)
                    {
                        if (Settings.cash.CartList[i].ProductID.ToString() == index.ToString())
                        {
                            Settings.cash.CartList.RemoveAt(i);
                            Settings.prouductPage.Type = "Materials";
                            //Settings.prouductPage.SetDataAsync();
                            Settings.SaveCash();
                            break;
                        }

                    }

                    ImgMarketGray = true;
                    ImgMarket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
                    Settings.Message = "تم حذف المنتج من السلة";
                    //Marcket.Text = "F";
                    //ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
                }
                else
                {
                    for (int i = 0; i < Settings.cash.CartList.Count; i++)
                    {
                        if (Settings.cash.CartList[i].ProductID.ToString() == index.ToString())
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {

                        Settings.cash.CartList.Add(prouductDetails);
                        //Settings.prouductPage.Type = "Materials";
                        //Settings.prouductPage.SetDataAsync();
                        Settings.SaveCash();
                        Settings.Message = "تم اضافة المنتج للسلة";
                        ImgMarketGray = false;
                        ImgMarket.Source = ImageSource.FromResource("DentalShop.Images.OrangeBag.png");
                    }
                }
                Settings.prouductPage.LBItemNumber.Text = Settings.cash.CartList.Count.ToString();
                Settings.mainPage.LItemNumber.Text = Settings.cash.CartList.Count.ToString();
                Settings.studentProuduct.LBItemNumber.Text = Settings.cash.CartList.Count.ToString();
            }
            catch
            {

            }
        }
            


        public void SetData()
        {
            LBBrief.Text = prouductDetails.ProuductDescription;
            LBPrice.Text = prouductDetails.Price + " جنية مصري";
            ImgMainPhoto.Source = prouductDetails.FirstPhoto;
            LBExDateTitle.Text = "تاريخ الانتهاء";
            LBGuarantee.Text = prouductDetails.Guarantee;
            LBExDate.Text = prouductDetails.EXDate;
            LBMadeIn.Text = prouductDetails.MadeIn;
        }

    }
}
