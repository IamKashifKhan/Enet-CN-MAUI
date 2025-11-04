using Newtonsoft.Json;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class CategoryRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "Category_Main_Key")]
        public string Category_Main_Key { get; }

        public CategoryRequest()
        {
            Authorization = "123";
            Category_Main_Key = "4";
        }
    }
}
