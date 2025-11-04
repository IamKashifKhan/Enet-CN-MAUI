using System;

namespace ConnectNow.Requests.User;

public class SetPasswordRequest
{
    public int Id { get; set; }
    public string NewPassword { get; set; }
}

