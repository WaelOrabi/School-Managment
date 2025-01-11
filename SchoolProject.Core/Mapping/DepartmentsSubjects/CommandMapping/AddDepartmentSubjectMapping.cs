using SchoolProject.Core.Features.DepartmentsSubjects.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.DepartmentsSubjects
{
    public partial class DepartmentSubjectProfile
    {
        public void AddDepartmentSubjectMapping()
        {
            CreateMap<AddDepartmentSubjectCommandModel, DepartmentSubject>()
                .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentID))
                .ForMember(dest => dest.SubID, opt => opt.MapFrom(src => src.SubjectID));
        }
    }
}
