using System;

namespace EnetCNMAUI.Requests.User;

public class UserVerificationByEmailRequest
{
    public string Email { get; set; }
    public string VerificationCode { get; set; }

}
