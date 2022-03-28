using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Extensions;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Utilities;
using Online_Rezervacija_Restorana.ViewModels;

namespace Online_Rezervacija_Restorana.Repository
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }

        public ICollection<Restaurant> GetRestaurantsByLocation(string cityName)
        {
            List<Restaurant> restaurantList;
            if (cityName != null)
            {
                restaurantList = _dbContext.Restaurants.Where(x => x.City_name == cityName).Select(s => new Restaurant
                {
                    ID = s.ID,
                    CityId = s.CityId,
                    City_name = s.City_name,
                    Description = s.Description,
                    Latitude = s.Latitude,
                    Longitude = s.Longitude,
                    Name = s.Name,
                    PriceRange = s.PriceRange,
                    Ratings = _dbContext.Ratings.Where(w => w.RestaurantID == s.ID).ToList(),
                    Tables = _dbContext.Tables.Where(w => w.RestaurantId == s.ID).ToList(),
                    Images = _dbContext.Images.Where(w=> w.RestaurantID == s.ID).ToList(),
                    Menus = _dbContext.Menus.Include(i => i.Meals).Where(w => w.RestaurantID == s.ID).ToList()


                }).ToList();
            }
            else
            {
                restaurantList = _dbContext.Restaurants.Select(s=> new Restaurant
                {
                    ID = s.ID,
                    CityId = s.CityId,
                    City_name = s.City_name,
                    Description = s.Description,
                    Latitude = s.Latitude,
                    Longitude = s.Longitude,
                    Name = s.Name,
                    PriceRange = s.PriceRange,
                    Ratings = _dbContext.Ratings.Where(w=> w.RestaurantID == s.ID).ToList(),
                    Tables = _dbContext.Tables.Where(w=> w.RestaurantId == s.ID).ToList(),
                    Images = _dbContext.Images.Where(w => w.RestaurantID == s.ID).ToList(),
                    Menus = _dbContext.Menus.Include(i => i.Meals).Where(w => w.RestaurantID == s.ID).ToList()


                }).ToList();
            }

            List<Restaurant> restaurants = new List<Restaurant>();

            foreach (var item in restaurantList)
            {
                restaurants.Add(new Restaurant
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    PriceRange = item.PriceRange,
                    City_name = item.City_name,
                    CityId = item.CityId,
                    Ratings = _dbContext.Ratings.Where(w => w.RestaurantID == item.ID).ToList(),
                    Tables = _dbContext.Tables.Where(w => w.RestaurantId == item.ID).ToList(),
                    Images = _dbContext.Images.Where(w => w.RestaurantID == item.ID).ToList(),
                    Menus = _dbContext.Menus.Include(i=> i.Meals).Where(w => w.RestaurantID == item.ID).ToList()


                });
            }

            return restaurants;
        }

        public ICollection<Restaurant> GetRestaurantsByType(long typeId)
        {
            List<Restaurant> restaurant = _dbContext.Restaurants.Where(w=> w.ID == typeId).Select(s => new Restaurant
            {
                ID = s.ID,
                CityId = s.CityId,
                City_name = s.City_name,
                Description = s.Description,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                Name = s.Name,
                PriceRange = s.PriceRange,
                Ratings = _dbContext.Ratings.Where(w => w.RestaurantID == s.ID).ToList(),
                Tables = _dbContext.Tables.Where(w => w.RestaurantId == s.ID).ToList(),
                Images = _dbContext.Images.Where(w => w.RestaurantID == s.ID).ToList(),
                Menus = _dbContext.Menus.Include(i => i.Meals).Where(w => w.RestaurantID == s.ID).ToList()


            }).ToList();
            if (restaurant != null)
                return restaurant;
            else
                return null;

        }
        public Restaurant GetRestaurantByType(long typeId)
        {
            List<Restaurant> restaurant = _dbContext.Restaurants.Where(w => w.ID == typeId).Select(s => new Restaurant
            {
                ID = s.ID,
                CityId = s.CityId,
                City_name = s.City_name,
                Description = s.Description,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                Name = s.Name,
                PriceRange = s.PriceRange,
                Ratings = _dbContext.Ratings.Where(w => w.RestaurantID == s.ID).ToList(),
                Tables = _dbContext.Tables.Include(i=> i.Reservations).Where(w => w.RestaurantId == s.ID).ToList(),
                Images = _dbContext.Images.Where(w => w.RestaurantID == s.ID).ToList(),
                Menus = _dbContext.Menus.Include(i => i.Meals).Where(w => w.RestaurantID == s.ID).ToList()
            }).ToList();
            Restaurant res = restaurant[0];
            if (res != null)
            {
                foreach(Menu item in res.Menus)
                {
                    foreach(Meal m in item.Meals)
                    {
                        m.MealType = _dbContext.MealTypes.Where(w => w.ID == m.MealTypeID).SingleOrDefault();
                    }
                }
                foreach(Table i in res.Tables)
                {
                    if(i.Reservations != null) { 
                        foreach ( Reservation x in i.Reservations)
                        {
                                i.Reservations.Add(x);
                        }
                    }
                }
                return res;
            }
            else
                return null;
        }
        public ICollection<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurant = _dbContext.Restaurants.Include(s => s.Tables)
                 .Include(s => s.Menus)
                 .Include(s => s.Ratings)
                 .Include(s => s.Images)
                 .ToList();
            if (restaurant != null)
                return restaurant;
            else
                return null;

        }
        public PagedResult<Restaurant> GetPagedRestaurants(int page)
        {
            return _dbContext.Set<Restaurant>()
                .Include(res => res.Tables)
                .Include(res => res.Images)
                .GetPaged(page, 10);
        }
        public ICollection<SelectListItem> GetRestaurantsForSelectList()
        {
            List<SelectListItem> model = _dbContext.Restaurants.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.ID.ToString()
            }).ToList();

            return model;
        }
    }
}
