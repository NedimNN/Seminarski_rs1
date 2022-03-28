using Online_Rezervacija_Restorana.Models;
using System.Collections.Generic;

namespace Online_Rezervacija_Restorana.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        // Add model specific methods
        ICollection<Order> GetOrdersByUser(long userId);
        Order GetOrderByReservation(long reservationId);

    }
}
