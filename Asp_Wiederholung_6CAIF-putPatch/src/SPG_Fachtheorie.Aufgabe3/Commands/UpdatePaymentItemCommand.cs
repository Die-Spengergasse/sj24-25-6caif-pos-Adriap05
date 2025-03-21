using SPG_Fachtheorie.Aufgabe1.Model;
using System.ComponentModel.DataAnnotations;

namespace SPG_Fachtheorie.Aufgabe3.Commands
{
    public record UpdatePaymentItemCommand(
        [Range(1, int.MaxValue, ErrorMessage = "Invalid PaymentItem Number." )]
        int Id,
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Invalid ArticleName")]
        string ArticleName,
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Amount" )]
        int Amount,
        [Range(0.1, 9999999999.99, ErrorMessage = "Invalid Price")]
        decimal Price,
        [Range(1, int.MaxValue, ErrorMessage = "Invalid PaymentId" )]
        Payment PaymentId,
        DateTime? LastUpdated
    );
}
