using System;
using System.Collections.Generic;

namespace UFCW.Services.Models.Inbox
{
    public class MailboxResponse: BaseResponse
    {
		public List<InBoxMessage> InBoxMessages { get; set; }
		public List<SentMessage> SentMessages { get; set; }
		public object AboutUS { get; set; }
    }

	public class SentMessage
	{
		public string MailBoxMessageID { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public bool IsEmailNotified { get; set; }
		public bool IsRead { get; set; }
		public string ToUserId { get; set; }
		public string ToDescription { get; set; }
		public string FromUserId { get; set; }
		public string FromDescription { get; set; }
		public string DateCreated { get; set; }
		public string DateUpdated { get; set; }
	}
	public class InBoxMessage
	{
		public string MailBoxMessageID { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public bool IsEmailNotified { get; set; }
		public bool IsRead { get; set; }
		public string ToUserId { get; set; }
		public string ToDescription { get; set; }
		public string FromUserId { get; set; }
		public string FromDescription { get; set; }
		public string DateCreated { get; set; }
		public string DateUpdated { get; set; }
	}
   
}
