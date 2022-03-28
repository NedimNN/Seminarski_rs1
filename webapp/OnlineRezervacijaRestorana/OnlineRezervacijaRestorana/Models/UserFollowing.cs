using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public class UserFollowing
    {
        [Key]
        [Column(Order =1)]
        public long UserID { get; set; }
        public virtual User User { get; set; }
        [Key]
        [Column(Order = 2)]
        public long RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
