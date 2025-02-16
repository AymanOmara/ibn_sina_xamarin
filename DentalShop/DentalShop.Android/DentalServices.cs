using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Android.Support.V4.App;
using Newtonsoft.Json;
using DentalShop.Droid;


namespace DentalShop.Droid


{
    [Service]
    class DentalServices : IntentService
    {
        public static bool NotificationRecieved = false;
        public static bool IsRunning = false;
        public static Activity Main;
        private static NotificationManager notificationManager;
        protected override void OnHandleIntent(Intent intent)
        {

        }
        public const int SERVICE_RUNNING_NOTIFICATION_ID = 10001;
        int id = 3000;
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Main = MyReciever.Main;
            PendingIntent pendingIntent = PendingIntent.GetActivity(MyReciever.Main, SERVICE_RUNNING_NOTIFICATION_ID, MyReciever.Main.Intent, PendingIntentFlags.Immutable);
            var notification = new Notification.Builder(this)
                .SetContentTitle("Dental Shop")
                .SetContentText("Welcome to Dental Shop")
                .SetSmallIcon(Resource.Drawable.icon) 
                .SetContentIntent(pendingIntent)
                .SetOngoing(true)
                .Build();
            // Enlist this instance of the service as a foreground service
            //StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notification);
            // start a task here
            new Task(async () =>
            {
                IsRunning = true;
                // long running code
                while (true)
                {
                    System.Threading.Thread.Sleep(10000);
                    try
                    {
                        if (Settings.cash.LoggedIn)
                        {
                            String LastNotification = Settings.cash.LastNotification;
                            String Id = Settings.cash.UserInfo.UserId;
                            String Json = await Settings.GetLastNotifictionAsync( LastNotification);
                            if (Json != "false" && Json!=null&&Json!="[]")
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
                                                NotificationViewObject notify = JsonConvert.DeserializeObject<NotificationViewObject>(Notifications[i].LBNotificationText);
                                                // Instantiate the builder and set notification elements, including pending intent:
                                                Android.Net.Uri sound = Android.Net.Uri.Parse("android.resource://" + Main.ApplicationContext.PackageName + "/raw/" + Resource.Raw.alarm);
                                                Notification.Builder builder = new Notification.Builder(Main)
                                                    .SetContentIntent(pendingIntent)
                                                    .SetContentTitle("DentalShop")
                                                    .SetContentText(notify.LBNotificationText +" "+ Notifications[i].Time)
                                                    .SetSmallIcon(Resource.Drawable.icon)
                                                    .SetAutoCancel(true)
                                                    .SetSound(sound);
                                                //Build the notification:
                                                Notification Not = builder.Build();
                                                //Get the notification manager:
                                                //Publish the notification:
                                                int notificationId = id;
                                                if (notificationManager == null)
                                                    notificationManager = (NotificationManager)Main.GetSystemService(Context.NotificationService);
                                                notificationManager.Notify(notificationId, Not);
                                                id++;
                                            }
                                            try
                                            {
                                                Settings.cash.LastNotification = Settings.ToMysqlTime(Settings.ToSystemDateTime(Notifications[Notifications.Length - 1].Time));
                                                Settings.SaveCash();
                                            }
                                            catch { }
                                            NotificationRecieved = true;
                                        }
                                        catch
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
            }).Start();
            return StartCommandResult.Sticky;
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
            Intent NotificationIntent = new Intent();
            NotificationIntent.SetAction("com.alr.text");
            NotificationIntent.PutExtra("Dental Shop", "Restart");
            SendBroadcast(NotificationIntent);
        }
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }
}