using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XamlColors.Model;

namespace XamlColors.ViewModel
{
    public class XamlColorsViewModel : ObservableRecipient, ICloseableViewModel
    {
        public XamlColorsAppSettings AppSettings { get; set; }

        public const string SettingsFileName = "XamlColorsAppSettings.json";


        public XamlColorsViewModel()
        {
            ReadSettingsAsync();
            
        }

        private async Task ReadSettingsAsync()
        {
            if (File.Exists(SettingsFileName))
            {
                try
                {
                    string jsonString = File.ReadAllText(SettingsFileName);
                    AppSettings = JsonSerializer.Deserialize<XamlColorsAppSettings>(jsonString)!;
                }
                catch (Exception ex) { }
            }
        }

        public void Closing()
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            string jsonString = JsonSerializer.Serialize(AppSettings);
            try
            {
                File.WriteAllText(SettingsFileName, jsonString);
            }
            catch (Exception ex) { }
        }
    }
}
