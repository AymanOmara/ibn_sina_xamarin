using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentalShop
{
    public class StudentProuduct
    {
        int w;
        int h;
        public ScrollView Scroll = new ScrollView();
        AbsoluteLayout Container;
        public Grid MainLayout;
        AbsoluteLayout MenuBar;
        AbsoluteLayout Load;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.White;
        Label LBTop;
        Image ImgControlPanel;
        Image ImgBack;
        SearchBar SBSearch;
        Image ImgCar;
        Image ImgItemNumer;
        public Label LBItemNumber;
        Image ImgTitle;
        public List<ProuductView> ProudectList;
        public List<ProuductView> ProudectList2;
        public StackLayout LVProudect;
        public StackLayout LVProudect2;
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
        public string Type = "Student";
        public GetStudentProuduct getProuduct = new GetStudentProuduct();
        public int CurrentIndex = 1;
        public int LastIndex = 0;
        //public Label LBLoadMore;

        //Label LBA;
        //Label LBB;
        //Label LBC;
        //Label LBD;
        //Label LBE;
        //Label LBF;
        //Label LBG;
        //Label LBH;
        //Label LBI;
        //Label LBJ;
        //Label LBK;
        //Label LBL;
        //Label LBM;
        //Label LBN;
        //Label LBO;
        //Label LBP;
        //Label LBQ;
        //Label LBR;
        //Label LBS;
        //Label LBT;
        //Label LBU;
        //Label LBV;
        //Label LBW;
        //Label LBX;
        //Label LBY;
        //Label LBZ;
        bool Alpha = false;

        Label LBNoData;
        private ActivityIndicator AILoading;
        public static int count = 1;
        public StudentProuduct(int w, int h, HomePage home)
        {
            home.BackgroundColor = LabelColor;
            this.home = home;
            this.w = w;
            this.h = h;
            Container = new AbsoluteLayout();
            Container.WidthRequest = w;
            Container.BackgroundColor = Settings.BackGroundColor;
            Load = new AbsoluteLayout();
            Load.WidthRequest = w - 40;
            Load.HeightRequest = 25;
            Load.BackgroundColor = Settings.BackGroundColor;
            InitializeComponents();
            Scroll.Content = Container;
            // Scroll.ScrollToAsync(0, 0, false);
            MainLayout = new Grid();
            MainLayout.RowSpacing = 0;
            MainLayout.BackgroundColor = Color.White;
            MainLayout.RowDefinitions.Add(new RowDefinition { Height = LBTop.HeightRequest + 10 + SBSearch.HeightRequest + ImgTitle.HeightRequest + 10 });
            MainLayout.RowDefinitions.Add(new RowDefinition());
            MainLayout.RowDefinitions.Add(new RowDefinition { Height = 40 });
            MainLayout.Margin = new Thickness(0, 0, 0, 0);
            MainLayout.Children.Add(Scroll, 0, 1);
            MainLayout.Children.Add(MenuBar, 0, 0);
            MainLayout.Children.Add(Load, 0, 2);
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
            LBTop.BackgroundColor = Settings.MainColor;
            LBTop.HorizontalTextAlignment = TextAlignment.Center;
            LBTop.VerticalTextAlignment = TextAlignment.Center;
            LBTop.FontFamily = Settings.ArabicFontFamily;

            MenuBar.Children.Add(LBTop, new Point(0, 0));


            ImgControlPanel = new Image();
            ImgControlPanel.Aspect = Aspect.Fill;
            ImgControlPanel.Source = ImageSource.FromResource("DentalShop.Images.ControlPanel.png");
            ImgControlPanel.WidthRequest = ImgControlPanel.HeightRequest = LBTop.HeightRequest - 15;
            MenuBar.Children.Add(ImgControlPanel, new Point(w - 15 - ImgControlPanel.WidthRequest, 5));
            ImgControlPanel.IsVisible = false;

            //img back
            ImgBack = new Image();
            ImgBack.Aspect = Aspect.Fill;
            ImgBack.Source = ImageSource.FromResource("DentalShop.Images.whiteback.png");
            ImgBack.WidthRequest = Labelheight;
            ImgBack.HeightRequest = Labelheight;
            MenuBar.Children.Add(ImgBack, new Point(10, 10));


            double ypoint = 10 + LBTop.HeightRequest; ;

            ImgCar = new Image();
            ImgCar.WidthRequest = ImgCar.HeightRequest = LBTop.HeightRequest;


            ImgItemNumer = new Image();
            ImgItemNumer.WidthRequest = ImgItemNumer.HeightRequest = LBTop.HeightRequest - 15;

            SBSearch = new SearchBar();
            SBSearch.WidthRequest = width - 20 - ImgCar.WidthRequest - (ImgItemNumer.WidthRequest / 2);
            SBSearch.HeightRequest = ButtonHeight;
            SBSearch.FontSize = FontSize;
            SBSearch.HorizontalTextAlignment = TextAlignment.Start;
            SBSearch.PlaceholderColor = new Color(218.0 / 255, 218.0 / 255, 218.0 / 255);
            SBSearch.Placeholder = "ابحث عن منتجات هنا";
            SBSearch.BackgroundColor = Color.White;
            Point SBSearchLocation = new Point(10, ypoint);
            MenuBar.Children.Add(SBSearch, SBSearchLocation);
            SBSearch.TextChanged += SBSearch_TextChangedAsync;


            ImgCar.Aspect = Aspect.Fill;
            ImgCar.Source = ImageSource.FromResource("DentalShop.Images.car.png");
            ImgCar.HorizontalOptions = LayoutOptions.Center;
            Point ImgCarLocation = new Point(width - ImgCar.WidthRequest, ypoint + 2);
            MenuBar.Children.Add(ImgCar, ImgCarLocation);



            ImgItemNumer.Aspect = Aspect.Fill;
            ImgItemNumer.Source = ImageSource.FromResource("DentalShop.Images.Circle.png");
            ImgItemNumer.HorizontalOptions = LayoutOptions.Center;
            Point ImgItemNumerLocation = new Point(width - ImgCar.WidthRequest - (ImgItemNumer.WidthRequest / 1.5) + 2, ypoint - 3);
            MenuBar.Children.Add(ImgItemNumer, ImgItemNumerLocation);



            LBItemNumber = new Label();
            LBItemNumber.WidthRequest = ImgItemNumer.WidthRequest / 2;
            LBItemNumber.HeightRequest = ImgItemNumer.HeightRequest / 2;
            LBItemNumber.TextColor = LabelColor;
            LBItemNumber.FontSize = FontSize - 3;
            LBItemNumber.FontAttributes = FontAttributes.Bold;
            LBItemNumber.Text = "8";
            Point LItemNumberLocation = new Point(width - ImgCar.WidthRequest - (ImgItemNumer.WidthRequest / 1.5) + 10, ypoint);
            MenuBar.Children.Add(LBItemNumber, LItemNumberLocation);

            ypoint += 5 + SBSearch.HeightRequest;

            ImgTitle = new Image();
            ImgTitle.Aspect = Aspect.Fill;
            ImgTitle.WidthRequest = w;
            ImgTitle.HeightRequest = w * .12;
            ImgTitle.HorizontalOptions = LayoutOptions.Center;
            MenuBar.Children.Add(ImgTitle, new Point(0, ypoint));

            ypoint += 5 + ImgTitle.HeightRequest;

            LBNoData = new Label();
            LBNoData.WidthRequest = w - 40; ;
            LBNoData.HeightRequest = 20;
            LBNoData.TextColor = Settings.MainColor;
            LBNoData.FontSize = FontSize;
            LBNoData.HorizontalTextAlignment = TextAlignment.Center;
            LBNoData.IsVisible = false;
            LBNoData.FontAttributes = FontAttributes.Bold;
            LBNoData.FontFamily = Settings.ArabicFontFamily;

            LBNoData.Text = "لا يوجد منتجات ";

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


            AILoading = new ActivityIndicator();
            AILoading.Color = Settings.MainColor;
            AILoading.IsRunning = false;
            AILoading.WidthRequest = Labelheight * 6;
            AILoading.HeightRequest = Labelheight * 6;
            Container.Children.Add(AILoading, new Point(w / 2 - AILoading.WidthRequest / 2, h / 2 - AILoading.HeightRequest / 2 - 40));

            //{
            //    ypoint = 5;
            //    LBA = new Label();
            //    LBA.WidthRequest = 30;
            //    LBA.TextColor = Settings.MainColor;
            //    LBA.HeightRequest = 30;
            //    LBA.Text = "A";
            //    LBA.FontSize = FontSize + 5;
            //    LBA.FontAttributes = FontAttributes.Bold;
            //    LBA.HorizontalTextAlignment = TextAlignment.Start;
            //    LBA.VerticalTextAlignment = TextAlignment.Center;
            //    Container.Children.Add(LBA, new Point(10, ypoint));

            //    int PADDING = 4;
            //    ypoint += LBA.WidthRequest + PADDING;

            //    LBB = new Label();
            //    LBB.WidthRequest = LBA.WidthRequest;
            //    LBB.TextColor = Settings.MainColor;
            //    LBB.HeightRequest = LBA.HeightRequest;
            //    LBB.Text = "B";
            //    LBB.FontAttributes = FontAttributes.Bold;
            //    LBB.FontSize = LBA.FontSize;
            //    LBB.HorizontalTextAlignment = TextAlignment.Start;
            //    LBB.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBB, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBC = new Label();
            //    LBC.WidthRequest = LBA.WidthRequest;
            //    LBC.TextColor = Settings.MainColor;
            //    LBC.HeightRequest = LBA.HeightRequest;
            //    LBC.Text = "C";
            //    LBC.FontAttributes = FontAttributes.Bold;
            //    LBC.FontSize = LBA.FontSize;
            //    LBC.HorizontalTextAlignment = TextAlignment.Start;
            //    LBC.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBC, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBD = new Label();
            //    LBD.WidthRequest = LBA.WidthRequest;
            //    LBD.TextColor = Settings.MainColor;
            //    LBD.HeightRequest = LBA.HeightRequest;
            //    LBD.Text = "D";
            //    LBD.FontSize = LBA.FontSize;
            //    LBD.FontAttributes = FontAttributes.Bold;
            //    LBD.HorizontalTextAlignment = TextAlignment.Start;
            //    LBD.VerticalTextAlignment = TextAlignment.Center;
            //    Container.Children.Add(LBD, new Point(10, ypoint));

            //    ypoint += LBA.WidthRequest + PADDING;

            //    LBE = new Label();
            //    LBE.WidthRequest = LBA.WidthRequest;
            //    LBE.TextColor = Settings.MainColor;
            //    LBE.HeightRequest = LBA.HeightRequest;
            //    LBE.Text = "E";
            //    LBE.FontAttributes = FontAttributes.Bold;
            //    LBE.FontSize = LBA.FontSize;
            //    LBE.HorizontalTextAlignment = TextAlignment.Start;
            //    LBE.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBE, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBF = new Label();
            //    LBF.WidthRequest = LBA.WidthRequest;
            //    LBF.TextColor = Settings.MainColor;
            //    LBF.HeightRequest = LBA.HeightRequest;
            //    LBF.Text = "F";
            //    LBF.FontAttributes = FontAttributes.Bold;
            //    LBF.FontSize = LBA.FontSize;
            //    LBF.HorizontalTextAlignment = TextAlignment.Start;
            //    LBF.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBF, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;



            //    LBG = new Label();
            //    LBG.WidthRequest = LBA.WidthRequest;
            //    LBG.TextColor = Settings.MainColor;
            //    LBG.HeightRequest = LBA.HeightRequest;
            //    LBG.Text = "G";
            //    LBG.FontAttributes = FontAttributes.Bold;
            //    LBG.FontSize = LBA.FontSize;
            //    LBG.HorizontalTextAlignment = TextAlignment.Start;
            //    LBG.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBG, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBH = new Label();
            //    LBH.WidthRequest = LBA.WidthRequest;
            //    LBH.TextColor = Settings.MainColor;
            //    LBH.HeightRequest = LBA.HeightRequest;
            //    LBH.Text = "H";
            //    LBH.FontAttributes = FontAttributes.Bold;
            //    LBH.FontSize = LBA.FontSize;
            //    LBH.HorizontalTextAlignment = TextAlignment.Start;
            //    LBH.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBH, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBI = new Label();
            //    LBI.WidthRequest = LBA.WidthRequest;
            //    LBI.TextColor = Settings.MainColor;
            //    LBI.HeightRequest = LBA.HeightRequest;
            //    LBI.Text = "I";
            //    LBI.FontSize = LBA.FontSize;
            //    LBI.FontAttributes = FontAttributes.Bold;
            //    LBI.HorizontalTextAlignment = TextAlignment.Start;
            //    LBI.VerticalTextAlignment = TextAlignment.Center;
            //    Container.Children.Add(LBI, new Point(10, ypoint));

            //    ypoint += LBA.WidthRequest + PADDING;

            //    LBJ = new Label();
            //    LBJ.WidthRequest = LBA.WidthRequest;
            //    LBJ.TextColor = Settings.MainColor;
            //    LBJ.HeightRequest = LBA.HeightRequest;
            //    LBJ.Text = "J";
            //    LBJ.FontAttributes = FontAttributes.Bold;
            //    LBJ.FontSize = LBA.FontSize;
            //    LBJ.HorizontalTextAlignment = TextAlignment.Start;
            //    LBJ.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBJ, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBK = new Label();
            //    LBK.WidthRequest = LBA.WidthRequest;
            //    LBK.TextColor = Settings.MainColor;
            //    LBK.HeightRequest = LBA.HeightRequest;
            //    LBK.Text = "K";
            //    LBK.FontAttributes = FontAttributes.Bold;
            //    LBK.FontSize = LBA.FontSize;
            //    LBK.HorizontalTextAlignment = TextAlignment.Start;
            //    LBK.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBK, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;

            //    LBL = new Label();
            //    LBL.WidthRequest = LBA.WidthRequest;
            //    LBL.TextColor = Settings.MainColor;
            //    LBL.HeightRequest = LBA.HeightRequest;
            //    LBL.Text = "L";
            //    LBL.FontAttributes = FontAttributes.Bold;
            //    LBL.FontSize = LBA.FontSize;
            //    LBL.HorizontalTextAlignment = TextAlignment.Start;
            //    LBL.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBL, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBM = new Label();
            //    LBM.WidthRequest = LBA.WidthRequest;
            //    LBM.TextColor = Settings.MainColor;
            //    LBM.HeightRequest = LBA.HeightRequest;
            //    LBM.Text = "M";
            //    LBM.FontAttributes = FontAttributes.Bold;
            //    LBM.FontSize = LBA.FontSize;
            //    LBM.HorizontalTextAlignment = TextAlignment.Start;
            //    LBM.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBM, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;



            //    LBN = new Label();
            //    LBN.WidthRequest = LBA.WidthRequest;
            //    LBN.TextColor = Settings.MainColor;
            //    LBN.HeightRequest = LBA.HeightRequest;
            //    LBN.Text = "N";
            //    LBN.FontAttributes = FontAttributes.Bold;
            //    LBN.FontSize = LBA.FontSize;
            //    LBN.HorizontalTextAlignment = TextAlignment.Start;
            //    LBN.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBN, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBO = new Label();
            //    LBO.WidthRequest = LBA.WidthRequest;
            //    LBO.TextColor = Settings.MainColor;
            //    LBO.HeightRequest = LBA.HeightRequest;
            //    LBO.Text = "O";
            //    LBO.FontAttributes = FontAttributes.Bold;
            //    LBO.FontSize = LBA.FontSize;
            //    LBO.HorizontalTextAlignment = TextAlignment.Start;
            //    LBO.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBO, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBP = new Label();
            //    LBP.WidthRequest = LBA.WidthRequest;
            //    LBP.TextColor = Settings.MainColor;
            //    LBP.HeightRequest = LBA.HeightRequest;
            //    LBP.Text = "P";
            //    LBP.FontSize = LBA.FontSize;
            //    LBP.FontAttributes = FontAttributes.Bold;
            //    LBP.HorizontalTextAlignment = TextAlignment.Start;
            //    LBP.VerticalTextAlignment = TextAlignment.Center;
            //    Container.Children.Add(LBP, new Point(10, ypoint));

            //    ypoint += LBA.WidthRequest + PADDING;

            //    LBQ = new Label();
            //    LBQ.WidthRequest = LBA.WidthRequest;
            //    LBQ.TextColor = Settings.MainColor;
            //    LBQ.HeightRequest = LBA.HeightRequest;
            //    LBQ.Text = "Q";
            //    LBQ.FontAttributes = FontAttributes.Bold;
            //    LBQ.FontSize = LBA.FontSize;
            //    LBQ.HorizontalTextAlignment = TextAlignment.Start;
            //    LBQ.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBQ, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBR = new Label();
            //    LBR.WidthRequest = LBA.WidthRequest;
            //    LBR.TextColor = Settings.MainColor;
            //    LBR.HeightRequest = LBA.HeightRequest;
            //    LBR.Text = "R";
            //    LBR.FontAttributes = FontAttributes.Bold;
            //    LBR.FontSize = LBA.FontSize;
            //    LBR.HorizontalTextAlignment = TextAlignment.Start;
            //    LBR.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBR, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;

            //    LBS = new Label();
            //    LBS.WidthRequest = LBA.WidthRequest;
            //    LBS.TextColor = Settings.MainColor;
            //    LBS.HeightRequest = LBA.HeightRequest;
            //    LBS.Text = "S";
            //    LBS.FontAttributes = FontAttributes.Bold;
            //    LBS.FontSize = LBA.FontSize;
            //    LBS.HorizontalTextAlignment = TextAlignment.Start;
            //    LBS.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBS, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBT = new Label();
            //    LBT.WidthRequest = LBA.WidthRequest;
            //    LBT.TextColor = Settings.MainColor;
            //    LBT.HeightRequest = LBA.HeightRequest;
            //    LBT.Text = "T";
            //    LBT.FontSize = LBA.FontSize;
            //    LBT.FontAttributes = FontAttributes.Bold;
            //    LBT.HorizontalTextAlignment = TextAlignment.Start;
            //    LBT.VerticalTextAlignment = TextAlignment.Center;
            //    Container.Children.Add(LBT, new Point(10, ypoint));

            //    ypoint += LBA.WidthRequest + PADDING;

            //    LBU = new Label();
            //    LBU.WidthRequest = LBA.WidthRequest;
            //    LBU.TextColor = Settings.MainColor;
            //    LBU.HeightRequest = LBA.HeightRequest;
            //    LBU.Text = "U";
            //    LBU.FontAttributes = FontAttributes.Bold;
            //    LBU.FontSize = LBA.FontSize;
            //    LBU.HorizontalTextAlignment = TextAlignment.Start;
            //    LBU.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBU, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBV = new Label();
            //    LBV.WidthRequest = LBA.WidthRequest;
            //    LBV.TextColor = Settings.MainColor;
            //    LBV.HeightRequest = LBA.HeightRequest;
            //    LBV.Text = "V";
            //    LBV.FontAttributes = FontAttributes.Bold;
            //    LBV.FontSize = LBA.FontSize;
            //    LBV.HorizontalTextAlignment = TextAlignment.Start;
            //    LBV.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBV, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;



            //    LBW = new Label();
            //    LBW.WidthRequest = LBA.WidthRequest;
            //    LBW.TextColor = Settings.MainColor;
            //    LBW.HeightRequest = LBA.HeightRequest;
            //    LBW.Text = "W";
            //    LBW.FontAttributes = FontAttributes.Bold;
            //    LBW.FontSize = LBA.FontSize;
            //    LBW.HorizontalTextAlignment = TextAlignment.Start;
            //    LBW.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBW, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBX = new Label();
            //    LBX.WidthRequest = LBA.WidthRequest;
            //    LBX.TextColor = Settings.MainColor;
            //    LBX.HeightRequest = LBA.HeightRequest;
            //    LBX.Text = "X";
            //    LBX.FontSize = LBA.FontSize;
            //    LBX.FontAttributes = FontAttributes.Bold;
            //    LBX.HorizontalTextAlignment = TextAlignment.Start;
            //    LBX.VerticalTextAlignment = TextAlignment.Center;
            //    Container.Children.Add(LBX, new Point(10, ypoint));

            //    ypoint += LBA.WidthRequest + PADDING;

            //    LBY = new Label();
            //    LBY.WidthRequest = LBA.WidthRequest;
            //    LBY.TextColor = Settings.MainColor;
            //    LBY.HeightRequest = LBA.HeightRequest;
            //    LBY.Text = "Y";
            //    LBY.FontAttributes = FontAttributes.Bold;
            //    LBY.FontSize = LBA.FontSize;
            //    LBY.HorizontalTextAlignment = TextAlignment.Start;
            //    LBY.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBY, new Point(10, ypoint));


            //    ypoint += LBA.WidthRequest + PADDING;


            //    LBZ = new Label();
            //    LBZ.WidthRequest = LBA.WidthRequest;
            //    LBZ.TextColor = Settings.MainColor;
            //    LBZ.HeightRequest = LBA.HeightRequest;
            //    LBZ.Text = "Z";
            //    LBZ.FontAttributes = FontAttributes.Bold;
            //    LBZ.FontSize = LBA.FontSize;
            //    LBZ.HorizontalTextAlignment = TextAlignment.Start;
            //    LBZ.VerticalTextAlignment = TextAlignment.Center;

            //    Container.Children.Add(LBZ, new Point(10, ypoint));
            //}

            //LBLoadMore = new Label();
            //LBLoadMore.WidthRequest = w - 40; ;
            //LBLoadMore.HeightRequest = 40;
            //LBLoadMore.TextColor = Settings.MainColor;
            //LBLoadMore.FontSize = FontSize;
            //LBLoadMore.HorizontalTextAlignment = TextAlignment.Center;
            //LBLoadMore.VerticalTextAlignment = TextAlignment.Center;
            ////LBLoadMore.IsVisible = true;
            //LBLoadMore.FontAttributes = FontAttributes.Bold;
            //LBLoadMore.FontFamily = Settings.ArabicFontFamily;

            //LBLoadMore.Text = "مزيد من المنتجات ";

            //Load.Children.Add(LBLoadMore, new Point(20, 0));

            Scroll.Scrolled += Scroll_Scrolled;
            ImgBack.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgBackClick())
            });
            //LBA.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBAClickAsync())
            //});
            //LBB.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBBlickAsync())
            //});
            //LBC.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBCClick())
            //});
            //LBD.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBDClick())
            //});
            //LBE.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBEClick())
            //});
            //LBF.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBFClick())
            //});
            //LBG.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBGClick())
            //});
            //LBH.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBHClick())
            //});
            //LBI.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBIClick())
            //});
            //LBJ.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBJClick())
            //});
            //LBK.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBKClick())
            //});
            //LBL.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBLClick())
            //});
            //LBM.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBMClick())
            //});
            //LBN.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBNClick())
            //});
            //LBO.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBOClick())
            //});
            //LBP.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBPClick())
            //});
            //LBQ.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBQClick())
            //});
            //LBR.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBRClick())
            //});
            //LBS.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBSClick())
            //});
            //LBT.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBTClickAsync())
            //});
            //LBU.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBUClickAsync())
            //});
            //LBV.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBVClickAsync())
            //});
            //LBW.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBWClickAsync())
            //});
            //LBX.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBXClickAsync())
            //});
            //LBY.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBYClickAsync())
            //});
            //LBZ.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBZClickAsync())
            //});
            ImgCar.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgCarClickAsync())
            });
            //LBLoadMore.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() => LBLoadMoreClickAsync())
            //});
        }

        //private async void LBLoadMoreClickAsync()
        //{
        //    AILoading.IsRunning = true;
        //    count++;
        //    await Settings.studentProuduct.GetDataAsync();
        //    AILoading.IsRunning = false;
        //}
        private bool isLoading = false;
        private async void Scroll_Scrolled(object sender, ScrolledEventArgs e)
        {
            //// LBLoadMore.TranslationY = e.ScrollY;
            //AILoading.TranslationY = e.ScrollY;
            //// LBLoadMore.TranslationY = e.ScrollY;
            AILoading.TranslationY = e.ScrollY;

            var scrollView = sender as ScrollView;

            // Check if we're near bottom and not already loading
            if (!isLoading && scrollView != null &&
                scrollView.ScrollY >= scrollView.ContentSize.Height - scrollView.Height - 50)
            {
                try
                {
                    isLoading = true;
                    AILoading.IsRunning = true;
                    count++;
                    //await Settings.studentProuduct.GetDataAsync();
                    await Settings.studentProuduct.LoadMoreSet();
                }
                finally
                {
                    isLoading = false;
                    AILoading.IsRunning = false;
                }
            }
        }
        private async void ImgCarClickAsync()
        {
            AILoading.IsRunning = true;
            await Settings.GetDeliveryFees();
            Settings.cart.GetDataAsync();
            home.Content = Settings.cart.MainLayout;
            AILoading.IsRunning = false;
        }

        private async void LBZClickAsync()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "Z";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBVClickAsync()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "V";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBWClickAsync()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "W";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBXClickAsync()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "X";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBYClickAsync()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "Y";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBUClickAsync()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "U";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBTClickAsync()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "T";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBRClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "R";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBSClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "S";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBPClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "P";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBOClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "O";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBNClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "N";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBQClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "Q";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBLClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "L";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBMClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "M";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBJClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "J";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBKClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "K";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBHClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "H";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBIClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "I";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBGClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "G";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBFClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "F";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBEClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "E";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBDClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "D";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBCClick()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "C";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;

        }

        private async void LBBlickAsync()
        {
            Alpha = true;
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = "B";
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;
        }

        private async void LBAClickAsync()
        {
            try
            {
                Alpha = true;
                AILoading.IsRunning = true;
                getProuduct.AlphaBit = "A";
                await Settings.studentProuduct.GetDataAsync();
                AILoading.IsRunning = false;

            }
            catch (Exception ex)
            {

            }
        }

        public async void SBSearch_TextChangedAsync(object sender, TextChangedEventArgs e)
        {
            AILoading.IsRunning = true;
            getProuduct.SearchText = SBSearch.Text;
            try
            {
                await Settings.studentProuduct.GetDataAsync();
            }
            catch
            {

            }
            AILoading.IsRunning = false;
        }

        public void ImgBackClick()
        {
            home.SendBackButtonPressed();
        }
        public void ProuductDetails()
        {

            home.Content = Settings.proudectStudentDetails.MainLayout;

        }
        private void LVProudect_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        public async void AlphabitClickAsync(string AlphaBit)
        {
            AILoading.IsRunning = true;
            getProuduct.AlphaBit = AlphaBit;
            Alpha = true;
            getProuduct.SearchText = SBSearch.Text;
            await Settings.studentProuduct.GetDataAsync();
            AILoading.IsRunning = false;

        }

        private async System.Threading.Tasks.Task GetDataAsync()
        {
            LVProudect.Children.Clear();
            LVProudect2.Children.Clear();
            LBNoData.IsVisible = false;
            //LBLoadMore.IsVisible = true;
            if (ProudectList != null)
                ProudectList.Clear();
            if (ProudectList2 != null)
                ProudectList2.Clear();
            if (Alpha)
            {
                prouductEntity = await Settings.GetAlphaStudentProuductAsync(getProuduct);
                Alpha = false;
            }
            else
                prouductEntity = await Settings.GetStudentProuductAsync(getProuduct);
            ProudectList = new List<ProuductView>();
            ProudectList2 = new List<ProuductView>();
            if (prouductEntity.Length == 0)
            {
                LBNoData.IsVisible = true;
                //LBLoadMore.IsVisible = false;
            }
            int length = 0;
            if (prouductEntity.Length >= count * 20)
                length = count * 20;
            else
                length = prouductEntity.Length;
            for (int i = 0; i < length; i++)
            {
                double price = Convert.ToDouble(prouductEntity[i].Price);
                double discount = Convert.ToDouble(prouductEntity[i].Discount);
                double secoundprice = (100 - discount) / 100 * price;
                bool isOutOfStock = prouductEntity[i].Amount == "0"; // Check stock availability

                string LBName = prouductEntity[i].ProuductName;
                string LBSecondPrice = "";
                bool DiscountPhoto = false;
                string LBDiscoubt = "";
                bool ImgDiscount = false;
                bool DiscountBar = false;
                String Favorites = "F";
                String Marcket = "F";
                ImageSource FavoritesSource = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                ImageSource MarcketSource = ImageSource.FromResource("DentalShop.Images.bag.png");
                for (int j = 0; j < Settings.cash.FavoriteList.Count; j++)
                {
                    if (Settings.cash.FavoriteList[j].ProductID == prouductEntity[i].ProductID)
                    {
                        Favorites = "T";
                        FavoritesSource = ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                        break;
                    }

                }
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
                MyObject.ImgFavorites.Source = FavoritesSource;
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
                MyObject.Favorite.Text = Favorites;
                MyObject.OldPriceLabel.Text = prouductEntity[i].Price;// added the old price
                MyObject.PriceLabel.Text = "EGP " + LBSecondPrice;// added the last price 
                MyObject.Marcket.Text = Marcket;
                MyObject.Type.Text = prouductEntity[i].Type;
                MyObject.ListLocation.Text = "Student";
                MyObject.LBID.Text = prouductEntity[i].ProductID.ToString();
                if (isOutOfStock)
                {
                    //MyObject.Name.Text = prouductEntity[i].ProuductName + " (Out of Stock)";
                    MyObject.OutOfStockLabel.IsVisible = true;
                    MyObject.ImgMainPhoto.Opacity = 0.5; // Make image faded
                }
                else
                {
                    MyObject.OutOfStockLabel.IsVisible = false;
                }

                if (i % 2 == 0)
                    ProudectList.Add(MyObject);
                else
                    ProudectList2.Add(MyObject);
                if (prouductEntity[i].Discount != "0" && prouductEntity[i].Discount != null)
                {

                    prouductEntity[i].Price = secoundprice.ToString();
                }
            }

            for (int i = 0; i < ProudectList.Count; i++)
                LVProudect.Children.Add(ProudectList[i]);
            for (int i = 0; i < ProudectList2.Count; i++)
                LVProudect2.Children.Add(ProudectList2[i]);

        
        }


        public async System.Threading.Tasks.Task SetDataAsync()
        {
            count = 1;
            LBTop.Text = "ادوات الطلبة";
            ImgTitle.Source = ImageSource.FromResource("DentalShop.Images.Title_1.png");
            getProuduct.Type = Type;
            getProuduct.SearchText = "";
            await GetDataAsync();
        }



        public async Task LoadMoreSet()
        {


            int length = 0;
            if (prouductEntity.Length >= count * 20)
                length = count * 20;
            else
                length = prouductEntity.Length;
            for (int i = (count - 1) * 20; i < length; i++)
            {
                double price = Convert.ToDouble(prouductEntity[i].Price);
                double discount = Convert.ToDouble(prouductEntity[i].Discount);
                double secoundprice = (100 - discount) / 100 * price;
                bool isOutOfStock = prouductEntity[i].Amount == "0"; // Check stock availability

                string LBName = prouductEntity[i].ProuductName;
                string LBSecondPrice = "";
                bool DiscountPhoto = false;
                string LBDiscoubt = "";
                bool ImgDiscount = false;
                bool DiscountBar = false;
                String Favorites = "F";
                String Marcket = "F";
                ImageSource FavoritesSource = ImageSource.FromResource("DentalShop.Images.GrayHeart.png");
                ImageSource MarcketSource = ImageSource.FromResource("DentalShop.Images.bag.png");
                for (int j = 0; j < Settings.cash.FavoriteList.Count; j++)
                {
                    if (Settings.cash.FavoriteList[j].ProductID == prouductEntity[i].ProductID)
                    {
                        Favorites = "T";
                        FavoritesSource = ImageSource.FromResource("DentalShop.Images.RedHeart.png");
                        break;
                    }

                }
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
                MyObject.ImgFavorites.Source = FavoritesSource;
                MyObject.ImgDiscount.IsVisible = ImgDiscount;
                MyObject.LBDiscount.Text = LBDiscoubt;
                MyObject.LBDiscount.IsVisible = true;
                MyObject.ImgMarcket.Source = MarcketSource;
                MyObject.FirstPrice.Text = prouductEntity[i].Price;
                MyObject.LBSecondPrice.Text = LBSecondPrice;
                MyObject.LBSecondPrice.IsVisible = true;
                MyObject.OldPriceLabel.Text = prouductEntity[i].Price;// added the old price
                if (double.Parse(prouductEntity[i].Price.Trim()) != double.Parse(LBSecondPrice.Trim()))
                {
                    MyObject.OldPriceLabel.IsVisible = true;
                }
                else
                {
                    MyObject.OldPriceLabel.IsVisible = false;
                }
                MyObject.PriceLabel.Text = "EGP " + LBSecondPrice;// added the last price 
                MyObject.ImgMainPhoto.Source = prouductEntity[i].FirstPhoto;
                MyObject.Name.Text = prouductEntity[i].ProuductName;
                MyObject.LBIndex.Text = i.ToString();
                MyObject.ImgDiscountBar.IsVisible = DiscountBar;
                MyObject.Favorite.Text = Favorites;
                MyObject.Marcket.Text = Marcket;
                MyObject.Type.Text = prouductEntity[i].Type;
                MyObject.ListLocation.Text = "ProuductPage";
                MyObject.LBID.Text = prouductEntity[i].ProductID.ToString();
                if (isOutOfStock)
                {
                    //MyObject.Name.Text = prouductEntity[i].ProuductName + " (Out of Stock)";
                    MyObject.OutOfStockLabel.IsVisible = true;
                    MyObject.ImgMainPhoto.Opacity = 0.5; // Make image faded
                }
                else
                {
                    MyObject.OutOfStockLabel.IsVisible = false;
                }

                if (i % 2 == 0)
                    ProudectList.Add(MyObject);
                else
                    ProudectList2.Add(MyObject);
                if (prouductEntity[i].Discount != "0" && prouductEntity[i].Discount != null)
                {

                    prouductEntity[i].Price = secoundprice.ToString();
                }
            }
            for (int i = 0; i < ProudectList.Count; i++)
                LVProudect.Children.Add(ProudectList[i]);
            for (int i = 0; i < ProudectList2.Count; i++)
                LVProudect2.Children.Add(ProudectList2[i]);
            //Scroll.ScrollToAsync(0, 0, false);
            //home.RefreshContent();
        }


    }
}
