using System;
namespace Online_Rezervacija_Restorana.Configuration
{
    public class EmailConfig
    {
        public string SmtpHost { get; set; }
        public int Port { get; set; }
        public string AppEmail { get; set; }
        public string AppPassword { get; set; }
        public string DisplayName { get; set; }
    }
}
