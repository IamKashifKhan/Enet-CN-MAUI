using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.ViewModel
{
    public class WelcomePageThemeViewModel : BaseViewModel
    {
        public Color ScreenBg { get => screenBg; set { screenBg = value; OnPropertyChanged(); } }
        public Color CarouselTitleColor { get => carouselTitleColor; set { carouselTitleColor = value; OnPropertyChanged(); } }
        public Color CarouselDescColor { get => carouselDescColor; set { carouselDescColor = value; OnPropertyChanged(); } }
        public Color IndicatorColor { get => indicatorColor; set { indicatorColor = value; OnPropertyChanged(); } }
        public Color SelectedIndicatorColor { get => selectedIndicatorColor; set { selectedIndicatorColor = value; OnPropertyChanged(); } }
        public Color BtnBgColor { get => btnBgColor; set { btnBgColor = value; OnPropertyChanged(); } }
        public Color BtnTextColor { get => btnTextColor; set { btnTextColor = value; OnPropertyChanged(); } }
        public string LogoUrl { get => logoUrl; set { logoUrl = value; OnPropertyChanged(); } }
        public string CarouselImg1 { get => carouselImg1; set { carouselImg1 = value; OnPropertyChanged(); } }
        public string CarouselImg2 { get => carouselImg2; set { carouselImg2 = value; OnPropertyChanged(); } }
        public string CarouselImg3 { get => carouselImg3; set { carouselImg3 = value; OnPropertyChanged(); } }
        public Color PermissionDialogBg { get => permissionDialogBg; set { permissionDialogBg = value; OnPropertyChanged(); } }
        public string PermissionDialogIcon { get => permissionDialogIcon; set { permissionDialogIcon = value; OnPropertyChanged(); } }

        private Color screenBg;
        private Color carouselTitleColor;
        private Color carouselDescColor;
        private Color indicatorColor;
        private Color selectedIndicatorColor;
        private Color btnBgColor;
        private Color btnTextColor;
        private string logoUrl;
        private string carouselImg1, carouselImg2, carouselImg3;
        private Color permissionDialogBg;
        private string permissionDialogIcon;
    }
}
