using System;
using System.Collections.Generic;
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

        private void ExecuteTopicRefreshCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            RefreshTopicsCommand.ChangeCanExecute();
            
            //Load Topics
            TopicsViewModel.Load();
            
            IsBusy = false;
            RefreshTopicsCommand.ChangeCanExecute();
        } 

        public VirgilContentPage()
        {
            Title = "Hospital Patient Navigator";
            Icon = new FileImageSource
            {
                File = "HPN.png"
            };

            TopicsViewModel = new TopicsViewModel();
            //TODO:  Add loading page here...
            TopicsViewModel.Load();
            var topicsListView = new ListView
            {
                RowHeight = 40,
                ItemTemplate = new DataTemplate(typeof (TopicCell)),
                ItemsSource = TopicsViewModel.Topics,
                IsPullToRefreshEnabled = true,
            };

            topicsListView.RefreshCommand = new Command(() =>
            {
                if (IsBusy)
                {
                    return;
                }

                IsBusy = true;
                RefreshTopicsCommand.ChangeCanExecute();

                //Load Topics
                TopicsViewModel.Load();

                IsBusy = false;
                RefreshTopicsCommand.ChangeCanExecute();
            });

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
                    //new Image
                    //{
                    //    Source = "HPN.png",
                    //},
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
               // this.Padding = new Thickness(0, 20, 0, 0);
            }

            this.Content = new StackLayout
            {
                Children =
                {
                    //titleStack,
                    topicsListView
                }
            };
        }
    }
}
