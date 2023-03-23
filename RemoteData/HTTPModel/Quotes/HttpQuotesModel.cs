using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.HTTPModel.Quotes
{
    public class HttpQuotesModel
    {
        [JsonProperty("quotes")]
        public ObservableCollection<QuotesDetails> Quotes { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
       
    }

    public class QuotesDetails
    {
        [JsonProperty("author")]
       public string AutherName { get; set; }

        [JsonProperty("quote")]
        public string AuthorQuotes { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
