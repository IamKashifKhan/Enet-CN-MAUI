using System;

namespace ConnectNow.Requests.User;

public class UserVerificationByEmailRequest
{
    public string Email { get; set; }
    public string VerificationCode { get; set; }

}
