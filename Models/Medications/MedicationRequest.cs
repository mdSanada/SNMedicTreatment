using System;

namespace SNMedicTreatment.Models.Medications
{
    public class MedicationRequest
    {
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
