using System;
using Xamarin.Forms;

namespace DentalShop
{
    public class DeviceInfo
    {
        public String OS { get; set; }
        public String DisplayHeight { get; set; }
        public String DisplayWidth { get; set; }
        public String DisplayScale { get; set; }
        public String DisplayXdpi { get; set; }
        public String DisplayYdpi { get; set; }
        public String FirmwareVersion { get; set; }
        public String HardwareVersion { get; set; }
        public String Id { get; set; }
        public String LanguageCode { get; set; }
        public String Manufacturer { get; set; }
        public String CellularProvider { get; set; }
        public String ICC { get; set; }
        public String IsCellularDataEnabled { get; set; }
        public String MNC { get; set; }
        public String TimeZone { get; set; }
        public String TimeZoneOffset { get; set; }
		private String appVersion = "1.6.6";
        public String AppVersion
        {
            get { return appVersion; }
            set { appVersion = value; }
        }
        private string appType = "ServiceProvider";
        public String AppType
        {
            get { return appType; }
            set { appType = value; }
        }

        public DeviceInfo()
        {
         
        }
    }
}