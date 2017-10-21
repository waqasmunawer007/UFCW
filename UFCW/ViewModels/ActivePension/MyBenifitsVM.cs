using System;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services.Models.ActivePension;
using UFCW.Services.Services.ActivePension;

namespace UFCW.ViewModels.ActivePension
{
    public class MyBenifitsVM: INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        private MyBenifits benifits;
		private bool isBusy = false;

		/// <summary>
        /// Initializes a new instance of the <see cref="T:UFCW.ViewModels.ActivePension.MyBenifitsVM"/> class.
        /// </summary>
		public MyBenifitsVM()
		{
            benifits = new MyBenifits();
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
        /// Gets or sets a value of retiree.
        /// </summary>
        public MyBenifits Benifits
		{
			get { return benifits; }
			set
			{
				if (benifits != value)
				{
					benifits = value;
					OnPropertyChanged("Benifits");
				}
			}
		}
		
        /// <summary>
        /// Fetchs the benifits.
        /// </summary>
        /// <returns>The benifits.</returns>
		public async Task<MyBenifits> FetchBenifits()
		{
			var pensionService = new ActivePensionService();
            benifits = await pensionService.FetchBenifits();;
            return benifits;
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
