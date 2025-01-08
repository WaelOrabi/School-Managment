namespace SchoolProject.Data.Responses
{
    public class ManageUserClaimsResponse
    {
        public int UserId { get; set; }
        public List<UserClaims> userClaims { get; set; } = new();
    }
    public class UserClaims
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}
