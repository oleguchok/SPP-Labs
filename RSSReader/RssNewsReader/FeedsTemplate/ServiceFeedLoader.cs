using System;
using System.Collections.Generic;
using System.Configuration;
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
            SyndicationFeedFormatter formatter)
        {
            proxy.ConfigureEmailSender(ConfigurationManager.AppSettings["senderEmail"],
                ConfigurationManager.AppSettings["senderPassword"]);
            proxy.SendFeedToRecipientsByEmail(recipients.ToArray(), (Rss20FeedFormatter)formatter);
        }

        protected override SyndicationFeedFormatter LoadFilterFeeds(IEnumerable<string> feedsToLoad,
            IEnumerable<string> filterTags)
        {
            var feedItems = new List<SyndicationItem>();
            var formatter = new Rss20FeedFormatter();
            foreach (var feed in feedsToLoad)
            {
                formatter = proxy.GetFeed(feed);
                formatter = proxy.FilterFeed(formatter, filterTags.ToArray());
                feedItems.AddRange(formatter.Feed.Items);
            }
            formatter.Feed.Items = feedItems;
            return formatter;
        }

    }
}
