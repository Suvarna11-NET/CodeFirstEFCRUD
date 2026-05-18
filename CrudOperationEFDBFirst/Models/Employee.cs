using System.ComponentModel.DataAnnotations;

namespace CrudOperationEFDBFirst.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public decimal  Salary { get; set; }

    }
}
