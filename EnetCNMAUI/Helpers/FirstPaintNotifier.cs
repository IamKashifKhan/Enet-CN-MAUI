using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.Helpers
{
    public sealed class FirstPaintNotifier : IFirstPaintNotifier
    {
        public event Action? FirstPaint;
        public void Raise() => FirstPaint?.Invoke();
    }
}
