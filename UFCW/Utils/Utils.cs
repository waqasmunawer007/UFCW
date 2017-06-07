using System;
namespace UFCW.Utils
{
    public class Utils
    {
        public Utils()
        {
        }

        public static string GetUrlForApi(string api)
        {
            string url = "";

            if(Constants.AppConstants.environment == Constants.Environment.LIVE)
            {
                url = Constants.AppConstants.BaseUrlLive;
            }
            else
            {
                url = Constants.AppConstants.BaseUrlStaging;
            }

            return url;
        }
    }
}
