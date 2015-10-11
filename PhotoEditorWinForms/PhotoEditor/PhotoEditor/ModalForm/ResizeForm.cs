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
            float angle;
            if (Int32.TryParse(maskedTextBoxWidth.Text, out width) &&
                Int32.TryParse(maskedTextBoxHeight.Text, out height) &&
                Single.TryParse(maskedTextBoxAngle.Text, out angle))
            {
                if (width > 200 || height > 200)
                    MessageBox.Show("Percentage Must be less than 200");
                if (angle > 360)
                    MessageBox.Show("Angle must be less than 360");
                else
                {
                    DataExchanger.EventSizeHandler(width, height);
                    DataExchanger.EventAngleHandler(angle);
                    Close();
                } 
            }
            else
                MessageBox.Show("Incorrect input");
        }
    }
}
