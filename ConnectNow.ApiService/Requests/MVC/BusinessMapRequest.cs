using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.ApiService.Requests.MVC
{

    public class BusinessMapRequest
    {
        // [AliasAs("email")]
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }


        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }


        public BusinessMapRequest()
        {
            Authorization = Configuration.Authorization;
            APPID = "AAL_Mindy";
        }
    }
}
