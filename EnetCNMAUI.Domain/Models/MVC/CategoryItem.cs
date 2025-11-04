using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.Domain.Models.MVC
{
    public class CategoryItem
    {
        public string description { get; set; }
        public int numberItems { get; set; }
        public string image { get; set; }

        public string BGColors { get; set; } = "#F0FFD1";
        public string textColor { get; set; } = "#000000";
        public bool selected { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Keywords { get; set; }
        public bool IsVisible { get; set; }
        public string BackgroundColor { get; set; }
        public int ActiveBusinessCount { get; set; }
        public int ActiveOffersCount { get; set; }
        public string Category_Sub_Key { get; set; }
    }
}
