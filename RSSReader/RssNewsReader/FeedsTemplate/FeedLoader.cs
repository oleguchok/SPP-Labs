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
            var waitHandle = new ManualResetEvent(false);
            SyndicationFeedFormatter formatter = null;
            ThreadPool.QueueUserWorkItem((state =>
            {
                formatter = LoadFilterFeeds(feedsToLoad, filterTags);
                waitHandle.Set();
            }));
            waitHandle.WaitOne();
            ThreadPool.QueueUserWorkItem(state => SendToRecipients(recipients, formatter));
            return formatter.Feed.Items;
        }

        protected abstract void SendToRecipients(IEnumerable<string> recipients, 
            SyndicationFeedFormatter formatter);

        protected abstract SyndicationFeedFormatter LoadFilterFeeds(IEnumerable<string> feedsToLoad,
            IEnumerable<string> filterTags);
    }
}
