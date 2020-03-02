using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.ViewsModel
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public int id { get; set; }
        public string ExistingPhoto { get; set; }   
    }
}
