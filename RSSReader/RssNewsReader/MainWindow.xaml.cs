using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading;
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
using RssNewsReader.FeedsTemplate;

namespace RssNewsReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int menuShowClick = 0;
        private TimeSpan checkedRadioButtonTimeGroup = new TimeSpan(0,1,0);
        private List<SyndicationItem> currentFeeds = new List<SyndicationItem>(); 
        private List<SyndicationItem> filterResult = new List<SyndicationItem>();

        #region Observable Collections
        private ObservableCollection<string> rssFeedsList = new ObservableCollection<string>(
                ConfigurationManager.AppSettings["rssFeedList"].Split(new char[] { ';' }));
        private ObservableCollection<string> emailList = new ObservableCollection<string>(
            ConfigurationManager.AppSettings["emailList"].Split(new char[] { ';' })); 
        private ObservableCollection<string> tagList = new ObservableCollection<string>();
        #endregion

        public MainWindow() 
        {
            InitializeComponent();
            RssFeedsList.DataContext = rssFeedsList;
            EmailList.DataContext = emailList;
            TagList.DataContext = tagList;
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

        #region Menu

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

        #endregion

        #region Menu ListBoxes

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
            DeleteSelectedItemFromListBox(RssFeedsList.SelectedIndex, rssFeedsList);
        }

        private void AddEmailButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text != string.Empty)
            {
                emailList.Add(EmailTextBox.Text);
                EmailTextBox.Text = string.Empty;
            }
        }

        private void DeleteEmailButton_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteSelectedItemFromListBox(EmailList.SelectedIndex, emailList);
        }

        private void DeleteTagButton_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteSelectedItemFromListBox(TagList.SelectedIndex, tagList);
        }

        private void AddTagButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (TagTextBox.Text != string.Empty)
            {
                tagList.Add(TagTextBox.Text);
                TagTextBox.Text = string.Empty;
            }
        }

        private void DeleteSelectedItemFromListBox(int itemNum, 
            ObservableCollection<string> list)
        {
            if (itemNum != -1)
                list.RemoveAt(itemNum);
        }

        #endregion

        private void TimeRadio_Checked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            checkedRadioButtonTimeGroup = TimeSpan.Parse(radio.Tag.ToString());
        }

        private void GetFeedByCriteriasButton_OnClick(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(GetFeedByTime, checkedRadioButtonTimeGroup);
            ThreadPool.QueueUserWorkItem(ParseFeedByCtireria);
           // ThreadPool.QueueUserWorkItem(loader.LoadFeedsEntry)
            //FeedLoader loader = new ConcreteFeedLoader();
        }

        private void ParseFeedByCtireria(object state)
        {
            filterResult.Clear();
            foreach (var tag in tagList)
            {
                lock (currentFeeds)
                {
                    foreach (var syndicationItem in currentFeeds)
                    {
                        if (syndicationItem.Summary.Text.Contains(tag))
                        {
                            filterResult.Add(syndicationItem);
                        }
                    }
                }
            }
        }

        private void GetFeedByTime(object time)
        {
            lock (currentFeeds)
            {
                foreach (var feed in rssFeedsList)
            {
                    currentFeeds.AddRange(GetFeedsFromUrl(feed));
                }
            }
        }

        private IEnumerable<SyndicationItem> GetFeedsFromUrl(string feed)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(feed))
                {
                    var formatter = new Rss20FeedFormatter();
                    formatter.ReadFrom(reader);
                    return formatter.Feed.Items;
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "Syndication Reader");
                return null;
            }
        }
        private void RssFeedsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textUrl.Text = (string)RssFeedsList.SelectedValue;
        }
    }
}
