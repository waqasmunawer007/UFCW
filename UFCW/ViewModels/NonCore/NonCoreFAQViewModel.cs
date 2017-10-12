using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services;
using UFCW.Services.Models.NonCore;
using UFCW.Services.Services.NonCore;
using Xamarin.Forms;

namespace UFCW.ViewModels.NonCore
{
	public class NonCoreFAQViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<FAQ> faqList;
		private bool isBusy = false;
        private FAQ _oldFaq;
        public NonCoreFAQViewModel()
		{
			faqList = new ObservableCollection<FAQ>();
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

		public ObservableCollection<FAQ> FAQList
		{
			get { return faqList; }
			set
			{
				if (faqList != value)
				{
					faqList = value;
					OnPropertyChanged("FAQList");
				}
			}
		}
		/// <summary>
		/// Fetchs the public links.
		/// </summary>
		/// <returns>The public links.</returns>
		public async Task<NonCoreResponse> FetchPublicFAQ()
		{
            this.FAQList.Clear();
			IsBusy = true;
           var service = new NonCoreService();
			NonCoreResponse responseData = await service.FetchPublicNonCoreData();

			if (responseData != null && String.IsNullOrEmpty(responseData.Message))
			{
				foreach (FAQ faq in responseData.FAQ)
				{

					this.FAQList.Add(faq);
				}
				IsBusy = false;
			}
			else
			{
				IsBusy = false;
			}
            return responseData;
		}

		/// <summary>
		/// Fetchs the auth news letter.
		/// </summary>
		/// <returns>The auth news letter.</returns>
		public  async Task<NonCoreResponse>  FetchAuthFAQ()
		{
            this.FAQList.Clear();
			IsBusy = true;
			var service = new NonCoreService();
			NonCoreResponse responseData = await service.FetchAuthNonCoreData(Settings.UserToken, Settings.UserSSN);
			if (responseData != null && String.IsNullOrEmpty(responseData.Message))
			{
				foreach (FAQ faq in responseData.FAQ)
				{

					this.FAQList.Add(faq);
				}
				IsBusy = false;
			}
			else
			{
				IsBusy = false;
			}
            return responseData;
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
        internal void ShowOrHideFaq(FAQ faq)
        {
           
            if (_oldFaq == faq)
            {
                // click twice on the same item will hide it
                faq.IsVisible = !faq.IsVisible;
                UpDateFaqs(faq);
            }
            else
            {
                if (_oldFaq != null)
                {
                    // hide previous selected item
                    _oldFaq.IsVisible = false;
                     UpDateFaqs(_oldFaq);
                }
                     // show selected item
                faq.IsVisible = true;
                UpDateFaqs(faq);

            }
            _oldFaq = faq;
        }

        private void UpDateFaqs(FAQ faq)
        {
            // delete the previous faq then place the updated faq  at the same index of deleted'faq
            // and  notify changes in FAQList 
            var index = FAQList.IndexOf(faq);   
            FAQList.Remove(faq);
            FAQList.Insert(index, faq);
        }

    }
}