using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.ApiService.Requests.MVC
{

    public class OffersMarkUnmarkFavRequest
    {
        // [AliasAs("email")]
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }


        [JsonProperty(PropertyName = "BusinessOffersKey")]
        public int BusinessOffersKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public int UserKey { get; }



        public OffersMarkUnmarkFavRequest(int userkey, int businessOffersKey)
        {
            Authorization = Configuration.Authorization;
            BusinessOffersKey = businessOffersKey;
            UserKey = userkey;
        }
    }
}
