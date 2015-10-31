using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibleUIAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PanelLayoutAttribute : Attribute
    {
        public bool IsPanel { get; set; }

        public PanelLayoutAttribute(bool isPanel)
        {
            IsPanel = isPanel;
        }
    }
}
