using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UFCW.Helpers;
using UFCW.Services.Models.ActivePension;
using UFCW.Services.Services.ActivePension;
using Xamarin.Forms;

namespace UFCW.ViewModels.ActivePension
{
    public class DocumentsVM: INotifyPropertyChanged
    {
        public ICommand UrlCommand { set; get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PlanDocument> documentsList;
		private bool isBusy = false;
        

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UFCW.ViewModels.ActivePension.DocumentsVM"/> class.
        /// </summary>
		public DocumentsVM()
		{
			documentsList = new ObservableCollection<PlanDocument>();
            UrlCommand = new Command<PlanDocument>((e) => {
                PlanDocument selectedItem = e;
                string url = selectedItem.Link;

                Device.OpenUri(new System.Uri(url));


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

        /// <summary>
        /// Fetchs the documents.
        /// </summary>
        /// <returns>The documents.</returns>
        public async Task<PlanDocument[]> FetchDocuments()
		{
            var beniftisService = new ActivePensionService();
            return await beniftisService.FetchDocuments(Settings.UserToken, Settings.UserSSN);
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