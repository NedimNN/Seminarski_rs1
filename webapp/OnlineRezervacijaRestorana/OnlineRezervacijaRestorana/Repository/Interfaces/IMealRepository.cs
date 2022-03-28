using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public interface IMealRepository : IGenericRepository<Meal>
    {
        // Add model specific methods

        public Meal AddMeal(Meal m);


    }
}
