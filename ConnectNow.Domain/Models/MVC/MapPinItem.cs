using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Domain.Models.MVC
{
    public class MapPinItem
    {
        public int BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
       // public Position Position { get; set; }
        public double Radius { get; set; }
    }
}
