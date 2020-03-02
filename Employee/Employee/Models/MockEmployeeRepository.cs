using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<EmployeeProp> _Employee;
        public MockEmployeeRepository()
        {
            _Employee = new List<EmployeeProp>() {
                new EmployeeProp(){ Id= 1,Name="!shailesh",Email="A@gmail",Department= Dept.None },
                new EmployeeProp(){ Id= 2,Name="@shailesh",Email="B@gmail",Department= Dept.Employ },
                new EmployeeProp(){ Id= 3,Name="#shailesh",Email="C@gmail",Department= Dept.Hr },
                new EmployeeProp(){ Id= 4,Name="$shailesh",Email="D@gmail",Department= Dept.something },
            };
        }

        public EmployeeProp Add(EmployeeProp employee)
        {
           employee.Id =  _Employee.Max(e => e.Id) + 1;
            _Employee.Add(employee);
            return employee;
        }

        public EmployeeProp Delete(int id)
        {
           EmployeeProp employee =  _Employee.FirstOrDefault(e => e.Id == id);
            if(employee != null)
            {
                _Employee.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<EmployeeProp> GetAllEmployeeProps()
        {
            return _Employee;
        }

        public EmployeeProp GetEmployeeId(int Id)
        {
            return _Employee.FirstOrDefault(e => e.Id == Id);
        }

        public EmployeeProp Update(EmployeeProp EmployeeChanges)
        {
            EmployeeProp employee = _Employee.FirstOrDefault(e => e.Id == EmployeeChanges.Id);
            if (employee != null)
            {
                employee.Name = EmployeeChanges.Name;
                employee.Email = EmployeeChanges.Email;
                employee.Department = EmployeeChanges.Department;

            }
            return employee;
        }
    }
}
