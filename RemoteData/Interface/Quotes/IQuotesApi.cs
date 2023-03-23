using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Interface.Quotes
{
    public interface IQuotesApi
    {
        [Get("/quotes")]
        Task<HttpResponseMessage> GetQuotesAsync();

        [Get("/random")]
        Task<HttpResponseMessage> GetRandomQuotesAsync();
    }
}
