using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNMedicTreatment.Models.Entity
{
    public class BaseDB
    {
        [Key, Column(Order = 0)]
        [Required]
        public int Id { get; set; }

        //[Key, Column(Order = 1)]
        //[Required]
        //public int UserId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
