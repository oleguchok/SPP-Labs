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
    }
}
