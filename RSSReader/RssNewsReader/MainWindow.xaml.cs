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
using System.Timers;
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
using System.Windows.Threading;
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
        private System.Timers.Timer timer;

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
                    feedContent.DataContext = formatter.Feed.Items;
                    if (timer != null)
                        timer.Stop();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "Syndication Reader");
            }
            finally
            {
                if (timer != null)
                    timer.Dispose();
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
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
            timer = new System.Timers.Timer(100000);
            FeedLoader feedLoader = new ConcreteFeedLoader();
            ThreadPool.QueueUserWorkItem((state) => RefreshBindingInFeedContent(feedLoader));
            timer.Elapsed += (o, args) => RefreshBindingInFeedContent(feedLoader);
            timer.Start();
        }

        private void RefreshBindingInFeedContent(FeedLoader feedLoader)
        {
            feedContent.Dispatcher.BeginInvoke(
                new Action(() => feedContent.DataContext =
                    feedLoader.LoadFeedsEntry(rssFeedsList, tagList, emailList)));
        }
        
        private void RssFeedsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textUrl.Text = (string)RssFeedsList.SelectedValue;
        }
    }
}
