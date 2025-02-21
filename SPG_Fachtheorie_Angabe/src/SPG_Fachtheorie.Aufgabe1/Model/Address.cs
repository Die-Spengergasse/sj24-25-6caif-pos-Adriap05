using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Address
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        protected Address() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Address(string street, string city, string zip)
        {
            Street = street;
            City = city;
            Zip = zip;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Street { get; set; }
        [MaxLength(255)]
        public string City { get; set; }
        [MaxLength(10)]
        public string Zip { get; set; }
    }
}