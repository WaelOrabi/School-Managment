using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.Authorization
{
    public partial class AuthorizationProfile
    {
        public void EditRoleCommandMapping()
        {
            CreateMap<EditRoleCommandModel, Role>();
        }
    }
}
