using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Virgil
{
    public partial class SettingsPage : ContentPage
    {
        private ObservableCollection<languageModel> languages { get; set; }
        public SettingsPage()
        {
            languages = new ObservableCollection<languageModel>();
            InitializeComponent();
            
            settingsListView.ItemsSource = languages;
            //Commenting out German until deal is done...
            //languageModel deutsch = new languageModel
            //{
            //    Language = "Deutsch",
            //    Flag = "deutsch.png"
            //};

            languageModel english = new languageModel
            {
                Language = "English",
                Flag = "english.png"
            };
            
            settingsListView.ItemTemplate = new DataTemplate(typeof(ImageCell));
            settingsListView.ItemTemplate.SetBinding(ImageCell.TextProperty, "Language");
            settingsListView.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, "Flag");

            settingsListView.ItemTapped += async (sender, e) =>
            {
                var lang = (languageModel)e.Item;
                Virgil.Helpers.Settings.Language = lang.Language;
                System.Diagnostics.Debug.WriteLine($"Default language is now {lang.Language} stored as {Helpers.Settings.Language}");
                await Navigation.PopToRootAsync();
            };

            //languages.Add(deutsch);
            languages.Add(english);
            settingsListView.SelectedItem = languages.First(l => l.Language == Virgil.Helpers.Settings.Language);
        }

        public class languageModel
        {
            public string Language { get; set; }
            public string Flag { get; set; }
        }
    }
}
