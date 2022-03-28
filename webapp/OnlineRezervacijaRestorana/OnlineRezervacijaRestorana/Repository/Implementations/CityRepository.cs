using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }
    }
}
