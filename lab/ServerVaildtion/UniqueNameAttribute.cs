using lab.Models;
using lab.ViewModels;
using System.ComponentModel.DataAnnotations;
namespace lab.ServerVaildtion
{
    //[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class UniqueNameAttribute:ValidationAttribute
    {
        //public override bool IsValid(object? value)
        //{
        //    //ITIContext context = new();
        //    //var res=context.Employee.Where(e=>e.Fname == value.ToString()&&e.Lname==value.ToString()).ToList();
        //    //if (res.Count() > 0 )
        //    //{
        //    //    return false;
        //    //}
        //    //return true;

        //}
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var employeeVM = (EmployeeVM)validationContext.ObjectInstance;
            ITIContext context = new ITIContext();

            var existingEmployee = context.Employee
                .Where(e => e.Fname == employeeVM.Fname && e.Lname == employeeVM.Lname)
                .FirstOrDefault();

            if (existingEmployee != null)
            {
                return new ValidationResult("The combination of First Name and Last Name must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
