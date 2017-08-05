using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UFCW.Helpers;
using UFCW.Services.Models.NonCore;
using UFCW.Services.Services.NonCore;

namespace UFCW.ViewModels.NonCore
{
	public class NewsLetterViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<NewsLetter> newsLetterList;
		private bool isBusy = false;
        private NewsLetter _oldNewsLetter;
        public NewsLetterViewModel()
		{
			newsLetterList = new ObservableCollection<NewsLetter>();
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

		public ObservableCollection<NewsLetter> NewsLetterList
		{
			get { return newsLetterList; }
			set
			{
				if (newsLetterList != value)
				{
					newsLetterList = value;
					OnPropertyChanged("NewsLetterList");
				}
			}
		}
		/// <summary>
		/// Fetchs the public links.
		/// </summary>
		/// <returns>The public links.</returns>
		public async Task FetchPublicNewsLetter()
		{
            this.NewsLetterList.Clear();
			IsBusy = true;
			var service = new NonCoreService();
			NonCoreResponse responseData = await service.FetchPublicNonCoreData();
			if (responseData != null)
			{
                foreach (NewsLetter newsLetter in responseData.NewsLetters)
                {

                    this.NewsLetterList.Add(newsLetter);
                }
			}
			IsBusy = false;
		}
	
        /// <summary>
        /// Fetchs the auth news letter.
        /// </summary>
        /// <returns>The auth news letter.</returns>
		public async Task FetchAuthNewsLetter()
		{
            this.NewsLetterList.Clear();
			IsBusy = true;
			var service = new NonCoreService();
			NonCoreResponse responseData = await service.FetchAuthNonCoreData(Settings.UserToken, Settings.UserSSN);
			if (responseData != null)
			{
				foreach (NewsLetter newsLetter in responseData.NewsLetters)
				{

                    this.NewsLetterList.Add(newsLetter);
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
        internal void ShowOrHideNewsLetter(NewsLetter newsLetter)
        {
			var index = NewsLetterList.IndexOf(newsLetter);
			NewsLetter selectedLetter = NewsLetterList[index];
            if (selectedLetter.IsVisible)
            {
                selectedLetter.IsVisible = false;
				
            }
            else
            {
                selectedLetter.IsVisible = true;
				
            }

            //if (_oldNewsLetter == newsLetter)
            //{
            //    // click twice on the same item will hide it
            //    newsLetter.IsVisible = !newsLetter.IsVisible;
            //    UpDateNewsLetterList(newsLetter);
            //}
            //else
            //{
            //    if (_oldNewsLetter != null)
            //    {
            //        // hide previous selected item
            //        _oldNewsLetter.IsVisible = false;
            //        UpDateNewsLetterList(_oldNewsLetter);
            //    }
            //    // show selected item
            //    newsLetter.IsVisible = true;
            //    UpDateNewsLetterList(newsLetter);
            //}
            //_oldNewsLetter = newsLetter;
        }
        private void UpDateNewsLetterList(NewsLetter newsLetter)
        {
            // delete the previous newsletter then place the new newsletter (updated IsVisible Flag) at the same index of newsletter'faq
            // and  notify changes in newsLetterList 
            int index = NewsLetterList.IndexOf(newsLetter);
            if (index != -1)
            {
				NewsLetterList.Remove(newsLetter);
				NewsLetterList.Insert(index, newsLetter);
            }

        }
    }
}