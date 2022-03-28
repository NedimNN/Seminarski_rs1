using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public class MealRepository : GenericRepository<Meal>, IMealRepository
    {
        public MealRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }

        public Meal AddMeal(Meal m)
        {
            if(m != null)
            {
                _dbContext.Meals.Add(m);
                _dbContext.SaveChanges();
            }
            return m;
        }



    }
}
