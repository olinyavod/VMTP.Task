using System.Data.Entity.Migrations;
using VMTP.Task.Models;

namespace VMTP.Task.Data.Migrations.Migrations
{
    public class Configuration : DbMigrationsConfiguration<VMTPDbContext>
    {
	    public Configuration()
	    {
			AutomaticMigrationsEnabled = false;
	    }

	    protected override void Seed(VMTPDbContext context)
	    {
		    base.Seed(context);

			context.Set<Operation>()
				.AddOrUpdate(m => m.Name,
				new Operation { Name = "���������� ��", Price = 700},
				new Operation { Name = "���� ����������", Price = 1000},
				new Operation { Name = "������ ������������ ��-�������", Price = 1000},
				new Operation { Name = "������������", Price = 0},
				new Operation { Name = "���������� ������� WEB-�����", Price = 600},
				new Operation { Name = "���������� ������� Desctop-����������", Price = 800},
				new Operation { Name = "���������� ������� Mobile-����������", Price = 1500},
				new Operation { Name = "���������� WEB-����� (back-end)", Price = 500});

			context.Set<Customer>()
				.AddOrUpdate(m => m.Name,
				new Customer{ Name = "������ �. �."},
				new Customer { Name = "������� �. �."},
				new Customer { Name = "������ �. �."},
				new Customer { Name = "������ �. �."});

	    }
    }
}
