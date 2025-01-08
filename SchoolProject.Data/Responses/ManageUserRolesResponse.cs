﻿namespace SchoolProject.Data.Responses
{
    public class ManageUserRolesResponse
    {

        public int UserId { get; set; }
        public List<Roles> Roles { get; set; } = new List<Roles>();
    }
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasRole { get; set; }
    }
}
