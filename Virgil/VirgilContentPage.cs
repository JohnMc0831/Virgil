using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virgil.ViewModels;
using Xamarin.Forms;

namespace Virgil
{
    public class VirgilContentPage : ContentPage
    {
        public VirgilContentPage()
        {
            List<View> contentItems = new List<View>();
            var title = new Label()
            {
                Text = "Greetings! I am Virgil.  Let me be your guide...",
                FontAttributes = FontAttributes.Italic,
                FontSize = 20,
                BackgroundColor = Color.White,
                TextColor = Color.Green,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            
            var topicsStack = new StackLayout()
            {
                Padding = 5,
                Spacing = 0,            
            };
            
            var topicsVM = new TopicsViewModel();
            topicsVM.Load();
            var topics = topicsVM.Topics;
            var topicLabels = new List<Label>();
            foreach (var t in topics)
            {
                var topicLabel = new Label()
                {
                    Text = t.Title,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 14,
                    BackgroundColor = string.IsNullOrEmpty(t.BackColor) ? Color.Green : Color.FromHex(t.BackColor),
                    TextColor = string.IsNullOrEmpty(t.TextColor) ? Color.White : Color.FromHex(t.TextColor)
                };
                topicsStack.Children.Add(topicLabel);
            }

            var stackLayout = new StackLayout
            {
                Children =
                {
                    title,
                    topicsStack
                }
            };

            if (Device.OS == TargetPlatform.iOS)
            {
                // move layout under the status bar
                stackLayout.Padding = new Thickness(0, 20, 0, 0);
            }
            this.Content = stackLayout;
        }
    }
}
