
using DentalShop.Screens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentalShop
{
    public class Settings
    {
        public static Cash cash;
        public static string WebServiceUrl = @"http://ibnsinadental-001-site1.ftempurl.com/DentalShopWebService.asmx";
       // public static string WebServiceUrl = @"http://localhost:51644/DentalShopWebService.asmx";
        public static Color MainColor = new Color(243.0 / 255, 119.0 / 255, 5.0 / 255);
        public static Color GrayColor = new Color(226.0 / 255, 228.0 / 255, 231.0 / 255);
        public static Color DarkColor = new Color(204.0 / 255, 204.0 / 255, 204.0 / 255);
        public static Color BackGroundColor = Color.White;
        public static Color BlueColor = new Color(23.0 / 255, 145.0 / 255, 218.0 / 255);
        public static Color ShadowColor = new Color(225.0 / 255, 225.0 / 255, 208.0 / 255);
        public static string ICC = "eg";
        public static HomePage homePage;
        public static Stack<View> PageStack = new Stack<View>();
        public static double FontSize = 13;
        public static double width;
        public static double height;
        public static double CartWidth;
        public static double CartHeight;
        public static double OrderWidth;
        public static double OrderHeight;
        public static double ButtonHeight = 45;
        public static double Labelheight = 23;
        public static double CairoDelviryFees = 0;
        public static double OutDeliveryFees = 0;
        public static bool Login=false;
        public static IMyToast myToast = DependencyService.Get<IMyToast>();
        private static String message = "";
        public static String Message
        {
            get { return message; }
            set
            {
                message = value;
                if (value != null && value != "")
                    Settings.myToast.MakeText(value, false);
            }
        }
        public static HttpClient HttpClient = new HttpClient();
        public static List<CartView> cartList = new List<CartView>();
        public static List<ProuductEntity> EditProudctList = new List<ProuductEntity>();
        public static MainPage mainPage;
        public static CreateAcount createAcount;
        public static ImageCropper imageCropper;
        public static SplashScreen splashScreen;
        public static ForgotPassword forgotPassword;
        public static UpdateUserInfo updateUserInfo;
        public static Login login;
        public static ProuductPage prouductPage;
        public static ProudectStudentDetails proudectStudentDetails;
        public static ProudectDeivceDetails proudectDeivceDetails;
        public static ProudectsMachinesDetails proudectsMachinesDetails;
        public static ProudectEquipmentDetails proudectEquipmentDetails;
        public static ProuductCorrectionDetails prouductCorrectionDetails;
        public static ProudectMaterialsDetails proudectMaterialsDetails;
        public static ClothesDetails ClothesDetails ;
        public static Files FilesDetails;
        public static StudentProuduct studentProuduct;
        public static Favorites favorites;
        public static Cart cart;
        public static EditOrder editOrder;
        public static MyOrders myOrders;
        public static NotificationPage notification;
        public static AboutUs aboutUs;
        public static int Search = 0;
        public static TimeSpan GetTimeDifference()
        {
            return DateTime.Now.ToUniversalTime().Subtract(DateTime.Now);
        }

        private static DateTime PositionTime = DateTime.Now.AddDays(-1.0f);
        public static string EnglishFontFamily = "";
        public static string GetJson(String ServerResult)
        {
            ServerResult = ServerResult.Substring(ServerResult.Replace("</string>", "").LastIndexOf('>') + 1);
            String json = ServerResult.Replace("</string>", "");
            return json;

        }
        public static string ToMysqlDate(DateTime Date)
        {
            string day = "" + Date.Day; if (day.Length < 2) { day = "0" + day; }
            String month = "" + Date.Month; if (month.Length < 2) { month = "0" + month; }
            String year = "" + Date.Year;
            String date = year + "-" + month + "-" + day;
            return date;
        }
        public static string ToMysqlTime(DateTime time)
        {
            return ToMysqlDate(time) + " " + time.Hour + ":" + time.Minute + ":" + time.Second;
        }
        public static DateTime ToSystemDateTime(String Time)
        {
            {
                String[] TimeParts = Time.Split(' ');
                String[] DateParts = TimeParts[0].Split('/');
                String month = DateParts[0];
                String day = DateParts[1];
                String year = DateParts[2];
                String[] HourParst = TimeParts[1].Split(':');
                if (TimeParts[2] == "PM" && HourParst[0] == "12")
                {
                    HourParst[0] = "0";
                }
                else if (TimeParts[2] == "AM" && HourParst[0] == "12")
                {
                    HourParst[0] = "0";
                }
                if (TimeParts[2] == "PM")
                {
                    HourParst[0] = (Double.Parse(HourParst[0]) + 12).ToString();
                }
                int hour = int.Parse(HourParst[0]);
                int min = int.Parse(HourParst[1]);
                int sec = int.Parse(HourParst[2]);
                DateTime d = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), hour, min, sec);
                return d;
            }
        }
        public static string ArabicFontFamily = Device.OnPlatform
                (
                   "DroidSans-Bold",
                   "DroidSans-Bold.ttf#DroidSans-Bold",
                   "Assets/Fonts/DroidSans-Bold.ttf#DroidSans-Bold"
                );
        public static string CofiFontFamily = Device.OnPlatform
                (
                   "Ah-moharram-bold_0",
                   "Ah-moharram-bold_0.ttf#Ah-moharram-bold_0",
                   "Assets/Fonts/Ah-moharram-bold_0.ttf#Ah-moharram-bold_0"
                );
        public static void SetFont(ref AbsoluteLayout Container)
        {
            for (int i = 0; i < Container.Children.Count; i++)
            {
                Type type = Container.Children[i].GetType();
                if (type == typeof(Label))
                {
                    Label LB = (Label)Container.Children[i];
                   
                }
                else if (type == typeof(Button))
                {
                    Button BT = (Button)Container.Children[i];
                    
                }
                else if (type == typeof(Entry))
                {
                    Entry E = (Entry)Container.Children[i];
                    
                }
            }
        }

        public static void SaveCash()
        {
            string JsonCash = JsonConvert.SerializeObject(Settings.cash);
            Device.OnPlatform
            (
                WinPhone: () => DependencyService.Get<ISaveAndLoad>().SaveTextAsync("Cash.txt", JsonCash),
                Default: () => DependencyService.Get<ISaveAndLoad>().SaveText("Cash.txt", JsonCash)
            );
        }

        public static async Task<ProuductEntity[]> GetProuductAsync(GetProuduct ProuductJson)
        {
           
            try
            {
                
                Settings.HttpClient = new HttpClient(); Settings.HttpClient.Timeout = new TimeSpan(0, 0, 20);
                GetProuduct MyObject = new GetProuduct();
                MyObject = ProuductJson;

                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                try
                {
                    
                    var ServerResult = await Settings.HttpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetProudect"), content);
                    ServerResult.EnsureSuccessStatusCode();
                    string responseBody = await ServerResult.Content.ReadAsStringAsync();
                    string json = Settings.GetJson(responseBody);
                    ProuductEntity[] prouductEntities;
                    try
                    {
                        prouductEntities = JsonConvert.DeserializeObject<ProuductEntity[]>(json);
                        return prouductEntities;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
                catch (Exception ex2)
                {
                    return null;
                }
         
            }
            catch (Exception ex3)
            {
                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }

        public static async Task<ProuductEntity[]> GetAlphaProuductAsync(GetProuduct ProuductJson)
        {
            try
            {
                var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                GetProuduct MyObject = new GetProuduct();
                MyObject = ProuductJson;
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetAlphaProudect"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                ProuductEntity[] prouductEntities;
                try
                {
                    prouductEntities = JsonConvert.DeserializeObject<ProuductEntity[]>(json);
                    return prouductEntities;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }



        public static async Task<ProuductEntity[]> GetStudentProuductAsync(GetStudentProuduct ProuductJson)
        {
            try
            {
                var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();
               // httpClient.Timeout = new TimeSpan(0, 0, 20);
                GetStudentProuduct MyObject = new GetStudentProuduct();
                MyObject = ProuductJson;
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetStudentProudect"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                ProuductEntity[] prouductEntities;
                try
                {
                    prouductEntities = JsonConvert.DeserializeObject<ProuductEntity[]>(json);
                    return prouductEntities;
                }
                catch 
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }


        public static async Task<ProuductEntity[]> GetAlphaStudentProuductAsync(GetStudentProuduct ProuductJson)
        {
            try
            {
                var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                GetStudentProuduct MyObject = new GetStudentProuduct();
                MyObject = ProuductJson;
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetAlphaStudentProudect"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                ProuductEntity[] prouductEntities;
                try
                {
                    prouductEntities = JsonConvert.DeserializeObject<ProuductEntity[]>(json);
                    return prouductEntities;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }



        public static async Task<ProuductEntity[]> GetFavorites()
        {
            try
            {
                var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                string MyObject = Settings.cash.UserInfo.UserId;
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetFavorites"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                ProuductEntity[] prouductEntities;
                try
                {
                    Settings.cash.FavoriteList.Clear();
                    prouductEntities = JsonConvert.DeserializeObject<ProuductEntity[]>(json);
                    for (int i=0;i< prouductEntities.Length;i++)
                    {
                        Settings.cash.FavoriteList.Add(prouductEntities[i]);
                    }
                    Settings.SaveCash();
                    return prouductEntities;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }


        public static async void AddFavoriteAsync(AddFavorite favorite)
        {
            
                try
                {
                    Settings.Message = "";
                    var httpClient = Settings.HttpClient;
                    HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                    AddFavorite MyObject = new AddFavorite();
                    MyObject = favorite;
                    String Content = JsonConvert.SerializeObject(MyObject);
                    var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Content", Content)
                    };
                    var content = new FormUrlEncodedContent(pairs);
                    var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/AddFavorite"), content);
                    ServerResult.EnsureSuccessStatusCode();
                    string responseBody = await ServerResult.Content.ReadAsStringAsync();
                    string json = Settings.GetJson(responseBody);
                    //httpClient.Dispose();
                    try
                    {
                       
                    }
                    catch (Exception ex)
                    {

                      
                    }
                }
                catch
                {

                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
            }
             
            

        }

        public static async void DeleteFavoriteAsync(AddFavorite favorite)
        {

            try
            {
                Settings.Message = "";
                var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                AddFavorite MyObject = new AddFavorite();
                MyObject = favorite;
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Content", Content)
                    };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/DeleteFavorite"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                //httpClient.Dispose();
                try
                {

                }
                catch (Exception ex)
                {


                }
            }
            catch
            {
                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";

            }



        }


        public static async Task<string> DeleteAccountAsync(string userid)
        {
            try
            {
                Settings.Message = "";
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(20);

                    // Send a GET request with the userid as a query parameter
                    string requestUrl = $"{Settings.WebServiceUrl}/DeleteAccount?userid={userid}";

                    var serverResult = await httpClient.GetAsync(requestUrl);
                    serverResult.EnsureSuccessStatusCode();

                    string responseBody = await serverResult.Content.ReadAsStringAsync();
                    string json = Settings.GetJson(responseBody);
                    return json.Trim(); // Ensure no extra spaces
                }
            }
            catch
            {
                Settings.Message = "يرجى التحقق من الاتصال بالإنترنت";
                return "false"; // Return "false" in case of an error
            }
        }



        public static async Task GetDeliveryFees()
        {

            try
            {
                Settings.Message = "";
                //var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();
                HttpClient.Timeout = new TimeSpan(0, 0, 20);
                string MyObject = "";
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Content", Content)
                    };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await HttpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetDeliveryFees"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                //httpClient.Dispose();
                GetDelivery delivery = new GetDelivery();
                try
                {
                    delivery = JsonConvert.DeserializeObject<GetDelivery>(json);
                    Settings.CairoDelviryFees = Convert.ToDouble(delivery.Cairo);
                    Settings.OutDeliveryFees = Convert.ToDouble(delivery.Out);
                }
                catch (Exception ex)
                {


                }
            }
            catch
            {

                //Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
            }



        }


        public static async Task<ProuductEntity[]> GetOrderProuduct(string ID)
        {
            try
            {
                var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                String Content = JsonConvert.SerializeObject(ID);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetOrderProuduct"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                ProuductEntity[] prouductEntities;
                try
                {
                    prouductEntities = JsonConvert.DeserializeObject<ProuductEntity[]>(json);
                    return prouductEntities;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }



        public static async Task<Order[]> GetOrdersAsync()
        {
            try
            {
                var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                string MyObject = Settings.cash.UserInfo.UserId;
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetOrders"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                Order[] prouductEntities;
                try
                {
                    prouductEntities = JsonConvert.DeserializeObject<Order[]>(json);
                    return prouductEntities;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }

        public static async Task<OrderList[]> GetOrderProuductListAsync(string ID)
        {
            try
            {
                var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                string MyObject = ID;
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetOrdersList"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                OrderList[] prouductEntities;
                try
                {
                    prouductEntities = JsonConvert.DeserializeObject<OrderList[]>(json);
                    return prouductEntities;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }

        public static async Task<Notifications[]> GetNotifictionAsync()
        {
            try
            {
                var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                string MyObject = Settings.cash.UserInfo.UserId;
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetNotifiction"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                Notifications[] NotificationEntities;
                
                try
                {
                    NotificationEntities = JsonConvert.DeserializeObject<Notifications[]>(json);
                    
                    return NotificationEntities;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }

        public static async Task<string> GetLastNotifictionAsync(string lastNotification)
        {
            try
            {
                var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                LastNotificationObject MyObject = new LastNotificationObject ();
                MyObject.Id = Settings.cash.UserInfo.UserId;
                MyObject.LastNotification = Settings.cash.LastNotification;
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetLastNotifiction"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                Notifications[] NotificationEntities;

                try
                {
                    NotificationEntities = JsonConvert.DeserializeObject<Notifications[]>(json);
                    NotificationViewObject[] Notifications = new NotificationViewObject[NotificationEntities.Length];
                    for (int i = 0; i < NotificationEntities.Length; i++)
                    {
                        Notifications[i] = JsonConvert.DeserializeObject<NotificationViewObject>(NotificationEntities[i].LBNotificationText);
                    }
                    return json;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }


        public static async Task<string[]> GetPannerAsync()
        {
            try
            {
                HttpClient = new HttpClient();
                HttpClient.Timeout = new TimeSpan(0, 0, 20);
                string MyObject = "";
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await HttpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/GetPanner"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                string[] Panner;
                try
                {
                    Settings.cash.Panner.Clear();
                    Panner = JsonConvert.DeserializeObject<string[]>(json);
                    for (int i = 0; i < Panner.Length; i++)
                    {
                        Settings.cash.Panner.Add(Panner[i]);
                    }
                    Settings.SaveCash();
                    return Panner;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
               // Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }
        public static async Task<string> InsertNotificationAsync(LaterNotification laterNotification)
        {
            try
            {
                var httpClient = Settings.HttpClient;
                HttpClient = new HttpClient();httpClient.Timeout = new TimeSpan(0, 0, 20);
                LaterNotification MyObject = laterNotification;
                String Content = JsonConvert.SerializeObject(MyObject);
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Content", Content)
                };
                var content = new FormUrlEncodedContent(pairs);
                var ServerResult = await httpClient.PostAsync(new Uri(Settings.WebServiceUrl + "/InsertNotification"), content);
                ServerResult.EnsureSuccessStatusCode();
                string responseBody = await ServerResult.Content.ReadAsStringAsync();
                string json = Settings.GetJson(responseBody);
                
                try
                {
                    return json;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Settings.Message = "يرجى التحقق من الاتصال بالأنترنت";
                return null;
            }
        }
    }
}
