using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Helpers
{
    public interface IFirstPaintNotifier
    {
        event Action? FirstPaint;
        void Raise();
    }

}
