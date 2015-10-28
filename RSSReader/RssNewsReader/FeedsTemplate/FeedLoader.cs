using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.RightsManagement;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace RssNewsReader.FeedsTemplate
{
    public abstract class FeedLoader
    {
        public IEnumerable<SyndicationItem> LoadFeedsEntry(IEnumerable<string> feedsToLoad,
            IEnumerable<string> filterTags, IEnumerable<string> recipients)
        {
            ThreadPool.QueueUserWorkItem((state => LoadFeeds(feedsToLoad)));
            var feeds = new List<SyndicationItem>(){new SyndicationItem()};
            //var feeds = LoadFeeds(feedsToLoad);
            //feeds = FilterFeeds(feeds, filterTags);
            //SendToRecipients(recipients, feeds);
            return feeds;
        }

        protected abstract void SendToRecipients(IEnumerable<string> recipients,
            IEnumerable<SyndicationItem> feeds);

        protected abstract IEnumerable<SyndicationItem> FilterFeeds(IEnumerable<SyndicationItem> feeds,
            IEnumerable<string> filterTags);
        
        protected abstract IEnumerable<SyndicationItem> LoadFeeds(IEnumerable<string> feedsToLoad);
    }
}
