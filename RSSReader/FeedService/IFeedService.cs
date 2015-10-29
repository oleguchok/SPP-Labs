using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace FeedService
{
    [ServiceContract]
    public interface IFeedService
    {
        [OperationContract]
        Rss20FeedFormatter GetFeed(string feedUrl);
    }

}
