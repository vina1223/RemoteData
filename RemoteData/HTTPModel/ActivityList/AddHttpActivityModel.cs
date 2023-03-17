using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.HTTPModel.ActivityList
{
    public class AddHttpActivityModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public ActivityDetails Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }
}
