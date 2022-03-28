using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }

        public ICollection<Rating> GetLatestRatingsOfRestaurant(long restaurantId)
        {
            if (restaurantId != 0)
            {
                return _dbContext.Ratings
                    .Where(rating => rating.RestaurantID == restaurantId)
                    .Include(rating => rating.User)
                    .ThenInclude(user => user.UserData)
                    .OrderBy(rating => rating.InsertTime)
                    .Take(10)
                    .ToList();
            }
            else return null;
        }
    }
}
