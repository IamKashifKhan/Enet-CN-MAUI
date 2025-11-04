using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Domain.Models.MVC
{
    public class SubCategoryItem
    {
        public string description { get; set; }
        public int numberItems { get; set; }
        public string image { get; set; }

        // Using auto-property initializer for default value.
        public string BGColors { get; set; } = "#FF00D1";
        public string textColor { get; set; } = "#000000";
        public bool selected { get; set; }

        public int Category_Main_Key { get; set; }
        public string APPID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Keywords { get; set; }
        public bool IsVisible { get; set; }
        public string DisplayArea { get; set; }
        public string BackgroundColor { get; set; }
        public int SubCategoryCount { get; set; }
        public int ActiveBusinessCount { get; set; }
        public int ActiveOffersCount { get; set; }
    }
}
