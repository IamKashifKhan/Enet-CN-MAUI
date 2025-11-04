using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Views.CustomControls
{
    public class CustomWebView : WebView
    {
        public event EventHandler ClearCache;
        public void Clear()
        {
            if (ClearCache != null)
                ClearCache(this, new EventArgs());
        }
    }
}
