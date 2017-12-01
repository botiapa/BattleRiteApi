using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleRiteApi.Matches;

namespace BattleRiteApi.Matches
{
    public class MatchCollection
    {
        [JsonProperty("data")]
        public List<Match> matches;
        public List<IncludedItem> included; 
        public Links links;
        public object meta; // TODO: Add meta

        public class Links
        {
            public string next;
            public string self;
        }
    }
}
