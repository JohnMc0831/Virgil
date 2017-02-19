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

        private ListView topicsListView { get; set; }

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
            //var list = (ListView) sender;
            topicsListView.IsRefreshing = true;
            TopicsViewModel.Load();
            topicsListView.ItemsSource = TopicsViewModel.Topics;
            topicsListView.IsRefreshing = false;
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

            Title = "PatientAider";
            TopicsViewModel = new TopicsViewModel();
            TopicsViewModel.Load();
            topicsListView = new ListView()
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
                if (topic.Title == "Settings")
                {
                    await Navigation.PushAsync(new SettingsPage());
                }
                else
                {
                    await Navigation.PushAsync(new VirgilTopicPage(topic));
                }
                
            };

            if (Device.OS == TargetPlatform.iOS)
            {
                Padding = new Thickness(0, 20, 0, 0);
            }

            this.Content = new StackLayout
            {
                Children =
                {
                    topicsListView
                }
            };

            switch (Helpers.Settings.Language)
            {
                case "Deutsch":
                    LoadingMessage = "Themen werden geladen...";
                    break;
                case "English":
                    LoadingMessage = "Loading Topics...";
                    break;
                default:
                    LoadingMessage = "Loading Topics...";
                    break;
            }
            ShowLoadingFrame = true;
            ShowLoadingMessage = true;
            ShadeBackground = true;
            WaitingOrientation = StackOrientation.Vertical;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(TopicsViewModel.Language != Helpers.Settings.Language)
            {
                //change of language so refresh...
                TopicsViewModel.Language = Helpers.Settings.Language;
                switch (TopicsViewModel.Language)
                {
                    case "Deutsch":
                        LoadingMessage = "Themen werden geladen...";
                        break;
                    case "English":
                        LoadingMessage = "Loading Topics...";
                        break;
                    default:
                        LoadingMessage = "Loading Topics...";
                        break;
                }
                this.ExecuteTopicRefreshCommand();
            }

            if (TopicsViewModel.Topics.Count == 0)
            {
                IsWaiting = true;
                await Task.Delay(3000);
                IsWaiting = false;
            }
        }
    }
}
