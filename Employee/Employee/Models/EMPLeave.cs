using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
	public class EMPLeave
	{
		[Key]
		public int LeaveId { get; set; }
		public string LeaveType { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		//public int EMPId { get; set; }
		//[ForeignKey("EMPId")]
		//public EmployeeProp EmployeeProp { get; set; }

	}
}
