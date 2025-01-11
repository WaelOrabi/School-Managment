namespace SchoolProject.Data.AppMetaData
{
    public class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Role = $"{root}/{version}/";

        public static class StudentRouting
        {
            public const string Prefix = Role + "Student";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
            public const string Paginated = Prefix + "/Paginated";
        }

        public static class DepartmentRouting
        {
            public const string Prefix = Role + "Department";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "/id";
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
            public const string Paginated = Prefix + "/Paginated";
        }
        public static class InstructorRouting
        {
            public const string Prefix = Role + "Instructor";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
            public const string Paginated = Prefix + "/Paginated";
        }
        public static class SubjectRouting
        {
            public const string Prefix = Role + "Subject";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "/id";
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
            public const string Paginated = Prefix + "/Paginated";
        }
        public static class StudentSubjectRouting
        {
            public const string Prefix = Role + "Student-Subject";

            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete/{studentId}/{subjectId}";

        }
        public static class DepartmentSubjectRouting
        {
            public const string Prefix = Role + "Department-Subject";
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/Delete/{departmentId}/{subjectId}";

        }
        public static class InstructorSubjectRouting
        {
            public const string Prefix = Role + "Instructor-Subject";
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/Delete/{instructorId}/{subjectId}";

        }
        public static class ApplicationUserRouting
        {
            public const string Prefix = Role + "User";
            public const string Register = Prefix + "/Register";
            public const string Paginated = Prefix + "/Paginated";
            public const string GetById = Prefix + "/{id}";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
            public const string ChangePassword = Prefix + "/Change-Password";
        }
        public static class AuthenticationRouting
        {
            public const string Prefix = Role + "Authentication";
            public const string SignIn = Prefix + "/SignIn";
            public const string RefreshToken = Prefix + "/Refresh-Token";
            public const string ValidateToken = Prefix + "/Validate-Token";
        }
        public static class AuthorizationRouting
        {
            public const string Prefix = Role + "Authorization";
            public const string Roles = Prefix + "/Roles";
            public const string Claims = Prefix + "/Claims";
            public const string Create = Roles + "/Create";
            public const string Edit = Roles + "/Edit";
            public const string Delete = Roles + "/Delete/{id}";
            public const string RolesList = Roles + "/List";
            public const string GetById = Roles + "/GetById/{id}";
            public const string ManageUserRoles = Roles + "/Manage-User-Roles/{userId}";
            public const string UpdateUserRoles = Roles + "/Update-User-Roles";
            public const string ManageUserClaims = Claims + "/Manage-User-Claims/{userId}";
            public const string UpdateUserClaims = Roles + "/Update-User-Claims";
        }
    }
}
