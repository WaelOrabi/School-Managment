using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public const string List=Prefix+ "List";
            public const string GetByID = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
        }
    }
}
