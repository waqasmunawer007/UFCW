using System;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services.Models.ActivePension;
using UFCW.Services.Services.ActivePension;

namespace UFCW.ViewModels.ActivePension
{
    public class ParticipantDetailVM: INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        private Profile _profile;
		private bool isBusy = false;

		/// <summary>
        /// Initializes a new instance of the <see cref="T:UFCW.ViewModels.ActivePension.ParticipantDetailVM"/> class.
        /// </summary>
		public ParticipantDetailVM()
		{
			_profile = new Profile();
		}

		/// <summary>
		/// Gets or sets a value indicating for Activity Indicator.
		/// </summary>
		/// <value><c>true</c> if is busy; otherwise, <c>false</c>.</value>
		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				if (isBusy != value)
				{
					isBusy = value;
					OnPropertyChanged("IsBusy");
				}
			}
		}

		/// <summary>
        /// Gets or sets the profile.
        /// </summary>
        /// <value>The profile.</value>
		public Profile profile
		{
			get { return _profile; }
			set
			{
				if (_profile != value)
				{
					_profile = value;
					OnPropertyChanged("profile");
				}
			}
		}

		/// <summary>
        /// Fetchs the profile.
        /// </summary>
        /// <returns>The profile.</returns>
		public async Task<Profile> FetchProfile()
		{
			var pensionService = new ActivePensionService();
            _profile = await pensionService.FetchProfile();
            return _profile;
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
