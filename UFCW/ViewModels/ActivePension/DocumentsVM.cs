using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Services.Models.ActivePension;
using UFCW.Services.Services.ActivePension;

namespace UFCW.ViewModels.ActivePension
{
    public class DocumentsVM: INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PlanDocument> documentsList;

		private bool isBusy = false;

		string email = "sam@paysolar.com";
		string token = "0000";
		string ssn = "413112352";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UFCW.ViewModels.ActivePension.DocumentsVM"/> class.
        /// </summary>
		public DocumentsVM()
		{
			documentsList = new ObservableCollection<PlanDocument>();
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
            return await beniftisService.FetchDocuments(token, ssn);
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