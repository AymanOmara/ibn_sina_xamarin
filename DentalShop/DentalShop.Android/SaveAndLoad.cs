using System;
using DentalShop.Droid;
using System.IO;
using System.Threading.Tasks;
using DentalShop;
[assembly: Xamarin.Forms.Dependency(typeof(SaveAndLoad))]
namespace DentalShop.Droid
{
    public class SaveAndLoad : ISaveAndLoad
    {
        public void SaveText(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);
        }
        public string LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return System.IO.File.ReadAllText(filePath);
        }

        void ISaveAndLoad.SaveTextAsync(string filename, string text)
        {
            throw new NotImplementedException();
        }

        Task<string> ISaveAndLoad.LoadTextAsync(string filename)
        {
            throw new NotImplementedException();
        }
    }
}