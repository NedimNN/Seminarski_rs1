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
    public class RatingController : Controller
    {
        private readonly IRatingRepository ratingRepository;
        private readonly IUserRepository userRepository;
        private readonly IRestaurantRepository restaurantRepository;

        public RatingController(IRatingRepository ratingRepository, IUserRepository userRepository, IRestaurantRepository restaurantRepository)
        {
            this.ratingRepository = ratingRepository;
            this.userRepository = userRepository;
            this.restaurantRepository = restaurantRepository;

        }

        // GET: /<controller>/
        public IActionResult Index(long restaurantId)
        {

            RatingVM vM = new RatingVM {
                ratings = ratingRepository.GetLatestRatingsOfRestaurant(restaurantId),
                restaurantId = restaurantId
            };

            return PartialView("Rating", vM);
        }

        public IActionResult CreateRating(string commentText, RatingMark ratingValue, long restaurantId)
        {

            ratingRepository.Create(new Rating
            {
                Mark = ratingValue,
                Comment = commentText,
                InsertTime = DateTime.Now,
                RestaurantID = restaurantId,
                Restaurant = restaurantRepository.GetById(restaurantId),

                // As the User functionalities are not yet implemented, we use hardcoded values
                UserID = 1,
                User = userRepository.GetById(1)
            });

            RatingVM vM = new RatingVM
            {
                ratings = ratingRepository.GetLatestRatingsOfRestaurant(restaurantId),
                restaurantId = restaurantId
            };
            Restaurant model = restaurantRepository.GetRestaurantByType(restaurantId);
            return View("~/Views/Restaurant/RestaurantProfile.cshtml", model);
        }
    }
}
