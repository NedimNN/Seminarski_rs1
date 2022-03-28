using System;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Utilities;

namespace Online_Rezervacija_Restorana.ViewModels
{
    public class UserReservationVM
    {
        public PagedResult<Reservation> pagedResults { get; set; }
    }
}
