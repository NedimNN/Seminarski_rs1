using System.Collections.Generic;
using System.Linq;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }

        public ICollection<Order> GetOrdersByUser(long userId)
        {
            throw new System.NotImplementedException();
        }
        public Order GetOrderByReservation(long reservationId)
        {
            return _dbContext.Orders.Where(w => w.ReservationID == reservationId).FirstOrDefault();
        }

    }
}
