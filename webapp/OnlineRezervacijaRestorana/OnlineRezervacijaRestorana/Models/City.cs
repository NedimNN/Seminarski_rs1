using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public class City : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public long CountryID { get; set; }
        public virtual Country Country { get; set; }
       
    }
}
