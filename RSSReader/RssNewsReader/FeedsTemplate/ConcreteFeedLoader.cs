using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading;
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
            MailSender mailSender = new MailSender();
            string message = FormMessage(feeds);
            string subject = "You rss feeds by " + DateTime.Now;
            string sender = @"pasechny.denis@yandex.ru";
            string password = @"1q2w3e4rasdfzxc";
            foreach (var recipient in recipients)
            {
                try
                {
                    mailSender.Send(sender, password, recipient, message, subject);
                }
                catch { }
            }
        }

        private string FormMessage(IEnumerable<SyndicationItem> feeds)
        {
            string message = String.Empty;
            foreach (var feed in feeds)
            {
                    message += feed.Title.Text + " " + feed.Links.First().Uri + 
                        Environment.NewLine;
            }
            return message;
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
