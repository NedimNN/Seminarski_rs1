using System.Collections.Generic;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        ICollection<Rating> GetLatestRatingsOfRestaurant(long restaurantId);

        // Add model specific methods below ...
    }
}
