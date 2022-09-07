using SNMedicTreatment.Models.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNMedicTreatment.Models.Events
{
    [Table("events")]
    public class Event: BaseDB
    {
        public int IdUser { get; set; }
        public int IdPatient { get; set; }
        public int IdTreatment { get; set; }
        public int IdMedication { get; set; }
        public DateTime NotificationDate { get; set; }
        public int DosageNumber { get; set; }
    }
}
