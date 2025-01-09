using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.DTOs;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Data.Requests;
using SchoolProject.Data.Responses;
using SchoolProject.infrastructure.Data;
using SchoolProject.Service.Abstracts;
using System.Security.Claims;

namespace SchoolProject.Service.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {

        #region Fields
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion
        #region Constructor
        public AuthorizationService(RoleManager<Role> roleManager, UserManager<User> userManager, ApplicationDbContext applicationDbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }
        #endregion
        #region Handle Functions
        public async Task<string> AddRoleAsync(string roleName)
        {
            var identityRole = new Role();
            identityRole.Name = roleName;
            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
                return "Success";
            return "Failed";
        }



        public async Task<bool> IsRoleExistByName(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);

        }
        public async Task<string> EditRoleAsync(Role request)
        {
            var role = await _roleManager.FindByIdAsync(request.Id.ToString());
            if (role == null)
                return "notFound";
            role.Name = request.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded) return "Success";
            var errors = string.Join("-", result.Errors);
            return errors;
        }

        public async Task<string> DeleteRoleAsync(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null) return "NotFound";
            var users = await _userManager.GetUsersInRoleAsync(role.Name);
            if (users != null && users.Count() > 0) return "Used";
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded) return "Success";
            var errors = string.Join("-", result.Errors);
            return errors;
        }

        public async Task<List<Role>> GetRolesList()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int roleId)
        {
            return await _roleManager.FindByIdAsync(roleId.ToString());
        }

        public async Task<ManageUserRolesResponse> ManagerUserRolesData(User user)
        {
            var response = new ManageUserRolesResponse();



            var roles = await _roleManager.Roles.ToListAsync();

            response.UserId = user.Id;
            foreach (var role in roles)
            {
                var itemRoles = new Roles()
                {
                    Id = role.Id,
                    Name = role.Name,
                    HasRole = await _userManager.IsInRoleAsync(user, role.Name) ? true : false,

                };
                response.Roles.Add(itemRoles);
            }

            return response;
        }

        public async Task<string> UpdateUserRoles(UpdateUserRolesRequest request)
        {
            var transact = await _applicationDbContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                    return "UserIsNull";
                var userRoles = await _userManager.GetRolesAsync(user);
                var removeResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
                if (!removeResult.Succeeded)
                    return "FailedToRemoveOldRoles";
                var selectedRoles = request.Roles.Where(x => x.HasRole == true).Select(x => x.Name);
                var addRolesResult = await _userManager.AddToRolesAsync(user, selectedRoles);
                if (!addRolesResult.Succeeded)
                    return "FailedToAddNewRoles";

                await transact.CommitAsync();

                return "Success";

            }
            catch (Exception ex)
            {
                await transact.RollbackAsync();
                return "FailedToUpdateUserRoles";
            }
        }

        public async Task<ManageUserClaimsResponse> ManageUserClaimsData(User user)
        {
            var response = new ManageUserClaimsResponse();
            response.UserId = user.Id;
            var userClaimsList = await _userManager.GetClaimsAsync(user);
            foreach (var item in ClaimsStroe.claims)
            {
                if (userClaimsList.Any(x => x.Type == item.Type))
                    response.userClaims.Add(new UserClaims()
                    {
                        Type = item.Type,
                        Value = true
                    });
                else
                    response.userClaims.Add(new UserClaims()
                    {
                        Type = item.Type,
                        Value = false
                    });
            }
            return response;
        }

        public async Task<string> UpdateUserClaims(UpdateUserClaimsRequest request)
        {
            var transact = await _applicationDbContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                    return "UserIsNull";
                var userClaims = await _userManager.GetClaimsAsync(user);

                var removeResult = await _userManager.RemoveClaimsAsync(user, userClaims);
                if (!removeResult.Succeeded)
                    return "FailedToRemoveOldClaims";

                var selectedClaims = request.userClaims.Where(x => x.Value == true).Select(x => new Claim(x.Type, x.Value.ToString()));
                var addClaimsResult = await _userManager.AddClaimsAsync(user, selectedClaims);
                if (!addClaimsResult.Succeeded)
                    return "FailedToAddNewClaims";

                await transact.CommitAsync();

                return "Success";
            }
            catch (Exception exception)
            {
                await transact.RollbackAsync();
                return "FailedToUpdateUserClaims";
            }
        }


        #endregion
    }
}
