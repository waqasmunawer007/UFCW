﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services.Models.NonCore;
using UFCW.Services.Services.NonCore;

namespace UFCW.ViewModels
{
	public class NewsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<News> newsList;
		private bool isBusy = false;

		public NewsViewModel()
		{
            newsList = new ObservableCollection<News>();
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

		public ObservableCollection<News> NewsList
		{
			get { return newsList; }
			set
			{
				if (newsList != value)
				{
					newsList = value;
					OnPropertyChanged("NewsList");
				}
			}
		}

        /// <summary>
        /// Fetchs the public news.
        /// </summary>
        /// <returns>The public news.</returns>
		public async Task FetchPublicNews()
		{
            IsBusy = true;
            this.NewsList.Clear();
            var service = new NonCoreService();
            NonCoreResponse responseData = await service.FetchPublicNonCoreData();
            if (responseData != null)
            {
                foreach(News news in responseData.News)
                {

                    this.NewsList.Add(news);
                }
            }
            IsBusy = false;
		}

        /// <summary>
        /// Fetchs the news for authenticated user.
        /// </summary>
        /// <returns>The auth news.</returns>
		public async Task FetchAuthNews()
		{
			IsBusy = true;
			this.NewsList.Clear();
			var service = new NonCoreService();
            NonCoreResponse responseData = await service.FetchAuthNonCoreData(Settings.UserToken, Settings.UserSSN);
			if (responseData != null)
			{
				foreach (News news in responseData.News)
				{

					this.NewsList.Add(news);
				}
			}
			IsBusy = false;
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
