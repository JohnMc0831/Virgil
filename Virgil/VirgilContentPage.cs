using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        private Command refreshTopicsCommand;

        public TopicsViewModel TopicsViewModel { get; set; }
    
        public Command RefreshTopicsCommand
        {
            get
            {
                return refreshTopicsCommand ?? (refreshTopicsCommand = new Command(ExecuteTopicRefreshCommand, () => !IsBusy));
            }
        }

        void OnRefresh(object sender, EventArgs e)
        {
            IsBusy = true;
            var list = (ListView) sender;
            list.IsRefreshing = true;
            //Load Topics
            TopicsViewModel.Load();

            list.ItemsSource = null;  //force a refresh of the listview.  See Xamarin bug #26418 discussed here: https://forums.xamarin.com/discussion/18631/listview-binding-to-observablecollection-does-not-update-gui/p1
            list.ItemsSource = TopicsViewModel.Topics;
            list.IsRefreshing = false;
            IsBusy = false;
        }

        private void ExecuteTopicRefreshCommand()
        {
            OnRefresh(this, new EventArgs());
        } 

        public VirgilContentPage()
        {
            Title = "Hospital Patient Navigator";
            Icon = new FileImageSource
            {
                File = "HPN.png"
            };

            Grid grid = new Grid();
            grid.VerticalOptions = LayoutOptions.FillAndExpand;
            grid.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
            
            TopicsViewModel = new TopicsViewModel();
            //TODO:  Add loading page here...
            TopicsViewModel.Load();
            var topicsListView = new ListView()
            {
                RowHeight = 40,
                ItemTemplate = new DataTemplate(typeof (TopicCell)),
                ItemsSource = TopicsViewModel.Topics,
                IsPullToRefreshEnabled = true
            };
            topicsListView.Refreshing += OnRefresh;
            topicsListView.ItemSelected += async (sender, e) =>
            {
                var topic = (Topic) e.SelectedItem;
                await Navigation.PushAsync(new VirgilTopicPage(topic));
            };

            grid.Children.Add(topicsListView);

            var titleStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Spacing = 10,
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        Children = {
                            new Label()
                            {
                                Text = "Hospital Patient Navigator",
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
               this.Padding = new Thickness(0, 20, 0, 0);
            }

            this.Content = new StackLayout
            {
                Children =
                {
                    topicsListView
                }
            };
        }
    }
}
