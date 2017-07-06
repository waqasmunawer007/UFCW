using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UFCW.ViewModels.Eligibility
{
    public class EligibilityMenuVM
    {
        private static List<SampleCategory> eligibilityGridItemsList;

		public List<SampleCategory> Items
		{

			get
			{
				if (eligibilityGridItemsList == null)
				{
					return GetEligibilityItemsGrid();
				}

				return eligibilityGridItemsList;
			}
		}

		List<SampleCategory> GetEligibilityItemsGrid()
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
					page = new ParticipantDetailPage()
				}
			);
			categories.Add(
				"BenefitPlans",
				new SampleCategory
				{
					Name = "Benefits FAQ",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[2]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.Help,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
					page = new BenefitPlanPage()
				}
			);
			categories.Add(
				"ChecksIssued",
				new SampleCategory
				{
					Name = "Checks Issued",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[2]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.CreditCard,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
					page = new ChecksIssuedPage()
				}
			);
			categories.Add(
				"Dpenedents",
				new SampleCategory
				{
					Name = "My Depenedents",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = FontAwesomeFont.Group,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 5,
					Shape = GrialShapesFont.Circle,
					page = new DependentsPage()
				}
			);


			categories.Add(
				"TimeLoss",
				new SampleCategory
				{
					Name = "Time Loss",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.QueryBuilder,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
					page = new TimeLossPage()
				}
			);
			categories.Add(
				"EligibilityReport",
				new SampleCategory
				{
					Name = "Eligibility Report",
					BackgroundColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					BackgroundImage = SampleData.LoginImageGalleryItems[0],
                    Icon = GrialShapesFont.Copy,
					IconColor = Color.FromHex(SamplesDefinition._categoriesColors[0]),
					Badge = 2,
					Shape = GrialShapesFont.Circle,
					page = new EligibilityReportPage()
				}
			);

			eligibilityGridItemsList = new List<SampleCategory>();
			foreach (var sample in categories.Values)
			{
				eligibilityGridItemsList.Add(sample);
			}

            return eligibilityGridItemsList;
		}
    }
}
