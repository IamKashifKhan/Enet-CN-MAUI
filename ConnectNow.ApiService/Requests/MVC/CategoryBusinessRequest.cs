using Newtonsoft.Json;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class CategoryBusinessRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "Category_Sub_Key")]
        public string Category_Sub_Key { get; }

        public CategoryBusinessRequest(string subcatkey)
        {
            Authorization = "123";
            Category_Sub_Key = subcatkey;
        }
    }
}
