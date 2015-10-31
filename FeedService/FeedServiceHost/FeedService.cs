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
            using (var fs = new FileStream("config.txt", FileMode.Create))
            {
                using (var bw = new BinaryWriter(fs))
                {
                    bw.Write(email);
                    bw.Write(password);
                }
            }
        }

        public void SendFeedToRecipientsByEmail(IEnumerable<string> recipients, Rss20FeedFormatter formatter)
        {
            var mailSender = new MailSender();
            string sender, password;
            string message = FormMessage(formatter.Feed.Items);
            string subject = "You rss feeds by " + DateTime.Now;
            using (FileStream fs = new FileStream("config.txt", FileMode.Open))
            {
                using (var br = new BinaryReader(fs))
                {
                    sender = br.ReadString();
                    password = br.ReadString();
                }
            }
            foreach (var recipient in recipients)
            {
                try
                {
                    mailSender.Send(sender, password, recipient, message, subject);
                }
                catch { }
            }
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
    }
}
