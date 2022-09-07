using SNMedicTreatment.Contexts;
using SNMedicTreatment.Models.Events;
using System.Collections.Generic;
using System.Linq;

namespace SNMedicTreatment.Repositories
{
    public class EventsRepository : BaseRepository<Event>
    {
        public EventsRepository(Context context) : base(context)
        {

        }

        public List<Event> FindByUserId(int idUser)
        {
            return _context.Events.Where(u => u.IdUser == idUser).ToList();
        }
        public List<Event> FindByPatientId(int idPatient)
        {
            return _context.Events.Where(u => u.IdPatient == idPatient).ToList();
        }

        public List<Event> FindByTreatmentId(int treatmentId)
        {
            return _context.Events.Where(u => u.IdTreatment == treatmentId).ToList();

        }

        public List<Event> FindByMedicationId(int medicationId)
        {
            return _context.Events.Where(u => u.IdMedication == medicationId).ToList();

        }

        public void DeleteAll(int medicationId)
        {
            var events = FindByMedicationId(medicationId);
            events.ForEach(e => Delete(e));
        }
    }
}
