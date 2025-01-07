using Microsoft.Extensions.DependencyInjection;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.InfrastructureBases;
using SchoolProject.infrastructure.Repositories;

namespace SchoolProject.infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<InstructorRepository, InstructorRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            return services;
        }
    }
}
