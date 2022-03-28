using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Repository;
using Online_Rezervacija_Restorana.Services;
using Online_Rezervacija_Restorana.ViewModels;
using Online_Rezervacija_Restorana.Data;
using System.Net.Http;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online_Rezervacija_Restorana.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ReservationService reservationService;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUserRepository userRepository;
        private readonly IReservationRepository reservationRepository;
        private readonly EmailingService emailingService;
        private readonly ITableRepository tableRepository;
        private readonly IMealRepository mealRepository;


        public RestaurantController(
            ReservationService reservationService,
            IRestaurantRepository restaurantRepository,
            IUserRepository userRepository,
            IReservationRepository reservationRepository,
            EmailingService emailingService,
            ITableRepository tableRepository,
            IMealRepository mealRepository
        )
        {
            this.reservationService = reservationService;
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
            this.reservationRepository = reservationRepository;
            this.emailingService = emailingService;
            this.tableRepository = tableRepository;
            this.mealRepository = mealRepository;
        }

        //GET: /<controller>/
        public IActionResult Index()
        {
            bool isSoonestAvailableTommorow = DateTime.Now.Hour > 20;
            DateTime soonestDate = DateTime.Now.AddDays(1);

            ReservationIndexMV vM = new ReservationIndexMV
            {
                dateNow = soonestDate
            };

            return View("Restaurant", vM);
        }
        public IActionResult ShowRestaurants(string cityname)
        {
            
            List<Restaurant> restaurantList = restaurantRepository.GetRestaurantsByLocation(cityname).ToList();
            List<RestaurantVM> vm = new List<RestaurantVM>();
           
            foreach (var item in restaurantList)
            {
                vm.Add(new RestaurantVM
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    PriceRange = item.PriceRange,
                    City_name = item.City_name,
                    CityId = item.CityId,
                    Ratings = item.Ratings,
                    Tables = item.Tables,
                    Images = item.Images,
                    Menus = item.Menus
                });
            }
            return View("Restaurant", vm);
        }
        public IActionResult RestaurantProfile(int restaurantId)
        {
            Restaurant model = restaurantRepository.GetRestaurantByType(restaurantId);
            if (model != null)
                return View(model);
            else
                return View();
        }
        public IActionResult CreateRestaurant()
        {
            return View();
        }

        public IActionResult AddTable(long restaurantId, int sittingPlaces)
        {
            Table table = new Table
            {
                SittingPlaces = sittingPlaces,
                RestaurantId = restaurantId
            };
            tableRepository.AddTable(table);

            return Redirect("/Restaurant/RestaurantProfile?restaurantId=" + restaurantId);

        }
        public IActionResult AddMealtoMenu(long restaurantId,string name, string description, float price, long mealtypeId, long menuId)
        {
            Meal meal = new Meal
            {
                Name = name,
                Description = description,
                Price = price,
                MealTypeID = mealtypeId,
                MenuID = menuId
            };
            mealRepository.AddMeal(meal);

            return Redirect("/Restaurant/RestaurantProfile?restaurantId="+restaurantId);

        }
    }
}
