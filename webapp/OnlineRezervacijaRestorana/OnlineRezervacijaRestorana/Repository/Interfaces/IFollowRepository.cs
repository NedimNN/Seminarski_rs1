using System.Collections.Generic;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public interface IFollowRepository 
    {
        public void Add(long userId, long restaurantId);

        public ICollection<Restaurant> GetRestaurants(long userId);

        public ICollection<User> GetUsers(long restaurantId);

        public void Remove(long userId, long restaurantId);
    }
}
