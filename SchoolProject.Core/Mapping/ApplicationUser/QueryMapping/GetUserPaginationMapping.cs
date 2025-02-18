﻿using SchoolProject.Core.Features.ApplicationUser.Queries.Response;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserPaginationMapping()
        {
            CreateMap<User, GetUserPaginationResponse>();
        }
    }
}
