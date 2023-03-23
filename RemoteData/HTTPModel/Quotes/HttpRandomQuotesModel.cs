using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.HTTPModel.Quotes
{
    public class HttpRandomQuotesModel
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("quote")]
        public string Quote { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
    }
}
