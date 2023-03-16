using Newtonsoft.Json;
using Plugin.Connectivity;
using RemoteData.EndPoint.AvitvityList;
using RemoteData.HTTPModel.ActivityList;
using RemoteData.Result.Recipe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Model.ActivityList
{
    public class ActivityListModel
    {
        private ActivityListEndpoint _ActivityEndPoint;
        public List<ActivityDetails> DetailsActivity { get; set; }
        public ActivityListModel()
        {
            _ActivityEndPoint = new ActivityListEndpoint(); ;
        }

        public async Task<MyResult> GetActivityDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var responce = await _ActivityEndPoint.ExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var activity = JsonConvert.DeserializeObject<HttpActivityListModel>(data);
                    DetailsActivity = activity.ActivityNewDetails;
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
                        Message = "Something Went wrong"
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
