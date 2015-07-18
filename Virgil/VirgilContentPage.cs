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
            Title = "I am Virgil";
            Icon = new FileImageSource() {File = "Icon-Small-40.png"};
            var topicsVM = new TopicsViewModel();
            topicsVM.Load();
            var topics = topicsVM.Topics;

            var topicsListView = new ListView()
            {
                RowHeight = 40
            };
            topicsListView.ItemsSource = topics;
            topicsListView.ItemTemplate = new DataTemplate(typeof(TopicCell));

            topicsListView.ItemSelected += async (sender, e) =>
            {
                var topic = (Topic) e.SelectedItem;
                await Navigation.PushAsync(new VirgilTopicPage(topic));
                //await DisplayAlert("Tapped!", topic.Title + " was tapped.", "OK");
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
                                TextColor = Color.Silver,
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
