using System.ComponentModel.DataAnnotations;

namespace MyMvc.Models
{
    public class employee
    {
        [Display (Name="Employee Id")]
        public int Id { get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display (Name =" Last Name")]
        public string LastName { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        [Display (Name="Hire Date")]
        public DateTime HireDate { get; set; }

    }
}
