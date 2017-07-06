using System;
namespace UFCW.Services
{
	public class ClaimDetail:Claim
	{
		public string SERV_FROM_DATE { get; set; }
		public string SERV_TO_DATE { get; set; }
		public double CHARGES { get; set; }
		public string PROVIDER_NAME { get; set; }
		public object DOCTOR_NAME { get; set; }
		public object PATIENT { get; set; }
		public double PAYABLE_AMT { get; set; }
		public string SERVICE_ID { get; set; }
		public object DENTAL_SERVICE { get; set; }
		public object MEDICAL_SERVICE { get; set; }
		public object MEDICAL_PAYMENTS { get; set; }
	}
}
