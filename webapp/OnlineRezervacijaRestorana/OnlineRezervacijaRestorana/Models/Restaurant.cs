using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public enum PriceRange {
        CHEAP, MID, EXPENSIVE
    };
    public class Restaurant : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PriceRange PriceRange { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }

        public long CityId { get; set; }
        public  string City_name { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
