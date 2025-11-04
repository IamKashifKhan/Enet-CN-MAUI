using System;

namespace ConnectNow.Requests.User;

public class Auth0RegisterRequest
{
        public string Auth0UserId { get; set; }
        public string FullName { get; set; }
        public string Picture { get; set; }
        public string Email { get; set; }

}
