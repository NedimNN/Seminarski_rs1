using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Services.SMS;

namespace Online_Rezervacija_Restorana.Services.Worker
{
    public class ReservationReminderWorkerService : IHostedService, IDisposable
    {
        private Timer timer;
        private readonly IServiceScopeFactory scopedFactory;

        public ReservationReminderWorkerService(IServiceScopeFactory scopedFactory)
        {
            this.scopedFactory = scopedFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.timer = new Timer(
                GetAndSendReservationReminders,
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(200)
            );

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void GetAndSendReservationReminders(object state)
        {
            using (var scope = scopedFactory.CreateScope())
            {
                ReservationService reservationService = scope.ServiceProvider.GetService<ReservationService>();
                EmailingService emailingService = scope.ServiceProvider.GetService<EmailingService>();
                SMSService smsService = scope.ServiceProvider.GetService<SMSService>();

                foreach (Reservation reservation in reservationService.GetReservationsForReminders())
                {
                    emailingService.SendReminderMessage(reservation);
                    smsService.SendReminderSMS(reservation.Number, reservation.Table.Restaurant.Name, reservation.StartTime.ToShortTimeString());
                }
            }
        }

        public void Dispose()
        {
            this.timer?.Dispose();
        }
    }
}
