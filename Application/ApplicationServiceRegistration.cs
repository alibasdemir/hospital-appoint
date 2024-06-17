using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.CrossCuttingConcerns.Logging.Serilog;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Serilog;


namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddSingleton<FileLogger>();
            services.AddSingleton<MsSqlLogger>();

            services.AddSingleton<LoggerServiceBase>(provider =>
            {
                var fileLogger = provider.GetRequiredService<FileLogger>();
                var msSqlLogger = provider.GetRequiredService<MsSqlLogger>();

                return new LoggerServiceBase
                {
                    Logger = new LoggerConfiguration()
                        .WriteTo.Logger(fileLogger.Logger) // parallel logging
                        .WriteTo.Logger(msSqlLogger.Logger) // parallel logging
                        .CreateLogger()
                };
            });

            services.AddHttpContextAccessor();
            return services;
        }
    }
}
