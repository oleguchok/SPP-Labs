using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace FeedServiceHost
{
    public class FeedService : IFeedService
    {
        private string emailSender;
        private string passwordSender;

        public Rss20FeedFormatter GetFeed(string feedUrl)
        {
            var formatter = new Rss20FeedFormatter();
            try
            {
                using (var reader = XmlReader.Create(feedUrl))
                {
                    formatter.ReadFrom(reader);
                }
            }
            catch (FileNotFoundException ex) { }
            catch (WebException ex) { }
            return formatter;
        }

        public Rss20FeedFormatter FilterFeed(Rss20FeedFormatter formatterFeed, IEnumerable<string> tags)
        {
            var feed = new SyndicationFeed() {Title = new TextSyndicationContent("Service Feed")};
            var result = new Rss20FeedFormatter(feed);
            result.Feed.Items = FilterItemsInFeedByTags(formatterFeed.Feed.Items, tags);
            return result;
        }


        public void ConfigureEmailSender(string email, string password)
        {
            emailSender = email;
            passwordSender = password;
        }

        private List<SyndicationItem> FilterItemsInFeedByTags(IEnumerable<SyndicationItem> items,
            IEnumerable<string> tags)
        {
            var filteredList = new List<SyndicationItem>();
            if (tags.Any())
            {
                foreach (var syndicationItem in items)
                {
                    foreach (var tag in tags)
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
            return items.ToList();
        }
    }
}
