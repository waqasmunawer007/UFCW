using System;
using System.Collections.Generic;
using UFCW.Views.Pages.Pension;
using Xamarin.Forms;

namespace UFCW.ViewModels.Pension
{
    public class PensionMenuVM
    {
        private static List<SampleCategory> pensionGridItemsList;

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

		List<SampleCategory> GetPensionItemsGrid()
		{
			var categories = new Dictionary<string, SampleCategory>();

			//SamplesList = new List<Sample> {
					//new Sample("Summary Docs", typeof(SummaryPlanDocPage), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder),
					//new Sample("My Benefits", typeof(My_Benifits), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Search),
					//new Sample("My Taxes", typeof(MyTaxes), SampleData.LoginImageGalleryItems[0], GrialShapesFont.Copy),
					//new Sample("Monthly Benefits", typeof(MonthlyBenefits), SampleData.LoginImageGalleryItems[0], GrialShapesFont.CreditCard),
					//new Sample("Direct Deposit", typeof(DirectDeposit), SampleData.LoginImageGalleryItems[0], FontAwesomeFont.Paste),
					//new Sample("Survivor's Data", typeof(SurvivorDate), SampleData.LoginImageGalleryItems[0], GrialShapesFont.QueryBuilder)



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
					Icon = GrialShapesFont.Help,
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
					Icon = GrialShapesFont.CreditCard,
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
					page = new SummaryPlanDocPage()
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
