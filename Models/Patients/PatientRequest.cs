using SNMedicTreatment.Models.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNMedicTreatment.Models.Patients
{
    public class PatientRequest
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }
        public double Weigth { get; set; }
        public string Allergy { get; set; }
        public string Image { get; set; }
    }
}
