using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class OffersFeaturedRequest
    {
        // [AliasAs("email")]
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }


        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        public OffersFeaturedRequest(string userkey)
        {
            Authorization = Configuration.Authorization;
            UserKey = userkey;
            APPID = Configuration.AppId;
        }
    }

}
