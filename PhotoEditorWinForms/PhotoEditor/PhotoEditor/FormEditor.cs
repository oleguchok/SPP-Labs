using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
        private Size modifiedImageSize;
        private Image originalImage;

        public FormEditor()
        {
            ; ;
            InitializeComponent();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = IMAGE_FORMATS;

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {          
                pictureBox.Image = Image.FromFile(ofd.FileName);
                pictureBox.Height = pictureBox.Image.Height;
                pictureBox.Width = pictureBox.Image.Width;
                originalImage = Image.FromFile(ofd.FileName);
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
            
        }

        private void FormEditor_Resize(object sender, EventArgs e)
        {
            PictureBoxLocation();
        }

        private void toolStripComboBoxZoom_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == 13)
            {
                ResizeImageOnPictureBox(toolStripComboBoxZoom.Text);
            }
        }

        private void CalculateModifiedImageSize(String text)
        {
            try
            {
                Int32 zoom = ParseSizeString(text);
                modifiedImageSize = new Size(
                    (originalImage.Width * zoom) / 100,
                    (originalImage.Height * zoom) / 100);
            } catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private int ParseSizeString(String text)
        {
            var temp = "";
            foreach(char c in text)
            {
                if (Char.IsNumber(c))
                    temp += c;
                else
                    break;
            }
            if (temp == "")
                throw new ArgumentException("Incorrect input");
            else
            {
                var result = Int32.Parse(temp);
                if (result > 200)
                    throw new ArgumentException("Value must be less than 200%");
                else
                    return result;                    
            }
        }

        private void toolStripComboBoxZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResizeImageOnPictureBox(toolStripComboBoxZoom.Text);
        }

        private void toolStripComboBoxZoom_Leave(object sender, EventArgs e)
        {
            ResizeImageOnPictureBox(toolStripComboBoxZoom.Text);
        }

        private void ResizeImageOnPictureBox(String text)
        {
            CalculateModifiedImageSize(text);
            if (pictureBox.Image != null)
            {
                Bitmap bm_source = new Bitmap(originalImage);
                Bitmap bm_dest = new Bitmap(modifiedImageSize.Width, modifiedImageSize.Height,
                    PixelFormat.Format24bppRgb);
                using(Graphics gr_dest = Graphics.FromImage(bm_dest))
                {
                    gr_dest.CompositingQuality = CompositingQuality.HighQuality;
                    gr_dest.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr_dest.SmoothingMode = SmoothingMode.HighQuality;
                    gr_dest.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1);
                }                

                InsertImageInPictureBox(pictureBox, bm_dest);
                PictureBoxLocation();
            }
        }

        private void InsertImageInPictureBox(PictureBox pictureBox, Image image)
        {
            pictureBox.Image = image;
            pictureBox.Width = image.Width;
            pictureBox.Height = image.Height;
        }

        private void TrackBarBrightness_Scroll(object sender, EventArgs e)
        {
            float value = TrackBarBrightness.Value * 0.01f;
            float[][] colorMatrixElements = 
            {
                new float[] {1,0,0,0,0},
                new float[] {0,1,0,0,0},
                new float[] {0,0,1,0,0},
                new float[] {0,0,0,1,0},
                new float[] {value,value,value,0,1}
            };
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            ImageAttributes imageAttributes = new ImageAttributes();


            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            //PictureBox1.Image
            Graphics g = Graphics.FromImage(originalImage);
            g.DrawImage(originalImage,new Rectangle(0,0,originalImage.Width,originalImage.Height), 0, 0, 
                originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, imageAttributes);
            
        }
    }

}
