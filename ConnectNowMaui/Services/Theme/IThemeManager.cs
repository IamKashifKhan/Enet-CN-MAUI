using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Services.Theme
{
    public interface IThemeManager
    {
        public void Register(object recipient, IJSRuntime js);
        public void UnregisterAll();
        public void UpdateAppTheme(AppTheme appTheme);
        public AppTheme GetSelectedTheme();
        public void UpdateWelcomePageTheme();
    }
}
