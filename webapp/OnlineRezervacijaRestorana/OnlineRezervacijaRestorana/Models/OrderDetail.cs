using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public class OrderDetail : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Description { get; set; }
        public string Allergies { get; set; }

        public long OrderID { get; set; }
        public virtual Order Order{ get; set; }

        public virtual ICollection<Meal> Meals { get; set; }

    }
}
