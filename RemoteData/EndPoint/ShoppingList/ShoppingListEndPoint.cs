using Refit;
using RemoteData.Interface.ShoppingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.EndPoint.ShoppingList
{
    public class ShoppingListEndPoint
    {
       
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                 For<IShoppingListApi>("https://dummyjson.com/products/").
                 GetShoppingListAsync();
                
        }

        public string Category { get; set; }
        public async Task<HttpResponseMessage> ProductExecuteAsync()
        {
            return await RestService.
                For<IShoppingListApi>("https://dummyjson.com/products/").
                GetShoppingList(Category);
        }
    }
}
