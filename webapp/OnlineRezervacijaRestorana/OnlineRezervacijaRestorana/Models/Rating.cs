using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public enum RatingMark {
        ONE_STAR, TWO_STAR, THREE_STAR, FOUR_STAR, FIVE_STAR
    }
    public class Rating : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public RatingMark Mark { get; set; }
        public string Comment { get; set; }
        public DateTime InsertTime { get; set; }

        public long UserID { get; set; }
        public virtual User User { get; set; }

        public long RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
