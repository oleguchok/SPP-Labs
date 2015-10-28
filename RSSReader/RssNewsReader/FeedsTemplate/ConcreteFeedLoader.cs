using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace RssNewsReader.FeedsTemplate
{
    public class ConcreteFeedLoader : FeedLoader
    {

        protected override void SendToRecipients(IEnumerable<string> recipients,
            IEnumerable<SyndicationItem> feeds)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<SyndicationItem> LoadFeeds(IEnumerable<string> feedsToLoad)
        {
            try
            {
                var items = new List<SyndicationItem>();
                foreach (var feed in feedsToLoad)
                {
                    using (XmlReader reader = XmlReader.Create(feed))
                    {
                        var formatter = new Rss20FeedFormatter();
                        formatter.ReadFrom(reader);
                        items.AddRange(formatter.Feed.Items);
                    }
                }
                MessageBox.Show("1");
                return items;
            }
            catch (WebException ex)
            {
                throw new WebException("RSS Reader Exception");
            }
        }

        protected override IEnumerable<SyndicationItem> FilterFeeds(IEnumerable<SyndicationItem> feeds,
            IEnumerable<string> filterTags)
        {
            throw new NotImplementedException();
        }
    }
}
