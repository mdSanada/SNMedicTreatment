using SNMedicTreatment.Models.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNMedicTreatment.Models.Tokens
{
    [Table("refresh_token")]
    public class RefreshToken
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Revoked { get; set; }
        public bool IsExpired => DateTimeOffset.UtcNow >= Expires;
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
