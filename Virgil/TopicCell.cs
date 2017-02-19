using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Virgil
{
    class TopicCell : ViewCell
    {
        public string Language { get; set; }
        public string Text { get; set; }
        public TopicCell()
        {
            this.Language = Helpers.Settings.Language;
            var appIcon = new Image
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Source = ImageSource.FromFile("PatientAider-29x29.png")
            };

            var title = new Label();
            //Title binding based on language
            switch (Language)
            {
                case "Deutsch":
                    title.SetBinding(Label.TextProperty, "TitleGerman");
                    break;
                case "English":
                    title.SetBinding(Label.TextProperty, "Title");
                    break;
                default:
                    title.SetBinding(Label.TextProperty, "Title");
                    break;
            }
            

            var topicLayout = CreateTopicLayout();
            topicLayout.Spacing = 10f;
            var viewLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { appIcon, topicLayout },
                Padding = new Thickness(10, 10, 10, 10)
            };
            View = viewLayout;
        }

        static StackLayout CreateTopicLayout()
        {
            var Language = Helpers.Settings.Language;
            var titleLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                HeightRequest = 24f
            };

            //Title binding based on language
            switch (Language)
            {
                case "Deutsch":
                    titleLabel.SetBinding(Label.TextProperty, "TitleGerman");
                    break;
                case "English":
                    titleLabel.SetBinding(Label.TextProperty, "Title");
                    break;
                default:
                    titleLabel.SetBinding(Label.TextProperty, "Title");
                    break;
            }

            titleLabel.TextColor = Color.FromRgb(0, 102, 204);
            titleLabel.FontFamily = Device.OnPlatform(
                iOS: "Avenir",
                Android: "Droid Sans Mono",
                WinPhone: "Ariel"
            );

            titleLabel.FontSize = Device.OnPlatform(
                22,
                Device.GetNamedSize(NamedSize.Medium, titleLabel),
                Device.GetNamedSize(NamedSize.Large, titleLabel)
            );

            var detailLabel = new Label
            {
                FontSize = Device.OnPlatform(12f, 12f, 12f),
                HeightRequest = 14f,
                FontAttributes = FontAttributes.Italic,
                TextColor = Color.FromRgb(160,160,160),
            };

            switch (Language)
            {
                case "Deutsch":
                    detailLabel.SetBinding(Label.TextProperty, "SummaryGerman");
                    break;
                case "English":
                    detailLabel.SetBinding(Label.TextProperty, "Summary");
                    break;
                default:
                    detailLabel.SetBinding(Label.TextProperty, "Summary");
                    break;
            }
                      
            var topicLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { titleLabel, detailLabel }
            };
            return topicLayout;
        }

    }
}
