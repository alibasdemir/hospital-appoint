﻿using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services) 
        {
            services.AddDbContext<HospitalAppointDbContext>();

            services.AddScoped<IAdminActionRepository, AdminActionRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDoctorAvailabilityRepository, DoctorAvailabilityRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IPatientReportRepository, PatientReportRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ISystemStatRepository, SystemStatRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

            return services;
        }
    }
}
