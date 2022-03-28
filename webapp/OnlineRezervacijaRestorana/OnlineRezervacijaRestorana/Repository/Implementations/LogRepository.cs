using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public class LogRepository : GenericRepository<Log>, ILogRepository
    {
        public LogRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }
    }
}
