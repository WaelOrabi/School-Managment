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
            public const string GetByID = Prefix + "/id";
        }
        public static class ApplicationUserRouting
        {
            public const string Prefix = Role + "User";
            public const string Create = Prefix + "/Create";
            public const string Paginated = Prefix + "/Paginated";
            public const string GetById = Prefix + "/{id}";
        }
    }
}
