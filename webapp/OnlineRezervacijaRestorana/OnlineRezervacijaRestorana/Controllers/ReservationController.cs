using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Repository;
using Online_Rezervacija_Restorana.Services;
using Online_Rezervacija_Restorana.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online_Rezervacija_Restorana.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationService reservationService;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUserRepository userRepository;
        private readonly IReservationRepository reservationRepository;
        private readonly EmailingService emailingService;

        public ReservationController(
            ReservationService reservationService,
            IRestaurantRepository restaurantRepository,
            IUserRepository userRepository,
            IReservationRepository reservationRepository,
            EmailingService emailingService
        ){
            this.reservationService = reservationService;
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
            this.reservationRepository = reservationRepository;
            this.emailingService = emailingService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            bool isSoonestAvailableTommorow = DateTime.Now.Hour > 20;
            DateTime soonestDate = DateTime.Now.AddDays(1);

            ReservationIndexMV vM = new ReservationIndexMV
            {
                restaurants = (List<SelectListItem>)restaurantRepository.GetRestaurantsForSelectList(),
                dateNow = soonestDate
            };

            return View("Reservation", vM);
        }

        public IActionResult ConfirmReservation(
            int numberOfGuests,
            DateTime reservationDate,
            DateTime reservationTime,
            string email,
            string number,
            int restaurantId
        )
        {

            Restaurant restaurant = restaurantRepository.GetById(restaurantId);

            DateTime startTime = new DateTime(
                    reservationDate.Year,
                    reservationDate.Month,
                    reservationDate.Day,
                    reservationTime.Hour,
                    reservationTime.Minute,
                    reservationTime.Second
            );

            Reservation reservation = reservationService.CreateReservation(
                userRepository.GetById(1),
                numberOfGuests,
                restaurant,
                startTime,
                startTime.AddHours(2),
                null,
                email,
                new string(number.Where(c => char.IsDigit(c)).ToArray())
            );

            bool completedReservation = reservation != null ? true : false;

            ConfirmReservationVM vM = new ConfirmReservationVM
            {
                restaurantName = restaurant.Name,
                reservationStartDate = reservationDate.ToShortDateString(),
                reservationStartTime = reservationTime.ToShortTimeString(),
                reservationEndTime = reservationTime.AddHours(2).ToShortTimeString(),
                reservationNumberOfGuests = numberOfGuests,
                completedReservation = completedReservation
            };

            if (completedReservation)
            {
                this.emailingService.SendConfirmationMessage(email, vM);
            }

            return View("ConfirmReservation", vM);
        }

        public IActionResult UserReservation(int page = 1)
        {
            UserReservationVM vM = new UserReservationVM
            {
                pagedResults = reservationRepository.GetPagedByUser(page, 1)
            };

            return View(vM);
        }
    }
}
