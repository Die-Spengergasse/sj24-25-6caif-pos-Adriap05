using Spg.Fachtheorie.Aufgabe3.API.Test;
using SPG_Fachtheorie.Aufgabe1.Commands;
using SPG_Fachtheorie.Aufgabe1.Model;
using SPG_Fachtheorie.Aufgabe1.Services;
using SPG_Fachtheorie.Aufgabe3.Controllers;
using SPG_Fachtheorie.Aufgabe3.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SPG_Fachtheorie.Aufgabe3.Test
{
    public class PaymentsControllerTests
    {
        [Theory]
        [InlineData(1, HttpStatusCode.OK)] // GET /api/payments?cashDesk = 1
        [InlineData(2, HttpStatusCode.NotFound)] 

        public async Task GetAllPaymentsTests(
            int cashDeskNumber, HttpStatusCode expectedStatusCode)
        {
            // ARRANGE
            var factory = new TestWebApplicationFactory();
            factory.InitializeDatabase(db =>
            {
            });
            var cashDesk = new CashDesk(1);
                var cashier = new Cashier(
                    2, "FN", "LN", new DateOnly(2004, 2, 1),
                    3000M, null, "Feinkost");
                var payment = new Payment(cashDesk, new DateTime(2025, 05, 05), 
                    cashier, PaymentType.Cash);
                //db.AddRange(payment);
                //db.SaveChanges();
           

            // ACT
            var (statusCode, content) = await factory.GetHttpContent<List<PaymentDto>>($"/api/payments/{cashDeskNumber}");

            // ASSERT
            Assert.True(statusCode == expectedStatusCode);
            Assert.NotNull(content);
            Assert.True(content.First().CashDeskNumber == cashDeskNumber);

        }
    }
}
