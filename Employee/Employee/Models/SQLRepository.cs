using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class SQLRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLRepository(AppDbContext context)
        {
            this.context = context;
        }
        public EmployeeProp Add(EmployeeProp employee)
        {
            context.EmployeeProps.Add(employee);
            context.SaveChanges();
                return employee;
        }

        public EmployeeProp Delete(int id)
        {
           EmployeeProp employeeProp =  context.EmployeeProps.Find(id);
            if (employeeProp != null)
            {
                context.EmployeeProps.Remove(employeeProp);
                context.SaveChanges();
            }
                return employeeProp;
        }


        public IEnumerable<EmployeeProp> GetAllEmployeeProps()
        {
            return context.EmployeeProps;
        }

        public EmployeeProp GetEmployeeId(int id)
        {
            return context.EmployeeProps.Find(id);
        }

        public EmployeeProp Update(EmployeeProp EmployeeChanges)
        {
            var employ = context.EmployeeProps.Attach(EmployeeChanges);
            employ.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            
            return EmployeeChanges;
            
        }
    }
}
