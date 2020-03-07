using System.Threading.Tasks;

namespace hotel_reservation_website.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
