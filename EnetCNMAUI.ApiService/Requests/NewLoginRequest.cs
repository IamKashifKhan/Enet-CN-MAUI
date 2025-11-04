using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnetCNMAUI.Requests
{
   
    public class NewLoginRequest
        {
          [JsonProperty(PropertyName = "email")]
            public string? Email { get; private set; }
          [JsonProperty(PropertyName = "phone")]

        public string? Phone { get; private set; }
        [JsonProperty(PropertyName = "password")]

        public string Password { get; private set; }
        [JsonProperty(PropertyName = "auth0UserId")]

        public string? Auth0UserId { get; private set; }

        public class Builder
        {
            private readonly NewLoginRequest _loginRequest = new NewLoginRequest();

            public Builder SetEmail(string email)
            {
                _loginRequest.Email = email;
                return this;
            }

            public Builder SetPhone(string phone)
            {
                _loginRequest.Phone = phone;
                return this;
            }

            public Builder SetPassword(string password)
            {
                _loginRequest.Password = password;
                return this;
            }

            public Builder SetAuth0UserId(string auth0UserId)
            {
                _loginRequest.Auth0UserId = auth0UserId;
                return this;
            }

            public NewLoginRequest Build()
            {
                // Add validation if necessary
                return _loginRequest;
            }
        }
    }




    public class ChangePasswordRequest
    { 
        // [AliasAs("email")]
        [JsonProperty(PropertyName = "Username")]
        public string Username { get; }

        //  [AliasAs("password")]
        [JsonProperty(PropertyName = "OldPassword")]
        public string OldPassword { get; }

        [JsonProperty(PropertyName = "NewPassword")]
        public string NewPassword { get; }


        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }


        public ChangePasswordRequest(string userName, string oldPassword, string newPassword)
        {
            Username = userName;
            OldPassword = oldPassword;
            NewPassword = newPassword;
            AuthorizationKey = Configuration.AuthorizationKey;
        }
    }


    public class SearchRequest
    {
        [JsonProperty(PropertyName = "NameSearch")]
        public string NameSearch { get; }

        //  [AliasAs("password")]
        [JsonProperty(PropertyName = "PageNo")]
        public string PageNo { get; }


        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        public SearchRequest(string nameSearch, string pageNo)
        {
            NameSearch = nameSearch;
            PageNo = pageNo;
            AuthorizationKey = "SERVICEkeyTLP";
        }
    }

}
