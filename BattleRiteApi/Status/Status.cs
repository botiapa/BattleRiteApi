using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRiteApi.Status
{
    public class FullStatus
    {
        [JsonProperty("data")]
        public Status status;
    }

    public class Status
    {
        public string type;
        public string id;
        public StatusAttributes attributes;
    }

    public class StatusAttributes
    {
        public string releasedAt;
        public string version;
    }
}
