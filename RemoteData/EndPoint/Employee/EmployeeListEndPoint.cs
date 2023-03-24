using Refit;
using RemoteData.Interface.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.EndPoint.Employee
{
    public class EmployeeListEndPoint
    {

        public async Task<HttpResponseMessage> GetEmployeeListAsync()
        {
            return await RestService.
                For<IEmployeeListApi>("https://reqres.in/api/").
                GetEmployeList();

        }
    }
}
