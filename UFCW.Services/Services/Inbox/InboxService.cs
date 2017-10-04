using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services.Models.Inbox;
using UFCW.Services.Services.Inbox;
namespace UFCW.Services.Services.Inbox
{
	public class InboxService : BaseService, IInboxService
	{
      
        /// <summary>
        /// Fetchs the mailbox include both sent and inbox messages.
        /// </summary>
        /// <returns>The mailbox.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<MailboxResponse> FetchMailbox()
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
		
            parameters.Add(WebApiConstants.TOKEN, Settings.UserToken); //Todo temp code
            parameters.Add(WebApiConstants.SSN, Settings.UserSSN);
            parameters.Add(WebApiConstants.UserID, Settings.UserID);
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage responseJson = await client.PostAsync(WebApiConstants.MailboxApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				if (json != null) //only parse json if it contains data
				{
					var mailbox = JsonConvert.DeserializeObject<MailboxResponse>(json);
					return mailbox;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("FetchMailbox", ex.Message);
			}
			return null;
        }

        public async Task<InBoxMessage> GetMessage(string messageId)
        {
			try
			{
                string url = WebApiConstants.GetMessageApi+ "?Id=" + messageId;
				HttpResponseMessage responseJson = await client.GetAsync(url);
				var json = await responseJson.Content.ReadAsStringAsync();
				if (json != null)
				{
					var readMailbox = JsonConvert.DeserializeObject<InBoxMessage>(json);
					return readMailbox;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("GetMessage", ex.Message);
			}
			return null;
        }

        public async Task<ReadEmailResponse> ReadMessage(string messageId)
        {
            try
            {
                string url = WebApiConstants.ReadMessageApi+ "?Id=" + messageId;
				HttpResponseMessage responseJson = await client.GetAsync(url);
                var json = await responseJson.Content.ReadAsStringAsync();
				if (json != null)
				{
					var readMailbox = JsonConvert.DeserializeObject<ReadEmailResponse>(json);
					return readMailbox;
				}
            }catch(Exception ex)
            {
                Debug.WriteLine("ReadMessage", ex.Message);
            }
            return null;
        }
        public async Task<SendMessageResponse> SendMessage(Dictionary<string, object> parameters)
        {
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage responseJson = await client.PostAsync(WebApiConstants.SendMessageApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				if (json != null)
				{
					var mailbox = JsonConvert.DeserializeObject<SendMessageResponse>(json);
					return mailbox;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("SendMessage", ex.Message);
			}
			return null;
        }
    }
}
