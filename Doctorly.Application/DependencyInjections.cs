using Doctorly.Application.CQRS.Commands.CreateEvent;
using Doctorly.Application.CQRS.Commands.DeleteEvent;
using Doctorly.Application.CQRS.Commands.UpdateEvent;
using Doctorly.Application.CQRS.Queries.GetAllEventsByFilter;
using Doctorly.Application.Services.Email;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Doctorly.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(CreateEventCommandHandler).Assembly);
            services.AddMediatR(typeof(DeleteEventCommandHandler).Assembly);
            services.AddMediatR(typeof(UpdateEventCommandHandler).Assembly);
            services.AddMediatR(typeof(GetAllEventsByFilterQueryHandler).Assembly);

            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
