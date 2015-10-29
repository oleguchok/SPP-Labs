using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FeedServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(FeedService)))
            {
                host.Open();
                Console.WriteLine("Feed Service Console Host is open");
                Console.ReadLine();
            }
        }
    }
}
