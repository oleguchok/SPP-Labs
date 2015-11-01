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

namespace GroupBoxPlugin
{
    [GroupBoxLayout(true)] 
    [PanelLayout(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                MessageBox.Show("Hello, " + textBox1.Text);
            }
            else
            {
                MessageBox.Show("Hello, anonymous");
            }
        }
    }
}
