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
            TopicsViewModel.Load();
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
           
            TopicsViewModel = new TopicsViewModel();
            TopicsViewModel.Load();
            var topicsListView = new ListView()
            {
                RowHeight = 60,
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

            if (Device.OS == TargetPlatform.iOS)
            {
                // move layout under the status bar
               this.Padding = new Thickness(0, 20, 0, 0);
            }

            this.Content = new StackLayout
            {
                Padding = new Thickness(0,0,0,10),
                Children =
                {
                    topicsListView
                }
            };
        }
    }
}
