using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public interface IEmployeeRepository
    {

        IEnumerable<EmployeeProp> GetAllEmployeeProps();
        EmployeeProp GetEmployeeId(int Id);
        EmployeeProp Add(EmployeeProp employee);
        EmployeeProp Update(EmployeeProp EmployeeChanges);
        EmployeeProp Delete(int id);
    }
}
