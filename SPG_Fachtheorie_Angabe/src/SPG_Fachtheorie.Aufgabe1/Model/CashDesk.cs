using System.ComponentModel.DataAnnotations;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class CashDesk
    {
        [Key]
        public int Number { get; set; }

        public CashDesk(int number)
        {
            Number = number;
        }
    }
}