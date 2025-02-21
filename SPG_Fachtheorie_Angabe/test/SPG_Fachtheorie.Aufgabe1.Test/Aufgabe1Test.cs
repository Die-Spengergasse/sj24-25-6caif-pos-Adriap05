using Bogus;
using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Infrastructure;
using SPG_Fachtheorie.Aufgabe1.Model;
using System;
using System.Linq;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace SPG_Fachtheorie.Aufgabe1.Test
{
    [Collection("Sequential")]
    public class Aufgabe1Test
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

        // Creates an empty DB in Debug\net8.0\cash.db
        [Fact]
        public void CreateDatabaseTest()
        {
            using var db = GetEmptyDbContext();
        }

        [Fact]
        public void AddCashierSuccessTest()
        {
            // TODO: Remove Exception and add your code here
            // ARRANGE
            using var db = GetEmptyDbContext();
            var address = new Address("Spengergasse", "Wien", "1050");
            var cashier = new Cashier(12, "Adrian", "Plank", address, "Typ", "IT-Experte");
            // ACT
            db.Cashiers.Add(cashier);
            db.SaveChanges();
            // ASSERT
            db.ChangeTracker.Clear();
            var cashierFromDb = db.Cashiers.First();
            Assert.True(cashierFromDb.RegistrationNumber == 12);
        }

        [Fact]
        public void AddPaymentSuccessTest()
        {
            // TODO: Remove Exception and add your code here
            // ARRANGE
            using var db = GetEmptyDbContext();
            var address = new Address("Spengergasse", "Wien", "1050");
            var cashier = new Cashier(12, "Adrian", "Plank", address, "Typ", "IT-Experte");
            // var employee = new Employee(10, "Adrian", "Plank", address, "Type");

            var cashDesk = new CashDesk(10);
            var payment = new Payment(cashDesk ,new DateTime(2025, 2, 14, 9, 0, 0), PaymentType.Cash, cashier);
            var paymentItem = new PaymentItem("Wasser", 3, 50.00m, payment);


            // ACT
            db.Payments.Add(payment);
            db.SaveChanges();
            db.PaymentItems.Add(paymentItem);
            db.SaveChanges();

            // ASSERT
            db.ChangeTracker.Clear();
            var PaymentFromDb = db.PaymentItems.First();
            Assert.True(PaymentFromDb.Id != default);
        }

        [Fact]
        public void EmployeeDiscriminatorSuccessTest()
        {

        }
    }
}