using System;
using System.Collections.Generic;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Repository;

namespace Online_Rezervacija_Restorana.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository reservationRepository;
        private readonly ITableRepository tableRepository;

        public ReservationService(IReservationRepository reservationRepository, ITableRepository tableRepository)
        {
            this.reservationRepository = reservationRepository;
            this.tableRepository = tableRepository;

        }

        private bool CanCreateReservation(int numberOfPeople, long restaurantId, DateTime startTime, DateTime endTime)
        {
            return reservationRepository.CanCreateReservation(numberOfPeople, restaurantId, startTime, endTime);
        }

        public Reservation CreateReservation(User user, int numberOfPeople, Restaurant restaurant, DateTime startTime, DateTime endTime, Order order, string email, string number)
        {
            if (!CanCreateReservation(numberOfPeople, restaurant.ID, startTime, endTime))
            {
                return null;
            }

            Table table = tableRepository.GetAvailableTable(numberOfPeople, restaurant.ID, startTime, endTime);
            if(table == null)
                 return null;
            
            Reservation reservation = new Reservation();
            reservation.GuestNumber = numberOfPeople;
            reservation.IsTemporary = false;
            reservation.CreatedOn = System.DateTime.Now;
            reservation.StartTime = startTime;
            reservation.EndTime = endTime;
            reservation.Order = order;
            reservation.Table = table;
            reservation.TableID = table.ID;
            reservation.User = user;
            reservation.Email = email;
            reservation.Number = number;
            reservation.NotifiedReminder = false;

            return reservationRepository.Create(reservation);
        }

        public ICollection<Reservation> GetReservationsForReminders()
        {
            return reservationRepository.GetReservationsForReminders();
        }
    }
}
