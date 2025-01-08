using System.Security.Claims;

namespace SchoolProject.Data.Helpers
{
    public static class ClaimsStroe
    {
        public static List<Claim> claims = new() {
        new Claim("Create Student", "false"),
        new Claim("Edit Student","false"),
        new Claim("Delete Student","false")
        };
    }
}
