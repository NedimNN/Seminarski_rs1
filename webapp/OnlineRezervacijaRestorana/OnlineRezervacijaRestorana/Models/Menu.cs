using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public class Menu : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Name { get; set; }

        public long RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
