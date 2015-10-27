using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace RssNewsReader.FeedsTemplate
{
    public abstract class FeedLoader
    {
        private TimeSpan reloadTime;
        private IEnumerable<string> feedsToLoad;
        private IEnumerable<string> filterTags;
        private IEnumerable<string> recipients; 

        public FeedLoader(IEnumerable<string> feedsToLoad,
            IEnumerable<string> filterTags, IEnumerable<string> recipients,
            TimeSpan reloadTime)
        {
            this.feedsToLoad = feedsToLoad;
            this.filterTags = filterTags;
            this.recipients = recipients;
            this.reloadTime = reloadTime;
        }

        //public void LoadFeedsEntry()
        //{
            
        //}

        public IEnumerable<SyndicationItem> LoadFeedsEntry()
        {
            var feeds = LoadFeeds(feedsToLoad);
            feeds = feeds.Select(FilterFeeds(filterTags));
            SendToRecipients(recipients, feeds);
            return feeds;
        }

        protected abstract void SendToRecipients(IEnumerable<string> recipients, IEnumerable<SyndicationItem> feeds);

        protected abstract Func<SyndicationItem, SyndicationItem> FilterFeeds(IEnumerable<string> filterTags);
        
        protected abstract IEnumerable<SyndicationItem> LoadFeeds(IEnumerable<string> feedsToLoad);
    }
}
