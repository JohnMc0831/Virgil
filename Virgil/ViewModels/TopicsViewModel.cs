using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Virgil.ViewModels
{
    public class TopicsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public TopicsViewModel() : base()
        {}
        
        private ObservableCollection<Topic> myTopics;

        public ObservableCollection<Topic> MyTopics
        {
            get
            {
                return myTopics;
            }
            set
            {
                myTopics = value;
                NotifyPropertyChanged("MyTopics");
            }
        }

        private ObservableCollection<Topic> topics;

        public ObservableCollection<Topic> Topics {
            get
            {
                return topics;
            }
            set
            {
                topics = value;
                NotifyPropertyChanged("Topics");
            }
        }

        public async void Load()
        {
            IsLoading = true;
            //escape if already loaded
            if (Topics != null)
            {
                return;
            }
            Topics = new ObservableCollection<Topic>();
            var topicList = await App.GetTopicManager().GetTopics();
            foreach (var t in topicList)
            {
                Topics.Add(t);
            }
            IsLoading = false;
        }
    }
}
