using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab.Models
{
    public class Project
    {
        [Key]
        public int Pnumber { get; set; }

        public string Pname { get; set; }

        public string Plocation { get; set; }

        public string City { get; set; }

        [ForeignKey("DeptProject")]
        public int? Dnum { get; set; }

        // Navigation Properties
        public Department DeptProject { get; set; }
        public List<Works_for> WorkForProject { get; set; }
    }
}
