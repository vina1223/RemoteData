using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.HTTPModel.Recipe
{
    public class HttpRecipeModel
    {
        [JsonProperty("recipes")]
        public ObservableCollection<RecipeDetails> RecipeNewDetails { get; set; }
    }

    public class RecipeDetails
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("time_to_prepare")]
        public string Time_to_prepeare { get; set; }

        [JsonProperty("image_url")]
        public string Image_url { get; set; }
    }
}
