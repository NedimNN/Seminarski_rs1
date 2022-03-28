using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Rezervacija_Restorana.ViewModels
{
    public class AddOrderVM
    {
        public int reservationId { get; set; }
        public string orderDesc { get; set; }
        public string orderAller { get; set; }
        public List<SelectListItem> orderMeal { get; set; }
        public long orderMealId { get; set; }

    }
}
