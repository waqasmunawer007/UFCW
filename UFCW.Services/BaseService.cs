using System;
using System.Net.Http;
using UFCW.Constants;

namespace UFCW.Services
{
    public class BaseService
    {
        protected HttpClient client = new HttpClient();

        public BaseService()
        {
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
            client.BaseAddress = new Uri(AppConstants.BaseUrl);
        }
    }
}
