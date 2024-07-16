namespace Core.Mailing;

public interface IMailService
{
    Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true);
    Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true);
    Task BookedAppointmentMailAsync(string to, DateTime startTime, string userName, string userSurname);
}
