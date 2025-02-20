﻿using System.Threading.Tasks;


namespace DentalShop
{
    public interface ISaveAndLoad
    {
        void SaveText(string filename, string text);
        string LoadText(string filename);
        void SaveTextAsync(string filename, string text);
        Task<string> LoadTextAsync(string filename);
    }
}
