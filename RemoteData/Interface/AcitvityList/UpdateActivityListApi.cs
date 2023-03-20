using Refit;
using RemoteData.HTTPModel.ActivityList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Interface.AcitvityList
{
    public interface UpdateActivityListApi
    {
        [Put ("/Activities/{id}")]
        Task<HttpResponseMessage> UpdateActivity([Body] ActivityRequestModel model , int id);
    }
}
