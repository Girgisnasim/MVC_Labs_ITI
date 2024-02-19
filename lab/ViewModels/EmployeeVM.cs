using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using lab.ServerVaildtion;

namespace lab.ViewModels
{
    public class EmployeeVM
    {
        [Key]
        public int SSN { get; set; }
        [Length(3,50,ErrorMessage ="Frist Name is required")]
        [UniqueName]
        public string Fname { get; set; }
        [Length(3, 50, ErrorMessage = "Last Name is required")]
        [UniqueName]
        public string Lname { get; set; }
        //[RegularExpression("^(Alex|Cairo|Giza)$", ErrorMessage="Alex or Cairo or Giza")]
        [Remote("CheckAddress", "ClientSideValidation", ErrorMessage = "This field must be (Alex, Cairo, or Giza)")]        //[Required]
        public string Address { get; set; }
        [Range(10000, 100000, ErrorMessage="salary must be from 10000 to 100000")]
        public decimal Salary { get; set; }
        [Required]
        [RegularExpression("^(male|famale|Famale|Male)$", ErrorMessage = "Male or Famale")]
        public string Sex { get; set; }

        public int? Dno { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Compare("confirmPassword",ErrorMessage ="password must match confirm password")]
        public string Password { get; set; }
        [Compare("Password")]
        public string confirmPassword { get; set; }
        [ValidateNever]
        public SelectList departments { get; set; }
    }
}
