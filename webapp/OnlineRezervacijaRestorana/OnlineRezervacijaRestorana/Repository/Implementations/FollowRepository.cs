using System;
using System.Collections.Generic;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public class FollowRepository : IFollowRepository
    {
        private readonly ApplicationDbContext _context;
        public FollowRepository(ApplicationDbContext context) {
            _context = context;
        }

        public void Add(long userId, long restaurantId) {
            throw new NotImplementedException();
        }

        public ICollection<Restaurant> GetRestaurants(long userId) {
            throw new NotImplementedException();
        }

        public ICollection<User> GetUsers(long restaurantId) {
            throw new NotImplementedException();
        }

        public void Remove(long userId, long restaurantId) {
            throw new NotImplementedException();
        }
    }
}
