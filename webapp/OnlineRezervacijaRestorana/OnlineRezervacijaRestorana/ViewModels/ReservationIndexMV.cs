using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Online_Rezervacija_Restorana.ViewModels
{
    public class ReservationIndexMV
    {
        public DateTime dateNow { get; set; }
        public DateTime soonesAvailableTime { get; set; }
        public List<SelectListItem> restaurants { get; set; }
        public int restaurantId { get; set; }
    }
}
