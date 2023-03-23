using Refit;
using RemoteData.Interface.Quotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.EndPoint.Quotes
{
    public class QuotesEndPoint
    {
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
               For<IQuotesApi>("https://dummyjson.com/").
               GetQuotesAsync();
        } 

        public async Task<HttpResponseMessage> RandomExecuteAsync()
        {
            return await RestService.
                For<IQuotesApi>("https://dummyjson.com/quotes/").
                GetRandomQuotesAsync();
        }
    }
}
