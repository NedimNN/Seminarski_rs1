using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public class Coupon : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public int Percentage { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Name { get; set; }

        public int RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
