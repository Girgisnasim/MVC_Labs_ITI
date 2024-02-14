using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab.Models
{
    public class Department
    {
        [Key]
        public int Dnum { get; set; }

        public string Dname { get; set; }

        [ForeignKey("Leader")]
        public int? MGRSSN { get; set; }

        // Navigation Properties

        public List<Project> ProjectsDepatrment { get; set; }

        [InverseProperty("WorkIn")]
        public List<Employee> EmployeeDapatrment { get; set; }

        [InverseProperty("Manage")]
        public Employee Leader { get; set; }

    }
}
