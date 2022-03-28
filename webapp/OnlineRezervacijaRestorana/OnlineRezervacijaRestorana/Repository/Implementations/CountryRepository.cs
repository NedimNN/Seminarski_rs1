using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }
    }
}
