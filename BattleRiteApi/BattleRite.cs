using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BattleRiteApi.Http;
using BattleRiteApi.Matches;
using BattleRiteApi.Status;

namespace BattleRiteApi
{
    public class BattleRite
    {
        #region Private Fields
        private string ApiKey;
        private Requester requester;

        private const string apiStatusUrl = "https://api.dc01.gamelockerapp.com/status";
        private const string matchCollectionUrl = "https://api.dc01.gamelockerapp.com/shards/global/matches?page[offset]={0}&page[limit]={1}&sort={2}&filter[createdAt-start]={3}&filter[createdAt-end]={4}"; // The filters don't work for some reason but here they are: &filter[playerNames]={5}&filter[playerIds]={6}&filter[teamNames]={7}&filter[gameMode]={8}
        private const string singleMatchUrl = "https://api.dc01.gamelockerapp.com/shards/global/matches/{0}";
        #endregion


        /// <summary>
        /// Gets an instance of the battle rite api.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        public BattleRite(string apiKey)
        {
            // Api Key
            ApiKey = apiKey;
            // The requester
            requester = new Requester(ApiKey);
        }
        /// <summary>
        /// Gets an instance of the battle rite api using a file as a key.
        /// </summary>
        /// <param name="apiKeyFileUri">The URI of the file containing the apiKey</param>
        public BattleRite(Uri apiKeyFileUri)
        {
            // Api Key
            FileStream file = File.Open(apiKeyFileUri.AbsolutePath, FileMode.Open);
            StreamReader fileReader = new StreamReader(file);
            ApiKey = fileReader.ReadToEnd();
            // The requester
            requester = new Requester(ApiKey);
        }
        #region Status
        public Status.Status GetApiStatus()
        {
            string jsonString = requester.Get(apiStatusUrl);
            var obj = JsonConvert.DeserializeObject<FullStatus>(jsonString);
            return obj.status;
        }

        public async Task<Status.Status> GetApiStatusAsync()
        {
            string jsonString = await requester.GetAsync(apiStatusUrl);
            var obj = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<FullStatus>(jsonString));
            return obj.status;
        }
        #endregion

        #region Match
        public MatchCollection GetMatchCollection(int pageOffset = 0, int pageLimit = 5, string sort = "createdAt", string filterCreatedAtStart = "Now-28days", string filterCreatedAtEnd = "Now", string filterPlayerNames = "none", string filterPlayerIds = "none", string filterTeamNames = "none", string filterGameMode = "none")
        {
            string requestUrl = String.Format(matchCollectionUrl, pageOffset, pageLimit, sort, filterCreatedAtStart, filterCreatedAtEnd);
            string jsonString = requester.Get(requestUrl);
            var obj = JsonConvert.DeserializeObject<MatchCollection>(jsonString);
            return obj;
        }

        public async Task<MatchCollection> GetMatchCollectionAsync(int pageOffset = 0, int pageLimit = 5, string sort = "createdAt", string filterCreatedAtStart = "Now-28days", string filterCreatedAtEnd = "Now", string filterPlayerNames = "none", string filterPlayerIds = "none", string filterTeamNames = "none", string filterGameMode = "none")
        {
            string requestUrl = String.Format(matchCollectionUrl, pageOffset, pageLimit, sort, filterCreatedAtStart, filterCreatedAtEnd);
            string jsonString = await requester.GetAsync(requestUrl);
            var obj = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MatchCollection>(jsonString));
            return obj;
        }

        public SingleMatch GetSingeMatch(string matchId)
        {
            string requestUrl = String.Format(singleMatchUrl, matchId);
            string jsonString = requester.Get(requestUrl);
            var obj = JsonConvert.DeserializeObject<SingleMatch>(jsonString);
            return obj;
        }

        public async Task<SingleMatch> GetSingeMatchAsync(string matchId)
        {
            string requestUrl = String.Format(singleMatchUrl, matchId);
            string jsonString = await requester.GetAsync(requestUrl);
            var obj = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SingleMatch>(jsonString));
            return obj;
        }

        #endregion


    }
}
