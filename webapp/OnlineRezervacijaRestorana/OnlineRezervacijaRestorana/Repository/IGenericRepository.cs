using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public interface IGenericRepository<TEntity>
    where TEntity : class, IEntity
    {
        Utilities.PagedResult<TEntity> GetPaged(int page);

        TEntity GetById(long id);

        TEntity Create(TEntity entity);

        TEntity Update(long id, TEntity entity);

        TEntity Delete(long id);
    }
}
