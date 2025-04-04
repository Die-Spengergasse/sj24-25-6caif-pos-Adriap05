using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Commands;
using SPG_Fachtheorie.Aufgabe1.Infrastructure;
using SPG_Fachtheorie.Aufgabe1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG_Fachtheorie.Aufgabe1.Services
{
    public class PaymentService
    {
        private readonly AppointmentContext _db;

        public PaymentService(AppointmentContext db)
        {
            _db = db;
        }

        public IQueryable<Payment> Payments => _db.Payments.AsQueryable();

        public Payment CreatePayment(NewPaymentCommand cmd)
        {
            DateTime PaymentDateTime = DateTime.UtcNow;
            var cashDesk = _db.CashDesks.FirstOrDefault(c => c.Number == cmd.CashDeskNumber);
            if (cashDesk is null) throw new PaymentServiceException("Invalid CashDesk");
            var employee = _db.Employees
                .FirstOrDefault(e => e.RegistrationNumber == cmd.EmployeeRegistrationNumber);
            if (employee is null) throw new PaymentServiceException("Invalid Employee");
            // Erzeuge die Modelklasse
            var paymentType = Enum.Parse<PaymentType>(cmd.PaymentType);

            var payment = new Payment(
                cashDesk, 
                PaymentDateTime, 
                employee, 
                paymentType);
                _db.Payments.Add(payment);

            var hasOpenPayment = _db.Payments.Any(p =>
            p.CashDesk.Number == cmd.CashDeskNumber &&
            p.Confirmed == null);

            if (hasOpenPayment)
            {
                throw new PaymentServiceException("Open payment for cashdesk.");
            }

            _db.Payments.Add(payment);
            SaveOrThrow();
            return payment;
        }

        private void SaveOrThrow()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new EmployeeServiceException(e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
