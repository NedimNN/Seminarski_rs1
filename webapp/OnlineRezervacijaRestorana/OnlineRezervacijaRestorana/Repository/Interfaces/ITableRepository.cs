using System;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public interface ITableRepository : IGenericRepository<Table>
    {
        public Table GetAvailableTable(int numberOfPeople, long restaurantId, DateTime startTime, DateTime endTime);
        public Table AddTable(Table t);
        public Table GetTable(long tableId);
        // Add model specific methods below 
    }
}
