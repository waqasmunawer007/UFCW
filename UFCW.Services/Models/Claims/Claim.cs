using System;
using UFCW.Services.Models;

namespace UFCW.Services
{
	public class Claim:BaseResponse
	{
		public string CLAIM_ID { get; set; }
		public object SSN { get; set; }
		public object CLAIM_NUMBER { get; set; }
		public object CLAIM_SUFFIX { get; set; }
		public object CLAIM_TYPE { get; set; }
		public object COVERAGE_PF { get; set; }
		public object FUND_ID { get; set; }
		public object PLAN_ID { get; set; }
		public object LOCAL_NUMBER { get; set; }
		public object CLAIMANT_TYPE { get; set; }
		public object EMPLOYER_NAME { get; set; }
		public object COV_FROM_DATE { get; set; }
		public object COV_TO_DATE { get; set; }
		public object MAINTENANCE_DATE { get; set; }
		public object ADJUSTMENT_CODE { get; set; }
		public object CLAIM_STATUS { get; set; }
		public object SERVICE_REMARKS { get; set; }
		public object PAY_REMARKS { get; set; }
		public object GENDER { get; set; }
		public int AGE { get; set; }
		public object INSURED_INITIALS { get; set; }
		public object INSURED_LAST_NAME { get; set; }
		public object ADDRESS1 { get; set; }
		public object ADDRESS2 { get; set; }
		public object CITY { get; set; }
		public object STATE_CODE { get; set; }
		public object ZIP_CODE { get; set; }
		public object DEP_FIRST_NAME { get; set; }
		public object DEP_LAST_NAME { get; set; }
		public object DEP_INITIAL { get; set; }
		public object DEP_TYPE { get; set; }
		public object YTD_DENTAL { get; set; }
		public object DENTAL_DEDUCTION { get; set; }
		public object LT_DENTAL { get; set; }
		public object LT_ORTHODONTIC { get; set; }
		public object X_RAY_DATE { get; set; }
		public object EXAM_CLEAN_DATE { get; set; }
		public object CLAIM_FILE_FLAG { get; set; }
		public object ADJUSTMENT_EXPL { get; set; }
		public object DateCreated { get; set; }
		public object DateUpdated { get; set; }
	}
}
