using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Helper;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Repository;
using Online_Rezervacija_Restorana.ViewModels;

namespace Online_Rezervacija_Restorana.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class RestaurantsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RestaurantsApiController(ApplicationDbContext context, IRestaurantRepository restaurantRepository)
        {
            _context = context;
        }
        [HttpGet]
        public List<City> GetCities()
        {
            var data = _context.Cities.AsQueryable();
            return data.ToList();

        }


        // GET: /RestaurantsApi/GetRestaurants
        [HttpGet]
        public List<Restaurant> GetRestaurants()
        {
            var data = _context.Restaurants.Include(s => s.Tables)
                 .Include(s => s.Menus)
                 .Include(s => s.Ratings)
                 .Include(s => s.Images)
                 .AsQueryable();

            return data.ToList();

        }

        // GET: /RestaurantsApi/GetRestaurant/5
        [HttpGet("{id}")]
        public Restaurant GetRestaurant(long id)
        {
            var restaurants = _context.Restaurants.Where(w => w.ID == id)
                .Include(s => s.Tables)
                .Include(s => s.Menus)
                .Include(s => s.Ratings)
                .Include(s => s.Images)
                .AsQueryable();
            Restaurant restaurant = restaurants.FirstOrDefault();
            if (restaurant == null)
            {
                return null;
            }

            return restaurant;
        }

        // PUT: /RestaurantsApi/PutRestaurant/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(long id, Restaurant restaurant)
        {
            if (id != restaurant.ID)
            {
                return BadRequest();
            }

            _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: /RestaurantsApi/PostRestaurant
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Restaurant> PostRestaurant([FromBody] RestaurantAddVM restaurant)
        {
            if (restaurant.City_name == null)
                return BadRequest(restaurant.City_name);
            Restaurant res = new Restaurant()
            {
                Name = restaurant.Name,
                Description = restaurant.Description,
                CityId = _context.Cities.Where(c => c.Name == restaurant.City_name).Select(s => s.ID).SingleOrDefault(),
                City_name = restaurant.City_name,
                PriceRange = restaurant.PriceRange
            };
            
            _context.Restaurants.Add(res);
            _context.SaveChanges();

            Menu menu = new Menu { Name = "Daily Menu", RestaurantID = res.ID };
            _context.Menus.Add(menu);

            _context.SaveChanges();

            return CreatedAtAction("GetRestaurant", new { id = restaurant.ID }, restaurant);
        }
        // POST : /RestaurantsApi/AddRestaurantImage
        [HttpPost("{id}")]
        public ActionResult<Restaurant> AddRestaurantImage(long id, [FromForm] RestaurantImageAddVM slika)
        {
            try
            {
                Restaurant res = _context.Restaurants.Include(s => s.Tables)
                .Include(s => s.Menus)
                .Include(s => s.Ratings)
                .Include(s => s.Images)
                .FirstOrDefault(r => r.ID == id);
                if (slika != null && res != null)
                {
                    if (slika.restaurant_image.Length > 300 * 1000)
                        return BadRequest("Max file size is 300KB");

                    string ext = Path.GetExtension(slika.restaurant_image.FileName);
                    var filename = $"{Guid.NewGuid()}{ext}";

                    slika.restaurant_image.CopyTo(new FileStream(Config.slikeFolder + filename, FileMode.Create));
                    Image slikaZaDodati = new Image
                    {
                        Url = Config.slikeUrl + filename,
                        RestaurantID = res.ID
                    };
                    _context.Images.Add(slikaZaDodati);
                    _context.SaveChanges();

                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }
        // DELETE: /RestaurantsApi/DeleteRestaurant
        [HttpPost]
        public Restaurant DeleteRestaurant(Restaurant res)
        {
            Restaurant restaurant = _context.Restaurants.Find(res.ID);

            if (restaurant == null || res.ID == 1)
                return null;

            Menu menu = _context.Menus.Where(w => w.RestaurantID == res.ID).FirstOrDefault();

            List<Meal> meals = _context.Meals.Where(w => w.MenuID == menu.ID).ToList();
            List<Table> tables = _context.Tables.Where(w => w.RestaurantId == res.ID).ToList();

            foreach (var item in meals)
            {
                _context.Remove(item);
            }
            foreach (var item in tables)
            {
                _context.Remove(item);
            }
            _context.Remove(menu);
            _context.Remove(restaurant);

            _context.SaveChanges();
            return restaurant;
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] AddOrderVM x)
        {
            Meal m = _context.Meals.Find(x.orderMealId);
            List<Meal> mealsO = new List<Meal>();
            mealsO.Add(m);
            Order o = new Order
            {
                ReservationID = x.reservationId
            };
            _context.Orders.Add(o);
            _context.SaveChanges();
            OrderDetail od = new OrderDetail
            {
                OrderID = o.ID,
                Description = x.orderDesc,
                Allergies = x.orderAller,
                Meals = mealsO
            };
            
            _context.OrderDetails.Add(od);
            _context.SaveChanges();

  
            return Ok();
        }
        private bool RestaurantExists(long id)
        {
            return _context.Restaurants.Any(e => e.ID == id);
        }
    }
}
