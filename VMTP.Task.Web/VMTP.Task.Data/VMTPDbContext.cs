using System.Data.Entity;

namespace VMTP.Task.Data
{
    public class VMTPDbContext : DbContext
    {
	    public VMTPDbContext()
	    {
		    
	    }

	    protected override void OnModelCreating(DbModelBuilder modelBuilder)
	    {
		    base.OnModelCreating(modelBuilder);
		    modelBuilder.Configurations.AddFromAssembly(typeof (VMTPDbContext).Assembly);


	    }
    }
}
