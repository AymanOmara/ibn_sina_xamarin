using System;
using System.Collections.Generic;

namespace DentalShop
{
    public class Cash
    {
        public String LastNotification { get; set; }
        public bool LoggedIn { get; set; }
        public UserEntity UserInfo { get; set; }
        private bool deviceInfoSaved = false;
        public bool DeviceInfoSaved
        {
            get { return deviceInfoSaved; }
            set { deviceInfoSaved = value; }
        }
        public List<ProuductEntity> FavoriteList { get; set; }
        public List<ProuductEntity> CartList { get; set; }
        public List<String> Panner { get; set; }
        public Cash()
        {
            LastNotification = "";
            FavoriteList = new List<ProuductEntity>();
            CartList = new List<ProuductEntity>();
            Panner = new List<string>();
        }
    }
}
