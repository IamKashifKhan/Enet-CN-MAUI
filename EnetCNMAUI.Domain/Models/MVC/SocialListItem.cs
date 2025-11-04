using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.Domain.Models.MVC
{
    public class SocialListItem
    {
        public int BusinessKey { get; set; }
        public string Platform { get; set; }
        public string IconPath { get; set; }
        public string Link { get; set; }
    }
}
