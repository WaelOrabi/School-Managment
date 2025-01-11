using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void AddDepartmentMapping()
        {
            CreateMap<AddDepartmentCommandModel, Department>()
                  .ForMember(dest => dest.DNameAr, opt => opt.MapFrom(src => src.NameAr))
                  .ForMember(dest => dest.DNameEn, opt => opt.MapFrom(src => src.NameEn))
                  .ForMember(dest => dest.InsManager, opt => opt.MapFrom(src => src.ManagerId));
        }
    }
}
