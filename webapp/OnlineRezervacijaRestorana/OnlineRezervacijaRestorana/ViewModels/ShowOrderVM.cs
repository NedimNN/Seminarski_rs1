using Online_Rezervacija_Restorana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Rezervacija_Restorana.ViewModels
{
    public class ShowOrderVM
    {
        public long reservationId { get; set; }
        public string orderDesc { get; set; }
        public string orderAller { get; set; }
        public Meal meal { get; set; }



    }
}
