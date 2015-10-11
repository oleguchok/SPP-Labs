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
    public partial class ResizeForm : Form
    {
        public ResizeForm()
        {
            InitializeComponent();
        }

        private void buttonResizeCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonResizeOk_Click(object sender, EventArgs e)
        {
            int height, width;
            if (Int32.TryParse(maskedTextBoxWidth.Text, out width) &&
                Int32.TryParse(maskedTextBoxHeight.Text, out height))
            {
                if (width > 200 || height > 200)
                    MessageBox.Show("Percentage Must be less than 200");
                else
                {
                    DataExchanger.EventHandler(width, height);
                    Close();
                }
                    
            }
            else
                MessageBox.Show("Incorrect input");
        }
    }
}
