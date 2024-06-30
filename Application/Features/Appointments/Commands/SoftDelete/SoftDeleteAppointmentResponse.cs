namespace Application.Features.Appointments.Commands.SoftDelete
{
    public class SoftDeleteAppointmentResponse
	{
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
