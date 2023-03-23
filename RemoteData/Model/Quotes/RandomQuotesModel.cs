using Newtonsoft.Json;
using Plugin.Connectivity;
using RemoteData.EndPoint.Quotes;
using RemoteData.HTTPModel.Quotes;
using RemoteData.Result.Recipe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Model.Quotes
{
    public class RandomQuotesModel
    {
        public QuotesEndPoint _quotesEndPoint;

         public string Author { get; set; }
         public string Quotes { get; set; }

        public RandomQuotesModel()
        {
            _quotesEndPoint= new QuotesEndPoint();  
        }

        public async Task<MyResult> GetRandomQuotesList()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var responce = await _quotesEndPoint.RandomExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<HttpRandomQuotesModel>(data);
                    Quotes = result.Quote;
                    Author = result.Author;
                    return new MyResult()
                    {
                        IsSucess = true,
                    };
                }
                else
                {
                    return new MyResult()
                    {
                        IsSucess = false,
                        Message = " Something Is Wrong",
                    };
                }
            }
            else
            {
                return new MyResult()
                {
                    IsSucess = false,
                    IsInternetError = true,
                    Message = "No Internet Connection",
                };
            }
        }
    }
}
