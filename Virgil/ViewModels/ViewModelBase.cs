using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Virgil.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool loading;

        public ViewModelBase() //INavigation navigation
        {
            //Navigation = navigation;
        }
        
        public bool IsLoading
        {
            get { return loading; }
            set
            {
                loading = value;
                NotifyPropertyChanged("IsLoading");
            }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //public INavigation Navigation { get; }
    }
}

