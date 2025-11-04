using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.Domain.Models.MVC
{
    public class DateItem
    {
        public string month { get; set; }
        public string day { get; set; }
        public string dayWeek { get; set; }
        public bool selected { get; set; }
        public string backgroundColor { get; set; }
        public string textColor { get; set; }
        public List<CurrentEvents> currentevents { get; set; }
    }

    public class CurrentEvents
    {
        public string events { get; set; }
    }
}
