using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SPG_Fachtheorie.Aufgabe1.Test
{
    public class PaymentServiceTests
    {
        private AppointmentContext GetEmptyDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite(@"Data Source=cash.db")
                .Options;

            var db = new AppointmentContext(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }

        // "Invalid cashdesk"
        // "Invalid employee"
        // "Open payment for cashdesk."
        // "Insufficient rights to create a credit card payment."
        [Theory]
        [InlineData()]
        public void CreatePaymentExceptionsTest()
        {
            // ARRANGE
            var db = GetEmptyDbContext();



            // ACT & ASSERT
        }
    }
}
