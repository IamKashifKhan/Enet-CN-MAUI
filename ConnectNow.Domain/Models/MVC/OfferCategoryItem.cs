using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Domain.Models.MVC
{
    public class OfferCategoryItem
    {
        public string Category_Main_ID { get; set; }
        public string Category_Main_Name { get; set; }
        public string Category_Main_ImagePath { get; set; }
        public string Category_Main_Description { get; set; }
        public string Category_Sub_ID { get; set; }
        public string Category_Sub_Name { get; set; }
        public string Category_Sub_Description { get; set; }
        public string Timestamp { get; set; }
    }
}
