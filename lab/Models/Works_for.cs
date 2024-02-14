using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.Models
{
    [PrimaryKey("ESSn", "Pno")]
    public class Works_for
    {
        [ForeignKey("EmpWorkFor")]
        public int? ESSn { get; set; }

        [ForeignKey("ProjWorkFor")]
        public int? Pno { get; set; }

        public int Hours { get; set; }

        // Navigation Properties

        public Employee EmpWorkFor { get; set; }

        public Project ProjWorkFor { get; set; }
    }
}
