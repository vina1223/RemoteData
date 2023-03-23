using Newtonsoft.Json;
using Plugin.Connectivity;
using RemoteData.EndPoint.Quotes;
using RemoteData.HTTPModel.Quotes;
using RemoteData.Result.Recipe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Model.Quotes
{
    public class QuotesModel
    {
        public QuotesEndPoint _QuotesEndPoint;

        public ObservableCollection<QuotesDetails> Details { get; set; }
        public QuotesModel() 
        {
            _QuotesEndPoint= new QuotesEndPoint();
        }

        public async Task<MyResult> GetQuotes()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
               var responce = await _QuotesEndPoint.ExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<HttpQuotesModel>(data);
                    Details = result.Quotes;
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
                        Message = "Something is Wrong",
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
