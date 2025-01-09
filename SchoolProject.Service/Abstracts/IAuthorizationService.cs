using SchoolProject.Data.DTOs;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Requests;
using SchoolProject.Data.Responses;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<string> AddRoleAsync(string roleName);
        public Task<bool> IsRoleExistByName(string roleName);
        //  public Task<string> EditRoleAsync(EditRoleRequest request);
        public Task<string> EditRoleAsync(Role request);
        public Task<string> DeleteRoleAsync(int roleId);
        public Task<List<Role>> GetRolesList();
        public Task<Role> GetRoleById(int roleId);
        public Task<ManageUserRolesResponse> ManagerUserRolesData(User user);
        public Task<string> UpdateUserRoles(UpdateUserRolesRequest request);
        public Task<ManageUserClaimsResponse> ManageUserClaimsData(User user);
        public Task<string> UpdateUserClaims(UpdateUserClaimsRequest request);
    }
}
