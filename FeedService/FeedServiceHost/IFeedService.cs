using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml.Serialization;

namespace FeedServiceHost
{
    [ServiceContract]
    public interface IFeedService
    {
        [OperationContract]
        Rss20FeedFormatter GetFeed(string feedUrl);

        [OperationContract]
        Rss20FeedFormatter FilterFeed(Rss20FeedFormatter formatterFeed, IEnumerable<string> tags);

        [OperationContract]
        void ConfigureEmailSender(string email, string password);

        [OperationContract]
        void SendFeedToRecipientsByEmail(IEnumerable<string> recipients, Rss20FeedFormatter formatter);
    }

}
