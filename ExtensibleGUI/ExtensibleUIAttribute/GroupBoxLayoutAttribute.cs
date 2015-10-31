using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibleUIAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GroupBoxLayoutAttribute : Attribute
    {
        public bool IsGroupBox { get; set; }

        public GroupBoxLayoutAttribute(bool isGroupBox)
        {
            IsGroupBox = isGroupBox;
        }
    }
}
