using AutoMapper;

namespace SchoolProject.Core.Mapping.Instructors
{
    public partial class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            AddInstructorCommandMapping();
            EditInstructorCommandMapping();
            GetInstructorByIdMapping();
            GetInstructorListMapping();
            GetInstructorPaginationMapping();
        }
    }
}
