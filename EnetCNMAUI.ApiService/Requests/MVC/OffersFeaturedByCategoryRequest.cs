using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class OffersFeaturedByCategoryRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "Category_Sub_Key")]
        public string Category_Sub_Key { get; }

        [JsonProperty(PropertyName = "Count")]
        public string Count { get; }

        public OffersFeaturedByCategoryRequest(string userkey, string categorySubKey, string count)
        {
            Authorization = Configuration.Authorization;
            UserKey = userkey;
            APPID = Configuration.AppId;
            Category_Sub_Key = categorySubKey;
            Count = count;
        }
    }
}