using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Interface.AcitvityList
{
    public interface ActivityListApi
    {
        [Get("/Activities")]
        Task<HttpResponseMessage> GetActivityList();
    }
}
