using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Result.Recipe
{
    public class MyResult
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public bool IsInternetError { get; set; }
    }
}
