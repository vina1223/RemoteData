using Refit;
using RemoteData.Interface.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.EndPoint.Recipe
{
    public class GetRecipeEndPoint
    {
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IRecipeApi>("https://run.mocky.io/v3/19d42796-27a9-4b70-b753-5e710ae6e339").
                GetRecipeList();
        }
    }
}
