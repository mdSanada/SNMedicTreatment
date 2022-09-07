using SNMedicTreatment.Models.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNMedicTreatment.Models.Events
{
    public class EventResponse
    {
        public EventResponse(Event _event, string _medication)
        {
            IdUser = _event.IdUser;
            IdPatient = _event.IdPatient;
            IdTreatment = _event.IdTreatment;
            IdMedication = _event.IdMedication;
            NotificationDate = _event.NotificationDate;
            DosageNumber = _event.DosageNumber;
            Medication = _medication;
        }

        public int IdUser { get; set; }
        public int IdPatient { get; set; }
        public int IdTreatment { get; set; }
        public int IdMedication { get; set; }
        public DateTime NotificationDate { get; set; }
        public int DosageNumber { get; set; }
        public string Medication { get; set; }
    }
}
