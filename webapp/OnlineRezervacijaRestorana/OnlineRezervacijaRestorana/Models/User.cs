using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual UserData UserData { get; set; }  

        public long UserRoleID { get; set; }
        public virtual UserRole UserRole { get; set; }
       
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
