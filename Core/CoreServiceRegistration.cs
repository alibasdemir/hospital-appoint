using Core.JWT;
using Core.Mailing;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, TokenOptions tokenOptions) 
        {
            services.AddScoped<ITokenHelper, JwtHelper>(_ => new JwtHelper(tokenOptions));
			services.AddTransient<IMailService, MailService>();

			return services;
        }
    }
}
