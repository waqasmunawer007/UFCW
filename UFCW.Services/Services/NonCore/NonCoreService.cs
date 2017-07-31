﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UFCW.Constants;
using UFCW.Services.Models.NonCore;

namespace UFCW.Services.Services.NonCore
{
    public class NonCoreService : BaseService, INonCoreService
    {
        
        public async Task<NonCoreResponse> FetchPublicNonCoreData()
        {
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage responseJson = await client.PostAsync(WebApiConstants.PublicNonCoreApi, content);

				var json = await responseJson.Content.ReadAsStringAsync();
				if (json != null) //only parse json if it contains data
				{
					var nonCoreResponseData = JsonConvert.DeserializeObject<NonCoreResponse>(json);
					return nonCoreResponseData;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("FetchPublicNonCoreException", ex.Message);
			}
			return null;
        }
    }
}
