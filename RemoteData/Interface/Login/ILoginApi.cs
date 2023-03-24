using Refit;
using RemoteData.HTTPModel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Interface.Login
{
   
     public interface ILoginApi
    {
        [Post("/login")]
        Task<HttpResponseMessage> SendCredintial([Body] LoginRequestModel model);
    }
}
