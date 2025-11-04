using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Domain.Models.MVC
{
    public class RedemptionSummaryItem
    {
        public int Redemptions { get; set; }
        public decimal RedemptionCostsTotal { get; set; }
        public decimal RedemptionDiscountsTotal { get; set; }
        public decimal RedemptionPaidValuesTotal { get; set; }
    }



}
