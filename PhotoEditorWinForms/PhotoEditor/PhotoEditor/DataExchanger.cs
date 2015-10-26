using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEditor
{
    public static class DataExchanger
    {
        public delegate void ExchangeSizeEvent(int width, int height);
        public static ExchangeSizeEvent EventSizeHandler;
    }
}
