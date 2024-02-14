using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab.Models
{
    public class Employee
    {
        [Key]
        public int SSN { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        public DateOnly Bdate { get; set; }

        public string Address { get; set; }

        public string Sex { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        [ForeignKey("suber")]
        public int? Superssn { get; set; }

        [ForeignKey("WorkIn")]
        public int? Dno { get; set; }

        // Navigation Properties

        public Employee suber { get; set; }
        [InverseProperty("suber")]
        public List<Employee> groub { get; set; }

        public Department WorkIn { get; set; }
        public Department Manage { get; set; }

        public List<Dependent> DependentEmployee { get; set; }

        public List<Works_for> worksForEmployee { get; set; }
    }
}
