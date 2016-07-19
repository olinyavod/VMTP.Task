using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VMTP.Task.Models
{
	public class Customer : EntityBase
	{
		[Required, StringLength(128)]
		public string Name { get; set; }

		public decimal Debt { get; set; }

		public ICollection<CustomerOperation> Operations { get; set; }
	}
}