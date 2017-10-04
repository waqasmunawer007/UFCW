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
        public async Task<MailboxResponse> FetchMailbox(string userId)
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, 0494);
			parameters.Add(WebApiConstants.SSN, 254049432);
            //parameters.Add(WebApiConstants.TOKEN, Settings.UserToken); //Todo temp code
            //parameters.Add(WebApiConstants.SSN, Settings.UserSSN);
            parameters.Add(WebApiConstants.UserID, userId);
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
        public async Task<ReadEmailResponse> ReadMessage(string userId)
        {
            try
            {
				string url = WebApiConstants.ReadMessageApi + userId;
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

/*
[
    {
        "From": "Umar",
        "To": "Sam",
        "Subject": "This is subject",
        "Date": "8/18/2017",
        "Time": "9:05:39 AM",
        "Body": "This is body"
    },
    {
        "From": "Waqas",
        "To": "Samules",
        "Subject": "This is subject2",
        "Date": "22/18/2017",
        "Time": "10:05:39 AM",
        "Body": "This is body2"
    }
]
 */
