using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services;
using UFCW.Services.Services.Claims;

namespace UFCW
{
	public class FAQViewModel: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<FAQ> FAQList;
		private bool isBusy = false;
        private FAQ _oldFaq;
        public FAQViewModel()
		{
			FAQList = new ObservableCollection<FAQ>();
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
		/// Gets the FAQ.
		/// </summary>
		/// <returns>The FAQ.</returns>
		public async Task<FAQ[]> GetFAQs()
		{
			var claimService = new ClaimService();
			return await claimService.FetchFAQ(Settings.UserToken, Settings.UserSSN);
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
            // product.IsVisible = true;
            // UpDateProducts(product);
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
            var index = FAQList.IndexOf(faq);
            FAQList.Remove(faq);
            FAQList.Insert(index, faq);
        }

    }
}
