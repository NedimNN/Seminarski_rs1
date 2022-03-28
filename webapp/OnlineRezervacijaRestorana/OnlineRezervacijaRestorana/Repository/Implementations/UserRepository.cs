using System.Linq;
using Microsoft.EntityFrameworkCore;
using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Extensions;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Utilities;

namespace Online_Rezervacija_Restorana.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }

        public PagedResult<User> GetPagedUsers(int page)
        {
            return _dbContext.Set<User>()
                .Include(user => user.UserData)
                .Include(user => user.UserRole)
                .GetPaged(page, 10);
        }
    }
}
