using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class EmployeeProp
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "Name must be less than 50 characters")]
        public String Name { get; set; }
        [Required]
        public  String Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
        public string photoPath { get; set; }

        //public ICollection<EMPLeave> EMPLeaves { get; set; }
}
}
