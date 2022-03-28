using System;
using System.Collections.Generic;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Online_Rezervacija_Restorana.Utilities;
using Online_Rezervacija_Restorana.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Online_Rezervacija_Restorana.Repository
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }
        public Reservation GetReservation(long reservationId)
        {

            return _dbContext.Reservations.Where(w => w.ID == reservationId).FirstOrDefault();
        }

        public ICollection<Reservation> GetReservationsByRestaurant(long restaurantId)
        {
            Restaurant restaurant = _dbContext.Set<Restaurant>().Find(restaurantId);

            List<Reservation> reservations = new List<Reservation>();

            foreach (Table table in restaurant.Tables)
            {
                reservations.AddRange(table.Reservations);
            }

            return reservations;
        }
        public ICollection<Reservation> GetReservationsByUser(long userId)
        {
            User user = _dbContext.Set<User>().Find(userId);

            return user.Reservations;
        }

        public bool CanCreateReservation(int numberOfPeople, long restaurantId, DateTime startTime, DateTime endTime)
        {
            int numberOfRestaurantTables = _dbContext.Tables.Count();
            return
            numberOfRestaurantTables > 0 &&
            (
                from table in _dbContext.Set<Table>()
                join restaurant in _dbContext.Set<Restaurant>() on table.RestaurantId equals restaurantId
                join reservation in _dbContext.Set<Reservation>() on table.ID equals reservation.TableID
                where table.SittingPlaces >= numberOfPeople && reservation.EndTime > startTime && reservation.StartTime < endTime
                select table
            ).Distinct().Count() < numberOfRestaurantTables;
        }

        public PagedResult<Reservation> GetPagedByUser(int page, int userId)
        {
            return _dbContext.Set<Reservation>()
                .Where(reservation => reservation.UserID == userId)
                .Include(reservation => reservation.Table)
                .ThenInclude(table => table.Restaurant)
                .GetPaged(page, 10);
        }

        ICollection<Reservation> IReservationRepository.GetReservationsForReminders()
        {
            List<Reservation> reservations = _dbContext.Set<Reservation>()
                .Where(
                    reservation => reservation.StartTime.Date == DateTime.Today.Date
                    && reservation.NotifiedReminder == false
                )
                .Include(reservation => reservation.Table)
                .ThenInclude(table => table.Restaurant)
                .ToList();
           
            foreach (Reservation reservation in reservations)
            {
                reservation.NotifiedReminder = true;
                this.Update(reservation.ID, reservation);
                _dbContext.SaveChanges();
            }
            
            return reservations;
            

        }
    }
}
