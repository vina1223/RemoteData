using Newtonsoft.Json;
using Plugin.Connectivity;
using RemoteData.EndPoint.Recipe;
using RemoteData.HTTPModel.Recipe;
using RemoteData.Result.Recipe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Model.Recipe
{
    public class RecipeModel
    {
            private GetRecipeEndPoint _Recipeendpoint;
            public ObservableCollection<RecipeDetails> Details { get; set; }

            public  RecipeModel() 
            {
                _Recipeendpoint= new GetRecipeEndPoint();
            }

            public async Task<MyResult> GetRecipeAsync()
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    var response = await _Recipeendpoint.ExecuteAsync();
               

                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var recipe = JsonConvert.DeserializeObject<HttpRecipeModel>(data);
                        Details = recipe.RecipeNewDetails;
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
                            Message = "Something Went Wrong",
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
