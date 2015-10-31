using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibleUIAttribute
{
    [AttributeUsage(AttributeTargets.All)]
    public class PositionAttribute
    {
        public readonly bool isTab;

        public PositionAttribute(bool isTab)
        {
            this.isTab = isTab;
        }
    }
}
