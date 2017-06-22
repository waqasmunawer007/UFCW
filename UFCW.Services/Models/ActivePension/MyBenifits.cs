using System;
namespace UFCW.Services.Models.ActivePension
{
    public class MyBenifits
    {
		public Int64 CreditedServiceYears { get; set; }
		public Int64 EstimatedMonthlyBenefit { get; set; }
		public Int64 EligibilityServiceYears { get; set; }
		public object Errors { get; set; }
    }
}
