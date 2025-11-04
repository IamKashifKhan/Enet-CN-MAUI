using System;
using Newtonsoft.Json;

namespace EnetCNMAUI.Requests
{
    

    public class BusinessBasicDetailsRequest
    {
      
        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]

        public string UserKey { get; }

        [JsonProperty(PropertyName = "BusinessKey")]

        public string BusinessKey { get; }


        public BusinessBasicDetailsRequest(string userkey, string businesskey)
        {

            UserKey = userkey;
            BusinessKey = businesskey; 
            AuthorizationKey = Configuration.AuthorizationKey;
        }
    }

    public class BusinessLocationRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "Zipcode")]

        public string Zipcode { get; }

        public BusinessLocationRequest(string zipcode)
        {

            Zipcode = zipcode;
            AuthorizationKey = Configuration.AuthorizationKey;
        }
    }
}
