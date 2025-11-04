using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class CityBusinessRequest
    {
        // [AliasAs("email")]
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }


        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "City")]
        public string City { get; }

        [JsonProperty(PropertyName = "SearchAll")]
        public string SearchAll { get; }


        public CityBusinessRequest(string city, string searchall)
        {
            Authorization = Configuration.Authorization;
            APPID = "AAL_Mindy";
            City = city;
            SearchAll = searchall;
        }
    }
}
