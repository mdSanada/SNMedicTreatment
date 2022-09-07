using SNMedicTreatment.Models.Entity;
using SNMedicTreatment.Models.Tokens;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNMedicTreatment.Models.Users
{
    // Nome da tabela
    [Table("users")]
    public class User: BaseDB
    {
        public User()
        {
           RefreshTokens = new List<RefreshToken>();
        }

        public string Email { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
        public string DeviceId { get; set; }
        [ForeignKey("IdUser")]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
