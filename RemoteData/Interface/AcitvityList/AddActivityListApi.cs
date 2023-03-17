using Refit;
using RemoteData.HTTPModel.ActivityList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Interface.AcitvityList
{
    public interface AddActivityListApi
    {
        Task<HttpResponseMessage> AddActivity([Body] AddHttpActivityModel model);

    }
}
