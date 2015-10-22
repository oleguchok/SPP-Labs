﻿using System.Windows.Forms;
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
        public string OpenFolderPath { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            OpenFolderPath = Environment.GetFolderPath(
                Environment.SpecialFolder.MyPictures);
            DataContext = this;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sp = new SaveFileDialog();
            sp.Title = "Save a picture";
            sp.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (sp.ShowDialog() == true)
            {
                Image image = imgPhoto;
                
                
            }
        }

        private void ButtonOpenFolder_OnClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
        }

        public List<ImageInViewer> AllImages
        {
            get
            {
                List<ImageInViewer> result = new List<ImageInViewer>();
                foreach (string filename in
                    System.IO.Directory.GetFiles(OpenFolderPath))
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
    }
}
