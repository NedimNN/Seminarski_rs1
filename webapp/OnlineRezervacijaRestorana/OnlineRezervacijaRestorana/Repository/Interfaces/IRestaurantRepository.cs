using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Utilities;
using System.Collections.Generic;

namespace Online_Rezervacija_Restorana.Repository
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {
        // Add model specific methods
  
        ICollection<Restaurant> GetRestaurantsByType(long typeId);
        Restaurant GetRestaurantByType(long typeId);
        ICollection<Restaurant> GetRestaurants();
        PagedResult<Restaurant> GetPagedRestaurants(int page);
        ICollection<Restaurant> GetRestaurantsByLocation(string cityName);
        ICollection<SelectListItem> GetRestaurantsForSelectList();
    }
}
