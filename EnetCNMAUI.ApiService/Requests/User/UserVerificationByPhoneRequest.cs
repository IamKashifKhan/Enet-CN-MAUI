using System;

namespace EnetCNMAUI.Requests.User;

public class UserVerificationByPhoneRequest
{
    public string Phone { get; set; }
    public string VerificationCode { get; set; }

}
