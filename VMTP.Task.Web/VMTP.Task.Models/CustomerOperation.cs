namespace VMTP.Task.Models
{
	public class CustomerOperation
	{
		public int OperationId { get; set; }

		public Operation Operation { get; set; }

		public int CustomerId { get; set; }

		public Customer Customer { get; set; }

		public decimal Price { get; set; }

		public CustomerOperationStatus Status { get; set; }
	}
}