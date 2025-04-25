using Microsoft.Extensions.DependencyInjection;
using School.Service.Abstracts;
using School.Service.Implementation;

namespace School.Service
{
    public static class ModuleServiceDependecies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            return services;
        }
    }
}
