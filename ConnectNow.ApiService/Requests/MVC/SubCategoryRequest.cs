using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class SubCategoryRequest
    {
        [JsonProperty(PropertyName = "JsonData")]
        public string JsonData { get; }

        public SubCategoryRequest(int parameter1 = 0, string parameter2 = "")
        {
            JSONPacketIn jSONPacketIn = new JSONPacketIn
            {
                Authorization = "123",
                data = new List<object> { new { Category_Main_Key = parameter1 } }
            };
            JsonData = JsonConvert.SerializeObject(jSONPacketIn);
        }
    }
    public class JSONPacketIn
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; set; }

        [JsonProperty(PropertyName = "data")]
        public object data { get; set; }

    }
}
