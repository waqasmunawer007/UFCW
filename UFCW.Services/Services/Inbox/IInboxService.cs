using System;
using System.Threading.Tasks;
using UFCW.Services.Models.Inbox;

namespace UFCW.Services.Services.Inbox
{
    public interface IInboxService
	{
        
        Task<Message[]> FetchInboxList(String Token, String SSN); //Fetch user messages
	}
}
