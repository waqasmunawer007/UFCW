using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UFCW.Constants;

namespace UFCW.Services.Services.Claims
{
    public class ClaimService:BaseService,IClaimService
    {
        
        /// <summary>
        /// Fetchs the FAQ list.
        /// </summary>
        /// <returns>The FAQ.</returns>
        /// <param name="token">Token.</param>
        /// <param name="ssn">Ssn.</param>
        public async Task<FAQ[]> FetchFAQ(string token, string ssn)
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, token);
			parameters.Add(WebApiConstants.SSN, ssn);
			
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage responseJson = await client.PostAsync(WebApiConstants.FAQApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				if (!json.Equals("[]")) //only parse json if it contains data
				{
					var faqResponse = JsonConvert.DeserializeObject<FAQ[]>(json);
					return faqResponse;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("FetchFAQ", ex.Message);
			}
			return null;
        }
    }
}
