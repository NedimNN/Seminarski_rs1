using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Repository;
using Online_Rezervacija_Restorana.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online_Rezervacija_Restorana.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IRestaurantRepository restaurantRepository;

        public AdminPanelController(
            IUserRepository userRepository,
            IRestaurantRepository restaurantRepository

        )
        {
            this.userRepository = userRepository;
            this.restaurantRepository = restaurantRepository;

        }

        public IActionResult AdminPanelUsers(int page = 1)
        {
            AdminPanelVM vM = new AdminPanelVM
            {
                pagedUserResults = userRepository.GetPagedUsers(page)
            };

            return View("AdminPanelIndex", vM);
        }
        public IActionResult AdminPanelRestaurants(int page = 1)
        {
            AdminPanelRestaurantsVM vM = new AdminPanelRestaurantsVM
            {
                pagedRestaurantResults = restaurantRepository.GetPagedRestaurants(page)
            };

            return View("AdminPanelRestaurants", vM);
        }
    }
}
