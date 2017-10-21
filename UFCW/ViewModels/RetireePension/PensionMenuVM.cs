using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services.Models.Pension;
using UFCW.Services.Services.Pension;
using UFCW.Views.Pages.Pension;
using Xamarin.Forms;

namespace UFCW.ViewModels.Pension
{
    public class PensionMenuVM: INotifyPropertyChanged
    {
        private static List<SampleCategory> pensionGridItemsList;
		private bool isBusy = false;
		public Retiree retiree;
		public event PropertyChangedEventHandler PropertyChanged;

		public PensionMenuVM()
		{ 
			 retiree = new Retiree();
		}


		public List<SampleCategory> Items
		{
			get
			{
				if (pensionGridItemsList == null)
				{
                    return GetPensionItemsGrid();
				}
				return pensionGridItemsList;
			}
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
			return await pensionService.FetchRetiree();
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

		/// <summary>
		/// Prepare the submenu option grid for Pension Retiree
		/// </summary>
		/// <returns>The pension items grid.</returns>
		List<SampleCategory> GetPensionItemsGrid()
		{
			var categories = new Dictionary<string, SampleCategory>();

			categories.Add(
				"MyBenefits",
				new SampleCategory
                {
                    Name = "My Benefits",
                    BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
                    BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.Person,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
					page = new MyBenifitsPage()
				}
			);
			categories.Add(
				"MyTaxes",
				new SampleCategory
				{
					Name = "My Taxes",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[2]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.CardAmericaExpress,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
					page = new MyTaxesPage()
				}
			);
			categories.Add(
				"MonthlyBenefits",
				new SampleCategory
                {
                    Name = "Monthly Benefits",
                    BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[2]),
                    BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.QueryBuilder,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
					page = new MonthlyBenefitsPage()
				}
			);
			categories.Add(
				"DirectDeposit",
				new SampleCategory
				{
					Name = "Direct Deposit",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = FontAwesomeFont.CreditCard,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 5,
					Shape = GrialShapesFont.Circle,
					page = new DirectDepositPage()
				}
			);


			categories.Add(
				"SurvivorData",
				new SampleCategory
				{
					Name = "Survivor's Data",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.Copy,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
					page = new SurvivorDate()
				}
			);

			categories.Add(
				"SummaryDocs",
				new SampleCategory
				{
					Name = "Summary Plan Docs",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
					Icon = GrialShapesFont.Paste,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
					page = new PensionSummaryPlanDocPage()
				}
			);

			pensionGridItemsList = new List<SampleCategory>();
			foreach (var sample in categories.Values)
			{
				pensionGridItemsList.Add(sample);
			}

			return pensionGridItemsList;
		}
	}
}
