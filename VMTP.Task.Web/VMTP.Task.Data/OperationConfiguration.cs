using System.Data.Entity.ModelConfiguration;
using VMTP.Task.Models;

namespace VMTP.Task.Data
{
	public class OperationConfiguration : EntityTypeConfiguration<Operation>
	{
		public OperationConfiguration()
		{
			ToTable("Operations");

			HasKey(m => m.Id);
		}
	}
}