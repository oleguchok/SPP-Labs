using System;
using System.Collections.Generic;
using System.IO;
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

        protected override IEnumerable<SyndicationItem> LoadFilterFeeds(IEnumerable<string> feedsToLoad,
            IEnumerable<string> filterTags)
        {
            var items = new List<SyndicationItem>();
            foreach (var feed in feedsToLoad)
            {
                try
                {
                    using (XmlReader reader = XmlReader.Create(feed))
                    {
                        var formatter = new Rss20FeedFormatter();
                        formatter.ReadFrom(reader);
                        items.AddRange(formatter.Feed.Items);
                    }
                }
                catch (FileNotFoundException ex) { }
                catch (WebException ex) { }
            }
            return FilterLoadedFeeds(items, filterTags);
        }

        private IEnumerable<SyndicationItem> FilterLoadedFeeds(IEnumerable<SyndicationItem> loadedFeeds,
            IEnumerable<string> filterTags)
        {
            var filteredList = new List<SyndicationItem>();
            if (filterTags.Any())
            {
                foreach (var syndicationItem in loadedFeeds)
                {
                    foreach (var tag in filterTags)
                    {
                        if (syndicationItem.Summary.Text.ToUpper().Contains(tag.ToUpper()))
                        {
                            filteredList.Add(syndicationItem);
                            break;
                        }
                    }
                }
                return filteredList;
            }
                return loadedFeeds;
        }
    }
}
