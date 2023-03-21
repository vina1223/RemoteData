using Newtonsoft.Json;
using Plugin.Connectivity;
using RemoteData.EndPoint.AvitvityList;
using RemoteData.HTTPModel.ActivityList;
using RemoteData.Result.Recipe;

namespace RemoteData.Model.ActivityList
{
    public class DeleteActivityModel
    {
        private DeleteActivityListEndPoint _deleteActivityListEndPoint;

        public int Id { get; set; }
        public DeleteActivityModel()
        {
            _deleteActivityListEndPoint = new DeleteActivityListEndPoint(); 
        }

        public async Task<MyResult> DeleteActivityDetailAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                _deleteActivityListEndPoint.ID = Id;
                var responce = await _deleteActivityListEndPoint.ExecuteAsync();

                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var mydata = JsonConvert.DeserializeObject<DeleteActivityResponceModel>(data);
                    return new MyResult()
                    {
                        IsSucess = true,
                        Message = "Delete Successfully",
                    };
                }
                else
                {
                    return new MyResult()
                    {
                        IsSucess = false,
                        Message = "Somthing is Worng",
                    };
                }
            }
            else
            {
                return new MyResult()
                {
                    IsSucess = false,
                    IsInternetError = true,
                    Message = "No Internet Connection",
                };
            }
        }
    }
}
