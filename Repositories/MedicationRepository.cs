using SNMedicTreatment.Contexts;
using SNMedicTreatment.Models.Medications;
using System.Collections.Generic;
using System.Linq;

namespace SNMedicTreatment.Repositories
{
    public class MedicationRepository : BaseRepository<Medication>
    {
        public MedicationRepository(Context context) : base(context)
        {

        }

        public List<Medication> FindByUserId(int idUser)
        {
            return _context.Medications.Where ( u => u.IdUser == idUser ).ToList();
        }
        public List<Medication> FindByPatientId(int idPatient)
        {
            return _context.Medications.Where(u => u.IdPatient == idPatient).ToList();
        }

        public List<Medication> FindByTreatmentId(int treatmentId)
        {
            return _context.Medications.Where(u => u.IdTreatment == treatmentId).ToList();

        }

        public void DeleteAll(int idTreatment)
        {
            var events = FindByTreatmentId(idTreatment);
            events.ForEach(e => Delete(e));
        }
    }
}
