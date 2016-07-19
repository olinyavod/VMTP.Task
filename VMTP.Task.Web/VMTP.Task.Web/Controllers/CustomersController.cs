using VMTP.Task.Data;
using VMTP.Task.Models;

namespace VMTP.Task.Web.Controllers
{
    public class CustomersController : CrudControllerBase<Customer, VMTPDbContext>
    {
	    protected override void Update(Customer oldEntity, Customer newEntity)
	    {
		    oldEntity.Name = newEntity.Name;
	    }
    }
}
