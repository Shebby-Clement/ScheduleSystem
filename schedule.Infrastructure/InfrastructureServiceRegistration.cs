

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using schedule.Application.Contracts;
using schedule.Application.Contracts.Persistence;
using schedule.Application.Models;
using schedule.Infrastructure.Mail;
using schedule.Infrastructure.Persistence;
using schedule.Infrastructure.Repositories;

namespace schedule.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ScheduleContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ScheduleConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAttendeeRepository, AttendeeRepository>();

            // I did not include email settings on the appSettings
           // services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
