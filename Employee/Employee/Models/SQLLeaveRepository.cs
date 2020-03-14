using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
	public class SQLLeaveRepository : IEmployeeLeaveRepository
	{
		private readonly AppDbContext context;

		public SQLLeaveRepository(AppDbContext context)
		{
			this.context = context;
		}
		public IEnumerable<EMPLeave> GetEMPLeaves()
		{
			return context.EMPLeaves;
		}
		public EMPLeave AddLeave(EMPLeave eMPLeave)
		{
			context.EMPLeaves.Add(eMPLeave);
			context.SaveChanges();
			return eMPLeave;
		}
	}}
