using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Rezervacija_Restorana.Models;
using System.Collections.Generic;

namespace Online_Rezervacija_Restorana.Repository
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        // Add model specific methods

        OrderDetail GetOrderDetailsByOrder(long orderId);
        void AddRange(ICollection<OrderDetail> orderDetails);
        public ICollection<SelectListItem> GetMealsForSelectList(long restaurantId);

    }
}
