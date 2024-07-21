using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.CrossCuttingConcerns.Logging.Serilog;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Serilog;
using Application.Services.DoctorService;
using Application.Services.AuthService;
using Application.Services.PatientService;
using Application.Services.UserService;
using Application.Services.AppointmentService;
using Application.Services.DoctorAvailabilityService;
using Application.Services.UserOperationClaimService;
using Application.Services.OperationClaimService;
using Application.Features.Auth.Rules;
using Application.Features.Users.Rules;
using Application.Features.Departments.Rules;
using Application.Features.Doctors.Rules;
using Application.Features.Feedbacks.Rules;
using Application.Features.Notifications.Rules;
using Application.Features.OperationClaims.Rules;
using Application.Features.PatientReports.Rules;
using Application.Features.Patients.Rules;
using Application.Features.SupportRequests.Rules;
using Application.Features.UserOperationClaims;
using Application.Features.DoctorAvailabilities.Rules;
using Application.Features.Appointments.Rules;


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

            services.AddScoped<IDoctorService, DoctorManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IPatientService, PatientManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAppointmentService, AppointmentManager>();
            services.AddScoped<IDoctorAvailabilityService, DoctorAvailabilityManager>();
            services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
            services.AddScoped<IOperationClaimService, OperationClaimManager>();

            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<DepartmentBusinessRules>();
            services.AddScoped<DoctorBusinessRules>();
            services.AddScoped<FeedbackBusinessRules>();
            services.AddScoped<NotificationBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<PatientReportBusinessRules>();
            services.AddScoped<PatientBusinessRules>();
            services.AddScoped<SupportRequestBusinessRules>();
            services.AddScoped<UserOperationClaimBusinessRule>();
            services.AddScoped<DoctorAvailabilityBusinessRules>();
            services.AddScoped<AppointmentBusinessRules>();

            return services;
        }
    }
}
