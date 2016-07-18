using System.ComponentModel.DataAnnotations;

namespace VMTP.Task.Models
{
	public class Operation : EntityBase
	{
		[Required, StringLength(128)]
		public string Name { get; set; }

		public decimal Price { get; set; }
	}
}
