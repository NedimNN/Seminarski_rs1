using System;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Utilities;

namespace Online_Rezervacija_Restorana.ViewModels
{
    public class AdminPanelRestaurantsVM
    {
        public PagedResult<Restaurant> pagedRestaurantResults { get; set; }

    }
}
