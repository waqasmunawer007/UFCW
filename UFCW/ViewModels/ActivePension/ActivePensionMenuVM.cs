using System;
using System.Collections.Generic;
using UFCW.Views.Pages.PensionActive;
using Xamarin.Forms;

namespace UFCW.ViewModels.ActivePension
{
    public class ActivePensionMenuVM
    {
		private static List<SampleCategory> ActivepensionGridItemsList;

		public List<SampleCategory> Items
		{
			get
			{
                if (ActivepensionGridItemsList == null)
				{
                    return GetActivePensionItemsGrid();
				}

				return ActivepensionGridItemsList;
			}
		}

		List<SampleCategory> GetActivePensionItemsGrid()
		{
			var categories = new Dictionary<string, SampleCategory>();

			categories.Add(
				"ParticipantDetails",
				new SampleCategory
				{
					Name = "Participant Details",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
					Icon = GrialShapesFont.Person,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
                    page = new UFCW.Views.Pages.PensionActive.ParticipantDetailPage()
				}
			);
			categories.Add(
				"MyBenifits",
				new SampleCategory
				{
					Name = "My Benifits",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[2]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
					Icon = GrialShapesFont.CardAmericaExpress,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
                    page = new MyBenifitsPage()
				}
			);
			categories.Add(
				"CurrentYearContributions",
				new SampleCategory
				{
					Name = "Current Year Contributions",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[2]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
					Icon = GrialShapesFont.QueryBuilder,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
                    page = new CurrentYearContributionPage()
				}
			);
			categories.Add(
				"ContributionHistoryEmp",
				new SampleCategory
				{
                Name = "Contribution History (Employer)",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
					Icon = FontAwesomeFont.CreditCard,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 5,
					Shape = GrialShapesFont.Circle,
                page = new ContributionHistoryEmployerPage()
				}
			);


			categories.Add(
				"ContributionHistoryYear",
				new SampleCategory
				{
                    Name = "Contribution History \n(Year)",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
					Icon = GrialShapesFont.Copy,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
					page = new ContributionHistoryYearPage()
				}
			);

			categories.Add(
				"Documents",
				new SampleCategory
				{
					Name = "Documents",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
					Icon = GrialShapesFont.Paste,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
                page = new DocumentsPage()
				}
			);

			ActivepensionGridItemsList = new List<SampleCategory>();
			foreach (var sample in categories.Values)
			{
				ActivepensionGridItemsList.Add(sample);
			}

			return ActivepensionGridItemsList;
		}
	}
}
