using Newtonsoft.Json;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class LoginRequest
    {
        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; private set; }

        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; private set; }

        [JsonProperty(PropertyName = "Phone")]
        public string Phone { get; private set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; private set; }

        // 1) private ctor gives the default values from Configuration
        private LoginRequest()
        {
            APPID = Configuration.AppId;
            Authorization = Configuration.Authorization;
        }

        public class Builder
        {
            private readonly LoginRequest _loginRequest = new LoginRequest();

            // 2) you can still override APPID if you really need to:
            public Builder SetAPPID(string appId)
            {
                _loginRequest.APPID = appId;
                return this;
            }

            // 3) same for Authorization
            public Builder SetAuthorization(string authorization)
            {
                _loginRequest.Authorization = authorization;
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

            public LoginRequest Build()
            {
                // example validation:
                if (string.IsNullOrWhiteSpace(_loginRequest.Phone))
                    throw new InvalidOperationException("Phone is required.");
                if (string.IsNullOrWhiteSpace(_loginRequest.Password))
                    throw new InvalidOperationException("Password is required.");

                return _loginRequest;
            }
        }
    }
}
