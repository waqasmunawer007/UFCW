using System;
namespace UFCW.Services.Models.ActivePension
{
	public class CurrentYearContribution
	{
		public object Employer { get; set; }
		public object Plan { get; set; }
		public string HireDate { get; set; }
		public string FirstContributionDate { get; set; }
		public string LastHoursUpdateDate { get; set; }
		public string EligibilityYearsTotal { get; set; }
		public string CreditedServiceYearsTotal { get; set; }
		public string JAN { get; set; }
		public string FEB { get; set; }
		public string MAR { get; set; }
		public string APR { get; set; }
		public string MAY { get; set; }
		public string JUN { get; set; }
		public string JUL { get; set; }
		public string AUG { get; set; }
		public string SEP { get; set; }
		public string OCT { get; set; }
		public string NOV { get; set; }
		public string DEC { get; set; }
		public object Errors { get; set; }
	}
}
