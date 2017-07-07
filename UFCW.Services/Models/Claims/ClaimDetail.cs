using System;
namespace UFCW.Services
{
	public class ClaimDetail:Claim
	{
		public string SERV_FROM_DATE { get; set; }
		public string SERV_TO_DATE { get; set; }
		public double CHARGES { get; set; }
		public string PROVIDER_NAME { get; set; }
		public string DOCTOR_NAME { get; set; }
		public string PATIENT { get; set; }
		public double PAYABLE_AMT { get; set; }
		public string SERVICE_ID { get; set; }
		public string DENTAL_SERVICE { get; set; }
		public string MEDICAL_SERVICE { get; set; }
		public string MEDICAL_PAYMENTS { get; set; }
	}
}
