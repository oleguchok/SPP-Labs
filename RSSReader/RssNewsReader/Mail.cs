using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RssNewsReader
{
    public class MailSender
    {
        public Boolean Send(string mailFrom, string password, string mailTo, string message, string subject)
        {
            return Send(mailFrom, password, mailTo, message, subject, null);
        }

        public Boolean Send(string mailFrom, string password, string mailTo, string message, string subject, string attachFile)
        {
            bool returnValue = false;
            string host = mailFrom.Split('@')[1];
            string username = mailFrom.Split('@')[0];
            Mail Server = DefineHost(host);
            MailMessage mailmessage = CreateMailMessage(mailFrom, mailTo, message, subject, attachFile);
            try
            {
                CreateSMTPClient(mailmessage, Server, password, username);
                returnValue = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Mail send: " + ex.Message);
            }
            return returnValue;
        }

        private Mail DefineHost(string host)
        {
            switch (host)
            {
                case "mail.ru": return new Mail();
                case "gmail.com": return new Gmail();
                case "yandex.ru": return new Yandex();
                default: break;
            }
            return new Mail();
        }


        private MailMessage CreateMailMessage(string mailFrom, string mailTo, string message, string subject)
        {
            return CreateMailMessage(mailFrom, mailTo, message, subject, null);
        }

        private MailMessage CreateMailMessage(string mailFrom, string mailTo, string message,
            string subject, string attachFile)
        {
            MailMessage mail = null;
            try
            {
                mail = new MailMessage();
                mail.From = new MailAddress(mailFrom);
                mail.To.Add(new MailAddress(mailTo));
                mail.Subject = subject;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
            }
            catch (Exception ex)
            {
                throw new Exception("MailCreate: " + ex.Message);
            }
            return mail;
        }

        private void CreateSMTPClient(MailMessage mail, Mail server, string password, string username)
        {
            SmtpClient client = new SmtpClient(server.Host);
            client.Port = server.Port;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(username, password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(mail);
            mail.Dispose();
        }
    }

    public class Mail
    {
        protected string _host;
        protected int _port;
        public int Port
        {
            get { return _port; }
        }
        public string Host
        {
            get { return _host; }
        }
        public Mail()
        {
            _host = "smtp.mail.ru";
            _port = 25;
        }
    }

    public class Gmail : Mail
    {
        public Gmail()
        {
            _host = "smtp.gmail.com";
            _port = 587;
        }
    }

    public class Yandex : Mail
    {
        public Yandex()
        {
            _host = "smtp.yandex.ru";
            _port = 25;
        }
    }
}
