using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class OffersSearchRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "SearchText")]
        public string SearchText { get; }

        [JsonProperty(PropertyName = "Count")]
        public string Count { get; }

        public OffersSearchRequest(string userKey, string searchText, string count = "20")
        {
            Authorization = Configuration.Authorization;
            UserKey = userKey;
            APPID = Configuration.AppId;
            SearchText = searchText;
            Count = count;
        }
    }
}