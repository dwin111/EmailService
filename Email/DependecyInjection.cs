using Email.Services;
using Email.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace Email
{
	public static class DependecyInjection
	{
        public static IServiceCollection AddEmailSender(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            return services;
        }
    }
}

