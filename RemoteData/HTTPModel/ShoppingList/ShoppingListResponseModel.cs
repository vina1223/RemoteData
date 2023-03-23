using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace RemoteData.HTTPModel.ShoppingList
{
    public class ShoppingListResponseModel
    {
        [JsonProperty("MyArray")]
        public List<string> ShoppingList { get; set; }
    
    }

    
    


}
