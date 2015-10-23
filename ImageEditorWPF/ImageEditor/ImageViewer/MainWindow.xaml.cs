using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

using ImageInViewer = ImageViewer.Model.Image; 

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string filterToImages = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

        public MainWindow()
        {
            InitializeComponent();
            OpenFolderPath = Environment.GetFolderPath(
                Environment.SpecialFolder.MyPictures);
            DataContext = this;
        }

        #region Properties
        public string OpenFolderPath { get; set; }

        public List<ImageInViewer> AllImages
        {
            get
            {
                List<ImageInViewer> result = new List<ImageInViewer>();
                foreach (string filename in
                    Directory.GetFiles(OpenFolderPath))
                {
                    try
                    {
                        result.Add(
                            new ImageInViewer(
                            new BitmapImage(
                            new Uri(filename)),
                            System.IO.Path.GetFileNameWithoutExtension(filename)));
                    }
                    catch { }
                }
                return result;
            }
        }

        #endregion

        #region Button Load, OpenFolder, Save

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = filterToImages;
            if (op.ShowDialog() == true)
            {
                ImgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
        
        private void ButtonOpenFolder_OnClick(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    OpenFolderPath = fbd.SelectedPath;
                    FolderNameLabel.Content = OpenFolderPath;
                    BindingExpression dplb = ListBoxImages.GetBindingExpression(ItemsControl.ItemsSourceProperty);
                    dplb.UpdateTarget();
                }
            }
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog {Title = "Save a picture",
                Filter = filterToImages};
            if (sfd.ShowDialog() == true)
            {
                string extension = System.IO.Path.GetExtension(sfd.FileName);

                switch (extension)
                {
                    case ".png": SaveUsingEncoder(sfd.FileName, new PngBitmapEncoder());
                        break;
                    case ".jpg": 
                    default: SaveUsingEncoder(sfd.FileName, new JpegBitmapEncoder());
                        break;
                }
            }
        }

        #endregion

        private void SaveUsingEncoder(string fileName, BitmapEncoder encoder)
        {
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)ImgPhoto.Source));
            using (var filestream = new FileStream(fileName, FileMode.Create))
                encoder.Save(filestream);
        }

        private void ListBoxImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                IList addedItems = e.AddedItems;
                ImageInViewer image = (ImageInViewer) addedItems[0];
                ImgPhoto.Source = image.ImageSrc;
            }
        }
        
    }
}
