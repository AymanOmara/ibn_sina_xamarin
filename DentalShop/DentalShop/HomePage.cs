using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;
namespace DentalShop
{
    public class HomePage : ContentPage
    {
        double w;
        double h;
        public HomePage()
        {
            try
            {
                Settings.ICC = Resolver.Resolve<IPhoneService>().ICC;
            }
            catch (Exception ex)
            {
                Settings.ICC = "eg";
            }
            w = App.w;
            h = App.h;
            var hardware = Resolver.Resolve<IDevice>();

            if ((w == 0 || h == 0) && Device.OS != TargetPlatform.iOS)
            {
                w = hardware.Display.Width / hardware.Display.Scale;
                h = hardware.Display.Height / hardware.Display.Scale;
            }
            else if (Device.OS != TargetPlatform.iOS)
            {
                w = w / hardware.Display.Scale;
                h = h / hardware.Display.Scale;
            }
            ReSetDeviceInfo(hardware);
            Settings.splashScreen = new SplashScreen((int)w, (int)h, this);
            this.PropertyChanged += Content_PropertyChanged;
        }
        public static void ReSetDeviceInfo(IDevice hardware)
        {
            DeviceInfo DI = new DeviceInfo();
            try
            {
                DI.OS = Device.OS.ToString();
                DI.DisplayHeight = "" + hardware.Display.Height;
                DI.DisplayScale = "" + hardware.Display.Scale;
                DI.DisplayWidth = "" + hardware.Display.Width;
                DI.DisplayXdpi = "" + hardware.Display.Xdpi;
                DI.DisplayYdpi = "" + hardware.Display.Ydpi;
                DI.FirmwareVersion = hardware.FirmwareVersion;
                DI.HardwareVersion = hardware.HardwareVersion;
                DI.Id = hardware.Id;
                DI.LanguageCode = hardware.LanguageCode;
                DI.Manufacturer = hardware.Manufacturer;
                DI.TimeZone = hardware.TimeZone;
                DI.TimeZoneOffset = "" + hardware.TimeZoneOffset;
                DI.CellularProvider = hardware.PhoneService.CellularProvider;
                DI.ICC = hardware.PhoneService.ICC;
                DI.IsCellularDataEnabled = (hardware.PhoneService.IsCellularDataEnabled == true) ? "true" : "false";
                DI.MNC = hardware.PhoneService.MNC;
            }
            catch
            {

            }
            //Settings.DeviceInfo = DI;
        }
        private void Content_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "Content")
                {
                    if (Content != null )
                    {
                        if (Settings.PageStack.Count != 0)
                        {
                            if (Content != Settings.PageStack.Peek())
                            {
                                if ( Content == Settings.mainPage.MainLayout)
                                    Settings.PageStack.Clear();
                                Settings.PageStack.Push(Content);
                            }
                        }
                        else
                        {
                            Settings.PageStack.Push(Content);
                        }
                    }
                }
            }
            catch { }
        }
        protected override bool OnBackButtonPressed()
        {
            if (Content==Settings.proudectMaterialsDetails.MainLayout)
            {
                Settings.proudectMaterialsDetails.ImgBackClickAsync();
                return true;
            }
            else if (Content == Settings.proudectDeivceDetails.MainLayout)
            {
                Settings.proudectDeivceDetails.ImgBackClickAsync();
                return true;
            }
            else if (Content == Settings.proudectEquipmentDetails.MainLayout)
            {
                Settings.proudectEquipmentDetails.ImgBackClickAsync();
                return true;
            }
            else if (Content == Settings.proudectsMachinesDetails.MainLayout)
            {
                Settings.proudectsMachinesDetails.ImgBackClickAsync();
                return true;
            }
            else if (Content == Settings.prouductCorrectionDetails.MainLayout)
            {
                Settings.prouductCorrectionDetails.ImgBackClickAsync();
                return true;
            }
            else if (Content == Settings.ClothesDetails.MainLayout)
            {
                Settings.ClothesDetails.ImgBackClickAsync();
                return true;
            }

            else
            {
                try
                {
             
                    View Current = Settings.PageStack.Pop();
                    if (Current == Settings.mainPage.MainLayout || Current == Settings.splashScreen.MainLayout)
                    {
                        ShowExitDialog();
                        Settings.PageStack.Clear();
                        Settings.PageStack.Push(Current);
                        return true;
                    }
                    try
                    {
                        this.Content = Settings.PageStack.Pop();
                    }
                    catch { }
                    return true;
                }
                catch
                {
                    if (Settings.mainPage != null)
                    {
                        Settings.splashScreen.LoadScreensAsync();
                        Content = Settings.mainPage.MainLayout;
                        return true;
                    }
                    else
                        return false;
                }
            }
        }


        private async void ShowExitDialog()
        {
            bool close = false;
            
                close = await DisplayAlert("DentalShop", "هل تريد بالفعل إغلاق التطبيق؟", "نعم", "لا");
           
            if (close)
            {
                DependencyService.Get<IAppHider>().HideApp();
            }

        }
        public void RefreshContent()
        {
            if (Settings.PageStack.Count != 0)
            {
                ClearValue(ContentProperty);
                Content = Settings.PageStack.Peek();
            }
        }
    }
}
