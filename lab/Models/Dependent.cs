using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    [PrimaryKey("ESSN", "Dendent_name")]
    public class Dependent
    {
        [ForeignKey("EmpDependent")]
        public int? ESSN { get; set; }

        public string Dendent_name { get; set; }

        public string Sex { get; set; }

        public DateOnly Bdate { get; set; }

        // Navigation Properties
        public Employee EmpDependent { get; set; }
    }
}
