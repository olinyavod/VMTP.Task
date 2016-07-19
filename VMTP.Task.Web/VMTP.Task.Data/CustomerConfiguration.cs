using System.Data.Entity.ModelConfiguration;
using VMTP.Task.Models;

namespace VMTP.Task.Data
{
	public class CustomerConfiguration : EntityTypeConfiguration<Customer>
	{
		public CustomerConfiguration()
		{
			ToTable("Customers");

			HasKey(m => m.Id);

			/*HasMany(m => m.Operations)
				.WithRequired(m => m.Customer)
				.HasForeignKey(m => m.CustomerId)
				.WillCascadeOnDelete();*/
		}
	}
}