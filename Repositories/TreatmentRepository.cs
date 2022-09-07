using SNMedicTreatment.Contexts;
using SNMedicTreatment.Models.Treatments;
using System.Collections.Generic;
using System.Linq;

namespace SNMedicTreatment.Repositories
{
    public class TreatmentRepository: BaseRepository<Treatment>
    {
        public TreatmentRepository(Context context) : base(context)
        {

        }

        public List<Treatment> FindByUserId(int idUser)
        {
            return _context.Treatments.Where(u => u.IdUser == idUser).ToList();
        }

        public List<Treatment> FindByPatientId(int idPatient)
        {
            return _context.Treatments.Where(u => u.IdPatient == idPatient).ToList();
        }

        public List<Treatment> FindByTreatmentId(int treatmentId)
        {
            return _context.Treatments.Where(u => u.Id == treatmentId).ToList();

        }

        public void DeleteAll(int idPatient)
        {
            var treatments = FindByPatientId(idPatient);
            treatments.ForEach(e => Delete(e));
        }
    }
}
