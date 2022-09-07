using SNMedicTreatment.Models.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNMedicTreatment.Models.Medications
{
    [Table("medication")]
    public class Medication : BaseDB
    {
        public int IdUser { get; set; }
        public int IdPatient { get; set; }
        public int IdTreatment { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Days { get; set; }
        public DateTime StartDate { get; set; }
        public int Frequency { get; set; }
        public double Dosage { get; set; }
        public string Description { get; set; }
    }
}
