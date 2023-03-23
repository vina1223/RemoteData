using Newtonsoft.Json;
using Plugin.Connectivity;
using RemoteData.EndPoint.ShoppingList;
using RemoteData.HTTPModel.ShoppingList;
using RemoteData.Result.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Model.ShoppingList
{
    public class ProductListModel
    {
        private ShoppingListEndPoint _shoppingEndPoint;

        public string Category { get; set; }
        public List<ShoppingDetails> ShoppingList { get; set; }

        public ProductListModel()
        {
            _shoppingEndPoint = new ShoppingListEndPoint();
        }

        public async Task<MyResult> GetProductDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                _shoppingEndPoint.Category = Category;
                var responce = await _shoppingEndPoint.ProductExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var Data = await responce.Content.ReadAsStringAsync(); ;
                    var product = JsonConvert.DeserializeObject<HttpShoppingModel>(Data);
                    ShoppingList = product.ProductList;
                    return new MyResult()
                    {
                        IsSucess = true,
                    };
                }
                else
                {
                    return new MyResult()
                    {
                        IsSucess = false,
                        Message = "No Internet Connected"
                    };
                }

            }
            else
            {
                return new MyResult()
                {
                    IsSucess = false,
                    IsInternetError = false,
                    Message = "No Internet Connection"
                };
            }
        }

    }


}

