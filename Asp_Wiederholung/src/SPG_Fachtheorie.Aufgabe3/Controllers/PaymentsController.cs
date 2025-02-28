using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPG_Fachtheorie.Aufgabe1.Infrastructure;
using SPG_Fachtheorie.Aufgabe1.Model;
using SPG_Fachtheorie.Aufgabe3.Dtos;

namespace SPG_Fachtheorie.Aufgabe3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly AppointmentContext _db;

        public PaymentsController(AppointmentContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<PaymentDto>> GetAllPayments([FromQuery] string? PaymentType)
        {
            var payments = _db.Payments
                .Where(e => string.IsNullOrEmpty(PaymentType)
                    ? true : e.PaymentType.ToLower() == PaymentType.ToLower())
                .Select(e => new PaymentDto(
                    e.Id, e.EmployeeFirstName, e.EmployeeLastName,
                    e.CashDeskNumber, e.PaymentType, e.TotalAmount))
                .ToList();
            return Ok(payments);
        }






    }
}
