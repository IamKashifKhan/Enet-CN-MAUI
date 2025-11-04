using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class EventMarkUnmarkFavRequest
    {
        // [AliasAs("email")]
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }


        [JsonProperty(PropertyName = "EventKey")]
        public int EventKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public int UserKey { get; }



        public EventMarkUnmarkFavRequest(int userkey, int eventkey)
        {
            Authorization = Configuration.Authorization;
            EventKey = eventkey;
            UserKey = userkey;
        }
    }

}
