using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Interface.ShoppingList
{
    public interface IShoppingListApi
    {
        [Get("/categories")]
        Task<HttpResponseMessage> GetShoppingListAsync();

        [Get("/category/{category}")]
        Task<HttpResponseMessage> GetShoppingList(string category);
    }
}
