
using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Newtonsoft.Json;

namespace DentalShop.Droid
{
    //[BroadcastReceiver(Exported = true, Label = "ClcexApp")]
    [IntentFilter(new string[] { "com.alr.text" })]
    public class MyReciever : Android.Content.BroadcastReceiver
    {
        public static Activity Main = null;
        private int id = 6000;
        Intent current = null;
        public static NotificationManager notificationManager = null;
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == "com.alr.text")
            {

                current = intent;
                /*
                try
                {
                    String Content = intent.GetStringExtra("ClcexDataProvider") ?? "";
                    if (Content == "Restart")
                    {
                        Main.StartService(new Intent(Main, typeof(ClcexServices)));
                    }
                }
                catch { }
                */
            }
        }
    }
}