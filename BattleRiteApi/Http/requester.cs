using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace BattleRiteApi.Http
{
    class Requester
    {
        #region Private Fields
        private string ApiKey;
        #endregion

        public Requester(string apiKey)
        {
            ApiKey = apiKey;
        }

        #region Public Methods
        public string Get(string requestUrl)
        {
            // Create webrequest
            HttpWebRequest webRequest = HttpWebRequest.CreateHttp(requestUrl);
            webRequest.Headers.Add("Authorization", ApiKey);
            webRequest.Accept = "application/vnd.api+json";

            // Get stream, and read until the end
            Stream responseStream = webRequest.GetResponse().GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string responseString = streamReader.ReadToEnd();
            // Return the response string
            return responseString;
        }

        public async Task<string> GetAsync(string requestUrl)
        {
            // Create webrequest
            HttpWebRequest webRequest = HttpWebRequest.CreateHttp(requestUrl);
            webRequest.Headers.Add("Authorization", ApiKey);
            webRequest.Accept = "application/vnd.api+json";

            // Get stream, and read until the end
            Stream responseStream =  (await webRequest.GetResponseAsync()).GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string responseString = await streamReader.ReadToEndAsync();
            // Return the response string
            return responseString;
        }
        #endregion
    }
}
