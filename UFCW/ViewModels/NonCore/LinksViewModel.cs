﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services.Models.NonCore;
using UFCW.Services.Services.NonCore;
using Xamarin.Forms;

namespace UFCW.ViewModels.NonCore
{
	public class LinksViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<LinkResponse> linksList;
		public ICommand VisitButtonCommand { get; set; }
		private bool isBusy = false;

        public LinksViewModel()
		{
           linksList = new ObservableCollection<LinkResponse>(); 

			VisitButtonCommand = new Command((e) =>
			{
				LinkResponse selectedItem = (e as LinkResponse);
                if (selectedItem.Links != null && selectedItem.Links.Count > 0)
                {
                    String url = selectedItem.Links[0].Url;
                    if (!String.IsNullOrEmpty(url))
                    {
                        Device.OpenUri(new System.Uri(url));

                    }
                }
			});
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

		public ObservableCollection<LinkResponse> LinksList
		{
			get { return linksList; }
			set
			{
				if (linksList != value)
				{
					linksList = value;
					OnPropertyChanged("LinksList");
				}
			}
		}

		/// <summary>
        /// Fetchs the public links.
        /// </summary>
        /// <returns>The public links.</returns>
		public async Task FetchPublicLinks()
		{
            this.LinksList.Clear();
			IsBusy = true;
			var service = new NonCoreService();
			NonCoreResponse responseData = await service.FetchPublicNonCoreData();
			if (responseData != null && String.IsNullOrEmpty(responseData.Message))
			{
				foreach (LinkResponse link in responseData.Links)
				{

					this.LinksList.Add(link);
				}
				IsBusy = false;

			}
			else
			{
				IsBusy = false;
				await Application.Current.MainPage.DisplayAlert(AppConstants.ERROR_TITLE, responseData.Message, "OK");
			}
		}
        /// <summary>
        /// Fetchs the links for authenticated user.
        /// </summary>
        /// <returns>The auth links.</returns>
		public async Task FetchAuthLinks()
		{
			this.LinksList.Clear();
			IsBusy = true;
			var service = new NonCoreService();
			NonCoreResponse responseData = await service.FetchAuthNonCoreData();
            if (responseData != null && String.IsNullOrEmpty(responseData.Message))
			{
				foreach (LinkResponse link in responseData.Links)
				{

					this.LinksList.Add(link);
				}
                IsBusy = false;

			}
            else
            {
                IsBusy = false; 
                await Application.Current.MainPage.DisplayAlert(AppConstants.ERROR_TITLE, responseData.Message, "OK");
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

