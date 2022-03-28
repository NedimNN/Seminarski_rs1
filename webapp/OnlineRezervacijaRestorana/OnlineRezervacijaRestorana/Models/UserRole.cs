using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public enum Role {
        ADMIN, VISITOR, RESTAURANT_OWNER
    }
    public class UserRole : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set;}
        public Role Role { get; set; }
    }
}