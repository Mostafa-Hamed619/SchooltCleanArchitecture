using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using School.Core.Behaviors;
using System.Reflection;

namespace School.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // Mediator configuration
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
