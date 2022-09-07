using System;
using System.Security.Claims;

namespace SNMedicTreatment.Helper
{
    public static class IdentityHelper
    {
        public static int GetId(ClaimsPrincipal user)
        {
            var claimsIdentity = user.Identity as ClaimsIdentity;
            var id = claimsIdentity.FindFirst("id");

            return Convert.ToInt32(id.Value);
        }
    }
}

