using System;
using System.Text;

namespace Online_Rezervacija_Restorana.Services.Emailing
{
    public class Email
    {
        public string toEmail { get; }
        public string fromEmail { get; }
        public string fromDisplayName { get; }
        public string emailBody { get; }
        public Encoding bodyEncoding { get; }

        public Email(
            string toEmail,
            string fromEmail,
            string fromDisplayName,
            string emailBody,
            Encoding bodyEncoding
        ) {
            this.toEmail = toEmail;
            this.fromEmail = fromEmail;
            this.fromDisplayName = fromDisplayName;
            this.emailBody = emailBody;
            this.bodyEncoding = bodyEncoding;
        }

        public Email(
            string toEmail,
            string fromEmail,
            string fromDisplayName,
            string emailBody
        ) {
            this.toEmail = toEmail;
            this.fromEmail = fromEmail;
            this.fromDisplayName = fromDisplayName;
            this.emailBody = emailBody;
            this.bodyEncoding = Encoding.UTF8;
        }

    }
}
