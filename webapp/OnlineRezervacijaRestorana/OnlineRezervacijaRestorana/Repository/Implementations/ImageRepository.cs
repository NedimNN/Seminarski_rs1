using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }
    }
}
