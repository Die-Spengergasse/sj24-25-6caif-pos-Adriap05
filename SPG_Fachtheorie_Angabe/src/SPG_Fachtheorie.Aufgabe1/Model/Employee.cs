using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public abstract class Employee
    {
        [Key]
        public int RegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
}