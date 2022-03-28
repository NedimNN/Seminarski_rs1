using System;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.ViewModels
{
    public class ConfirmReservationVM
    {
        public string restaurantName { get; set; }
        public string reservationStartDate { get; set; }
        public string reservationStartTime { get; set; }
        public string reservationEndTime { get; set; }
        public int reservationNumberOfGuests { get; set; }

        public bool completedReservation { get; set; }


    }
}
