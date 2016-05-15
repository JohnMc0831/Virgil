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
        public string Text { get; set; }
        public TopicCell()
        {
            var appIcon = new Image
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Source = ImageSource.FromFile("PatientSafe-25x25.png")
            };

            var title = new Label();
            title.SetBinding(Label.TextProperty, "Title");

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
            var titleLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                HeightRequest = 24f
            };

            titleLabel.SetBinding(Label.TextProperty, "Title");
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

            detailLabel.SetBinding(Label.TextProperty, "Summary");

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
