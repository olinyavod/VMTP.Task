using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace VMTP.Task.Models
{
	public class Customer : EntityBase
	{
		[Required, StringLength(128)]
		public string Name { get; set; }

		public decimal Debt { get; set; }

		public Collection<CustomerOperation> Operations { get; set; }
	}
}