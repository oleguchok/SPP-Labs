using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEditor.ModalForm
{
    public partial class NewEmptyImageForm : Form
    {
        public NewEmptyImageForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            int height, width;
            if (Int32.TryParse(textBox1.Text, out width) &&
                Int32.TryParse(textBox2.Text, out height))
            {
                if (width > 1024 || height > 1024)
                    MessageBox.Show(@"Must be less than 1024");
                else
                {
                    DataExchanger.EventEmptyImageSizeHandler(width, height);
                    Close();
                }
            }
            else
                MessageBox.Show(@"Incorrect input");
        }
    }
}
