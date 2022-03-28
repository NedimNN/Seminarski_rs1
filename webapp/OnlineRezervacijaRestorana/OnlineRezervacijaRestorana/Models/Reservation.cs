using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Rezervacija_Restorana.Models
{
    public class Reservation : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set;}
        public int GuestNumber { get; set; }

        public bool NotifiedReminder { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string SpecialRequest { get; set; }
        public bool IsTemporary { get; set;}
        public DateTime CreatedOn { get; set;}

        public long TableID { get; set; }
        public virtual Table Table { get; set; }

        public long UserID { get; set; }
        public virtual User User { get; set; }

        public virtual Order Order { get; set; }    
    }
}