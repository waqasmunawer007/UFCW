using System;
using UFCW.Services.Models;

namespace UFCW.Services
{
	public class Claim:BaseResponse
	{
		public string CLAIM_ID { get; set; }
		public long SSN { get; set; }
		public long CLAIM_NUMBER { get; set; }
		public string CLAIM_SUFFIX { get; set; }
		public string CLAIM_TYPE { get; set; }
		public string COVERAGE_PF { get; set; }
		public string FUND_ID { get; set; }
		public string PLAN_ID { get; set; }
		public long LOCAL_NUMBER { get; set; }
		public string CLAIMANT_TYPE { get; set; }
		public string EMPLOYER_NAME { get; set; }
		public string COV_FROM_DATE { get; set; }
		public string COV_TO_DATE { get; set; }
		public string MAINTENANCE_DATE { get; set; }
		public string ADJUSTMENT_CODE { get; set; }
		public string CLAIM_STATUS { get; set; }
		public string SERVICE_REMARKS { get; set; }
		public string PAY_REMARKS { get; set; }
		public string GENDER { get; set; }
		public int AGE { get; set; }
		public string INSURED_INITIALS { get; set; }
		public string INSURED_LAST_NAME { get; set; }
		public string ADDRESS1 { get; set; }
		public string ADDRESS2 { get; set; }
		public string CITY { get; set; }
		public int STATE_CODE { get; set; }
		public int ZIP_CODE { get; set; }
		public string DEP_FIRST_NAME { get; set; }
		public string DEP_LAST_NAME { get; set; }
		public string DEP_INITIAL { get; set; }
		public string DEP_TYPE { get; set; }
		public string YTD_DENTAL { get; set; }
		public string DENTAL_DEDUCTION { get; set; }
		public object LT_DENTAL { get; set; }
		public object LT_ORTHODONTIC { get; set; }
		public string X_RAY_DATE { get; set; }
		public string EXAM_CLEAN_DATE { get; set; }
		public string CLAIM_FILE_FLAG { get; set; }
		public string ADJUSTMENT_EXPL { get; set; }
		public string DateCreated { get; set; }
		public string DateUpdated { get; set; }
	}
}
