using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.infrastructure.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<Role> _roleManager)
        {
            var usersCount = await _roleManager.Roles.CountAsync();
            if (usersCount <= 0)
            {

                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Admin"
                });
                await _roleManager.CreateAsync(new Role()
                {
                    Name = "User"
                });
            }
        }
    }
}
