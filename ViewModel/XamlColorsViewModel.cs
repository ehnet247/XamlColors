using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using XamlColors.Model;

namespace XamlColors.ViewModel
{
    public class XamlColorsViewModel : ObservableRecipient, ICloseableViewModel
    {
        public ObservableCollection<ColorModel> Colors { get; set; }
        public XamlColorsAppSettings AppSettings { get; set; }
        public ICommand AddColorCmd { get; set; }

        public const string SettingsFileName = "XamlColorsAppSettings.json";


        public XamlColorsViewModel()
        {
            ReadSettingsAsync();
            AddColorCmd = new RelayCommand(AddColor);
            Colors = new ObservableCollection<ColorModel>();
            
        }

        private void AddColor()
        {
            Colors.Add(new ColorModel());
            OnPropertyChanged(nameof(Colors));
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
