using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Online_Rezervacija_Restorana.Configuration;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Services.Emailing;
using Online_Rezervacija_Restorana.ViewModels;

namespace Online_Rezervacija_Restorana.Services
{
    public class EmailingService
    {
        private readonly SmtpClient client;
        private readonly EmailConfig emailConfig;

        private readonly string confirmationTemplate = "<!DOCTYPE html><h1 style=\"color: #5e9ca0;\"><span style=\"color: #5e9ca0;\">Reservation Confirmation</span></h1> <p>Your reservation has been successfuly confirmed. This is the confirmation email.</p> <h2 style=\"color: #2e6c80;\">Reservation Information: </h2> <table class=\"editorDemoTable\"> <thead> <tr style=\"height: 16px;\"> <td style=\"height: 16px;\">Info</td> <td style=\"height: 16px;\">Values</td> </tr> </thead> <tbody> <tr style=\"height: 22px;\"> <td style=\"height: 22px;\">Restaurant name</td> <td style=\"height: 22px;\">{0}</td> </tr> <tr style=\"height: 22px;\"> <td style=\"height: 22px;\">Date</td> <td style=\"height: 22px;\">{1}</td> </tr> <tr style=\"height: 22px;\"> <td style=\"height: 22px;\">Time</td> <td style=\"height: 22px;\">{2}</td> </tr> <tr style=\"height: 22px;\"> <td style=\"height: 22px;\">End Time</td> <td style=\"height: 22px;\">{3}</td> </tr> <tr style=\"height: 36px;\"> <td style=\"height: 36px;\">Number Of Guests</td> <td style=\"height: 36px;\">{4}</td> </tr> </tbody> </table> <p><strong> </strong></p> <p><strong>Thank you for using our services.<br />Fitba1902 seminarski rad! </strong></p>";

        private readonly string reminderTemplate = "<!DOCTYPE html><h1 style=\"color: #5e9ca0;\"><span style=\"color: #5e9ca0;\">Reservation Reminder</span></h1> <p>Your reservation is due today.</p> <h2 style=\"color: #2e6c80;\">Reservation Information:</h2> <table class=\"editorDemoTable\"> <thead> <tr style=\"height: 16px;\"> <td style=\"height: 16px;\">Info</td> <td style=\"height: 16px;\">Values</td> </tr> </thead> <tbody> <tr style=\"height: 22px;\"> <td style=\"height: 22px;\">Restaurant name</td> <td style=\"height: 22px;\">{0}</td> </tr> <tr style=\"height: 22px;\"> <td style=\"height: 22px;\">Date</td> <td style=\"height: 22px;\">{1}</td> </tr> <tr style=\"height: 22px;\"> <td style=\"height: 22px;\">Time</td> <td style=\"height: 22px;\">{2}</td> </tr> <tr style=\"height: 36px;\"> <td style=\"height: 36px;\">Number Of Guests</td> <td style=\"height: 36px;\">{3}</td> </tr> </tbody> </table> <p> </p> <p><strong>Thank you for using our services.<br />Fitba1902 seminarski rad! </strong></p>";

        public EmailingService(EmailConfig emailConfig)
        {
            this.emailConfig = emailConfig;
            this.client = new SmtpClient(emailConfig.SmtpHost, emailConfig.Port);
            this.client.UseDefaultCredentials = false;
            this.client.Credentials = new System.Net.NetworkCredential(
                emailConfig.AppEmail,
                emailConfig.AppPassword
            );
            this.client.EnableSsl = true;
        }

        public void SendConfirmationMessage(string emailAdress, ConfirmReservationVM info)
        {
            string emailBody = String.Format(
                confirmationTemplate,
                info.restaurantName,
                info.reservationStartDate,
                info.reservationStartTime,
                info.reservationEndTime,
                info.reservationNumberOfGuests
            );

            Email email = new Email(emailAdress, emailConfig.AppEmail, emailConfig.DisplayName, emailBody);

            this.SendEmailMessage(email);
        }

        public void SendReminderMessage(Reservation reservation)
        {
            string emailBody = String.Format(
                reminderTemplate,
                reservation.Table.Restaurant.Name,
                reservation.StartTime.ToShortDateString(),
                reservation.StartTime.ToShortTimeString(),
                reservation.GuestNumber
            );

            Email email = new Email(reservation.Email, emailConfig.AppEmail, emailConfig.DisplayName, emailBody);

            this.SendEmailMessage(email);
        }

        private async Task<int> SendEmailMessage(Email email)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(email.fromEmail, email.fromDisplayName);
            mail.To.Add(new MailAddress(email.toEmail));
            mail.Body = email.emailBody;
            mail.BodyEncoding = email.bodyEncoding;
            mail.IsBodyHtml = true;

            await this.client.SendMailAsync(mail);
            mail.Dispose();
            return 0;
        }
    }
}
