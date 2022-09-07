using SNMedicTreatment.Models.Patients;
using System.Collections.Generic;

namespace SNMedicTreatment.Models.Users
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string RefreshToken {  get; set; }
    }
}
