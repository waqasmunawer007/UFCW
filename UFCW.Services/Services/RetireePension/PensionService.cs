using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services.Models.Pension;
using UFCW.Views.Pages.Pension;

namespace UFCW.Services.Services.Pension
{
    public class PensionService: BaseService, IPensionService
    {
		/// <summary>
		/// Fetchs the Retiree pension.
		/// </summary>
		/// <returns>The Retiree.</returns>
		/// <param name="Token">Token.</param>
		/// <param name="SSN">Ssn.</param>
		/// <param name="Email">Email.</param>
		public async Task<Retiree> FetchRetiree()
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(WebApiConstants.TOKEN, Settings.UserToken);
            parameters.Add(WebApiConstants.SSN, Settings.UserSSN);
            parameters.Add(WebApiConstants.EMAIL, Settings.UserEmail);
            try
            {
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(AppConstants.PensionRetireeApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				var response = JsonConvert.DeserializeObject<Retiree>(json);
				return response;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("FetchRetireePension", ex.Message);
            }
            return null;
		}

		/// <summary>
		/// Fetchs the Summary Plan Docs.
		/// </summary>
		/// <returns>The Summary plan Docs.</returns>
		/// <param name="Token">Token.</param>
		/// <param name="SSN">Ssn.</param>
		/// <param name="Email">Email.</param>
		public async Task<SummaryPlanDoc[]> FetchSummaryPlanDoc()
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Settings.UserToken);
			parameters.Add(WebApiConstants.SSN, Settings.UserSSN);
			parameters.Add(WebApiConstants.EMAIL, Settings.UserEmail);
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
				HttpResponseMessage responseJson = await client.PostAsync(Constants.AppConstants.SummaryPlanDocApi, content);
				var json = await responseJson.Content.ReadAsStringAsync();
				if (!json.Equals("[]")) //only parse json if it contains data
				{
					var response = JsonConvert.DeserializeObject<SummaryPlanDoc[]>(json);
					return response;
				}
			}
			catch (Exception ex)
			{
                Debug.WriteLine("FetchRetireeSummaryPlanDoc", ex.Message);
			}             return null;
		}
    }
}
