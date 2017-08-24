using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UFCW.Constants;
using UFCW.Services.Models.Inbox;
using UFCW.Services.Services.Inbox;
namespace UFCW.Services.Services.Inbox
{
	public class InboxService : BaseService, IInboxService
	{
        /// <summary>
        /// Fetchs the inbox list.
        /// </summary>
        /// <returns>The inbox list.</returns>
        /// <param name="Token">Token.</param>
        /// <param name="SSN">Ssn.</param>
		public async Task<Message[]> FetchInboxList(string Token, string SSN)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Token);
			parameters.Add(WebApiConstants.SSN, SSN);
			try
			{
				//var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                //HttpResponseMessage responseJson = await client.PostAsync(AppConstants.AP_FetchInboxListApi, content);
                //var json = await responseJson.Content.ReadAsStringAsync();
                var json = "[\n    {\n        \"From\": \"UmarUmarUmar\",\n        \"To\": \"Sam\",\n        \"Subject\": \"This is subjectThis is subjectThis is subject\",\n        \"Date\": \"8/18/2017\",\n        \"Time\": \"9:05:39 AM\",\n        \"Body\": \"This is body\"\n    },\n    {\n        \"From\": \"WaqasWaqas Waqas\",\n        \"To\": \"Samules\",\n        \"Subject\": \"This is subject2\",\n        \"Date\": \"22/18/2017\",\n        \"Time\": \"10:05:39 AM\",\n        \"Body\": \"This is body2\"\n    }\n]";
				if (!json.Equals("[]")) //only parse json if it contains data
				{
                    Message[] messagesList = JsonConvert.DeserializeObject<Message[]>(json);
                    if (messagesList.Length > 0)
                    {
                        Debug.WriteLine("Sender[0]: " + messagesList[0].From);
                    }
                    else
                    {
                        Debug.WriteLine("No message received...");
                    }
					return messagesList;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("FetchInboxList", ex.Message);
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
