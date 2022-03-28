using Online_Rezervacija_Restorana.Data;
using Online_Rezervacija_Restorana.Models;

namespace Online_Rezervacija_Restorana.Repository
{
    public class PaymentDetailRepository : GenericRepository<PaymentDetail>, IPaymentDetailRepository
    {
        public PaymentDetailRepository(ApplicationDbContext context)
            : base(context)
        {
            // Nothing to do here ...
        }
    }
}
