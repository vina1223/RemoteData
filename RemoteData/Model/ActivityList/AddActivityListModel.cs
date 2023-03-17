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
    public class AddActivityListModel
    {
        private AddActivityListEndPoint _ActivtiyEndPoint;
        public string Name { get; set; }
        public string DataTime { get; set; }
        public bool IsComplete { get; set; }

        public AddActivityListModel()
        {
            _ActivtiyEndPoint = new AddActivityListEndPoint();
        }

        public async Task<MyResult> AddActivityDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var requestModel = new ActivityRequestModel()
                {
                    Name= Name,
                    DataTime= DataTime,
                    IsComplete= IsComplete,
                };
                _ActivtiyEndPoint.AddActivityRequestModel = requestModel;
                var responce = await _ActivtiyEndPoint.ExecuteAsync();

                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var employee = JsonConvert.DeserializeObject<AddHttpActivityModel>(data);
                    return new MyResult()
                    {
                        IsSucess = true,
                        Message= "Something went wrong"
                    };

                }
                else
                {
                    return new MyResult()
                    {
                        IsSucess = false,
                        Message = "Something went wrong"
                    };
                }
              
            }
            else
            {
                return new MyResult()
                {
                    IsSucess = false,
                    IsInternetError = true,
                    Message = "No Internet Connection"
                };
            }
        }

    }
}
