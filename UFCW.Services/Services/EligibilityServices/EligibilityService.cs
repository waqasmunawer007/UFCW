using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UFCW.Constants;
using UFCW.Services.Models.User;
using UFCW.Services.Services;
using System.Collections.Generic;
using System.Text;
using UFCW.Services.Services.EligibilityServices;
using UFCW.Services.Models.Eligibility;
using UFCW.Services.Models.Eligibility.Benifits;

namespace UFCW.Services.UserService
{
    public class Eligibility : BaseService, IEligibilityService
    {
       /// <summary>
       /// Fetchs the time loss.
       /// </summary>
       /// <returns>The time loss.</returns>
       /// <param name="Token">Token.</param>
       /// <param name="SSN">Ssn.</param>
       /// <param name="Email">Email.</param>
        public Task<TimeLossServerResponse> FetchTimeLoss(string Token, string SSN, string Email)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Fetchs user benifits list.
		/// </summary>
		/// <returns>The time loss.</returns>
		/// <param name="token">Token.</param>
		/// <param name="SSN">Ssn.</param>
		/// <param name="email">Email.</param>
        public async Task<Benifits[]> FetchUserBenifits(string token, string SSN, string email)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(WebApiConstants.TOKEN, token);
			parameters.Add(WebApiConstants.SSN, SSN);
            parameters.Add(WebApiConstants.EMAIL, email);

            var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, WebApiConstants.API_MEDIA_TYPE);
            HttpResponseMessage responseJson = await client.PostAsync(WebApiConstants.BenifitsApi, content);
			var json = await responseJson.Content.ReadAsStringAsync();
            var benifitsList = JsonConvert.DeserializeObject<Benifits[]>(json);
            //foreach (var item in benifitsList)
            //{
            //    Debug.WriteLine("Answer: " + item.Answer);
            //}
            return benifitsList;
		}
    }
}
