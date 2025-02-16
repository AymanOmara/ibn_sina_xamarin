
using Foundation;
using UIKit;
// New Xlabs
using XLabs.Ioc; // Using for SimpleContainer
using XLabs.Platform.Services.Geolocation; // Using for Geolocation
using XLabs.Platform.Device; // Using for Device
using XLabs.Platform.Services.Media;
using UserNotifications;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace DentalShop.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public static bool NotificationRecieved = false;
        public static bool IsRunning = false;
        public static Notifications notify = new Notifications();
        bool firstRun = true;
        public int NotificationId = 1;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            System.Net.ServicePointManager.DnsRefreshTimeout = 0;
            var container = new XLabs.Ioc.SimpleContainer();
            container.Register<IDevice>(t => AppleDevice.CurrentDevice);
            container.Register<IGeolocator, Geolocator>();
            container.Register<IMediaPicker, MediaPicker>();
            Resolver.SetResolver(container.GetResolver());
            // End new Xlabs
            global::Xamarin.Forms.Forms.Init();

            App.setScreenSize((int)UIScreen.MainScreen.Bounds.Width, (int)UIScreen.MainScreen.Bounds.Height);
            LoadApplication(new App());
            UIApplication.SharedApplication.StatusBarHidden = true;
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound | UNAuthorizationOptions.Badge, (approved, err) => {
                // Handle approval
            });
            UNUserNotificationCenter.Current.GetNotificationSettings((settings) => {
                var alertsAllowed = (settings.AlertSetting == UNNotificationSetting.Enabled);
            });
            notification();
            return base.FinishedLaunching(app, options);
        }
        public void notification()
        {

            Task.Run(async () =>
            {
                IsRunning = true;
                var sapp = UIApplication.SharedApplication;
                var id = sapp.BeginBackgroundTask(null);
                while (true)
                {
                    System.Threading.Thread.Sleep(10000);
                    try
                    {
                        if (Settings.cash.LoggedIn)
                        {
                            String LastNotification = Settings.cash.LastNotification;
                            String Id = Settings.cash.UserInfo.UserId;
                            String Json = await Settings.GetLastNotifictionAsync(LastNotification);
                            if (Json != "false" && Json != null && Json != "[]")
                            {
                                //Intent NotificationIntent = new Intent();
                                //NotificationIntent.SetAction("com.alr.text");
                                //NotificationIntent.PutExtra("ClcexDataProvider", Json);
                                //SendBroadcast(NotificationIntent);
                                try
                                {
                                    ////////////////////////////////////////////////////////////////////
                                    try
                                    {
                                        //Toast.MakeText(context, Content, ToastLength.Short).Show();
                                        try
                                        {
                                            Notifications[] Notifications = JsonConvert.DeserializeObject<Notifications[]>(Json);
                                            for (int i = 0; i < Notifications.Length; i++)
                                            {

                                                var content = new UNMutableNotificationContent();
                                                content.Title = "DentalShop";
                                                DateTime date = Convert.ToDateTime(Notifications[i].Time);
                                                date = date.AddHours(2);
                                                content.Subtitle = date.ToString();
                                                content.Body = notify.LBNotificationText + " " + Notifications[i].Time;
                                                content.Badge = 1;
                                                content.Sound = UNNotificationSound.GetSound("alarm.mp3");
                                                var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(5, false);

                                                var requestID = (NotificationId).ToString();
                                                NotificationId++;
                                                var request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);
                                                UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) => {
                                                    if (err != null)
                                                    {
                                                        // Do something with error...
                                                        new UIAlertView("DentalShop", err.LocalizedDescription, null, "Done", null).Show();
                                                    }

                                                });

                                            }
                                            try
                                            {
                                                Settings.cash.LastNotification = Settings.ToMysqlTime(Settings.ToSystemDateTime(Notifications[Notifications.Length - 1].Time));
                                                Settings.SaveCash();
                                            }
                                            catch { }
                                            AppDelegate.NotificationRecieved = true;
                                            System.Threading.Thread.Sleep(65000);
                                            UNUserNotificationCenter.Current.RemoveAllPendingNotificationRequests();
                                        }
                                        catch (Exception ex)
                                        {

                                        }

                                    }
                                    catch
                                    {

                                    }
                                    ///////////////////////////////////////////////////////////////////
                                }
                                catch
                                {
                                    //Toast.MakeText(this,"Not Running",ToastLength.Long);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                sapp.EndBackgroundTask(id);

            });

        }
        /*
        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            // Get current device token
            var DeviceToken = deviceToken.Description;
            if (!string.IsNullOrWhiteSpace(DeviceToken))
            {
                DeviceToken = DeviceToken.Trim('<').Trim('>');
            }

            // Get previous device token
            var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");

            // Has the token changed?
            if (string.IsNullOrEmpty(oldDeviceToken) || !oldDeviceToken.Equals(DeviceToken))
            {
                //TODO: Put your own logic here to notify your server that the device token has changed/been created!
                //new UIAlertView("Clcex", "clcex is here", null, "Done", null).Show();



            }

            // Save new device token
            NSUserDefaults.StandardUserDefaults.SetString(DeviceToken, "PushDeviceToken");

        }
        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            new UIAlertView("ePMS", error.LocalizedDescription, null, "Done", null).Show();
        }
        */
        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            // show an alert
            UIAlertController okayAlertController = UIAlertController.Create(notification.AlertTitle, notification.AlertBody, UIAlertControllerStyle.Alert);
            okayAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            try
            {
                Window.RootViewController.PresentViewController(okayAlertController, true, null);
            }
            catch (Exception ex)
            { }
            // reset our badge
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }
        public override void OnActivated(UIApplication uiApplication)
        {
            base.OnActivated(uiApplication);
            try
            {
                if (AppDelegate.NotificationRecieved)
                {
                    if (Settings.cash.LoggedIn)
                    {
                        Settings.homePage.Content = Settings.notification.MainLayout;
                        Settings.notification.GetData();

                    }
                    else
                    {
                        Settings.homePage.Content = Settings.mainPage.MainLayout;
                    }
                }
                UNUserNotificationCenter.Current.RemoveAllDeliveredNotifications();
                NotificationId = 1;
                UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
                AppDelegate.NotificationRecieved = false;
            }
            catch
            {
                UNUserNotificationCenter.Current.RemoveAllDeliveredNotifications();
                NotificationId = 1;
                UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
                AppDelegate.NotificationRecieved = false;
            }
        }

    }
    public class UserNotificationCenterDelegate : UNUserNotificationCenterDelegate
    {
        #region Constructors
        public UserNotificationCenterDelegate()
        {
        }
        #endregion

        #region Override Methods
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            // Do something with the notification


            // Tell system to display the notification anyway or use
            // `None` to say we have handled the display locally.
            completionHandler(UNNotificationPresentationOptions.Alert);
        }
        #endregion
    }
}
