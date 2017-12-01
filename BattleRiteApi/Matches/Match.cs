using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRiteApi.Matches
{
    public class Match
    {
        public string type;
        public string id;

        public Attributes attributes;
        public object relationships; // TODO: Add relationships
        public Links links;

        public class Attributes
        {
            public string createdAt;
            public int duration;
            public string gameMode;
            public string patchVersion;
            public string shardId;
            public string titleId;
            public Stats stats;

            public class Stats
            {
                public string mapID;
                public string type;
            }

        }

        public class Links
        {
            public string schema;
            public string self;
        }

    }

    public class SingleMatch
    {
        [JsonProperty("data")]
        public Match match;
        public List<IncludedItem> included; 
        public Links links;
        public object meta; // TODO: Add meta

        public class Links
        {
            public string next;
            public string self;
        }
    }

    public class IncludedItem
    {
        public string type;
        public string id;
    }
}
