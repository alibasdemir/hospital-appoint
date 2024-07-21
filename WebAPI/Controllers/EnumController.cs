using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        [HttpGet("get-genders")]
        public IActionResult GetGenders()
        {
            var enumValues = Enum.GetValues(typeof(Gender)).Cast<Gender>();
            var enumObjects = enumValues.Select(e => new
            {
                Value = (int)e,
                Name = e.ToString()
            }).ToList();

            return Ok(enumObjects);
        }
        [HttpGet("get-cities")]
        public IActionResult GetCities()
        {
            var enumValues = Enum.GetValues(typeof(City)).Cast<City>();
            var enumObjects = enumValues.Select(e => new
            {
                Value = (int)e,
                Name = e.ToString()
            }).ToList();

            return Ok(enumObjects);
        }
        [HttpGet("get-blood-types")]
        public IActionResult GetBloodTypes()
        {
            var enumValues = Enum.GetValues(typeof(BloodType)).Cast<BloodType>();
            var enumObjects = enumValues.Select(e => new
            {
                Value = (int)e,
                Name = e.ToString()
            }).ToList();

            return Ok(enumObjects);
        }
        [HttpGet("get-insurance-type")]
        public IActionResult GetInsuranceTypes()
        {
            var enumValues = Enum.GetValues(typeof(InsuranceType)).Cast<InsuranceType>();
            var enumObjects = enumValues.Select(e => new
            {
                Value = (int)e,
                Name = e.ToString()
            }).ToList();

            return Ok(enumObjects);
        }

        [HttpGet("get-appointmentStatus-type")]
        public IActionResult GetAppointmentStatusTypes()
        {
            var enumValues = Enum.GetValues(typeof(AppointmentStatus)).Cast<AppointmentStatus>();
            var enumObjects = enumValues.Select(e => new
            {
                Value = (int)e,
                Name = e.ToString()
            }).ToList();

            return Ok(enumObjects);
        }

        [HttpGet("get-notification-type")]
        public IActionResult GetNotificationTypes()
        {
            var enumValues = Enum.GetValues(typeof(NotificationType)).Cast<NotificationType>();
            var enumObjects = enumValues.Select(e => new
            {
                Value = (int)e,
                Name = e.ToString()
            }).ToList();

            return Ok(enumObjects);
        }
    }
}
