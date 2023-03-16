using Refit;
using RemoteData.Interface.AcitvityList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.EndPoint.AvitvityList
{
    public class ActivityListEndpoint
    {
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<ActivityListApi>("https://fakerestapi.azurewebsites.net/api/v1/Activities").
                GetActivityList();
        }
    }
}
