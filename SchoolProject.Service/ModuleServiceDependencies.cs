using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementations;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IInstructorService, InstructorService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IStudentSubjectService, StudentSubjectService>();
            services.AddTransient<IDepartmentSubjectService, DepartmentSubjectService>();
            services.AddTransient<IInstructorSubjectService, InstructorSubjectService>();
            return services;
        }
    }
}
