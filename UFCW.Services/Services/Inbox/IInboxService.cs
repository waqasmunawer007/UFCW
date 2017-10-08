using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UFCW.Services.Models.Inbox;

namespace UFCW.Services.Services.Inbox
{
    public interface IInboxService
	{
        Task<MailboxResponse> FetchMailbox(); 
        Task<SendMessageResponse> SendMessage(Dictionary<string, object> parameters);
        Task<ReadEmailResponse> ReadMessage(string messageId);
        Task<InBoxMessage> GetMessage(string messageId);
        Task<AdminMailbox[]> GetAdminMailbox();
	}
}
