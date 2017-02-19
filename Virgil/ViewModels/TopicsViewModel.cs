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

        public string Language { get; set; }

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
            Language = Helpers.Settings.Language;
            Topics = new ObservableCollection<Topic>();
            var topicList = await App.GetTopicManager().GetTopics();
            foreach (var t in topicList)
            {
                Topics.Add(t);
            }
        }
    }
}
