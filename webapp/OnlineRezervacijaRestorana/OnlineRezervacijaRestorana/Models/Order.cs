using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public class Order : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public long ReservationID { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
