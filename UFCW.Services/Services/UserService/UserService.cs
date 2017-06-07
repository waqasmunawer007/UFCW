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

namespace UFCW.Services.UserService
{
    public class UserService: BaseService, IUserService
    {
		public async Task<LoginResponse> LoginUser(String username, string password)
		{
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Email", username);
            parameters.Add("Password", password);

            var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
            HttpResponseMessage responseJson = await client.PostAsync(AppConstants.LoginApi, content);
            var json = await responseJson.Content.ReadAsStringAsync();
            //Debug.WriteLine("Response:   \n" + json);
            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(json);
			return loginResponse;
		}
    }
}
