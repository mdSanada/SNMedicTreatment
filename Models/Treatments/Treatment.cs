using SNMedicTreatment.Models.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNMedicTreatment.Models.Treatments
{
    [Table("treatment")]
    public class Treatment: BaseDB
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public int IdPatient { get; set; }
        public int Status { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public string Complement { get; set; }
    }
}