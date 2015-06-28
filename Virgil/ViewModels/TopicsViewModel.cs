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
    public class AuctionsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public AuctionsViewModel(INavigation navigation) : base(navigation)
        {
        }

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

        public void Load()
        {
            //escape if already loaded
            if (Topics != null)
            {
                 return;
            }
               
            IsLoading = true;
            App.GetTopicManager().GetTopicsAsync().ContinueWith(gmit => {
                if(gmit.Exception == null)
                {
                    myTopics = new ObservableCollection<Topic>(gmit.Result);
                }
                else
                {
                    //Notify of error
                }
                IsLoading = false;
            });
        }
    }
}
