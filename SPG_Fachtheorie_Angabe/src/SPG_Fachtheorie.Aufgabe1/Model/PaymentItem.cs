namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class PaymentItem
    {
        public PaymentItem(string articleName, int amount, decimal price)
        {
            ArticleName = articleName;
            Amount = amount;
            Price = price;
        }

        public string ArticleName { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

    }
}