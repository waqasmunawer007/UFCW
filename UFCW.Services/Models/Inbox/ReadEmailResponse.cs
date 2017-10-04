using System;
namespace UFCW.Services.Models.Inbox
{
    public class ReadEmailResponse:BaseService
    {
		public string MailBoxMessageID { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public bool IsEmailNotified { get; set; }
		public bool IsRead { get; set; }
		public string ToUserId { get; set; }
		public string ToDescription { get; set; }
		public string FromUserId { get; set; }
		public object FromDescription { get; set; }
		public string DateCreated { get; set; }
		public string DateUpdated { get; set; }
    }
}
