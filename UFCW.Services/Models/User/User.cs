using System;
namespace UFCW.Services.Models.User
{
    public class User
	{
		public string PARTICIPANT_ID { get; set; }
		public string LAST_NAME { get; set; }
		public string FIRST_NAME { get; set; }
		public string OTHER_NAMES { get; set; }
		public string SSN { get; set; }
		public string EMAIL { get; set; }
		public string STREET { get; set; }
		public string CITY { get; set; }
		public string STATE { get; set; }
		public string ZIP { get; set; }
		public string DATE_OF_BIRTH { get; set; }
		public string GENDER { get; set; }
		public string IS_ADMIN_APPROVED { get; set; }
		public string DateCreated { get; set; }
		public string DateUpdated { get; set; }
    }
}
