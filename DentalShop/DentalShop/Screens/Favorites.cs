using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentalShop
{
    public class Favorites
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
        Image ImgBack;
        SearchBar SBSearch;
        Image ImgHeart;
        Label LBItemNumber;
        Label LBNoData;
        List<ProuductView> ProudectList;
        List<ProuductView> ProudectList2;
        StackLayout LVProudect;
        StackLayout LVProudect2;

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
        public static GetProuduct getProuduct = new GetProuduct();

        public Favorites(int w, int h, HomePage home)
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
            Scroll.ScrollToAsync(0, 0, false);
            MainLayout = new Grid();
            MainLayout.RowSpacing = 0;
            MainLayout.BackgroundColor = Color.White;
            MainLayout.RowDefinitions.Add(new RowDefinition { Height = LBTop.HeightRequest + 10 + SBSearch.HeightRequest + 10 });
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
            MenuBar.BackgroundColor = Color.White;
            MenuBar.WidthRequest = w;
            MenuBar.HeightRequest = Labelheight * 2 + 20;


            LBTop = new Label();
            LBTop.WidthRequest = w;
            LBTop.TextColor = Color.White;
            LBTop.HeightRequest = Labelheight + 20;
            LBTop.FontSize = FontSize + 8;
            LBTop.Text = "المفضلة";
            LBTop.BackgroundColor = Settings.MainColor;
            LBTop.HorizontalTextAlignment = TextAlignment.Center;
            LBTop.VerticalTextAlignment = TextAlignment.Center;
            LBTop.FontFamily = Settings.ArabicFontFamily;
            MenuBar.Children.Add(LBTop, new Point(0, 0));




            //img back
            ImgBack = new Image();
            ImgBack.Aspect = Aspect.Fill;
            ImgBack.Source = ImageSource.FromResource("DentalShop.Images.whiteback.png");
            ImgBack.WidthRequest = Labelheight;
            ImgBack.HeightRequest = Labelheight;
            MenuBar.Children.Add(ImgBack, new Point(10, 10));


            double ypoint = 10 + LBTop.HeightRequest; ;


            ImgHeart = new Image();
            ImgHeart.Aspect = Aspect.Fill;
            ImgHeart.Source = ImageSource.FromResource("DentalShop.Images.FavoritesLogo.png");
            ImgHeart.WidthRequest = Labelheight;
            ImgHeart.HeightRequest = Labelheight;
            MenuBar.Children.Add(ImgHeart, new Point(w - 15 - ImgHeart.WidthRequest, ypoint));

            LBItemNumber = new Label();
            LBItemNumber.WidthRequest = ImgHeart.WidthRequest;
            LBItemNumber.TextColor = Settings.GrayColor;
            LBItemNumber.HeightRequest = Labelheight;
            LBItemNumber.FontSize = FontSize - 2;
            LBItemNumber.Text = "123";
            LBItemNumber.HorizontalTextAlignment = TextAlignment.Center;
            LBItemNumber.VerticalTextAlignment = TextAlignment.Center;
            LBItemNumber.FontFamily = Settings.ArabicFontFamily;
            MenuBar.Children.Add(LBItemNumber, new Point(w - 15 - ImgHeart.WidthRequest, ypoint + ImgHeart.HeightRequest));


            SBSearch = new SearchBar();
            SBSearch.WidthRequest = width - 40 - ImgHeart.WidthRequest;
            SBSearch.HeightRequest = ButtonHeight;
            SBSearch.FontSize = FontSize;
            SBSearch.HorizontalTextAlignment = TextAlignment.End;
            SBSearch.PlaceholderColor = new Color(218.0 / 255, 218.0 / 255, 218.0 / 255);
            SBSearch.Placeholder = "ابحث عن منتجات هنا";
            SBSearch.BackgroundColor = Color.White;
            Point SBSearchLocation = new Point(20, ypoint - 5);
            MenuBar.Children.Add(SBSearch, SBSearchLocation);
            SBSearch.TextChanged += SBSearch_TextChangedAsync;



            LBNoData = new Label();
            LBNoData.WidthRequest = w - 40; ;
            LBNoData.HeightRequest = 25;
            LBNoData.TextColor = Settings.MainColor;
            LBNoData.FontSize = FontSize;
            LBNoData.HorizontalTextAlignment = TextAlignment.Center;
            LBNoData.IsVisible = false;
            LBNoData.FontAttributes = FontAttributes.Bold;
            LBNoData.Text = "لا يوجد منتجات مفضلة ";
            LBNoData.FontFamily = Settings.ArabicFontFamily;

            Container.Children.Add(LBNoData, new Point(35, 0));


            LVProudect = new StackLayout();
            LVProudect.WidthRequest = (w - 80) / 2;
            Settings.width = (w - 80) / 2;
            Settings.height = 200;
            LVProudect.BackgroundColor = Color.White;
            Container.Children.Add(LVProudect, new Point(45, 10));


            LVProudect2 = new StackLayout();
            LVProudect2.WidthRequest = (w - 80) / 2;
            Settings.width = (w - 80) / 2;
            Settings.height = 200;
            LVProudect2.Margin = new Thickness(0, 0, 0, 5);

            Container.Children.Add(LVProudect2, new Point(45 + LVProudect.WidthRequest + 15, 10));

            //events

            ImgBack.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgBackClick())
            });
        }

        private void SBSearch_TextChangedAsync(object sender, TextChangedEventArgs e)
        {

        }
        public void ImgBackClick()
        {
            home.SendBackButtonPressed();
        }

        public async  Task GetDataAsync()
        {
            LVProudect.Children.Clear();
            LVProudect2.Children.Clear();
            LBNoData.IsVisible = false;
            if (ProudectList != null)
                ProudectList.Clear();
           
                prouductEntity = Settings.cash.FavoriteList.ToArray();
            ProudectList = new List<ProuductView>();
            ProudectList2 = new List<ProuductView>();
            if (prouductEntity.Length == 0)
            {
                LBNoData.IsVisible = true;
            }
            for (int i = 0; i < prouductEntity.Length; i++)
            {
                double price = Convert.ToDouble(prouductEntity[i].Price);
                double discount = Convert.ToDouble(prouductEntity[i].Discount);
                double secoundprice = (100 - discount) / 100 * price;

                string LBName = prouductEntity[i].ProuductName;
                string LBSecondPrice = "";
                bool DiscountPhoto = false;
                string LBDiscoubt = "";
                bool ImgDiscount = false;
                bool DiscountBar = false;
                String Marcket = "F";
                ImageSource MarcketSource = ImageSource.FromResource("DentalShop.Images.bag.png");
                for (int j = 0; j < Settings.cash.CartList.Count; j++)
                {
                    if (Settings.cash.CartList[j].ProductID == prouductEntity[i].ProductID)
                    {
                        Marcket = "T";
                        MarcketSource = ImageSource.FromResource("DentalShop.Images.OrangeBag.png");
                        break;
                    }

                }
                if (prouductEntity[i].Discount != "0" && prouductEntity[i].Discount != null)
                {
                    LBSecondPrice = secoundprice.ToString();
                    DiscountPhoto = true;
                    LBDiscoubt = "تخفيض            " + prouductEntity[i].Discount + " % ";
                    ImgDiscount = true;
                    DiscountBar = true;
                }
                else
                {
                    LBSecondPrice = "ج م";
                    DiscountPhoto = false;
                    LBDiscoubt = "";
                    ImgDiscount = false;
                    DiscountBar = false;
                }


                ProuductView MyObject = new ProuductView();
                MyObject.ImgFavorites.Source = ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                MyObject.ImgDiscount.IsVisible = ImgDiscount;
                MyObject.LBDiscount.Text = LBDiscoubt;
                MyObject.LBDiscount.IsVisible = true;
                MyObject.ImgMarcket.Source = MarcketSource;
                MyObject.FirstPrice.Text = prouductEntity[i].Price;
                MyObject.LBSecondPrice.Text = LBSecondPrice;
                MyObject.LBSecondPrice.IsVisible = true;
                MyObject.ImgMainPhoto.Source = prouductEntity[i].FirstPhoto;
                MyObject.Name.Text = prouductEntity[i].ProuductName;
                MyObject.LBIndex.Text = i.ToString();
                MyObject.ImgDiscountBar.IsVisible = DiscountBar;
                MyObject.Favorite.Text = "T";
                MyObject.Marcket.Text = Marcket;
                MyObject.Type.Text = prouductEntity[i].Type;
                MyObject.ListLocation.Text = "Favorite";
                MyObject.LBID.Text = prouductEntity[i].ProductID.ToString();

                if (i % 2 == 0)
                    ProudectList.Add(MyObject);
                else
                    ProudectList2.Add(MyObject);
                if (prouductEntity[i].Discount != "0" && prouductEntity[i].Discount != null)
                {

                    prouductEntity[i].Price = secoundprice.ToString();
                }



           

            }
            LBItemNumber.Text = prouductEntity.Length.ToString();
            //Scroll.ScrollToAsync(0, 0, false);
            for (int i = 0; i < ProudectList.Count; i++)
                LVProudect.Children.Add(ProudectList[i]);
            for (int i = 0; i < ProudectList2.Count; i++)
                LVProudect2.Children.Add(ProudectList2[i]);
        }
    }
}
