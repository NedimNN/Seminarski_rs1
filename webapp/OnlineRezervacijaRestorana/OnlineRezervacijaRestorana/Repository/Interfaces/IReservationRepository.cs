using Online_Rezervacija_Restorana.Models;
using System;
using System.Collections.Generic;


namespace Online_Rezervacija_Restorana.Repository
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        // Add model specific methods
  
        ICollection<Reservation> GetReservationsByUser(long userId);
        ICollection<Reservation> GetReservationsByRestaurant(long restaurantId);
        Reservation GetReservation(long reservationId);
        public Utilities.PagedResult<Reservation> GetPagedByUser(int page, int userId);
        bool CanCreateReservation(int numberOfPeople, long restaurantId, DateTime startTime, DateTime endTime);
        ICollection<Reservation> GetReservationsForReminders();
    }
}
