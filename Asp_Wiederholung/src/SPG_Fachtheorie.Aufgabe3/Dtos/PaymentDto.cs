﻿namespace SPG_Fachtheorie.Aufgabe3.Dtos
{
    public record PaymentDto(
        int Id, string EmployeeFirstName, 
        string EmployeeLastName, int CashDeskNumber, 
        string PaymentType, int TotalAmount
    );
}
