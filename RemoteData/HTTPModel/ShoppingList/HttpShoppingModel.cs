using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.HTTPModel.ShoppingList
{
    public class HttpShoppingModel
    {
        [JsonProperty("products")]
        public List<ShoppingDetails> ProductList { get; set; }
    }

    public class ShoppingDetails
    {
        [JsonProperty("title")]
        public string ProductTitle { get; set; }

        [JsonProperty("price")]
        public int ProductPrice { get; set; }

        [JsonProperty("thumbnail")]
        public ImageSource ThumbnailImage { get; set; }

        [JsonProperty("images")]
        public List<string> ProductImage { get; set; }

    }
}
