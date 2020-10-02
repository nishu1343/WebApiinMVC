using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;


namespace MVC.Models
{
    public partial class MvcEmployeeModel
    {
        [Key]
        public Guid EmployeeId { get; set; }

       [Required(ErrorMessage ="Please provide first Name")]
       [Display(Name = "First Name")]
       [StringLength(50)]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Please provide last Name")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string Last_Name { get; set; }

        public string Position { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }
    }
}