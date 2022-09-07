using SNMedicTreatment.Contexts;
using SNMedicTreatment.Models.Patients;
using System.Collections.Generic;
using System.Linq;

namespace SNMedicTreatment.Repositories
{
    public class PatientsRepository : BaseRepository<Patient>
    {
        public PatientsRepository(Context context) : base(context)
        {

        }

        public List<Patient> FindByUserId(int idUser)
        {
            return _context.Patients.Where(u => u.IdUser == idUser).ToList();
        }

        public void DeleteAll(int idUser)
        {
            var patients = FindByUserId(idUser);
            patients.ForEach(e => Delete(e));
        }
    }
}