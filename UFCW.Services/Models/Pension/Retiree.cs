using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace UFCW.Services.Models.Pension
{
    public class Retiree: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

		public PersonalInformation Personal_Information { get; set; }
		public MyBenefits My_Benefits { get; set; }
		public MyTaxes MyTaxes { get; set; }
		public MonthlyBenefits Monthly_Benefits { get; set; }
		public DirectDeposit Direct_Deposit { get; set; }
		public SurvivorsData SurvivorsData { get; set; }


		public PersonalInformation PersonalInformationProperty
		{
			get { return Personal_Information; }
			set
			{
				if (Personal_Information != value)
				{
					Personal_Information = value;
					OnPropertyChanged("Personal_Information");
				}
			}
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			var changed = PropertyChanged;
			if (changed != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
    }

	public class PersonalInformation: INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty(PropertyName = "SSN")]
		public string SSN { get; set; }
        [JsonProperty(PropertyName = "FIRST_NAME")]
        private string firstName { get; set; }
        [JsonProperty(PropertyName = "LAST_NAME")]
		public string LastName { get; set; }
        [JsonProperty(PropertyName = "ADDRESS_LINE1")]
		public string AddressLine1 { get; set; }
        [JsonProperty(PropertyName = "ADDRESS_LINE2")]
		public object AddressLine2 { get; set; }
        [JsonProperty(PropertyName = "CITY")]
		public string City { get; set; }
        [JsonProperty(PropertyName = "STATE")]
		public string State { get; set; }
        [JsonProperty(PropertyName = "ZIP_A")]
		public string ZIP_A { get; set; }
        [JsonProperty(PropertyName = "ZIP_B")]
		public string ZIP_B { get; set; }
        [JsonProperty(PropertyName = "IS_FOREIGN_COUNTRY")]
		public string IsForeignCountry { get; set; }
        [JsonProperty(PropertyName = "GENDER")]
        public string Gender { get; set; }
        [JsonProperty(PropertyName = "BIRTH_DATE")]
		public string BirthDate { get; set; }

		public string FirstName
		{
			get { return firstName; }
			set
			{
				if (firstName != value)
				{
					firstName = value;
					OnPropertyChanged("FirstName");
				}
			}
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			var changed = PropertyChanged;
			if (changed != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

	public class MyBenefits
	{

		[JsonProperty(PropertyName = "RETIREMENT_OPTION")]
		public string RetirementOption { get; set; }
		[JsonProperty(PropertyName = "LAST_EMPLOYER_NAME")]
		public string LastEmployerName { get; set; }
		[JsonProperty(PropertyName = "LAST_WORKING_DATE")]
		public string LastWorkingDate { get; set; }
		[JsonProperty(PropertyName = "RETIREMENT_DATE")]
		public string RetirementDate { get; set; }
		[JsonProperty(PropertyName = "FIRST_CHECK_DATE")]
		public string FirstCheckDate { get; set; }
		[JsonProperty(PropertyName = "SERVICE_YEARS")]
		public double ServiceYears { get; set; }
		[JsonProperty(PropertyName = "VESTING_YEARS")]
		public Int64 VestingYears { get; set; }
		[JsonProperty(PropertyName = "LEVEL_OPTION_AMT")]
		public Int64 LevelOptionAmt { get; set; }
		[JsonProperty(PropertyName = "YTD_GROSS")]
		public double YTDGross { get; set; }
		[JsonProperty(PropertyName = "YTD_DOM_REL_DEDUCTION")]
		public Int64 YTD_DOM_REL_Deduction { get; set; }
		[JsonProperty(PropertyName = "STATUS")]
		public string S { get; set; }
	}

	public class MyTaxes
	{
		[JsonProperty(PropertyName = "IS_FED_TAX")]
		public string IsFedTax { get; set; }
		[JsonProperty(PropertyName = "TAX_EXEMPT_TYPE")]
		public string TaxExemptType { get; set; }
		[JsonProperty(PropertyName = "TAX_ALLOWANCES_NO")]
		public Int64 TaxAllowancesNumber { get; set; }
		[JsonProperty(PropertyName = "YTD_FED_TAXES")]
		public double YTD_FedTaxes { get; set; }
	}

	public class MonthlyBenefits
	{
        [JsonProperty(PropertyName = "MTH_TOTAL_BENEFIT")]
        public double MTH_TotalBenifit { get; set; }
		[JsonProperty(PropertyName = "MTH_DOM_REL_TAX_RECEIP")]
		public Int64 MTH_DOM_REL_TaxReciept { get; set; }
		[JsonProperty(PropertyName = "MTH_DOM_REL_TAX_PARTIC")]
		public Int64 MTH_DOM_REL_TaxPartic { get; set; }
        [JsonProperty(PropertyName = "MTH_BENEFIT_GROSS")]
        public double MTH_BenifitGross { get; set; }
		[JsonProperty(PropertyName = "MTH_FED_TAXES")]
		public double MTH_FED_Taxes { get; set; }
	}

	public class DirectDeposit
	{
		[JsonProperty(PropertyName = "DIRECT_DEPOSIT_DESTINATION")]
		public string DirectDepositDestination { get; set; }
		[JsonProperty(PropertyName = "DIRECT_DEPOSIT_ACCOUNT_NO")]
		public string DirectDepositAccountnumber { get; set; }
		[JsonProperty(PropertyName = "DIRECT_DEPOSIT_TYPE")]
		public string DirectDepositType { get; set; }
	}

	public class SurvivorsData
	{
		[JsonProperty(PropertyName = "SURVIVOR_GENDER")]
		public object SurvivorGender { get; set; }
		[JsonProperty(PropertyName = "SURVIVOR_BIRTH_DATE")]
		public object SucrvivorBirthDate { get; set; }
		[JsonProperty(PropertyName = "SURVIVOR_GROSS")]
		public Int64 SucrvivorGross { get; set; }
		[JsonProperty(PropertyName = "SURVIVOR_RATE_AMT")]
		public Int64 SucrvivorRateAMT { get; set; }
		[JsonProperty(PropertyName = "SURVIVOR_STATUS")]
		public object SucrvivorStatus { get; set; }
	}
}
