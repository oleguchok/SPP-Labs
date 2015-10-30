using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using RssNewsReader.FeedServiceReference;

namespace RssNewsReader.FeedsTemplate
{
    public class ServiceFeedLoader : FeedLoader
    {
        private readonly FeedServiceClient proxy = new FeedServiceClient();

        protected override void SendToRecipients(IEnumerable<string> recipients,
            IEnumerable<SyndicationItem> feeds)
        {
            
        }

        protected override IEnumerable<SyndicationItem> LoadFilterFeeds(IEnumerable<string> feedsToLoad,
            IEnumerable<string> filterTags)
        {
            var feedItems = new List<SyndicationItem>();
            foreach (var feed in feedsToLoad)
            {
                var formatter = proxy.GetFeed(feed);
                formatter = proxy.FilterFeed(formatter, filterTags.ToArray());
                feedItems.AddRange(formatter.Feed.Items);
            }
            return feedItems;
        }

    }
}
