using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentalShop
{
    public class ProuductView :AbsoluteLayout
    {
        public Image ImgMarcket;
        public Image ImgMoreDeatils;
        public Image ImgFavorites;

        public Image ImgMainPhoto;
        public Image ImgDiscount;
        public Label LBDiscount;
        public Image ImgPrice;
        public Label FirstPrice;
        public Image ImgDiscountBar;
        public Label LBSecondPrice;
        public Label Name;
        public Label LBIndex;
        public Label Favorite;
        public Label Marcket;
        public Label Type;
        public Label ListLocation;
        public Label LBID;
        public Label PriceLabel; // New price label declaration
        public Label OldPriceLabel;
        public Label OutOfStockLabel;
        public ProuductView ()
        {
            AbsoluteLayout MainLayout = this;
            MainLayout.WidthRequest = Settings.width;
            MainLayout.HeightRequest = Settings.height;
            MainLayout.BackgroundColor = Color.White;
            AbsoluteLayout Container = new AbsoluteLayout();
            Container.WidthRequest = MainLayout.WidthRequest;
            Container.HeightRequest = MainLayout.HeightRequest - 5;
            Container.BackgroundColor = Color.White;
            /////////////////////////////////////////////////////////////////////
            // Add tap gesture to the entire container
            Container.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgMoreDeatilsClick())
            });
            ////////////////////////////////////////////////////////////////////

            double FontSize = 7;
             
            double ypoint = 0;
            ImgMainPhoto = new Image();
            ImgMainPhoto.WidthRequest = Settings.width;
            ImgMainPhoto.Aspect = Aspect.Fill;
            ImgMainPhoto.HeightRequest = MainLayout.HeightRequest*0.6;
            Container.Children.Add(ImgMainPhoto, new Point(0, ypoint));


            ImgDiscount = new Image();
            ImgDiscount.Aspect = Aspect.Fill;
            ImgDiscount.WidthRequest = Settings.Labelheight * 1.3;
            ImgDiscount.HeightRequest = Settings.Labelheight * 1.3;
           // ImgDiscount.Source = ImageSource.FromResource("DentalShop.Images.Discount.png");
           // Container.Children.Add(ImgDiscount, new Point(ImgMainPhoto.WidthRequest - 5 - ImgDiscount.WidthRequest, ypoint));

            LBDiscount = new Label();
            LBDiscount.WidthRequest = ImgDiscount.WidthRequest;
            LBDiscount.HeightRequest = ImgDiscount.HeightRequest;
            LBDiscount.TextColor = Color.White;
            LBDiscount.FontSize = FontSize;
            LBDiscount.HorizontalTextAlignment = TextAlignment.Center;
            LBDiscount.VerticalTextAlignment = TextAlignment.Center;
            // LBDiscount.FontFamily = Settings.ArabicFontFamily;
           // Container.Children.Add(LBDiscount, new Point(ImgMainPhoto.WidthRequest - 5 - ImgDiscount.WidthRequest, ypoint - 2));



            ImgPrice = new Image();
            ImgPrice.Aspect = Aspect.Fill;
            ImgPrice.WidthRequest = Settings.Labelheight*1.3;
            ImgPrice.HeightRequest = Settings.Labelheight*1.3;
           // ImgPrice.Source = ImageSource.FromResource("DentalShop.Images.Circle.png");
           // Container.Children.Add(ImgPrice, new Point(5, ypoint));




            FirstPrice = new Label();
            FirstPrice.WidthRequest = ImgPrice.WidthRequest-4;
            FirstPrice.HeightRequest = ImgPrice.HeightRequest/2-4;
            FirstPrice.TextColor = Color.White;
            FirstPrice.FontSize = FontSize ;
            FirstPrice.HorizontalTextAlignment = TextAlignment.Center;
            FirstPrice.VerticalTextAlignment = TextAlignment.Center;
            //FirstPrice.FontFamily = Settings.ArabicFontFamily;
           // Container.Children.Add(FirstPrice, new Point(5, ypoint+3));


            ImgDiscountBar = new Image();
            ImgDiscountBar.Aspect = Aspect.Fill;
            ImgDiscountBar.WidthRequest = FirstPrice.WidthRequest-12;
            ImgDiscountBar.HeightRequest = 4;
           // ImgDiscountBar.Source = ImageSource.FromResource("DentalShop.Images.DiscountPrice.png");
           // Container.Children.Add(ImgDiscountBar, new Point(11, ypoint+FirstPrice.HeightRequest/2+2));


            ypoint += FirstPrice.HeightRequest;

            LBSecondPrice = new Label();
            LBSecondPrice.WidthRequest = ImgPrice.WidthRequest - 4;
            LBSecondPrice.HeightRequest = ImgPrice.HeightRequest / 2 ;
            LBSecondPrice.TextColor = Color.White;
            LBSecondPrice.FontSize = FontSize ;
            LBSecondPrice.HorizontalTextAlignment = TextAlignment.Center;
            LBSecondPrice.VerticalTextAlignment = TextAlignment.Center;
            //LBSecondPrice.FontFamily = Settings.ArabicFontFamily;
           // Container.Children.Add(LBSecondPrice, new Point(5, ypoint));





            ypoint = ImgMainPhoto.HeightRequest-Settings.Labelheight*1.5;


            Image ImgNameBackground = new Image();
            ImgNameBackground.Aspect = Aspect.Fill;
            ImgNameBackground.WidthRequest = ImgMainPhoto.WidthRequest;
            ImgNameBackground.HeightRequest = Settings.Labelheight*1.5;
           // ImgNameBackground.Source = ImageSource.FromResource("DentalShop.Images.rectangle-prduct-name.png");
            Container.Children.Add(ImgNameBackground, new Point(0, ypoint));

            ypoint += 1;

            Name = new Label();
            //Name.WidthRequest = ImgNameBackground.WidthRequest - 5;
            //Name.HeightRequest = ImgNameBackground.HeightRequest; 
            Name.WidthRequest = AutoSize;
            Name.HeightRequest = Settings.Labelheight * 4;
            // Name.TextColor = Settings.MainColor;
            Name.TextColor = Color.FromHex("#003366"); // blue color, you can change this
            Name.FontSize = Settings.FontSize ;
            Name.FontAttributes = FontAttributes.Bold;
            Name.HorizontalTextAlignment = TextAlignment.Center;
            Name.VerticalTextAlignment = TextAlignment.Center;
            Name.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(Name, new Point(2.5, ypoint));

            ypoint = ImgMainPhoto.HeightRequest + 30;//30


            double xpoint = 0;

           

            double ImgWidthSize = 0;
            double  ImgHightSize = 0;

       

            ImgMarcket = new Image();
            ImgMarcket.Aspect = Aspect.Fill;
            ImgMarcket.WidthRequest = Settings.Labelheight*1.15;
            ImgMarcket.HeightRequest = Settings.Labelheight*1.15;
            Container.Children.Add(ImgMarcket, new Point(7, ypoint));


          

            // Add price label instead of More Details image
            PriceLabel = new Label
            {
                WidthRequest = Settings.Labelheight * 2.3,
                HeightRequest = Settings.Labelheight * 1.15,
                TextColor = Color.FromHex("#003366"), // blue color, you can change this
                FontSize = Settings.FontSize,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontFamily = Settings.ArabicFontFamily
            };
            
            Container.Children.Add(PriceLabel, new Point(MainLayout.WidthRequest / 2 - PriceLabel.WidthRequest / 2, ypoint+4));

            ypoint += 10;
            // Add the past price (strikethrough price) label
            OldPriceLabel = new Label
            {
                WidthRequest = Settings.Labelheight * 2.3,
                HeightRequest = Settings.Labelheight * 0.8,  // Make it slightly smaller than the current price
                TextColor = Color.FromHex("#99003366"),  // Using the same blue but with opacity
                FontSize = Settings.FontSize - 2,  // Slightly smaller font
                TextDecorations = TextDecorations.Strikethrough,  // This is the correct property  // Add strikethrough effect
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontFamily = Settings.ArabicFontFamily
            };

            // Add the old price label slightly above the current price
            Container.Children.Add(OldPriceLabel, new Point(MainLayout.WidthRequest / 2 - PriceLabel.WidthRequest / 2, ypoint +20));


            //ImgMoreDeatils = new Image();
            //ImgMoreDeatils.Aspect = Aspect.Fill;
            //ImgMoreDeatils.WidthRequest = Settings.Labelheight*2.3;
            //ImgMoreDeatils.HeightRequest = Settings.Labelheight*1.15;    
            //ImgMoreDeatils.Source = ImageSource.FromResource("DentalShop.Images.Details.png");
            //Container.Children.Add(ImgMoreDeatils, new Point(MainLayout.WidthRequest/2-ImgMoreDeatils.WidthRequest/2, ypoint+4));


            ImgFavorites = new Image();
            ImgFavorites.Aspect = Aspect.Fill;
            ImgFavorites.WidthRequest = Settings.Labelheight*1.15;
            ImgFavorites.HeightRequest = Settings.Labelheight*1.15;

            Container.Children.Add(ImgFavorites, new Point( ImgMainPhoto.WidthRequest-7-ImgFavorites.WidthRequest,ypoint));

            ypoint += ImgFavorites.HeightRequest;


            LBIndex = new Label();
            LBIndex.WidthRequest = Container.WidthRequest;
            LBIndex.HeightRequest = Settings.Labelheight - 3;
            LBIndex.Text = "";
            LBIndex.IsVisible=false;
            LBIndex.HorizontalTextAlignment = TextAlignment.Center;
            Container.Children.Add(LBIndex, new Point(0,ypoint ));


            Marcket = new Label();
            Marcket.Text = "";
            Marcket.IsVisible = false;
            Marcket.HorizontalTextAlignment = TextAlignment.Center;
            Container.Children.Add(Marcket, new Point(0, ypoint));


            Favorite = new Label();
            Favorite.Text = "";
            Favorite.IsVisible = false;
            Favorite.HorizontalTextAlignment = TextAlignment.Center;
            Container.Children.Add(Favorite, new Point(0, ypoint));


            Type = new Label();
            Type.Text = "";
            Type.IsVisible = false;
            Type.HorizontalTextAlignment = TextAlignment.Center;
            Container.Children.Add(Type, new Point(0, ypoint));


            ListLocation = new Label();
            ListLocation.Text = "";
            ListLocation.IsVisible = false;
            ListLocation.HorizontalTextAlignment = TextAlignment.Center;
            Container.Children.Add(ListLocation, new Point(0, ypoint));

            LBID = new Label();
            LBID.Text = "";
            LBID.IsVisible = false;
            LBID.SetBinding(Label.TextProperty, "LBID");
            LBID.HorizontalTextAlignment = TextAlignment.Center;
            Container.Children.Add(LBID, new Point(0, ypoint));

            MainLayout.Children.Add(Container, new Point(0, 0));

            OutOfStockLabel = new Label
            {
                Text = "Out of Stock",
                TextColor = Color.Red,
                FontSize = 21,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                IsVisible = false // Default is hidden
            };

            Container.Children.Add(OutOfStockLabel, new Point(15, (MainLayout.HeightRequest / 2)-30));

            //events 
            ImgFavorites.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgFavoritesClickAsync())
            });
            ImgMarcket.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgMarcketClickAsync())
            });
            //ImgMoreDeatils.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => ImgMoreDeatilsClick())
            //});
   
        }



        public void ImgMoreDeatilsClick()
        {
             if  (Favorite.Text == "T")
            {
                Settings.proudectDeivceDetails.ImgFavoritrGray = false;
                Settings.proudectEquipmentDetails.ImgFavoritrGray = false;
                Settings.proudectMaterialsDetails.ImgFavoritrGray = false;
                Settings.proudectsMachinesDetails.ImgFavoritrGray = false;
                Settings.proudectStudentDetails.ImgFavoritrGray = false;
                Settings.prouductCorrectionDetails.ImgFavoritrGray = false;
                Settings.ClothesDetails.ImgFavoritrGray = false;
                Settings.FilesDetails.ImgFavoritrGray = false;

                Settings.proudectDeivceDetails.ImgFavorite.Source= ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                Settings.proudectEquipmentDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                Settings.proudectMaterialsDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                Settings.proudectsMachinesDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                Settings.proudectStudentDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                Settings.prouductCorrectionDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                Settings.ClothesDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                Settings.FilesDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.RedHeart.png");

            }
             else
            {
                Settings.proudectDeivceDetails.ImgFavoritrGray = true;
                Settings.proudectEquipmentDetails.ImgFavoritrGray = true;
                Settings.proudectMaterialsDetails.ImgFavoritrGray = true;
                Settings.proudectsMachinesDetails.ImgFavoritrGray = true;
                Settings.proudectStudentDetails.ImgFavoritrGray = true;
                Settings.prouductCorrectionDetails.ImgFavoritrGray = true;
                Settings.ClothesDetails.ImgFavoritrGray = true;
                Settings.FilesDetails.ImgFavoritrGray = true;

                Settings.proudectDeivceDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                Settings.proudectEquipmentDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                Settings.proudectMaterialsDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                Settings.proudectsMachinesDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                Settings.proudectStudentDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                Settings.prouductCorrectionDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                Settings.ClothesDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                Settings.FilesDetails.ImgFavorite.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
            }
            if (Marcket.Text == "T")
            {
                Settings.proudectDeivceDetails.ImgMarketGray = false;
                Settings.proudectEquipmentDetails.ImgMarketGray = false;
                Settings.proudectMaterialsDetails.ImgMarketGray = false;
                Settings.proudectsMachinesDetails.ImgMarketGray = false;
                Settings.proudectStudentDetails.ImgMarketGray = false;
                Settings.prouductCorrectionDetails.ImgMarketGray = false;
                Settings.ClothesDetails.ImgMarketGray = false;
                Settings.FilesDetails.ImgMarketGray = false;

                Settings.proudectDeivceDetails.ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.OrangeBag.png");
                Settings.proudectEquipmentDetails.ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.OrangeBag.png");
                Settings.proudectMaterialsDetails.ImgMarket.Source = ImageSource.FromResource("DentalShop.Images.OrangeBag.png");
                Settings.proudectsMachinesDetails.ImgMarket.Source = ImageSource.FromResource("DentalShop.Images.OrangeBag.png");
                Settings.proudectStudentDetails.ImgMarket.Source = ImageSource.FromResource("DentalShop.Images.OrangeBag.png");
                Settings.prouductCorrectionDetails.ImgMarket.Source = ImageSource.FromResource("DentalShop.Images.OrangeBag.png");
                Settings.ClothesDetails.ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.OrangeBag.png");
                Settings.FilesDetails.ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.OrangeBag.png");

            }
            else
            {
                Settings.proudectDeivceDetails.ImgMarketGray = true;
                Settings.proudectEquipmentDetails.ImgMarketGray = true;
                Settings.proudectMaterialsDetails.ImgMarketGray = true;
                Settings.proudectsMachinesDetails.ImgMarketGray = true;
                Settings.proudectStudentDetails.ImgMarketGray = true;
                Settings.prouductCorrectionDetails.ImgMarketGray = true;
                Settings.ClothesDetails.ImgMarketGray = true;
                Settings.FilesDetails.ImgMarketGray = true;

                Settings.proudectDeivceDetails.ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
                Settings.proudectEquipmentDetails.ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
                Settings.proudectMaterialsDetails.ImgMarket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
                Settings.proudectsMachinesDetails.ImgMarket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
                Settings.proudectStudentDetails.ImgMarket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
                Settings.prouductCorrectionDetails.ImgMarket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
                Settings.ClothesDetails.ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
                Settings.FilesDetails.ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
            }
            int index = Convert.ToInt32(LBIndex.Text);

            if (Type.Text == "Devices")
            {
                Settings.prouductPage.Type = "Devices";
                if (ListLocation.Text== "ProuductPage")
                Settings.proudectDeivceDetails.prouductDetails = Settings.prouductPage.ProudctEntity[index];
                else if (ListLocation.Text == "Favorite")
                    Settings.proudectDeivceDetails.prouductDetails = Settings.favorites.ProudctEntity[index];
                else
                    Settings.proudectDeivceDetails.prouductDetails = Settings.studentProuduct.ProudctEntity[index];
                Settings.proudectDeivceDetails.SetData();
                Settings.prouductPage.ProuductDetails();
            }
            else if (Type.Text == "Correction")
            {
                Settings.prouductPage.Type = "Correction";
                if (ListLocation.Text == "ProuductPage")
                    Settings.prouductCorrectionDetails.prouductDetails = Settings.prouductPage.ProudctEntity[index];
                else if (ListLocation.Text == "Favorite")
                    Settings.prouductCorrectionDetails.prouductDetails = Settings.favorites.ProudctEntity[index];
                else
                    Settings.prouductCorrectionDetails.prouductDetails = Settings.studentProuduct.ProudctEntity[index];
                Settings.prouductCorrectionDetails.SetData();
                Settings.prouductPage.ProuductDetails();
            }
            else if (Type.Text == "Machines")
            {
                Settings.prouductPage.Type = "Machines";
                if (ListLocation.Text == "ProuductPage")
                    Settings.proudectsMachinesDetails.prouductDetails = Settings.prouductPage.ProudctEntity[index];
                else if (ListLocation.Text == "Favorite")
                    Settings.proudectsMachinesDetails.prouductDetails = Settings.favorites.ProudctEntity[index];
                else
                    Settings.proudectsMachinesDetails.prouductDetails = Settings.studentProuduct.ProudctEntity[index];
                Settings.proudectsMachinesDetails.SetData();
                Settings.prouductPage.ProuductDetails();
            }
            else if (Type.Text == "Equipment")
            {
                Settings.prouductPage.Type = "Equipment";
                if (ListLocation.Text == "ProuductPage")
                    Settings.proudectEquipmentDetails.prouductDetails = Settings.prouductPage.ProudctEntity[index];
                else if (ListLocation.Text == "Favorite")
                    Settings.proudectEquipmentDetails.prouductDetails = Settings.favorites.ProudctEntity[index];
                else
                    Settings.proudectEquipmentDetails.prouductDetails = Settings.studentProuduct.ProudctEntity[index];
                Settings.proudectEquipmentDetails.SetData();
                Settings.prouductPage.ProuductDetails();
            }
            else if (Type.Text == "Materials")
            {
                Settings.prouductPage.Type = "Materials";
                if (ListLocation.Text == "ProuductPage")
                    Settings.proudectMaterialsDetails.prouductDetails = Settings.prouductPage.ProudctEntity[index];
                else if (ListLocation.Text == "Favorite")
                    Settings.proudectMaterialsDetails.prouductDetails = Settings.favorites.ProudctEntity[index];
                else
                    Settings.proudectMaterialsDetails.prouductDetails = Settings.studentProuduct.ProudctEntity[index];
                Settings.proudectMaterialsDetails.SetData();
                Settings.prouductPage.ProuductDetails();
            }
            else if (Type.Text == "Clothes")
            {
                Settings.prouductPage.Type = "Clothes";
                if (ListLocation.Text == "ProuductPage")
                    Settings.ClothesDetails.prouductDetails = Settings.prouductPage.ProudctEntity[index];
                else if (ListLocation.Text == "Favorite")
                    Settings.ClothesDetails.prouductDetails = Settings.favorites.ProudctEntity[index];
                else
                    Settings.ClothesDetails.prouductDetails = Settings.studentProuduct.ProudctEntity[index];
                Settings.ClothesDetails.SetData();
                Settings.prouductPage.ProuductDetails();
            }
            else if (Type.Text == "Files")
            {
                Settings.prouductPage.Type = "Files";
                if (ListLocation.Text == "ProuductPage")
                    Settings.FilesDetails.prouductDetails = Settings.prouductPage.ProudctEntity[index];
                else if (ListLocation.Text == "Favorite")
                    Settings.FilesDetails.prouductDetails = Settings.favorites.ProudctEntity[index];
                else
                    Settings.FilesDetails.prouductDetails = Settings.studentProuduct.ProudctEntity[index];
                Settings.FilesDetails.SetData();
                Settings.prouductPage.ProuductDetails();
            }
            else if (Type.Text == "")
            {
                Settings.prouductPage.Type = "Student";
                if (ListLocation.Text == "Student")
                    Settings.proudectStudentDetails.prouductDetails = Settings.studentProuduct.ProudctEntity[index];
                else 
                    Settings.proudectStudentDetails.prouductDetails = Settings.favorites.ProudctEntity[index];
               
                Settings.proudectStudentDetails.SetData();
                Settings.prouductPage.ProuductDetails();
            }
            else
            {

            }
        }

        public async void ImgMarcketClickAsync()
        {
            if (Settings.cash.LoggedIn == false)
            {
                Settings.Message = "لابد من تسجيل الدخول اولا";
                return;
            }
            bool found = false;
            int index = Convert.ToInt32(LBIndex.Text);
            if (Marcket.Text=="T")
            {
                for (int i = 0; i < Settings.cash.CartList.Count; i++)
                {
                    if (Settings.cash.CartList[i].ProductID.ToString() == LBID.Text)
                    {
                        Settings.cash.CartList.RemoveAt(i);
                       
                        Settings.SaveCash();
                        break;
                    }

                }

                Marcket.Text = "F";
                ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
                Settings.Message = "تم حذف المنتج من السلة";
                //Marcket.Text = "F";
                //ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.bag.png");
            }
            else
            {
                for (int i = 0; i < Settings.cash.CartList.Count; i++)
                {
                    if (Settings.cash.CartList[i].ProductID.ToString() == LBID.Text)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    if (ListLocation.Text == "ProuductPage")
                        Settings.cash.CartList.Add(Settings.prouductPage.ProudctEntity[index]);
                    else if (ListLocation.Text == "Favorite")
                        Settings.cash.CartList.Add(Settings.favorites.ProudctEntity[index]);
                    else
                        Settings.cash.CartList.Add(Settings.studentProuduct.ProudctEntity[index]);

                    Settings.SaveCash();
                    Settings.Message = "تم اضافة المنتج للسلة";
                    Marcket.Text = "T";
                    ImgMarcket.Source = ImageSource.FromResource("DentalShop.Images.OrangeBag.png");
                }
            }
            Settings.prouductPage.LBItemNumber.Text = Settings.cash.CartList.Count.ToString();
            Settings.mainPage.LItemNumber.Text = Settings.cash.CartList.Count.ToString();
            Settings.studentProuduct.LBItemNumber.Text = Settings.cash.CartList.Count.ToString();
        }

        public async void ImgFavoritesClickAsync()
        {
            if (Settings.cash.LoggedIn==false)
            {
                Settings.Message = "لابد من تسجيل الدخول اولا";
                return;
            }
            bool found = false;
            int index = Convert.ToInt32(LBIndex.Text);
            if (Favorite.Text=="T")
            {
                for (int i = 0; i < Settings.cash.FavoriteList.Count; i++)
                {
                    if (Settings.cash.FavoriteList[i].ProductID.ToString() == LBID.Text)
                    {
                        Settings.cash.FavoriteList.RemoveAt(i);
                        new Task(async () =>
                        {
                            AddFavorite MyObject = new AddFavorite();
                            MyObject.UserID = Settings.cash.UserInfo.UserId;
                            MyObject.ProuductID = LBID.Text;
                            String Content = JsonConvert.SerializeObject(MyObject);
                            Settings.DeleteFavoriteAsync(MyObject);
                        }).Start();
                        Settings.SaveCash();
                        if (ListLocation.Text == "Favorite")
                        {
                            await Settings.favorites.GetDataAsync();
                        }
                        break;
                    }
                    
                }

                Favorite.Text = "F";
                ImgFavorites.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                Settings.Message = "تم حذف المنتج من المفضلة";

            }
            else
            {
                for (int i=0; i<Settings.cash.FavoriteList.Count;i++)
                {
                    if (Settings.cash.FavoriteList[i].ProductID.ToString()==LBID.Text)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    if (ListLocation.Text == "ProuductPage")
                        Settings.cash.FavoriteList.Add(Settings.prouductPage.ProudctEntity[index]);
                    else if (ListLocation.Text == "Favorite")
                        Settings.cash.FavoriteList.Add(Settings.favorites.ProudctEntity[index]);
                    else
                        Settings.cash.FavoriteList.Add(Settings.studentProuduct.ProudctEntity[index]);

                    Settings.SaveCash();
                    Settings.Message = "تم اضافة المنتج للمفضلة";
                    Favorite.Text = "T";
                    ImgFavorites.Source = ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                    new Task(async () =>
                    {
                        AddFavorite MyObject = new AddFavorite();
                        MyObject.UserID = Settings.cash.UserInfo.UserId;
                        MyObject.ProuductID = LBID.Text;
                        String Content = JsonConvert.SerializeObject(MyObject);
                        Settings.AddFavoriteAsync(MyObject);
                    }).Start();
                    return;
                }
               
                Favorite.Text = "F";
                Settings.Message = "  لم تتم اضافة المنتج للمفضلة";
                ImgFavorites.Source = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
            }
        }


    }
}
