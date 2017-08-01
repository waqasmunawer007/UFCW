using System;
using System.ComponentModel;

namespace UFCW.Models
{
    public class Profile: INotifyPropertyChanged
    {
        private string name;
        private string ssn;
        private string penstionStatus;
		public event PropertyChangedEventHandler PropertyChanged;

        public Profile(string userName,string ssn,string pensionStatus)
        {
            this.name = userName;
            this.ssn = ssn;
            this.penstionStatus = pensionStatus;
        }

		public String PenstionStatus
		{
			get { return penstionStatus; }
			set
			{
				penstionStatus = value;
				OnPropertyChanged("PenstionStatus");
			}
		}

        public String Name 
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

		public String SSN
		{
			get { return ssn; }
			set
			{
				ssn = value;
                OnPropertyChanged("SSN");
			}
		}

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
