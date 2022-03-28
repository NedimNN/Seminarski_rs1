using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public class Meal : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public long MenuID { get; set; }
        public virtual Menu Menu { get; set; }
        public long MealTypeID { get; set; }
        public virtual MealType MealType { get; set; }
    }
}
