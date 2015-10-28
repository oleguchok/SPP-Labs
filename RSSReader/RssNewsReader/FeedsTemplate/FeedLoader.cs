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
            dynamic feeds = null;
            ThreadPool.QueueUserWorkItem((state =>
            {
                feeds = LoadFilterFeeds(feedsToLoad, filterTags);
                waitHandle.Set();
            }));
            waitHandle.WaitOne();
            ThreadPool.QueueUserWorkItem(state => SendToRecipients(recipients, feeds));
            return feeds;
        }

        protected abstract void SendToRecipients(IEnumerable<string> recipients,
            IEnumerable<SyndicationItem> feeds);

        protected abstract IEnumerable<SyndicationItem> LoadFilterFeeds(IEnumerable<string> feedsToLoad,
            IEnumerable<string> filterTags);
    }
}
