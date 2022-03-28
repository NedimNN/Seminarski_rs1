using System;
using System.Collections.Generic;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.ViewModels
{
    public class RatingVM
    {
        public ICollection<Rating> ratings { get; set; }
        public long restaurantId { get; set; }
    }
}
