using System;
using Online_Rezervacija_Restorana.Configuration;
using Nexmo.Api;

namespace Online_Rezervacija_Restorana.Services.SMS
{
    public class SMSService
    {
        private readonly SMSConfig smsConfig;
        private readonly Client client;

        public SMSService(SMSConfig smsConfig)
        {
            this.smsConfig = smsConfig;

            this.client = new Client(new Nexmo.Api.Request.Credentials(
                smsConfig.ApiKey,
                smsConfig.ApiSecret
            ));
        }

        public void SendReminderSMS(string number, string restaurantName, string time)
        {
            this.SendSMS(number, "Your reservation for " + restaurantName + " at " + time + " is today.");
        }

        private void SendSMS(string number, string message)
        {
            this.client.SMS.Send(
                new Nexmo.Api.SMS.SMSRequest {
                    from = this.smsConfig.DisplayName,
                    to = number,
                    text = message
                }
            );
        }
    }
}
