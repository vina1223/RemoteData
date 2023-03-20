using Newtonsoft.Json;
using Plugin.Connectivity;
using RemoteData.EndPoint.AvitvityList;
using RemoteData.HTTPModel.ActivityList;
using RemoteData.Result.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Model.ActivityList
{
    public class UpdateActivityModel
    {
        private UpdateActivityListEndPoint _UpdateEndPoint;

        public string Name { get; set; }
        public string DateTime { get; set; }
        public bool IsComplete { get; set; }

        public UpdateActivityModel() 
        {
            _UpdateEndPoint= new UpdateActivityListEndPoint();
        }

        public async Task<MyResult> UpdateActivityDetailsAsync()
        {
            if(CrossConnectivity.Current.IsConnected)
            {
                var requestModel = new ActivityRequestModel() 
                {
                    Name = Name,
                    DataTime=DateTime,
                    IsComplete= IsComplete,
                };

                _UpdateEndPoint.UpdateActivityRequestModel = requestModel;
                var responce = await _UpdateEndPoint.ExecuteAsync();

                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync(); ;
                    var activity = JsonConvert.DeserializeObject<AddHttpActivityModel>(data);

                    return new MyResult()
                    {
                        IsSucess = true,
                        Message = "Activity UpDated Successfully",
                    };
                }
                else
                {
                    return new MyResult()
                    {
                        IsSucess = false,
                        Message = "Somthing Went Wrong",
                    };
                }

            }
            else
            {
                return new MyResult()
                {
                    IsSucess = false,
                    IsInternetError = true,
                    Message = "No Interne Connection"
                };
            }
        }

    }
}
