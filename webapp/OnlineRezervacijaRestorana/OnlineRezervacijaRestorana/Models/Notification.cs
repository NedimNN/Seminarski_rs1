using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public class Notification : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Description { get; set; }

        public long UserID { get; set; }
        public virtual User User { get; set; }

        public long? CouponID { get; set; }
        public virtual Coupon Coupon { get; set; }
        
        public long RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }


    }
}
