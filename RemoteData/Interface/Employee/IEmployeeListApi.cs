using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Interface.Employee
{
    public interface IEmployeeListApi
    {
        [Get("/users")]
        Task<HttpResponseMessage> GetEmployeList();
    }
}
