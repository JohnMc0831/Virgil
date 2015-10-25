using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Virgil.ViewModels;
using Xamarin.Forms;

namespace Virgil
{
    public class VirgilContentPage : ContentPage
    {
        public TopicsViewModel Model { get; set; }
        public VirgilContentPage()
        {
            Title = "I am Virgil";
            Icon = new FileImageSource() { File = "Icon-Small-40.png" };
            Model = new TopicsViewModel();
            Model.Load();
            var topicsListView = new ListView();
            topicsListView.RowHeight = 40;
            topicsListView.ItemTemplate = new DataTemplate(typeof(TopicCell));           
            topicsListView.ItemsSource = Model.Topics.ToList();
            topicsListView.ItemSelected += async (sender, e) =>
            {
                var topic = (Topic) e.SelectedItem;
                await Navigation.PushAsync(new VirgilTopicPage(topic));
            };

            var titleStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Spacing = 10,
                Children =
                {
                    new Image
                    {
                        Source = "Icon-Small-40.png",
                    },
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        Children = {
                            new Label()
                            {
                                Text = "Your Patient Survival Guide",
                                TextColor = Color.Green,
                                FontSize = 12
                            }
                        }
                    }
                }
            };

            if (Device.OS == TargetPlatform.iOS)
            {
                // move layout under the status bar
               // this.Padding = new Thickness(0, 20, 0, 0);
            }

            this.Content = new StackLayout
            {
                Children =
                {
                    titleStack,
                    topicsListView
                }
            };
        }
    }
}
