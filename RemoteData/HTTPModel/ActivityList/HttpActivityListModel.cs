using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RemoteData.HTTPModel.ActivityList
{
   

    public class ActivityDetails
    {
        [JsonProperty ("title")]
        public string Name { get; set; }

        [JsonProperty("dueDate")]
        public string DateTiem { get; set; }

        [JsonProperty("completed")]
        public bool Complete { get; set; }
    }
}
