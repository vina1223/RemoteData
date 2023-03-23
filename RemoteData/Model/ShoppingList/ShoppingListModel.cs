using Newtonsoft.Json;
using Plugin.Connectivity;
using RemoteData.EndPoint.ShoppingList;
using RemoteData.HTTPModel.ShoppingList;
using RemoteData.Result.Recipe;

namespace RemoteData.Model.ShoppingList
{
    public class ShoppingListModel
    {
        private ShoppingListEndPoint _ShoppingListEndPoint;

       
        public List<string> ShoppingDetails { get; set; }

        public ShoppingListModel()
        {
            _ShoppingListEndPoint= new ShoppingListEndPoint();
        }

        public async Task<MyResult> GetShoppingListDetailsAsync()
        {
            
            if(CrossConnectivity.Current.IsConnected)
            {
                var responce = await _ShoppingListEndPoint.ExecuteAsync();
                if(responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var shopping = JsonConvert.DeserializeObject<List<string>>(data);
                    ShoppingDetails = shopping;

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
                        Message = "SOmething Went wrong"
                    };
                }
            }
            else
            {
                return new MyResult()
                {
                    IsSucess = false,
                    IsInternetError = true,
                    Message = "No Internet Connection"
                };
            }
        }

    }
}
