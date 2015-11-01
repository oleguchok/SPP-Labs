using ExtensibleUIAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabPlugin
{
    [TabLayoutAttribute(true)]
    public partial class Form1 : Form
    {
        private int click;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                label2.ForeColor = Color.Red;
                click++;
            }
            else
            {
                label2.ForeColor = Color.SaddleBrown;
                click = 0;
            }
        }
    }
}
