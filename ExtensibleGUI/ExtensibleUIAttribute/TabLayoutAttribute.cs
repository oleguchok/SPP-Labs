using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibleUIAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TabLayoutAttribute : Attribute
    {
        public bool IsTab { get; set; }

        public TabLayoutAttribute(bool isTab)
        {
            IsTab = isTab;
        }
    }
}
