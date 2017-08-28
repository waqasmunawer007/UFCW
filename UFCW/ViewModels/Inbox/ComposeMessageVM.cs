using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace UFCW.ViewModels.Inbox
{
    public class ComposeMessageVM : INotifyPropertyChanged
    {
        public ComposeMessageVM()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
