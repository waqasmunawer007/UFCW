using System;
namespace UFCW.Services.Models.ActivePension
{
	public class HistoryByYear
	{
		public int SerialNumber { get; set; }
		public string Employer { get; set; }
		public double Year { get; set; }
		public string Plan { get; set; }
		public double Hour { get; set; }
		public double Wage { get; set; }
		public string EligibilityYearsTotal { get; set; }
		public string CreditedServiceYearsTotal { get; set; }
		public string FirstContributionDate { get; set; }
		public string LastHoursUpdateDate { get; set; }
	}
}
