﻿using System;
using System.ComponentModel;
using UFCW.Services.UserService;
using System.Collections.ObjectModel;
using UFCW.Services.Models.Eligibility;
using System.Threading.Tasks;

namespace UFCW.ViewModels.Eligibility
{
    public class ParticipantsViewModel:INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
		private bool isBusy = false;


		public ParticipantsViewModel()
		{
            //participantsList = new ObservableCollection<Participant>();
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

  //      public async Task<Participant[]> FetchParticipants()
		//{
		//	var beniftisService = new EligibilityService();
  //          return await beniftisService.FetchParticipants(token, ssn, email);
		//}

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