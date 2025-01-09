using SchoolProject.Core.Features.Authorization.Queries.Response;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.Authorization
{
    public partial class AuthorizationProfile
    {
        public void GetRolesListMapping()
        {
            CreateMap<Role, GetRoleResponse>();
        }
    }
}
