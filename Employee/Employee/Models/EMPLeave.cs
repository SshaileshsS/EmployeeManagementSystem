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
		[Required]
		public LeaveTypeEnum? LeaveType { get; set; }
		[Required]
		public  string Description { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime StartDate { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime EndDate { get; set; }
		
		public int EMPId { get; set; }
		[ForeignKey("EMPId")]
		public EmployeeProp EmployeeProp { get; set; }
	}
}
