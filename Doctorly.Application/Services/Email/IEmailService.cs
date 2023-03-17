namespace Doctorly.Application.Services.Email
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
