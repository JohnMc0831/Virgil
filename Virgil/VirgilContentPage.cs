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
    public class VirgilContentPage : WaitingPage
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
            Indicator.IsRunning = true;
            Indicator.IsVisible = true;
            OnRefresh(this, new EventArgs());
            Indicator.IsRunning = false;
            Indicator.IsVisible = false;
        }

        public VirgilContentPage()
        {
            var myContentPage = this;
            //this.Push(myContentPage);

            var s = "psmf_logo.png";
            NavigationPage.SetTitleIcon(myContentPage, s);
            Title = "PatientAider";
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
            topicsListView.ItemTapped += async (sender, e) =>
            {
                var topic = (Topic) e.Item;
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

            LoadingMessage = "Loading Topics...";
            ShowLoadingFrame = true;
            ShowLoadingMessage = true;
            ShadeBackground = true;
            WaitingOrientation = StackOrientation.Vertical;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (TopicsViewModel.Topics.Count == 0)
            {
                IsWaiting = true;
                await Task.Delay(3000);
                IsWaiting = false;
            }
        }
    }
}
