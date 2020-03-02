using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.ViewsModel
{
	public class CreateRoleViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="RoleName is required")]
		public string RoleName { get; set; }
	}
}
