using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using VMTP.Task.Models;

namespace VMTP.Task.Data
{
	public class CustomerOperationConfiguration : EntityTypeConfiguration<CustomerOperation>
	{
		public CustomerOperationConfiguration()
		{
			ToTable("CustomerOperations");

			HasKey(m => new {m.CustomerId, m.OperationId});

			Property(m => m.OperationId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			Property(m => m.CustomerId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			HasRequired(m => m.Customer)
				.WithMany(m => m.Operations)
				.HasForeignKey(m => m.CustomerId)
				.WillCascadeOnDelete();

			HasRequired(m => m.Operation)
				.WithMany()
				.HasForeignKey(m => m.OperationId)
				.WillCascadeOnDelete();
		}
	}
}