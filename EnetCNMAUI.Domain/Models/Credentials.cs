using System;
using System.Collections.Generic;
using System.Text;

namespace EnetCNMAUI.Models
{
    public class Credentials
    {
        public string dbEmail { get; set; }
        public string dbPassword { get; set; }
        public string AuthorizationKey = "SERVICEkeyTLP";

        public Credentials(string user, string pass)
        {
            dbEmail = user;
            dbPassword = pass;
        }
    }
}
