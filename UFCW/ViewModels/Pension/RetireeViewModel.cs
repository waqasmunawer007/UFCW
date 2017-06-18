using System;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Services.Models.Pension;
using UFCW.Services.Services.Pension;

namespace UFCW.ViewModels.Pension
{
    public class RetireeViewModel: INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
		public Retiree retiree;

		private bool isBusy = false;

		string email = "UfcwRetiree@sinettechnologies.com";
		string token = "0000";
		string ssn = "512429544";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UFCW.ViewModels.Pension.RetireeViewModel"/> class.
        /// </summary>
		public RetireeViewModel()
		{
            retiree = new Retiree();
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
        public Retiree Retiree
		{
            get { return retiree; }
			set
			{
				if (retiree != value)
				{
					retiree = value;
					OnPropertyChanged("Retiree");
				}
			}
		}
        /// <summary>
        /// Fetchs the retiree.
        /// </summary>
        /// <returns>The retiree.</returns>
        public async Task<Retiree> FetchRetiree()
		{
			var pensionService = new PensionService();
            return await pensionService.FetchRetiree(token, ssn, email);
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
