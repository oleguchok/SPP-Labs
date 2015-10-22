using System.Collections;
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
                var result = new List<ImageInViewer>();
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sp = new SaveFileDialog();
            sp.Title = "Save a picture";
            sp.Filter = filterToImages;
            if (sp.ShowDialog() == true)
            {
                Image image = ImgPhoto;
                
                
            }
        }

        private void ButtonOpenFolder_OnClick(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenFolderPath = fbd.SelectedPath;
                FolderNameLabel.Content = OpenFolderPath;
                var dplb = ListBoxImages.GetBindingExpression(ItemsControl.ItemsSourceProperty);
                dplb.UpdateTarget();
            }
        }

        private void ListBoxImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                IList addedItems = e.AddedItems;
                var image = (ImageInViewer) addedItems[0];
                ImgPhoto.Source = image.ImageSrc;
            }
        }
        
    }
}
