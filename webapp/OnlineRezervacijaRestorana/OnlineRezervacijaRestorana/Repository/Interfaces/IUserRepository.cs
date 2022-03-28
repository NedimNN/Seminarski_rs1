using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Utilities;

namespace Online_Rezervacija_Restorana.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public PagedResult<User> GetPagedUsers(int page);

        // Add model specific methods
    }
}
