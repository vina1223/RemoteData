using Refit;
using RemoteData.HTTPModel.ActivityList;
using RemoteData.Interface.AcitvityList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.EndPoint.AvitvityList
{
    public class UpdateActivityListEndPoint
    {
        public int ID { get; set; }
        public ActivityRequestModel UpdateActivityRequestModel { get; set; }

        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await
                RestService.For<UpdateActivityListApi>("https://fakerestapi.azurewebsites.net/api/v1/").UpdateActivity(UpdateActivityRequestModel, ID);
        }


    }
}
