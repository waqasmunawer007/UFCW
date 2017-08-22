using System;
namespace UFCW.Services.Models.Inbox
{
    public class Message
	{
		public string From { get; set; }
		public string To { get; set; }
		public string Subject { get; set; }
		public string Date { get; set; }
		public string Time { get; set; }
		public string Body { get; set; }
	}
}
