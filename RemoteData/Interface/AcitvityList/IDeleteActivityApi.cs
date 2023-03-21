using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Interface.AcitvityList
{
    public interface IDeleteActivityApi
    {
        [Delete("/Activities/{id}")]
        Task<HttpResponseMessage> DeleteActivity(int id);
    }
}
