using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Interface.Recipe
{
    public interface IRecipeApi
    {
        [Get("/recipes")]
        Task<HttpResponseMessage> GetRecipeList();
    }
}
