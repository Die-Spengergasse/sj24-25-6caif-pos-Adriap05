using System;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Payment
    {
        public Payment(CashDesk cashDesk, DateTime paymentDateTime, PaymentType paymentType, Employee employee)
        {
            CashDesk = cashDesk;
            PaymentDateTime = paymentDateTime;
            PaymentType = paymentType;
            Employee = employee;
        }

        public CashDesk CashDesk { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public PaymentType PaymentType { get; set; }
        public Employee Employee { get; set; }
    }
}