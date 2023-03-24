using Refit;
using RemoteData.HTTPModel.Login;
using RemoteData.Interface.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.EndPoint.Login
{
    public class LoginEndPoint
    {
       public LoginRequestModel LoginRequestModel { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<ILoginApi>("https://reqres.in/api/").SendCredintial(LoginRequestModel);
        }
    }
}
