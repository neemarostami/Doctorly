using Doctorly.Domain.Repositories;
using Doctorly.Infrastructure.Persistence;
using Doctorly.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Doctorly.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DoctorlyDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnectionString"), builder =>
                    builder.MigrationsAssembly(typeof(DoctorlyDbContext).Assembly.FullName)));

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAttendeeRepository, AttendeeRepository>();
            services.AddScoped<IDoctorlyDbContext, DoctorlyDbContext>();

            return services;
        }
    }
}
