using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace RssNewsReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int menuShowClick = 0;
        private ObservableCollection<string> rssFeedsList = new ObservableCollection<string>(
                ConfigurationManager.AppSettings["rssFeedList"].Split(new char[] { ';' }));

        public MainWindow() 
        {
            InitializeComponent();
            RssFeedsList.DataContext = rssFeedsList;
        }

        private void OnGetFeed(object sender, RoutedEventArgs e)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(textUrl.Text))
                {
                    var formatter = new Rss20FeedFormatter();
                    formatter.ReadFrom(reader);
                    this.DataContext = formatter.Feed;
                    this.feedContent.DataContext = formatter.Feed.Items;
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "Syndication Reader");
            }
        }

        private void btnTopMenuShow_Click(object sender, RoutedEventArgs e)
        {
            if (menuShowClick == 0)
            {
                ShowHideMenu("sbShowTopMenu", pnlTopMenu);
                menuShowClick++;
            }
            else
            {
                menuShowClick = 0;
                ShowHideMenu("sbHideTopMenu", pnlTopMenu);
            }
        }

        private void ShowHideMenu(string Storyboard, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);
        }

        private void AddNewRssFeedButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NewRssFeedTextBox.Text != string.Empty)
            {
                rssFeedsList.Add(NewRssFeedTextBox.Text);
                NewRssFeedTextBox.Text = string.Empty;
            }
        }

        private void DeleteRssFeedButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (RssFeedsList.SelectedIndex != -1)
            {
                rssFeedsList.RemoveAt(RssFeedsList.SelectedIndex);
            }
        }
    }
}
