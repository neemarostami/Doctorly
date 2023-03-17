namespace Doctorly.Application.Services.Email
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string toEmail, string subject, string body)
        {
            // Implement SMTP here

            return Task.CompletedTask;
        }
    }
}
