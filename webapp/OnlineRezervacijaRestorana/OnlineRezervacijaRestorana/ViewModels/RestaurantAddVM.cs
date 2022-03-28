using Microsoft.AspNetCore.Http;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Online_Rezervacija_Restorana.ViewModels
{
    public class RestaurantAddVM
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PriceRange PriceRange { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public long CityId { get; set; }
        public string City_name { get; set; }
    }
}
