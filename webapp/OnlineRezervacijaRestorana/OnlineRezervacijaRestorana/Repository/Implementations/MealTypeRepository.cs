using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Rezervacija_Restorana.Repository
{
    public class MealTypeRepository : GenericRepository<MealType>, IMealTypeRepository
    {
        public MealTypeRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }
    }
}
