using System;
using System.Collections.Generic;

namespace UFCW.Services.Models.Eligibility
{
    public class EligibilityReportResponse:BaseResponse
    {
		public List<Eligibilty> data { get; set; }
		public string merge { get; set; }
		public string error { get; set; }
    }
}
public class Eligibilty
{
	public int ID { get; set; }
	public string Name { get; set; }
	public string Month { get; set; }
	public string Date { get; set; }
	public string Employer { get; set; }
	public string FundName { get; set; }
	public string Plan { get; set; }
	public string Coverage { get; set; }
	public string ELIGIBILITY_ID { get; set; }
}