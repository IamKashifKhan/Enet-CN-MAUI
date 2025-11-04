using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class OffersFavoriteRequest
    {
        // [AliasAs("email")]
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }


        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        public OffersFavoriteRequest(string userkey)
        {
            Authorization = Configuration.Authorization;
            UserKey = userkey;
        }
    }
}
