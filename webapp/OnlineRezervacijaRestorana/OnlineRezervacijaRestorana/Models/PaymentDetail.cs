using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public class PaymentDetail : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Ccnumber { get; set; }
        public int CCV { get; set; }

        public long PaymentTypeID { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public long UserID { get; set; }
        public virtual User User { get; set; }
    }
}
