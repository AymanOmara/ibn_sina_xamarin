using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace DentalShop
{
    public class AboutUs
    {
        int w;
        int h;
        public ScrollView Scroll = new ScrollView();
        AbsoluteLayout Container;
        public Grid MainLayout;
        HomePage home;
        Color MainColor = Settings.MainColor;
        Color LabelColor = Color.White;
        Label LBTop;
        Image ImgBack;

        Label LBFirstTitle;

        Image ImgFace1;
        Label LBFace1;


        Image ImgFace2;
        Label LBFace2;

        Label LBSecondTitle;


        Image ImgWhats1;
        Label LBPhone1;
        Image ImgCall1;

        Image ImgWhats2;
        Label LBPhone2;
        Image ImgCall2;

        Label LBLastTitle;

        private bool ready1 = true;
        private ActivityIndicator AILoading;

        public AboutUs(int w, int h, HomePage home)
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
            {
                LBTop.WidthRequest = w;
                LBTop.TextColor = Color.White;
                LBTop.BackgroundColor = Settings.MainColor;
                LBTop.HeightRequest = Labelheight + 20;
                LBTop.FontSize = FontSize;
                LBTop.Text = "التواصل معنا";
                LBTop.FontAttributes = FontAttributes.Bold;
                LBTop.HorizontalTextAlignment = TextAlignment.Center;
                LBTop.VerticalTextAlignment = TextAlignment.Center;
                LBTop.FontFamily = Settings.ArabicFontFamily;
                Container.Children.Add(LBTop, new Point(0, 0));

            }





            //img back
            ImgBack = new Image();
            {
                ImgBack.Aspect = Aspect.Fill;
                ImgBack.Source = ImageSource.FromResource("DentalShop.Images.whiteback.png");
                ImgBack.WidthRequest = Labelheight;
                ImgBack.HeightRequest = Labelheight;
                Container.Children.Add(ImgBack, new Point(10, 10));
            }



            double ypoint = LBTop.HeightRequest + 20 + 20 ;




            //Title
            LBFirstTitle = new Label();
            {
                LBFirstTitle.WidthRequest = w-20;
                LBFirstTitle.TextColor = Settings.MainColor;
                LBFirstTitle.HeightRequest = 3*Labelheight + 20;
                LBFirstTitle.FontSize = FontSize;
                LBFirstTitle.Text = "للتواصل معنا من خلال الفيس بوك يمكنك من خلال الصفحات الاتية ";
                LBFirstTitle.FontAttributes = FontAttributes.Bold;
                LBFirstTitle.HorizontalTextAlignment = TextAlignment.Center;
                LBFirstTitle.VerticalTextAlignment = TextAlignment.Center;
                LBFirstTitle.FontFamily = Settings.ArabicFontFamily;
                Container.Children.Add(LBFirstTitle, new Point(10, ypoint));

            }

            ypoint += LBFirstTitle.HeightRequest + 10;



            //img face1
            ImgFace1 = new Image();
            {
                ImgFace1.Aspect = Aspect.Fill;
                ImgFace1.Source = ImageSource.FromResource("DentalShop.Images.face.png");
                ImgFace1.WidthRequest =1.5* Labelheight;
                ImgFace1.HeightRequest = ImgFace1.WidthRequest;
                Container.Children.Add(ImgFace1, new Point(w- 1.5 * Labelheight - 20, ypoint+5));
            }


            LBFace1 = new Label();
            {
                LBFace1.WidthRequest = w - 40- ImgFace1.WidthRequest;
                LBFace1.TextColor = Settings.MainColor;
                LBFace1.HeightRequest =  Labelheight + 20;
                LBFace1.FontSize = FontSize-3;
                LBFace1.Text = "https://www.facebook.com/Ibn.Sina.Mti/";
                LBFace1.FontAttributes = FontAttributes.Bold;
                LBFace1.HorizontalTextAlignment = TextAlignment.Center;
                LBFace1.VerticalTextAlignment = TextAlignment.Center;
                LBFace1.FontFamily = Settings.ArabicFontFamily;
                Container.Children.Add(LBFace1, new Point(10, ypoint));

            }


            ypoint += ImgFace1.HeightRequest + 20;


            //img face2
            ImgFace2 = new Image();
            {
                ImgFace2.Aspect = Aspect.Fill;
                ImgFace2.Source = ImageSource.FromResource("DentalShop.Images.face.png");
                ImgFace2.WidthRequest = 1.5 * Labelheight;
                ImgFace2.HeightRequest = ImgFace2.WidthRequest;
                Container.Children.Add(ImgFace2, new Point(w - 1.5 * Labelheight - 20, ypoint+5));
            }


            LBFace2 = new Label();
            {
                LBFace2.WidthRequest = w - 40 - ImgFace1.WidthRequest;
                LBFace2.TextColor = Settings.MainColor;
                LBFace2.HeightRequest = Labelheight + 20;
                LBFace2.FontSize = FontSize-3;
                LBFace2.Text = "https://www.facebook.com/profile.php?id=100008589991408";
                LBFace2.FontAttributes = FontAttributes.Bold;
                LBFace2.HorizontalTextAlignment = TextAlignment.Center;
                LBFace2.VerticalTextAlignment = TextAlignment.Center;
                LBFace2.FontFamily = Settings.ArabicFontFamily;
                Container.Children.Add(LBFace2, new Point(10, ypoint));

            }


            ypoint += ImgFace1.HeightRequest + 20;



            //Title
            LBSecondTitle = new Label();
            {
                LBSecondTitle.WidthRequest = w - 20;
                LBSecondTitle.TextColor = Settings.MainColor;
                LBSecondTitle.HeightRequest = 3 * Labelheight + 20;
                LBSecondTitle.FontSize = FontSize;
                LBSecondTitle.Text = "كما يمكنكم التواصل معنا من خلال الاتصال او الواتس اب بالارقام الاتية";
                LBSecondTitle.FontAttributes = FontAttributes.Bold;
                LBSecondTitle.HorizontalTextAlignment = TextAlignment.Center;
                LBSecondTitle.VerticalTextAlignment = TextAlignment.Center;
                LBSecondTitle.FontFamily = Settings.ArabicFontFamily;
                Container.Children.Add(LBSecondTitle, new Point(10, ypoint));

            }

            ypoint += LBSecondTitle.HeightRequest + 20;


            CustomLabel LBNumber = new CustomLabel();
            {
                LBNumber.WidthRequest = 115;
                LBNumber.HeightRequest = 25;
                LBNumber.TextColor = Settings.MainColor;
                LBNumber.FontSize = FontSize-3;
                LBNumber.Text = @"01010730714";
                LBNumber.HorizontalTextAlignment = TextAlignment.Center;
                LBNumber.VerticalTextAlignment = TextAlignment.Center;
                LBNumber.FontFamily = Settings.EnglishFontFamily;
                LBNumber.FontAttributes = FontAttributes.Bold;

                Container.Children.Add(LBNumber, new Point(125, ypoint + 10));
            }

            ImgWhats1 = new Image();
            {
                ImgWhats1.Aspect = Aspect.Fill;
                ImgWhats1.Source = ImageSource.FromResource("DentalShop.Images.Whats.png");
                ImgWhats1.WidthRequest = 40;
                ImgWhats1.HeightRequest = 40;
                Container.Children.Add(ImgWhats1, new Point(70, ypoint));

            }



            ImgCall1 = new Image();
            {
                ImgCall1.Aspect = Aspect.Fill;
                ImgCall1.Source = ImageSource.FromResource("DentalShop.Images.phone-icon.png");
                ImgCall1.WidthRequest = 40;
                ImgCall1.HeightRequest = 40;
                Container.Children.Add(ImgCall1, new Point(w - 110, ypoint));

            }


            ypoint += ImgCall1.HeightRequest + 20;



            CustomLabel LBNumber2 = new CustomLabel();
            {
                LBNumber2.WidthRequest = 115;
                LBNumber2.HeightRequest = 25;
                LBNumber2.TextColor = Settings.MainColor;
                LBNumber2.FontSize = FontSize-3;
                LBNumber2.Text = @"01008560926";
                LBNumber2.HorizontalTextAlignment = TextAlignment.Center;
                LBNumber2.VerticalTextAlignment = TextAlignment.Center;
                LBNumber2.FontFamily = Settings.EnglishFontFamily;
                LBNumber2.FontAttributes = FontAttributes.Bold;

                Container.Children.Add(LBNumber2, new Point(125, ypoint + 10));
            }

            ImgWhats2 = new Image();
            {
                ImgWhats2.Aspect = Aspect.Fill;
                ImgWhats2.Source = ImageSource.FromResource("DentalShop.Images.Whats.png");
                ImgWhats2.WidthRequest = 40;
                ImgWhats2.HeightRequest = 40;
                Container.Children.Add(ImgWhats2, new Point(70, ypoint));

            }



            ImgCall2 = new Image();
            {
                ImgCall2.Aspect = Aspect.Fill;
                ImgCall2.Source = ImageSource.FromResource("DentalShop.Images.phone-icon.png");
                ImgCall2.WidthRequest = 40;
                ImgCall2.HeightRequest = 40;
                Container.Children.Add(ImgCall2, new Point(w - 110, ypoint));

            }


            ypoint += ImgCall2.HeightRequest + 20;

            //events;

            LBLastTitle = new Label();
            {
                LBLastTitle.WidthRequest = w - 20;
                LBLastTitle.TextColor = Settings.MainColor;
                LBLastTitle.HeightRequest = 3 * Labelheight + 20;
                LBLastTitle.FontSize = FontSize;
                LBLastTitle.Text = "يسعدنا دائما ان نكون في خدمة حضراتكم ";
                LBLastTitle.FontAttributes = FontAttributes.Bold;
                LBLastTitle.HorizontalTextAlignment = TextAlignment.Center;
                LBLastTitle.VerticalTextAlignment = TextAlignment.Start;
                LBLastTitle.FontFamily = Settings.ArabicFontFamily;
                Container.Children.Add(LBLastTitle, new Point(10, ypoint));

            }



            ImgBack.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgBackClick())
            });

            ImgCall1.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgCall1Click())
            });
            ImgCall2.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgCall2Click())
            });



            ImgFace1.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgFace1Click())
            });


            ImgFace2.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgFace2Click())
            });

            LBFace1.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgFace1Click())
            });


            LBFace2.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgFace2Click())
            });

            ImgWhats1.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgWhats1Click())
            });


            ImgWhats2.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ImgWhats2Click())
            });
            AILoading = new ActivityIndicator();
            AILoading.Color = Settings.MainColor;
            AILoading.IsRunning = false;
            AILoading.WidthRequest = Labelheight * 6;
            AILoading.HeightRequest = Labelheight * 6;
            Container.Children.Add(AILoading, new Point(w / 2 - AILoading.WidthRequest / 2, h / 2 - AILoading.HeightRequest / 2));

            Scroll.Scrolled += Scroll_Scrolled;
        }

        private void ImgWhats2Click()
        {
            try
            {
                string url = "";
                Device.OnPlatform
                        (
                        iOS: () =>
                        {
                            url = String.Format("http://api.whatsapp.com/send?phone=+201008560926");


                        },
                        Android: () =>
                        {
                            url = String.Format("http://api.whatsapp.com/send?phone=+201008560926");
                        }
                    );
                Device.OpenUri(new Uri(url));

            }
            catch (Exception ex)
            {

            }
        }

        private void ImgWhats1Click()
        {
            try
            {
                string url = "";
                Device.OnPlatform
                        (
                        iOS: () =>
                        {
                            url = String.Format("http://api.whatsapp.com/send?phone=+201010730714");


                        },
                        Android: () =>
                        {
                            url = String.Format("http://api.whatsapp.com/send?phone=+201010730714");
                        }
                    );
                Device.OpenUri(new Uri(url));

            }
            catch (Exception ex)
            {

            }
        }

        private void ImgFace2Click()
        {
            string url = "";
            Device.OnPlatform
                (
                iOS: () =>
                {
                    url = String.Format("https://www.facebook.com/profile.php?id=100008589991408");
                },
                Android: () =>
                {
                    url = String.Format("https://www.facebook.com/profile.php?id=100008589991408");
                }
            );
            try
            {
                Device.OpenUri(new Uri(url));
            }
            catch (Exception ex)
            {

            }
        }

        private void ImgFace1Click()
        {
            string url = "";
            Device.OnPlatform
                (
                iOS: () =>
                {
                    url = String.Format("https://www.facebook.com/Ibn.Sina.Mti/");
                },
                Android: () =>
                {
                    url = String.Format("https://www.facebook.com/Ibn.Sina.Mti/");
                }
            );
            try
            {
                Device.OpenUri(new Uri(url));
            }
            catch (Exception ex)
            {

            }
        }

        private void ImgCall2Click()
        {
            try
            {
                Device.OpenUri(new Uri("tel:01008560926"));
            }
            catch
            {

            }
        }

        private void ImgCall1Click()
        {
            try
            {
                Device.OpenUri(new Uri("tel:01010730714"));
            }
            catch
            {

            }
        }

        private void Scroll_Scrolled(object sender, ScrolledEventArgs e)
        {
            AILoading.TranslationY = e.ScrollY;
        }

        public void ImgBackClick()
        {
            home.SendBackButtonPressed();
        }
    }
}
