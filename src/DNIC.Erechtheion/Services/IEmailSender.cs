using System.Threading.Tasks;

namespace DNIC.Erechtheion.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
