using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtensibleUIAttribute;

namespace PanelPlugin
{
    [PanelLayout(true)]
    [GroupBoxLayout(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            label1.Text = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
        }
    }
}
