using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
	public interface IEmployeeLeaveRepository
	{
		IEnumerable<EMPLeave> GetAllEMPLeave();

		//EmployeeProp GetLeaveById(int Id);

		EMPLeave AddLeave(EMPLeave eMPLeave);
		//EmployeeProp UpdateLeave(EmployeeProp EmployeeChanges);
		//EmployeeProp DeleteLeave(int id);
	}
}
