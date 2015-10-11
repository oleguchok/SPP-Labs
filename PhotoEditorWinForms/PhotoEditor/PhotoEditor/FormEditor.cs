using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class FormEditor : Form
    {
        private static readonly String IMAGE_FORMATS = 
            "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png";

        private Boolean isCropSelected = false;

        public FormEditor()
        {
            ;
            InitializeComponent();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = IMAGE_FORMATS;

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {          
                pictureBox.Image = Image.FromFile(ofd.FileName);
                Size imgSize = pictureBox.Image.Size;
                pictureBox.Height = imgSize.Height;
                pictureBox.Width = imgSize.Width;

                PictureBoxLocation();
            }  
        }

        private void PictureBoxLocation()
        {
            int _x = 0;
            int _y = 0;
            if (panelPictureBox.Width > pictureBox.Width)
            {
                _x = (panelPictureBox.Width - pictureBox.Width) / 2;
            }
            if (panelPictureBox.Height > pictureBox.Height)
            {
                _y = (panelPictureBox.Height - pictureBox.Height) / 2;
            }
            pictureBox.Location = new Point(_x, _y);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = IMAGE_FORMATS;

            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
            {
                pictureBox.Image.Save(sfd.FileName);
            }
        }

        private void toolStripButtonSelect_Click(object sender, EventArgs e)
        {
            isCropSelected = true;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isCropSelected)
            {
                try 
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        Cursor = Cursors.Cross;
                    }
                    pictureBox.Refresh();
                }
                catch (Exception ex)
                { }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isCropSelected)
            {
               
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {

        }      

        private void toolStripDefaultCursor_Click(object sender, EventArgs e)
        {
            isCropSelected = false;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("s");
        }

        private void FormEditor_Resize(object sender, EventArgs e)
        {
            PictureBoxLocation();
        }

    }

}
