using System;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Online_Rezervacija_Restorana.Repository
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        public TableRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }

        public Table GetTable(long tableId)
        {
            return _dbContext.Tables.Where(w => w.ID == tableId).FirstOrDefault();
        }
        public Table GetAvailableTable(int numberOfPeople, long restaurantId, DateTime startTime, DateTime endTime)
        {
            var tables = _dbContext.Tables
                .Include(table => table.Reservations)
                .Where(table => table.RestaurantId == restaurantId);

            foreach (var table in tables)
            {
                if (table.Reservations.Count() == 0 )
                    return table;
                foreach (var reservation in table.Reservations)
                {
                    if (
                        (reservation.StartTime > startTime && startTime < reservation.EndTime)
                        || (reservation.StartTime > endTime && endTime < reservation.EndTime)
                        || (startTime > reservation.StartTime && reservation.StartTime < endTime)
                    )
                    {
                        return table;

                    }
                }
            }

            return null;
        }
        public Table AddTable(Table t)
        {
            if(t != null) { 
                _dbContext.Tables.Add(t);
                _dbContext.SaveChanges();
            }
            return t;
        }
    }
}
