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
        public delegate void ExchangeAngleEvent(float angle);
        public static ExchangeSizeEvent EventSizeHandler;
        public static ExchangeAngleEvent EventAngleHandler;
    }
}
