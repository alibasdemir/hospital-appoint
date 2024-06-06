using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return services;
        }
    }
}
