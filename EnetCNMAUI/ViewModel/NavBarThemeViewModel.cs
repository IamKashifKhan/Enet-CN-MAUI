using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ViewModel
{
    public class NavBarThemeViewModel : BaseViewModel
    {
        public Color HeaderBg { get => headerBg; set { headerBg = value; OnPropertyChanged(); } }
        public Color BodyBg { get => bodyBg; set { bodyBg = value; OnPropertyChanged(); } }
        public Color FooterBg { get => footerBg; set { footerBg = value; OnPropertyChanged(); } }
        public Color ItemIconColor { get => itemIconColor; set { itemIconColor = value; OnPropertyChanged(); } }
        public Color ItemTextColor { get => itemTextColor; set { itemTextColor = value; OnPropertyChanged(); } }
        public Color ItemSelectedColor { get => itemSelectedColor; set { itemSelectedColor = value; OnPropertyChanged(); } }
        public Color FooterProfileColor { get => footerProfileColor; set { footerProfileColor = value; OnPropertyChanged(); } }
        public Color FooterUserColor { get => footerUserColor; set { footerUserColor = value; OnPropertyChanged(); } }
        public Color FooterEmailColor { get => footerEmailColor; set { footerEmailColor = value; OnPropertyChanged(); } }
        public Color SectionHeaderColor { get => sectionHeaderColor; set { sectionHeaderColor = value; OnPropertyChanged(); } }

        private Color headerBg;
        private Color bodyBg;
        private Color footerBg;
        private Color itemIconColor;
        private Color itemTextColor;
        private Color itemSelectedColor;
        private Color footerProfileColor;
        private Color footerUserColor;
        private Color footerEmailColor;
        private Color sectionHeaderColor;
    }
}
