using System.Runtime.InteropServices;
using PhotoEditor.ModalForm;
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

        private Boolean isImageScaling = false;
        private bool isPencil = false;
        private Size modifiedImageSize;
        private Image originalImage;
        private List<Point> pointsToDraw = new List<Point>();
        private Image modifiedImage;
        private PictureBox pictureBoxForCut;
        private Point firstPointCut;
        private Point secondPointCut;
        private Boolean isCut = false;

        private float[][] colorMatrixElements =
{
                new float[] {1,0,0,0,0},
                new float[] {0,1,0,0,0},
                new float[] {0,0,1,0,0},
                new float[] {0,0,0,1,0},
                new float[] {0,0,0,0,1}
            };

        public FormEditor()
        {
            InitializeComponent();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = IMAGE_FORMATS;

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                //pictureBox.Image = Image.FromFile(ofd.FileName);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                {
                    originalImage = Image.FromStream(fs);
                    modifiedImage = Image.FromStream(fs);
                    pictureBox.Image = Image.FromStream(fs);
                }

                pictureBox.Height = pictureBox.Image.Height;
                pictureBox.Width = pictureBox.Image.Width;
                modifiedImageSize = originalImage.Size;
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
                if (!isImageScaling)
                {
                    pictureBox.Image.Save(sfd.FileName);
                }
                else
                    originalImage.Save(sfd.FileName);
            }
        }

        private void FormEditor_Resize(object sender, EventArgs e)
        {
            PictureBoxLocation();
        }

        private void toolStripComboBoxZoom_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == 13)
            {
                ScaleImageOnPictureBox(toolStripComboBoxZoom.Text);
                isImageScaling = true;
            }
        }

        private void toolStripComboBoxZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScaleImageOnPictureBox(toolStripComboBoxZoom.Text);
            isImageScaling = true;
        }

        private void toolStripComboBoxZoom_Leave(object sender, EventArgs e)
        {
            ScaleImageOnPictureBox(toolStripComboBoxZoom.Text);
            isImageScaling = true;
        }

        private void CalculateModifiedImageSize(int widthZoom, int heightZoom)
        {
            if (originalImage == null)
                throw new ArgumentNullException("Image", @"Choose image");
            modifiedImageSize = new Size((originalImage.Width * widthZoom) / 100,
                    (originalImage.Height * heightZoom) / 100);
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

        private void ScaleImageOnPictureBox(String text)
        {
            try 
            {
                Int32 zoom = ParseSizeString(text);
                CalculateModifiedImageSize(zoom, zoom);
                if (pictureBox.Image != null)
                {
                    RedrawPictureBoxImage(originalImage, modifiedImageSize);
                    PictureBoxLocation();
                }
            } catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RedrawPictureBoxImage(Image source, Size modifiedSize)
        {
            Bitmap bm_source = new Bitmap(source);
            Bitmap bm_dest = new Bitmap(modifiedSize.Width, modifiedSize.Height,
                    PixelFormat.Format24bppRgb);
            using (Graphics gr_dest = Graphics.FromImage(bm_dest))
            {
                gr_dest.CompositingQuality = CompositingQuality.HighQuality;
                gr_dest.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr_dest.SmoothingMode = SmoothingMode.HighQuality;
                gr_dest.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width, bm_dest.Height);
            }
            InsertImageInPictureBox(pictureBox, bm_dest);
        }

        private void InsertImageInPictureBox(PictureBox pictureBox, Image image)
        {
            pictureBox.Image = image;
            pictureBox.Width = image.Width;
            pictureBox.Height = image.Height;
        }

        private void toolStripButtonResize_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeForm resizeForm = new ResizeForm();
                DataExchanger.EventSizeHandler =
                    new DataExchanger.ExchangeSizeEvent(ResizeImage);
                resizeForm.ShowDialog();
                resizeForm.Dispose();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResizeImage(int widht, int height)
        {
            CalculateModifiedImageSize(widht, height);
            RedrawPictureBoxImage(originalImage, modifiedImageSize);
            originalImage = pictureBox.Image;
            PictureBoxLocation();
        }

        #region Rotate Image
        private void toolStripButtonRotateRight_Click(object sender, EventArgs e)
        {
            RotateImageOnFlip(RotateFlipType.Rotate90FlipNone);
        }

        private void toolStripButtonRotateLeft_Click(object sender, EventArgs e)
        {
            RotateImageOnFlip(RotateFlipType.Rotate270FlipNone);
        }

        private void RotateImageOnFlip(RotateFlipType flipType)
        {
            if (pictureBox.Image == null)
                MessageBox.Show(@"Choose image");
            else
            {
                pictureBox.Image.RotateFlip(flipType);
                RedrawPictureBoxImage(pictureBox.Image, pictureBox.Image.Size);
                PictureBoxLocation();
                pictureBox.Refresh();
            }
        }

        #endregion

        #region Paint
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            ShowNewEmptyImageForm();
        }

        private void ShowNewEmptyImageForm()
        {
            NewEmptyImageForm form = new NewEmptyImageForm();
            DataExchanger.EventEmptyImageSizeHandler =
                new DataExchanger.ExchangeEmptyImageSizeEvent(CreateEmtyImage);
            form.ShowDialog();
            form.Dispose();
        }

        private void CreateEmtyImage(int width, int height)
        {
            Bitmap Bmp = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(Bmp))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                gfx.FillRectangle(brush, 0, 0, width, height);
            }
            pictureBox.Image = Bmp;
            originalImage = Bmp;
            PictureBoxLocation();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr LoadCursorFromFile(string lpFileName);
        
        private void toolStripButtonPen_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
                isPencil = true;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPencil)
            {
                IntPtr hCursor = LoadCursorFromFile("cur1046.cur");
                Cursor cursor = new Cursor(hCursor);
                Cursor = cursor;
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                {
                    pointsToDraw.Add(e.Location);
                    using (Graphics grp = Graphics.FromImage(pictureBox.Image))
                    {
                        if (pointsToDraw.Count > 1)
                            grp.DrawLines(Pens.Black, pointsToDraw.ToArray());
                    }
                    originalImage = pictureBox.Image;
                    pictureBox.Refresh();
                    pictureBox.Invalidate();
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (isPencil && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                pointsToDraw.Add(e.Location);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isPencil)
            {
                pointsToDraw.Clear();
            }
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = DefaultCursor;
        }

        private void toolStripButtonDefaultCursor_Click(object sender, EventArgs e)
        {
            isPencil = false;
            isCut = false;
            if (pictureBoxForCut != null)
                pictureBoxForCut.Enabled = false;
        }

        #endregion

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show(@"Choose image");
                return;
            }
            float v = trackBarBrightness.Value * 0.01f;
            colorMatrixElements[4][0] = v;
            colorMatrixElements[4][1] = v;
            colorMatrixElements[4][2] = v;
            ChangeAttributesOfImage();
        }

        private void trackBarColor_Scroll(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show(@"Choose image");
                return;
            }
            if (checkBoxRed.Checked)
            {
                float v = trackBarColor.Value * 0.01f;
                colorMatrixElements[0][0] = v;
                ChangeAttributesOfImage();
            }
            if (checkBoxGreen.Checked)
            {
                float v = trackBarColor.Value * 0.01f;
                colorMatrixElements[1][1] = v;
                ChangeAttributesOfImage();
            }
            if (checkBoxBlue.Checked)
            {
                float v = trackBarColor.Value * 0.01f;
                colorMatrixElements[2][2] = v;
                ChangeAttributesOfImage();
            }
        }

        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show(@"Choose image");
                return;
            }
            float v = trackBarContrast.Value * 0.01f;
            colorMatrixElements[0][0] = v;
            colorMatrixElements[1][1] = v;
            colorMatrixElements[2][2] = v;
            ChangeAttributesOfImage();
        }

        private void ChangeAttributesOfImage()
        {
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            ImageAttributes imageAttributes = new ImageAttributes();

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            Graphics g = Graphics.FromImage(modifiedImage);
            g.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height), 0, 0,
                originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, imageAttributes);
            RedrawPictureBoxImage(modifiedImage, modifiedImageSize);
        }

        private void toolStripButtonAccept_Click(object sender, EventArgs e)
        {
            originalImage = (Image)modifiedImage.Clone();
            ClearColorMatrix();
            trackBarBrightness.Value = 0;
            trackBarContrast.Value = 100;
            trackBarColor.Value = 100;
            checkBoxRed.Checked = false;
            checkBoxGreen.Checked = false;
            checkBoxBlue.Checked = false;
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            RedrawPictureBoxImage(originalImage, modifiedImageSize);
            ClearColorMatrix();
            trackBarBrightness.Value = 0;
            trackBarContrast.Value = 100;
            trackBarColor.Value = 100;
            checkBoxRed.Checked = false;
            checkBoxGreen.Checked = false;
            checkBoxBlue.Checked = false;
        }

        private void ClearColorMatrix()
        {
            colorMatrixElements.Initialize();
            colorMatrixElements[0][0] = 1;
            colorMatrixElements[1][1] = 1;
            colorMatrixElements[2][2] = 1;
            colorMatrixElements[3][3] = 1;
            colorMatrixElements[4][4] = 1;
        }

        private void cutToolStripButton1_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show(@"Choose image");
                return;
            }
            if (isCut == false)
            {
                modifiedImageSize = originalImage.Size;
                RedrawPictureBoxImage(originalImage, modifiedImageSize);
                if (pictureBoxForCut == null)
                {
                    pictureBoxForCut = new PictureBox
                    {
                        Size = pictureBox.Size,
                        Location = new Point(0, 0),
                        BackColor = Color.Transparent,
                        Cursor = Cursors.Cross
                    };
                    pictureBox.Controls.Add(pictureBoxForCut);
                    pictureBoxForCut.MouseDown += PictureBoxForCut_MouseDown;
                    pictureBoxForCut.MouseUp += PictureBoxForCut_MouseUp;
                    pictureBoxForCut.MouseMove += PictureBoxForCut_MouseMove;
                    pictureBoxForCut.DoubleClick += PictureBoxForCut_DoubleClick;
                    pictureBoxForCut.DragOver += PictureBoxForCut_DragOver;
                }
                else
                {
                    pictureBoxForCut.Enabled = true;
                }
                isCut = true;
            }
            else
            {
                CorrectPointOfRectangle(ref firstPointCut, ref secondPointCut);
                Bitmap bmp = originalImage as Bitmap;
                originalImage = null;
                originalImage = bmp.Clone(
                    new Rectangle
                    (
                        firstPointCut.X,
                        firstPointCut.Y,
                        secondPointCut.X - firstPointCut.X,
                        secondPointCut.Y - firstPointCut.Y
                    ), bmp.PixelFormat);
                modifiedImageSize = originalImage.Size;
                RedrawPictureBoxImage(originalImage, modifiedImageSize);

                isCut = false;
                pictureBoxForCut.Enabled = false;
            }

        }

        private void PictureBoxForCut_MouseDown(object sender, MouseEventArgs e)
        {
            firstPointCut = e.Location;
        }

        private void PictureBoxForCut_MouseUp(object sender, MouseEventArgs e)
        {
            secondPointCut = e.Location;
        }

        private void PictureBoxForCut_DragOver(object sender, DragEventArgs e)
        {
            pictureBoxForCut.Enabled = false;
        }

        private void PictureBoxForCut_DoubleClick(object sender, EventArgs e)
        {

        }

        private void PictureBoxForCut_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                RedrawCutRectangle(firstPointCut, e.Location);
            }
        }

        private void RedrawCutRectangle(Point p1, Point p2)
        {
            CorrectPointOfRectangle(ref p1, ref p2);
            pictureBoxForCut.Image = null;
            Graphics g = pictureBoxForCut.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Red), p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
        }

        private void CorrectPointOfRectangle(ref Point p1, ref Point p2)
        {
            if (p1.X > p2.X)
            {
                int tmp = p1.X;
                p1.X = p2.X;
                p2.X = tmp;
            }
            if (p1.Y > p2.Y)
            {
                int tmp = p1.Y;
                p1.Y = p2.Y;
                p2.Y = tmp;
            }
        }
    }

}
