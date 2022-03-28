using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }

        public void AddRange(ICollection<OrderDetail> orderDetails)
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetOrderDetailsByOrder(long orderId)
        {
            return _dbContext.OrderDetails.Include(m => m.Meals).Where(w => w.OrderID == orderId).FirstOrDefault();
        }
        public ICollection<SelectListItem> GetMealsForSelectList( long restaurantId)
        {
            Menu m = _dbContext.Menus.Where(w => w.RestaurantID == restaurantId).FirstOrDefault();
            List<SelectListItem> model = _dbContext.Meals.Where(w=> w.MenuID == m.ID).Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.ID.ToString()
            }).ToList();

            return model;
        }
    }
}
