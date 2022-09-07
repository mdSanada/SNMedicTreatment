using System;

namespace SNMedicTreatment.Models.Treatments
{
    public class TreatmentRequest
    {
        public string Name { get; set; }
        public int IdPatient { get; set; }
        public int Status { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public string Complement { get; set; }

    }
}
