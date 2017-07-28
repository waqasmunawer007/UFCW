using System;
namespace UFCW.Services.Models.Eligibility
{
    public class EligibilityDetail:BaseResponse
    {
		public string InsuredName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string StateCode { get; set; }
		public string ZipCode { get; set; }
		public string CoverageType { get; set; }
		public string Fund { get; set; }
		public string EnrollmentReceived { get; set; }
    }
}
