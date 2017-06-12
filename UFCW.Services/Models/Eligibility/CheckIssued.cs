using System;
using Newtonsoft.Json;

namespace UFCW.Services.Models.Eligibility
{
    public class CheckIssued
    {
        [JsonProperty(PropertyName = "DRAFT_ID")]
        public string DraftID { get; set; }
 		public string SSN { get; set; }
        [JsonProperty(PropertyName = "ISSUE_DATE")]
		public string IssueDate { get; set; }
        [JsonProperty(PropertyName = "DRAFT_CHECK_NUMBER")]
        public string DraftCheckNumber { get; set; }
        [JsonProperty(PropertyName = "PLAN_ID")]
		public string PlanID { get; set; }
        [JsonProperty(PropertyName = "FUND_ID")]
		public string FundID { get; set; }
        [JsonProperty(PropertyName = "COVERAGE_PF")]
		public string CoveragePF { get; set; }
        [JsonProperty(PropertyName = "INSURED_INTIALS")]
		public string InsuredInitials { get; set; }
        [JsonProperty(PropertyName = "INSURED_LAST_NAME")]
		public string InsuredLastName { get; set; }
        [JsonProperty(PropertyName = "DEP_NAME")]
		public object DepName { get; set; }
        [JsonProperty(PropertyName = "DEP_TYPE")]
		public string DepType { get; set; }
        [JsonProperty(PropertyName = "PAID_TO")]
		public string PaidTo { get; set; }
        [JsonProperty(PropertyName = "ADDRESS1")]
		public string Address1 { get; set; }
        [JsonProperty(PropertyName = "ADDRESS2")]
		public string Address2 { get; set; }
        [JsonProperty(PropertyName = "CITY")]
		public string City { get; set; }
        [JsonProperty(PropertyName = "STATE_CODE")]
		public string StateCode { get; set; }
        [JsonProperty(PropertyName = "ZIP_CODE")]
		public string ZipCode { get; set; }
        [JsonProperty(PropertyName = "IS_FOREIGN_COUNTRY")]
		public string IsForiegnCountry { get; set; }
        [JsonProperty(PropertyName = "DRAFT_TYPE")]
        public string DraftType { get; set; }
        [JsonProperty(PropertyName = "DRAFT_TOTAL_CHARGES")]
        public Int64 DraftTotalCharges { get; set; }
        [JsonProperty(PropertyName = "DRAFT_TIMELOSS")]
        public Int64 DraftTimeLoss { get; set; }
        [JsonProperty(PropertyName = "CLEAR_DATE")]
		public string ClearDate { get; set; }
        [JsonProperty(PropertyName = "DISABILITY_DATE")]
		public string DisabilityDate { get; set; }
        [JsonProperty(PropertyName = "TIMELOSS_FROM_DATE")]
		public string TimeLossFromDate { get; set; }
        [JsonProperty(PropertyName = "TIMELOSS_TO_DATE")]
		public string TimeLossToDate { get; set; }
        [JsonProperty(PropertyName = "TIMELOSS_DAYS_NO")]
		public Int64 TimeLossDaysNo { get; set; }
        [JsonProperty(PropertyName = "FICA_AMT")]
		public double FicaAmt { get; set; }
        [JsonProperty(PropertyName = "MEDICARE_AMT")]
		public double MedicareAmt { get; set; }
        [JsonProperty(PropertyName = "WITHHOLDING_AMT")]
		public Int64 WithHoldingAmt { get; set; }
        [JsonProperty(PropertyName = "GROSS_AMT")]
		public Int64 GrossAmt { get; set; }
        [JsonProperty(PropertyName = "NET_AMT")]
		public double NetAmt { get; set; }

		public Int64 DBCOD1 { get; set; }
		public Int64 DBAMT1 { get; set; }
		public Int64 DBCOD2 { get; set; }
		public Int64 DBAMT2 { get; set; }
		public Int64 DBCOD3 { get; set; }
		public Int64 DBAMT3 { get; set; }
		public Int64 DBCOD4 { get; set; }
		public Int64 DBAMT4 { get; set; }
		public Int64 DBCOD5 { get; set; }
		public Int64 DBAMT5 { get; set; }
		public Int64 DBCOD6 { get; set; }
		public Int64 DBAMT6 { get; set; }
		public Int64 DBCOD7 { get; set; }
		public Int64 DBAMT7 { get; set; }
		public Int64 DBCOD8 { get; set; }
		public Int64 DBAMT8 { get; set; }
		public Int64 DBCOD9 { get; set; }
		public Int64 DBAMT9 { get; set; }

        [JsonProperty(PropertyName = "CLAIM_NUMBER")]
		public string ClaimNumber { get; set; }
        [JsonProperty(PropertyName = "CLAIM_SUFFIX")]
        public string ClaimSuffix { get; set; }
        [JsonProperty(PropertyName = "TAXID")]
		public string TaxID { get; set; }
        [JsonProperty(PropertyName = "TAXID_CODE")]
		public string TaxIDCode { get; set; }
        [JsonProperty(PropertyName = "DRAFT_ADJ_TYPE")]
        public string DraftADJType { get; set; }
        [JsonProperty(PropertyName = "DRAFT_PROCESS_MONTH")]
        public Int64 DraftProcessMonth { get; set; }
        [JsonProperty(PropertyName = "DRAFT_PROCESS_YEAR")]
        public Int64 DraftProcessYear { get; set; }
        [JsonProperty(PropertyName = "DRAFT_KEY_COUNT")]
        public Int64 DraftKeyAccount { get; set; }

		public object DateCreated { get; set; }
		public object DateUpdated { get; set; }
    }
}
