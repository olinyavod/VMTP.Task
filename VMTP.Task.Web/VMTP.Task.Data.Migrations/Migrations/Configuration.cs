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
				new Operation { Name = "Разработка тз", Price = 700},
				new Operation { Name = "Сбор требований", Price = 1000},
				new Operation { Name = "Подбор оптимального ИТ-решения", Price = 1000},
				new Operation { Name = "Консультация", Price = 0},
				new Operation { Name = "Разработка дизайна WEB-Сайта", Price = 600},
				new Operation { Name = "Разработка дизайна Desctop-приложения", Price = 800},
				new Operation { Name = "Разработка дизайна Mobile-приложения", Price = 1500},
				new Operation { Name = "Разраюотка WEB-сайта (back-end)", Price = 500});

			context.Set<Customer>()
				.AddOrUpdate(m => m.Name,
				new Customer{ Name = "Петров П. П."},
				new Customer { Name = "Ситоров С. С."},
				new Customer { Name = "Иванов И. И."},
				new Customer { Name = "Пупкин В. В."});

	    }
    }
}
