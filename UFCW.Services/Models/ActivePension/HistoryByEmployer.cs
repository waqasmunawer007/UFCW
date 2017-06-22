using System;
namespace UFCW.Services.Models.ActivePension
{
	public class HistoryByEmployer
	{
		public int SerialNumber { get; set; }
		public string Employer { get; set; }
		public string Plan { get; set; }
		public string HireDate { get; set; }
		public string EligibilityYearsTotal { get; set; }
		public string CreditedServiceYearsTotal { get; set; }
		public string FirstContributionDate { get; set; }
		public string LastHoursUpdateDate { get; set; }
	}
}
