using System;
using Newtonsoft.Json;

namespace UFCW.Services.Models.User
{
    public class User
	{
        [JsonProperty(PropertyName = "PARTICIPANT_ID")]
		public string ParticipantID { get; set; }
        [JsonProperty(PropertyName = "LAST_NAME")]
		public string LastName { get; set; }
        [JsonProperty(PropertyName = "FIRST_NAME")]
		public string FirstName { get; set; }
        [JsonProperty(PropertyName = "OTHER_NAMES")]
		public string OtherNames { get; set; }
        [JsonProperty(PropertyName = "SSN")]
		public string SSN { get; set; }
        [JsonProperty(PropertyName = "EMAIL")]
		public string Email { get; set; }
        [JsonProperty(PropertyName = "STREET")]
		public string Street { get; set; }
        [JsonProperty(PropertyName = "CITY")]
		public string City { get; set; }
        [JsonProperty(PropertyName = "STATE")]
		public string State { get; set; }
        [JsonProperty(PropertyName = "ZIP")]
		public string ZIP { get; set; }
        [JsonProperty(PropertyName = "DATE_OF_BIRTH")]
        public string DateOfBirth { get; set; }
        [JsonProperty(PropertyName = "GENDER")]
		public string Gender { get; set; }
        [JsonProperty(PropertyName = "IS_ADMIN_APPROVED")]
		public string IsAdminApproved { get; set; }

		public string DateCreated { get; set; }
		public string DateUpdated { get; set; }
    }
}
