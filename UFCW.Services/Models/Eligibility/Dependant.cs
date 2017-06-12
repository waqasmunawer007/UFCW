using System;
using Newtonsoft.Json;

namespace UFCW.Services.Models.Eligibility
{
    public class Dependant
    {
        [JsonProperty(PropertyName = "DEPENDENT_ID")]
		public string DependentID { get; set; }
        [JsonProperty(PropertyName = "SSN")]
		public string SSN { get; set; }
        [JsonProperty(PropertyName = "TYPE_CODE")]
		public string TypeCode { get; set; }
        [JsonProperty(PropertyName = "DEPENDENT_NUMBER")]
        public Int64 DependentNumber { get; set; }
        [JsonProperty(PropertyName = "FUND_ID")]
		public string FunddID { get; set; }
        [JsonProperty(PropertyName = "COVERAGE_PF")]
		public string CoveragePF { get; set; }
        [JsonProperty(PropertyName = "DEPENDENT_TYPE")]
		public string DependentType { get; set; }
        [JsonProperty(PropertyName = "DEPENDENT_SSN")]
		public string DependentSSN { get; set; }
        [JsonProperty(PropertyName = "IS_PENDING")]
		public string IsPending { get; set; }
        [JsonProperty(PropertyName = "ENROLLMENT_RECEIVED")]
		public string EnrollmentReceived { get; set; }
        [JsonProperty(PropertyName = "ENROLLMENT_DATE")]
		public string EnrollmentDate { get; set; }
        [JsonProperty(PropertyName = "FIRST_NAME")]
		public string FirstName { get; set; }
        [JsonProperty(PropertyName = "MIDDLE_INITIAL")]
		public string MiddleInitial { get; set; }
        [JsonProperty(PropertyName = "LAST_NAME")]
		public string LastName { get; set; }
        [JsonProperty(PropertyName = "BIRTH_DATE")]
		public string BirthDate { get; set; }
        [JsonProperty(PropertyName = "GENDER")]
		public string Gender { get; set; }
        [JsonProperty(PropertyName = "EFFECTIVE_DATE")]
        public string EffectiveDate { get; set; }
        [JsonProperty(PropertyName = "TERMINATION_DATE")]
		public string TerminationDate { get; set; }
        [JsonProperty(PropertyName = "STUDENT_VERIFICATION_DATE_1")]
        public object StudentVerificationDate1 { get; set; }
        [JsonProperty(PropertyName = "STUDENT_VERIFICATION_DATE_2")]
		public object StudentVerificationDate1_2 { get; set; }
        [JsonProperty(PropertyName = "STUDENT_VERIFICATION_DATE_3")]
		public object StudentVerificationDate13 { get; set; }
        [JsonProperty(PropertyName = "STUDENT_VERIFICATION_DATE_4")]
		public object StudentVerificationDate14 { get; set; }
        [JsonProperty(PropertyName = "STUDENT_VERIFICATION_DATE_5")]
		public object StudentVerificationDate15 { get; set; }
        [JsonProperty(PropertyName = "STUDENT_VERIFICATION_DATE_6")]
		public object StudentVerificationDate16 { get; set; }
        [JsonProperty(PropertyName = "STUDENT_VER_REQ_DATE_1")]
        public object StudentVerificationRequiredDate1 { get; set; }
        [JsonProperty(PropertyName = "STUDENT_VER_REQ_DATE_2")]
		public object StudentVerificationRequiredDate2 { get; set; }
        [JsonProperty(PropertyName = "IS_MEDICARE_A_ELIG")]
		public string IsMedicareAElig { get; set; }
        [JsonProperty(PropertyName = "MEDICARE_A_FROM_DATE")]
		public object MedicareAFromDate { get; set; }
        [JsonProperty(PropertyName = "MEDICARE_A_TO_DATE")]
		public object MedicareAToDate { get; set; }
        [JsonProperty(PropertyName = "IS_MEDICARE_B_ELIG")]
		public string IsMedicareBElig { get; set; }
        [JsonProperty(PropertyName = "MEDICARE_B_FROM_DATE")]
		public object MedicareBFromDate { get; set; }
        [JsonProperty(PropertyName = "MEDICARE_B_TO_DATE")]
		public object MedicareBToDate { get; set; }
        [JsonProperty(PropertyName = "LT_NON_PPO_MAJOR_MED")]
		public object LT_NON_PPO_MAJOR_MED { get; set; }
        [JsonProperty(PropertyName = "LT_NON_PPO_SUBST_ABUSE")]
		public object LT_NON_PPO_SUBST_ABUSE { get; set; }
        [JsonProperty(PropertyName = "LT_NON_PPO_MENTAL_NERVOUS")]
		public object LT_NON_PPO_MENTAL_NERVOUS { get; set; }
        [JsonProperty(PropertyName = "LT_PPO_MAJOR_MED")]
		public object LT_PPO_MAJOR_MED { get; set; }
        [JsonProperty(PropertyName = "LT_PPO_SUBST_ABUSE")]
		public object LT_PPO_SUBST_ABUSE { get; set; }
        [JsonProperty(PropertyName = "LT_PPO_MENTAL_NERVOUS")]
		public object LT_PPO_MENTAL_NERVOUS { get; set; }
        [JsonProperty(PropertyName = "LT_HEARING_AID")]
		public object LT_HEARING_AID { get; set; }
        [JsonProperty(PropertyName = "LT_VISION")]
		public object LT_VISION { get; set; }
        [JsonProperty(PropertyName = "LT_DENTAL")]
		public object LT_DENTAL { get; set; }
        [JsonProperty(PropertyName = "LT_PHYSICAL")]
		public object LT_PHYSICAL { get; set; }
        [JsonProperty(PropertyName = "LT_ORTHO_SURGERY")]
		public object LT_ORTHO_SURGERY { get; set; }
        [JsonProperty(PropertyName = "LT_ORTHO")]
		public object LT_ORTHO { get; set; }
        [JsonProperty(PropertyName = "LT_TMJ")]
		public object LT_TMJ { get; set; }
        [JsonProperty(PropertyName = "LT_COB_NON_PPO_MAJOR_MED")]
		public object LT_COB_NON_PPO_MAJOR_MED { get; set; }
        [JsonProperty(PropertyName = "LT_COB_SUBST_ABUSE")]
		public object LT_COB_SUBST_ABUSE { get; set; }
        [JsonProperty(PropertyName = "LT_COB_MENTAL")]
		public object LT_COB_MENTAL { get; set; }
        [JsonProperty(PropertyName = "LT_COB_HEARING_AID")]
		public object LT_COB_HEARING_AID { get; set; }
        [JsonProperty(PropertyName = "LT_COB_TMJ")]
		public object LT_COB_TMJ { get; set; }
        [JsonProperty(PropertyName = "LT_COB_ORTHO_SURGERY")]
		public object LT_COB_ORTHO_SURGERY { get; set; }
        [JsonProperty(PropertyName = "EMPLOYER_NAME")]
		public string EMPLOYER_NAME { get; set; }
        [JsonProperty(PropertyName = "CHILD_STATUS")]
		public object CHILD_STATUS { get; set; }

		public object DateCreated { get; set; }
		public object DateUpdated { get; set; }
    }
}
