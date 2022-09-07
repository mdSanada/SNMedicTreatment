using SNMedicTreatment.Contexts;
using SNMedicTreatment.Models.Users;
using System.Linq;

namespace SNMedicTreatment.Repositories
{
    public class LoginRepository : BaseRepository<User>
    {

        public LoginRepository(Context context) : base(context)
        {
        }

        public User Find(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
