using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.HTTPModel.ActivityList
{
    public class DeleteActivityResponceModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
